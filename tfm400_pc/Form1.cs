using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace tfm400_pc
{
  public partial class Form1 : Form
  {
    // CONST
    private const int KEY_NUM = 63;
    private const int KEY_LEN = 32;
    private const int KEY_STR_LEN = 64;
    private const int UPAR_SIZE = 16;
    private const int FPAR_SIZE = 256;
    private const int PAGE_SIZE = 2048;
    private const int PROG_MAX_SIZE = 200 * 1024;
    private const int CHAN_SPACING = 12500;
    private const byte CMD_NOP = 0xFF;
    private const byte CMD_INFO = 1;
    private const byte CMD_STAT = 2;
    private const byte CMD_UPAR_RD = 3;
    private const byte CMD_UPAR_WR = 4;
    private const byte CMD_KEYS_WR = 5;
    private const byte CMD_SEND_DATA = 6;
    private const byte CMD_RECV_DATA = 7;
    private const byte CMD_PTT = 50;
    private const byte CMD_FPAR_RD = 51;
    private const byte CMD_FPAR_WR = 52;
    private const byte CMD_BOOT_HDR = 53;
    private const byte CMD_BOOT_BLK = 54;
    private const byte CMD_BOOT_INFO = 55;
    private const int TMO_CMD = 2000;
    private const string org_name = "TFM400 ТЮНЕР";
    private const int VER_MAJOR = 1;
    private const int VER_MINOR = 2;
    private string ver_str;

    // VAR
    private Random rand;
    private byte[] par1, par2;
    private byte[] prog_data;
    private byte[] page_data;
    private int prog_size;
    private int prog_sent;
    private int prog_ptr;
    private TabPage tpage;
    public string dev_name;
    public string sentMsg;

    public comRxDelegate comRxImpl;
    public comConDelegate comConImpl;

    private string statMsgTxt;
    private System.Timers.Timer cpTimer;
    private System.Timers.Timer statTimer;
    private System.Timers.Timer rspTimer;
    public bool running;    // COM thread is running
    ComPortNative cp;       // COM port object native
    byte cop;               // curren COM operation
    bool isdbg;             // debug enable
    bool cpo;               // is COM open

    private StreamWriter rssiLogWriter;
    private string rssiLogPath;
    private bool rssiLogActive;

    private class PttBand
    {
      public CheckBox CheckBox;
      public Int32 Frequency;
      public NumericUpDown HighPower;
      public NumericUpDown MediumPower;
      public NumericUpDown LowPower;

      public PttBand(CheckBox checkBox, Int32 frequency, NumericUpDown highPower, NumericUpDown mediumPower, NumericUpDown lowPower)
      {
        CheckBox = checkBox;
        Frequency = frequency;
        HighPower = highPower;
        MediumPower = mediumPower;
        LowPower = lowPower;
      }
    }

    public Form1()
    {
      InitializeComponent();
      tpage = tabControl.TabPages[tabControl.TabPages.Count - 1];
      tabControl.TabPages.Remove(tabControl.TabPages[tabControl.TabPages.Count - 1]);
      ver_str = "v" + VER_MAJOR.ToString() + "." + VER_MINOR.ToString();
      this.Text = org_name;
      dev_name = "Неизвестно";
      rand = new Random();
      par1 = new byte[UPAR_SIZE];
      par2 = new byte[UPAR_SIZE];
      prog_data = new byte[PROG_MAX_SIZE];
      page_data = new byte[PAGE_SIZE];
      comboBoxMode.SelectedIndex = 0;
      comboBoxBERtst.SelectedIndex = 0;
      comboBoxLostPkt.SelectedIndex = 0;
      comboBoxPwrSel.SelectedIndex = 0;
      comboBoxTxPwr.SelectedIndex = 0;
      tabControl.TabPages.Remove(tabPageKeys);
      // Timers
      cpTimer = new System.Timers.Timer();
      cpTimer.Elapsed += new ElapsedEventHandler(cpTimer_Elapsed);
      cpTimer.SynchronizingObject = this;
      statTimer = new System.Timers.Timer();
      statTimer.Elapsed += new ElapsedEventHandler(statTimer_Elapsed);
      statTimer.SynchronizingObject = this;
      rspTimer = new System.Timers.Timer();
      rspTimer.Elapsed += new ElapsedEventHandler(rspTimer_Elapsed);
      rspTimer.SynchronizingObject = this;
      // COM port
      cop = CMD_NOP;
      comRxImpl = new comRxDelegate(comRxMethod);
      comConImpl = new comConDelegate(comConMethod);
      cp = new ComPortNative(this);
      isdbg = false;
      UpdateRssiLogMenuState();
    }

    //
    // Utils
    //
    public UInt32 crc32(byte[] ptr, int idx, int len)
    {
      UInt32 temp;
      int i, j;

      temp = 0;
      for (i = 0; i < len; i++)
      {
        for (j = 7; j >= 0; j--)
        {
          if ((((temp >> 31) ^ ((int)ptr[i] >> j)) & 1) == 1)
            temp = (temp << 1) ^ (0x04C11DB7);
          else temp = temp << 1;
        }
      }
      temp = temp ^ 0xFFFFFFFF;
      return temp;
    }

    private int strLen(byte[] str, int idx, int maxlen)
    {
      int i;
      for (i = 0; i < maxlen; i++)
        if (str[idx + i] == 0) return i;
      return i;
    }

    private void statusMsg(string txt, Color c)
    {
      toolStripStatusLabelStatus.ForeColor = c;
      toolStripStatusLabelStatus.Text = txt;
    }

    private void statusMsgAppend(string txt)
    {
      toolStripStatusLabelStatus.Text += txt;
    }

    public void CopyBytes(byte[] dst, int didx, byte[] src, int sidx, int size)
    {
      for (int i = 0; i < size; i++) dst[didx + i] = src[sidx + i];
    }

    public void setUInt16LE(byte[] buf, int idx, UInt16 v)
    {
      buf[idx + 0] = (byte)(v >> 0);
      buf[idx + 1] = (byte)(v >> 8);
    }

    public UInt16 getUInt16LE(byte[] buf, int idx)
    {
      return (UInt16)(buf[idx] | buf[idx + 1] << 8);
    }

    public void setUInt32LE(byte[] buf, int idx, UInt32 v)
    {
      buf[idx + 0] = (byte)(v >> 0);
      buf[idx + 1] = (byte)(v >> 8);
      buf[idx + 2] = (byte)(v >> 16);
      buf[idx + 3] = (byte)(v >> 24);
    }

    public UInt32 getUInt32LE(byte[] buf, int idx)
    {
      return buf[idx] | (UInt32)buf[idx + 1] << 8 | (UInt32)buf[idx + 2] << 16 | (UInt32)buf[idx + 3] << 24;
    }

    private string keyGenerate()
    {
      char[] letters = "0123456789ABCDEF".ToCharArray();
      string key_str = "";
      for (int i = 0; i < 64; i++)
      {
        int letter_num = rand.Next(0, letters.Length);
        key_str += letters[letter_num];
      }
      return key_str;
    }

    private void fileSelect()
    {
      if (openFileDialogFWupd.ShowDialog() == DialogResult.OK)
      {
        textBoxFWfile.Text = openFileDialogFWupd.FileName;
      }
    }

    private void fileRead()
    {
      try
      {
        using (FileStream s = File.OpenRead(textBoxFWfile.Text))
        {
          if (s.Length < 32 || s.Length > PROG_MAX_SIZE)
          {
            statusMsg("ОШИБКА: файл поврежден", Color.Black);
            return;
          }
          prog_ptr = 32;
          prog_size = (int)s.Length;
          s.Read(prog_data, 0, (int)s.Length);
          bool res = comBootHdrWr();
          if (res)
          {
            statusMsg("Обновление ПО... 0 %", Color.Black);
          } else
          {
            statusMsg("ОШИБКА: запись в устройство", Color.Black);
          }
        }
      }
      catch (Exception)
      {
        statusMsg("ОШИБКА: файл поврежден", Color.Black);
      }
    }

    private void setUserPar(byte[] ip)
    {
      UInt32 id = getUInt32LE(ip, 0);
      numericUpDownID.Value = id;
      decimal freq = getUInt32LE(ip, 4);
      numericUpDownBaseFreq.Value = freq / 1000000;
      UInt32 bw = getUInt16LE(ip, 8);
      numericUpDownBW.Value = bw;
      UInt16 flags = getUInt16LE(ip, 10);
      comboBoxBERtst.SelectedIndex = (flags >> 2) & 1;
      comboBoxLostPkt.SelectedIndex = (flags >> 3) & 1;
      comboBoxMode.SelectedIndex = ip[12];
      comboBoxTxPwr.SelectedIndex = ip[13];
    }

    private byte[] getUserPar()
    {
      byte[] data = new byte[UPAR_SIZE];
      UInt32 id = (UInt32)numericUpDownID.Value;
      setUInt32LE(data, 0, id);
      UInt32 freq = (UInt32)(numericUpDownBaseFreq.Value * 1000000);
      setUInt32LE(data, 4, freq);
      UInt16 bw = (UInt16)numericUpDownBW.Value;
      setUInt16LE(data, 8, bw);
      UInt16 flags = 3;
      if (comboBoxBERtst.SelectedIndex != 0) flags |= 4;
      if (comboBoxLostPkt.SelectedIndex != 0) flags |= 8;
      setUInt16LE(data, 10, flags);
      data[12] = (byte)comboBoxMode.SelectedIndex;
      data[13] = (byte)comboBoxTxPwr.SelectedIndex;
      return data;
    }

    private NumericUpDown[] GetFactPowerControls()
    {
      return new NumericUpDown[]
      {
        numericUpDown400H, numericUpDown410H, numericUpDown420H, numericUpDown430H,
        numericUpDown440H, numericUpDown450H, numericUpDown460H, numericUpDown470H,
        numericUpDown400M, numericUpDown410M, numericUpDown420M, numericUpDown430M,
        numericUpDown440M, numericUpDown450M, numericUpDown460M, numericUpDown470M,
        numericUpDown400L, numericUpDown410L, numericUpDown420L, numericUpDown430L,
        numericUpDown440L, numericUpDown450L, numericUpDown460L, numericUpDown470L,
      };
    }

    private void setFactPar(byte[] ip)
    {
      int idx = 8;
      Int32 d = (Int32)getUInt32LE(ip, 0);
      numericUpDownFcorr.Value = d;
      Int16 v = (Int16)getUInt16LE(ip, 4);
      numericUpDownTpam.Value = v;
      v = (Int16)getUInt16LE(ip, 6);
      numericUpDownTcmx.Value = v;

      foreach (NumericUpDown control in GetFactPowerControls())
      {
        control.Value = getUInt16LE(ip, idx);
        idx += 2;
      }
    }

    private byte[] getFactPar()
    {
      int idx = 8;
      byte[] data = new byte[FPAR_SIZE];
      Int32 d = (Int32)numericUpDownFcorr.Value;
      setUInt32LE(data, 0, (UInt32)d);
      Int16 v = (Int16)numericUpDownTpam.Value;
      setUInt16LE(data, 4, (UInt16)v);
      v = (Int16)numericUpDownTcmx.Value;
      setUInt16LE(data, 6, (UInt16)v);

      foreach (NumericUpDown control in GetFactPowerControls())
      {
        setUInt16LE(data, idx, (UInt16)control.Value);
        idx += 2;
      }
      return data;
    }

    private byte[] getCarrTxPar()
    {
      byte[] data = new byte[8];

      Int32 d = (Int32)(numericUpDownCarrFreq.Value * 1000000);
      setUInt32LE(data, 0, (UInt32)d);
      Int16 v = (Int16)numericUpDownCarrPwr.Value;
      setUInt16LE(data, 4, (UInt16)v);
      data[6] = 1; // 0=level, 1=scalar
      data[7] = 0;
      return data;
    }

    private bool key2bin(string s, byte[] data, int idx, int n)
    {
      int x, v, len = s.Length;
      if (len != 2 * n) return false;
      for (int i = 0; i < n; i++)
      {
        x = s[2 * i] | 0x20;
        if (!((x >= 'a' && x <= 'f') || (x >= '0' && x <= '9')))
          return false;
        x = x <= '9' ? x - '0' : x - 'a' + 10;
        v = x << 4;
        x = s[2 * i + 1] | 0x20;
        if (!((x >= 'a' && x <= 'f') || (x >= '0' && x <= '9')))
          return false;
        x = x <= '9' ? x - '0' : x - 'a' + 10;
        v |= x;
        data[idx + i] = (byte)v;
      }
      return true;
    }

    private byte[] getKeys()
    {
      string s;
      byte[] keys = new byte[KEY_NUM * KEY_LEN];
      for (int i = 0; i < KEY_NUM; i++)
      {
        //s = listViewKeys.Items[i].Text;
        //key2bin(s, keys, i * KEY_LEN, KEY_LEN);
      }
      return keys;
    }

    private decimal freq2spacing(decimal freq)
    {
      decimal f = Math.Round(1000000 * freq / CHAN_SPACING);
      freq = f * CHAN_SPACING / 1000000;
      return freq;
    }

    private void updCCFreq(NumericUpDown nud)
    {
      decimal d = nud.Value;
      if (d != 0 && d < 430)
      {
        d = 430;
      }
      d = freq2spacing(d);
      nud.Value = d;
      //getParam();
    }

    private void infoSet(byte[] data, int size)
    {
      if (data == null || size < 20) return;
      UInt16 pid = getUInt16LE(data, 18);
      if (pid == 0) dev_name = "TFM400BFI";
      else dev_name = "Неизвестно";
      if(this.Text == org_name)
        this.Text += " :: " + dev_name;
      labelDevName.Text = dev_name;
      labelDevSN.Text = BitConverter.ToString(data, 0, 16).Replace("-", string.Empty);
      labelDevFWVer.Text = data[16].ToString() + "." + data[17].ToString();
    }

    private void bootInfoSet(byte[] data, int size)
    {
      if (size >= 18)
      {
        labelFWver.Text = data[8].ToString() + "." + data[9].ToString();
        UInt32 fwsize = getUInt32LE(data, 0);
        labelFWsize.Text = fwsize.ToString();
      }
    }

    private static string EscapeCsvField(string value)
    {
      if (value == null) return "";
      if (value.IndexOfAny(new char[] { ',', '"', '\r', '\n' }) >= 0)
        return "\"" + value.Replace("\"", "\"\"") + "\"";
      return value;
    }

    private string rfStatText(int rfstat)
    {
      switch (rfstat)
      {
        case 0:
          return "НЕТ АКТИВНОСТИ";
        case 1:
          return "ИНИЦИАЛИЗАЦИЯ";
        case 2:
          return "ОЖИДАНИЕ СВЯЗИ";
        case 3:
          return "СВЯЗЬ УСТАНОВЛЕНА";
        case 4:
          return "TX НЕСУЩАЯ ЧАСТОТА";
        case 5:
          return "BOOT РЕЖИМ";
        case 6:
          return "RX ИНДИКАЦИЯ RSSI";
        case 7:
          return "FDMA TX";
        default:
          return "FDMA RX";
      }
    }

    private void UpdateRssiLogMenuState()
    {
      startRssiLogToolStripMenuItem.Enabled = !rssiLogActive;
      stopRssiLogToolStripMenuItem.Enabled = rssiLogActive;
    }

    private bool StartRssiLog(string path)
    {
      try
      {
        StopRssiLog(false);
        rssiLogWriter = new StreamWriter(path, false, Encoding.UTF8);
        rssiLogWriter.WriteLine("timestamp_local,timestamp_utc,rssi,ber_percent,hwec,ttx,trx,rfstat,rfstat_text,com_port,device_name");
        rssiLogWriter.Flush();
        rssiLogPath = path;
        rssiLogActive = true;
        UpdateRssiLogMenuState();
        statusMsg("Лог RSSI: " + path, Color.DarkGreen);
        return true;
      }
      catch (Exception ex)
      {
        MessageBox.Show(
          "Не удалось начать запись лога RSSI:\r\n" + ex.Message,
          org_name,
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
        return false;
      }
    }

    private void StopRssiLog(bool showStatus)
    {
      if (rssiLogWriter != null)
      {
        try
        {
          rssiLogWriter.Flush();
          rssiLogWriter.Close();
        }
        catch (Exception)
        {
        }
        rssiLogWriter = null;
      }
      if (rssiLogActive && showStatus)
        statusMsg("Лог RSSI остановлен", Color.Black);
      rssiLogActive = false;
      rssiLogPath = null;
      UpdateRssiLogMenuState();
    }

    private void WriteRssiLogRow(Int16 rssi, decimal ber, UInt16 hwec, Int16 Ttx, Int16 Trx, int rfstat, string rfstatText)
    {
      if (!rssiLogActive || rssiLogWriter == null) return;
      try
      {
        DateTime local = DateTime.Now;
        DateTime utc = local.ToUniversalTime();
        string comPort = toolStripStatusLabelCom.Text;
        string line = string.Format(
          System.Globalization.CultureInfo.InvariantCulture,
          "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}",
          local.ToString("yyyy-MM-dd HH:mm:ss.fff"),
          utc.ToString("yyyy-MM-dd HH:mm:ss.fff"),
          rssi,
          ber.ToString("0.0###"),
          hwec,
          Ttx,
          Trx,
          rfstat,
          EscapeCsvField(rfstatText),
          EscapeCsvField(comPort),
          EscapeCsvField(dev_name));
        rssiLogWriter.WriteLine(line);
        rssiLogWriter.Flush();
      }
      catch (Exception ex)
      {
        StopRssiLog(false);
        MessageBox.Show(
          "Ошибка записи лога RSSI:\r\n" + ex.Message + "\r\nЗапись остановлена.",
          org_name,
          MessageBoxButtons.OK,
          MessageBoxIcon.Warning);
      }
    }

    private void statSet(byte[] data, int size)
    {
      if (data == null || size < 14) return;
      Int16 rssi = (Int16)getUInt16LE(data, 0);
      toolStripStatusLabelRSSI.Text = "RSSI= " + rssi.ToString();
      decimal ber = (decimal)getUInt16LE(data, 2) / 256;
      labelDevBER.Text = ber.ToString("N1") + " %";
      UInt16 hwec = (UInt16)getUInt16LE(data, 4);
      labelDevErr.Text = hwec.ToString();
      Int16 Ttx = (Int16)getUInt16LE(data, 6);
      Int16 Trx = (Int16)getUInt16LE(data, 8);
      toolStripStatusLabelTemp.Text = "Ttx= " + Ttx.ToString() + " :: Trx= " + Trx.ToString();
      int rfstat = data[13];
      string rfstatText = rfStatText(rfstat);
      labelRFstat.Text = rfstatText;
      if (rfstat != 5)
      {
        labelFWver.Text = "-----";
        labelFWsize.Text = "-----";
      }
      WriteRssiLogRow(rssi, ber, hwec, Ttx, Trx, rfstat, rfstatText);
    }

    private void devDisc()
    {
      labelDevName.Text = "-----";
      labelDevSN.Text = "-----";
      labelDevFWVer.Text = "-----";
      labelDevBER.Text = "-----";
      labelDevErr.Text = "-----";
      labelRFstat.Text = "-----";
      labelFWver.Text = "-----";
      labelFWsize.Text = "-----";
      this.Text = org_name;
      toolStripStatusLabelStatus.Text = "Нет связи с РС";
      toolStripStatusLabelRSSI.Text = "RSSI";
      toolStripStatusLabelTemp.Text = "Temp";
    }

    public void dbg(string s)
    {
      if (isdbg)
        Console.WriteLine(s);
    }
    public void dbg1(string s, Object v)
    {
      if (isdbg)
        Console.WriteLine("{0} {1}", s, v);
    }


    //
    // COM port Timer
    //
    private void cpTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
      if (!cpo) return; // COM port not open
      //statusMsgAppend("ТАЙМАУТ");
      statusMsg(statMsgTxt + "ТАЙМАУТ", Color.Black);
      cpTimerStop();
      cop = CMD_NOP;
    }

    private void cpTimerStart(int i)
    {
      cpTimerStop();
      cpTimer.Interval = i;
      cpTimer.Enabled = true;
    }

    private void cpTimerStop()
    {
      cpTimer.Enabled = false;
    }



    //
    // Status request Timer
    //
    private void statTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
      if (rspTimer.Enabled)
      {
        comStatRd();
      }
      else
      {
        comInfoRd();
      }
    }

    private void statTimerStart(int i)
    {
      statTimerStop();
      statTimer.Interval = i;
      statTimer.Enabled = true;
    }

    private void statTimerStop()
    {
      statTimer.Enabled = false;
    }



    //
    // Response Timer
    //
    private void rspTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
      rspTimerStop();
      devDisc();
    }

    private void rspTimerStart(int i)
    {
      rspTimerStop();
      rspTimer.Interval = i;
      rspTimer.Enabled = true;
    }

    private void rspTimerStop()
    {
      rspTimer.Enabled = false;
    }



    //
    // Commands
    //
    private bool comInfoRd()
    {
      byte[] data = new byte[1];
      data[0] = (byte)(checkBoxBootMode.Checked ? 1 : 0);
      return cp.portSend(data, 1, CMD_INFO);
    }

    private bool comStatRd()
    {
      byte[] data = new byte[1];
      data[0] = (byte)(checkBoxBootMode.Checked ? 1 : 0);
      return cp.portSend(data, 1, CMD_STAT);
    }

    private bool comUserParRd()
    {
      if (!cpo || cop != CMD_NOP) return false;
      bool res = cp.portSend(null, 0, CMD_UPAR_RD);
      if (res)
      {
        statMsgTxt = "Чтение параметров из устройства... ";
        statusMsg(statMsgTxt, Color.Black);
        cpTimerStart(TMO_CMD);
        cop = CMD_UPAR_RD;
      }
      return res;
    }

    private bool comUserParWr()
    {
      if (!cpo || cop != CMD_NOP) return false;
      byte[] data = getUserPar();
      bool res = cp.portSend(data, (UInt16)data.Length, CMD_UPAR_WR);
      if (res)
      {
        statMsgTxt = "Запись параметров в устройство... ";
        statusMsg(statMsgTxt, Color.Black);
        cpTimerStart(TMO_CMD);
        cop = CMD_UPAR_WR;
      }
      return res;
    }

    private bool comFactParRd()
    {
      if (!cpo || cop != CMD_NOP) return false;
      bool res = cp.portSend(null, 0, CMD_FPAR_RD);
      if (res)
      {
        statMsgTxt = "Чтение заводских настроек... ";
        statusMsg(statMsgTxt, Color.Black);
        cpTimerStart(TMO_CMD);
        cop = CMD_FPAR_RD;
      }
      return res;
    }

    private bool comFactParWr()
    {
      if (!cpo || cop != CMD_NOP) return false;
      byte[] data = getFactPar();
      bool res = cp.portSend(data, (UInt16)data.Length, CMD_FPAR_WR);
      if (res)
      {
        statMsgTxt = "Запись заводских параметров... ";
        statusMsg(statMsgTxt, Color.Black);
        cpTimerStart(TMO_CMD);
        cop = CMD_FPAR_WR;
      }
      return res;
    }

    private bool comCarrTx()
    {
      if (!cpo || cop != CMD_NOP) return false;
      byte[] data = getCarrTxPar();
      bool res = cp.portSend(data, (UInt16)data.Length, CMD_PTT);
      if (res)
      {
        statMsgTxt = "Передача несущей частоты... ";
        statusMsg(statMsgTxt, Color.Black);
        cpTimerStart(TMO_CMD);
        cop = CMD_PTT;
      }
      return res;
    }

    private bool comCarrTxOff()
    {
      if (!cpo || cop != CMD_NOP) return false;
      byte[] data = new byte[8];
      bool res = cp.portSend(data, (UInt16)data.Length, CMD_PTT);
      if (res)
      {
        statMsgTxt = "Остановка передачи... ";
        statusMsg(statMsgTxt, Color.Black);
        cpTimerStart(TMO_CMD);
        cop = CMD_PTT;
      }
      return res;
    }

    private bool comKeysWr()
    {
      if (!cpo || cop != CMD_NOP) return false;
      byte[] keys = getKeys();
      bool res = cp.portSend(keys, (UInt16)keys.Length, CMD_KEYS_WR);
      if (res)
      {
        statMsgTxt = "Запись ключей в РС... ";
        statusMsg(statMsgTxt, Color.Black);
        cpTimerStart(TMO_CMD);
        cop = CMD_KEYS_WR;
      }
      return res;
    }

    private bool comMsgWr()
    {
      if (!cpo || cop != CMD_NOP) return false;
      byte[] data = Encoding.GetEncoding(1251).GetBytes(textBoxMsg.Text);
      if (data == null || data.Length < 1) return false;
      bool res = cp.portSend(data, (UInt16)data.Length, CMD_SEND_DATA);
      if (res)
      {
        sentMsg = textBoxMsg.Text + Environment.NewLine;
        statMsgTxt = "Посылка сообщения... ";
        statusMsg(statMsgTxt, Color.Black);
        cpTimerStart(TMO_CMD);
        cop = CMD_SEND_DATA;
      }
      return res;
    }

    private bool comBootHdrWr()
    {
      if (!cpo || cop != CMD_NOP) return false;
      bool res = cp.portSend(prog_data, 32, CMD_BOOT_HDR);
      if (res)
      {
        cpTimerStart(TMO_CMD);
        cop = CMD_BOOT_HDR;
      }
      return res;
    }

    private bool comBootBlkWr()
    {
      if (!cpo || cop != CMD_NOP) return false;
      prog_sent = Math.Min(prog_size - prog_ptr, PAGE_SIZE);
      CopyBytes(page_data, 0, prog_data, prog_ptr, prog_sent);
      bool res = cp.portSend(page_data, (UInt16)prog_sent, CMD_BOOT_BLK);
      if (res)
      {
        cpTimerStart(TMO_CMD);
        cop = CMD_BOOT_BLK;
      }
      return res;
    }

    private PttBand[] GetPttBands()
    {
      return new PttBand[]
      {
        new PttBand(checkBox400, 405000000, numericUpDown400H, numericUpDown400M, numericUpDown400L),
        new PttBand(checkBox410, 415000000, numericUpDown410H, numericUpDown410M, numericUpDown410L),
        new PttBand(checkBox420, 425000000, numericUpDown420H, numericUpDown420M, numericUpDown420L),
        new PttBand(checkBox430, 435000000, numericUpDown430H, numericUpDown430M, numericUpDown430L),
        new PttBand(checkBox440, 445000000, numericUpDown440H, numericUpDown440M, numericUpDown440L),
        new PttBand(checkBox450, 455000000, numericUpDown450H, numericUpDown450M, numericUpDown450L),
        new PttBand(checkBox460, 465000000, numericUpDown460H, numericUpDown460M, numericUpDown460L),
        new PttBand(checkBox470, 475000000, numericUpDown470H, numericUpDown470M, numericUpDown470L),
      };
    }

    private PttBand GetSelectedPttBand()
    {
      foreach (PttBand band in GetPttBands())
      {
        if (band.CheckBox.Checked) return band;
      }
      return new PttBand(checkBox440, 440000000, numericUpDown440H, numericUpDown440M, numericUpDown440L);
    }

    private UInt16 GetSelectedPttPower(PttBand band)
    {
      int level = comboBoxPwrSel.SelectedIndex;
      if (level == 0) return (UInt16)band.HighPower.Value;
      if (level == 1) return (UInt16)band.MediumPower.Value;
      return (UInt16)band.LowPower.Value;
    }

    private bool comPtt(bool press)
    {
      if (!cpo || cop != CMD_NOP) return false;
      byte[] data = new byte[8];
      Int32 freq = 0;
      UInt16 pwr = 0;

      if (press)
      {
        PttBand band = GetSelectedPttBand();
        freq = band.Frequency;
        pwr = GetSelectedPttPower(band);
      }

      data[6] = 1; // 0=level, 1=scalar
      data[7] = 0;
      setUInt32LE(data, 0, (UInt32)freq);
      setUInt16LE(data, 4, pwr);
      bool res = cp.portSend(data, (UInt16)data.Length, CMD_PTT);
      if (res)
      {
        if (press)
          statMsgTxt = "PTT нажата... ";
        else
          statMsgTxt = "PTT отжата... ";
        statusMsg(statMsgTxt, Color.Black);
        cpTimerStart(TMO_CMD);
        cop = CMD_PTT;
      }
      return res;
    }



    //
    // Delegates
    //
    public delegate void comConDelegate(string pn);
    public void comConMethod(string pn)
    {
      if (pn != null)
      { // port open
        toolStripStatusLabelCom.Text = pn;
        toolStripStatusLabelCom.BackColor = Color.Lime;
        statTimerStart(300); // 500
        cpo = true;
      }
      else
      { // port close
        StopRssiLog(false);
        toolStripStatusLabelCom.Text = "COM";
        toolStripStatusLabelCom.BackColor = Color.LightCoral;
        statTimerStop();
        rspTimerStop();
        cpTimerStop();
        devDisc();
        cop = CMD_NOP;
        cpo = false;
      }
    }

    public delegate void comRxDelegate(int type, byte[] data, int size);
    public void comRxMethod(int type, byte[] data, int size)
    {
      switch (type)
      {
        case CMD_UPAR_RD:
          HandleUparRd(data, size);
          break;
        case CMD_UPAR_WR:
          HandleUparWr(data, size);
          break;
        case CMD_FPAR_RD:
          HandleFparRd(data, size);
          break;
        case CMD_FPAR_WR:
          HandleFparWr(data, size);
          break;
        case CMD_KEYS_WR:
          HandleKeysWr(data, size);
          break;
        case CMD_PTT:
          HandlePtt(data, size);
          break;
        case CMD_SEND_DATA:
          HandleSendData(data, size);
          break;
        case CMD_RECV_DATA:
          HandleRecvData(data, size);
          break;
        case CMD_BOOT_HDR:
          HandleBootHdr(data, size);
          break;
        case CMD_BOOT_BLK:
          HandleBootBlk(data, size);
          break;
        case CMD_BOOT_INFO:
          bootInfoSet(data, size);
          break;
        case CMD_INFO:
          HandleInfo(data, size);
          break;
        case CMD_STAT:
          HandleStat(data, size);
          break;
      }
    }

    private bool HasPayload(byte[] data, int size, int minSize)
    {
      return data != null && size >= minSize;
    }

    private void HandleUparRd(byte[] data, int size)
    {
      cpTimerStop();
      if (size == UPAR_SIZE)
      {
        statusMsgAppend("OK");
        CopyBytes(par1, 0, data, 0, size);
        CopyBytes(par2, 0, data, 0, size);
        setUserPar(par1);
      }
      else if (size == 1 && data != null)
      {
        int err = data[0];
        if (err == 1)
          statusMsgAppend("ОШИБКА (неверный формат)");
        else
          statusMsgAppend("ОШИБКА");
      }
      cop = CMD_NOP;
    }

    private void HandleUparWr(byte[] data, int size)
    {
      cpTimerStop();
      if (!HasPayload(data, size, 1))
      {
        statusMsgAppend("ОШИБКА (короткий ответ)");
        cop = CMD_NOP;
        return;
      }

      int err = data[0];
      if (err == 0)
      {
        statusMsgAppend("OK");
      }
      else if (err == 1)
      {
        statusMsgAppend("ОШИБКА (неверный формат)");
      }
      else
      {
        statusMsgAppend("ОШИБКА");
      }
      cop = CMD_NOP;
    }

    private void HandleFparRd(byte[] data, int size)
    {
      cpTimerStop();
      statusMsgAppend("OK");
      if (size == FPAR_SIZE)
      {
        setFactPar(data);
      }
      cop = CMD_NOP;
    }

    private void HandleFparWr(byte[] data, int size)
    {
      cpTimerStop();
      if (!HasPayload(data, size, 1))
      {
        statusMsgAppend("ОШИБКА (короткий ответ)");
        cop = CMD_NOP;
        return;
      }

      int err = data[0];
      if (err == 0)
      {
        statusMsgAppend("OK");
      }
      else
      {
        statusMsgAppend("ОШИБКА");
      }
      cop = CMD_NOP;
    }

    private void HandleKeysWr(byte[] data, int size)
    {
      cpTimerStop();
      if (HasPayload(data, size, 1))
      {
        int err = data[0];
        if (err == 0)
        {
          statusMsgAppend("OK");
        }
        else
        {
          statusMsgAppend("ОШИБКА");
        }
      }
      else
      {
        statusMsgAppend("ОШИБКА");
      }
      cop = CMD_NOP;
    }

    private void HandlePtt(byte[] data, int size)
    {
      cpTimerStop();
      if (!HasPayload(data, size, 1))
      {
        statusMsg(statMsgTxt + "ОШИБКА (короткий ответ)", Color.Black);
        cop = CMD_NOP;
        return;
      }

      int err = data[0];
      if (err == 0)
      {
        statusMsg(statMsgTxt + "OK", Color.Black);
      }
      else
      {
        statusMsg(statMsgTxt + "ОШИБКА", Color.Black);
      }
      cop = CMD_NOP;
    }

    private void HandleSendData(byte[] data, int size)
    {
      cpTimerStop();
      if (!HasPayload(data, size, 1))
      {
        statusMsg(statMsgTxt + "ОШИБКА (короткий ответ)", Color.Black);
        cop = CMD_NOP;
        return;
      }

      int err = data[0];
      if (err == 0)
      {
        statusMsg(statMsgTxt + "OK", Color.Black);
        if (size >= 2 && data[1] == 0)
        {
          textBoxChat.AppendText("TX: " + sentMsg);
          textBoxMsg.Text = "";
        }
      }
      else
      {
        statusMsg(statMsgTxt + "ОШИБКА", Color.Black);
      }
      cop = CMD_NOP;
    }

    private void HandleRecvData(byte[] data, int size)
    {
      if (!HasPayload(data, size, 1)) return;
      string msg = Encoding.GetEncoding(1251).GetString(data, 0, size);
      textBoxChat.AppendText("RX: " + msg + Environment.NewLine);
    }

    private void HandleBootHdr(byte[] data, int size)
    {
      cpTimerStop();
      cop = CMD_NOP;
      if (!HasPayload(data, size, 1))
      {
        statusMsg("Обновление ПО... ОШИБКА (короткий ответ)", Color.Black);
        return;
      }

      int err = data[0];
      if (err == 0)
      {
        bool res = comBootBlkWr();
        if (!res)
        {
          statusMsg("Обновление ПО... ОШИБКА", Color.Black);
        }
      }
      else
      {
        statusMsg("Обновление ПО... ОШИБКА", Color.Black);
      }
    }

    private void HandleBootBlk(byte[] data, int size)
    {
      cpTimerStop();
      cop = CMD_NOP;
      if (!HasPayload(data, size, 1))
      {
        statusMsg("Обновление ПО... ОШИБКА (короткий ответ)", Color.Black);
        return;
      }

      int err = data[0];
      if (err == 0)
      {
        prog_ptr += prog_sent;
        if (prog_ptr >= prog_size)
        {
          statusMsg("Обновление ПО... 100%", Color.Black);
        }
        else
        {
          bool res = comBootBlkWr();
          if (!res)
          {
            statusMsg("Обновление ПО... ОШИБКА", Color.Black);
          }
          else
          {
            err = 100 * prog_ptr / prog_size;
            statusMsg("Обновление ПО... " + err.ToString() + " %", Color.Black);
          }
        }
      }
      else
      {
        statusMsg("Обновление ПО... ОШИБКА", Color.Black);
      }
    }

    private void HandleInfo(byte[] data, int size)
    {
      if (size >= 20)
      {
        infoSet(data, size);
        rspTimerStart(3000);
      }
    }

    private void HandleStat(byte[] data, int size)
    {
      if (size >= 14)
      {
        statSet(data, size);
        rspTimerStart(3000);
      }
    }

    //
    // User IF
    //
    private void buttonUserParRd_Click(object sender, EventArgs e)
    {
      comUserParRd();
    }

    private void buttonUserParWr_Click(object sender, EventArgs e)
    {
      comUserParWr();
    }

    private void buttonFactParRd_Click(object sender, EventArgs e)
    {
      comFactParRd();
    }

    private void buttonFactParWr_Click(object sender, EventArgs e)
    {
      comFactParWr();
    }

    private void comboBoxTxPwr_SelectionChangeCommitted(object sender, EventArgs e)
    {
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      StopRssiLog(false);
      cp.comClose();
    }

    private void startRssiLogToolStripMenuItem_Click(object sender, EventArgs e)
    {
      saveFileDialogRssiLog.FileName = "rssi_log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
      if (saveFileDialogRssiLog.ShowDialog() == DialogResult.OK)
        StartRssiLog(saveFileDialogRssiLog.FileName);
    }

    private void stopRssiLogToolStripMenuItem_Click(object sender, EventArgs e)
    {
      StopRssiLog(true);
    }

    private void buttonCarrPtt_Click(object sender, EventArgs e)
    {
      comCarrTx();
    }

    private void buttonCarrTxOff_Click(object sender, EventArgs e)
    {
      comCarrTxOff();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      StopRssiLog(false);
      cp.comClose();
      Application.Exit();
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MessageBox.Show(
        "Программа для управления устройством TFM400 (" + ver_str.ToString() + ")",
        org_name,
        MessageBoxButtons.OK,
        MessageBoxIcon.Information,
        MessageBoxDefaultButton.Button1
      );
    }

    private void buttonChatClean_Click(object sender, EventArgs e)
    {
      textBoxChat.Text = "";
    }

    private void buttonMsgTx_Click(object sender, EventArgs e)
    {
      comMsgWr();
    }

    private void textBoxMsg_KeyPress(object sender, KeyPressEventArgs e)
    {
      switch (e.KeyChar)
      {
        case '\r':
          comMsgWr();
          break;
      }
    }

    private void buttonFileSel_Click(object sender, EventArgs e)
    {
      fileSelect();
    }

    private void buttonFWupd_Click(object sender, EventArgs e)
    {
      fileRead();
    }

    private void comboBoxMode_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void toolStripStatusLabelCom_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Middle)
      {
        if (tabControl.TabCount == 4)
          tabControl.TabPages.Remove(tpage);
        else
          tabControl.TabPages.Add(tpage);
      }
    }

    private void checkBoxPTT_CheckedChanged(object sender, EventArgs e)
    {
      if (checkBoxPTT.Checked)
      {
        comPtt(true);
      }
      else
      {
        comPtt(false);
      }
    }
  }



  //
  // COM port native
  //
  public class ComPortNative
  {
    private Form1 par;

    private const int UARTSP_RX_BUFF_SIZE = 64 * 1024;
    private ushort CRC_INIT = 0xABCD; // 0xFFFF

    private Thread oThread;
    private bool running;

    enum rx_s
    {
      BCSP_W4_PKT_DELIMITER,
      BCSP_W4_PKT_START,
      BCSP_W4_BCSP_HDR,
      BCSP_W4_DATA,
      BCSP_W4_CRC
    }; // state of RX sequence

    enum rx_esc_s
    {
      BCSP_ESCSTATE_NOESC,
      BCSP_ESCSTATE_ESC
    }; // escape or no escape symbol

    private uint ofs;
    private byte rx_esc_state;
    private byte rx_state;
    private byte[] hdr;
    private byte[] crc;
    private byte[] as_buff;
    private byte[] unslip;
    private int rx_count;
    private ushort[] crc_table;
    private UInt16 message_crc;

    public ComPortNative(Form1 parent)
    {
      par = parent;
      crc_table = new ushort[] {
      0x0000, 0x1081, 0x2102, 0x3183,
      0x4204, 0x5285, 0x6306, 0x7387,
      0x8408, 0x9489, 0xa50a, 0xb58b,
      0xc60c, 0xd68d, 0xe70e, 0xf78f};
      hdr = new byte[4];
      crc = new byte[2];
      as_buff = new byte[UARTSP_RX_BUFF_SIZE];
      startPortThread();
    }

    public void putUInt16BE(byte[] buf, int idx, UInt16 v)
    {
      buf[idx + 0] = (byte)(v >> 8);
      buf[idx + 1] = (byte)(v >> 0);
    }
    public UInt16 getUInt16BE(byte[] buf, int idx)
    {
      return (UInt16)((UInt16)buf[idx + 1] | (UInt16)buf[idx] << 8);
    }
    public void startPortThread()
    {
      if (oThread != null && oThread.IsAlive) return;
      running = true;
      oThread = new Thread(new ThreadStart(Run));
      oThread.IsBackground = true;
      oThread.Start();
      while (!oThread.IsAlive) ;
    }

    public void stopPortThread()
    {
      running = false;
      if (oThread != null && oThread.IsAlive && Thread.CurrentThread != oThread)
      {
        if (!oThread.Join(1000))
          par.dbg("COM thread did not stop in time" + Environment.NewLine);
      }
      if (oThread != null && !oThread.IsAlive)
        oThread = null;
    }

    public void comClose()
    {
      stopPortThread();
    }

    //
    //  Serial protocol
    //
    private void crc_update(ref ushort crc, byte d)
    {
      ushort reg = crc;

      reg = (ushort)((reg >> 4) ^ crc_table[(reg ^ d) & 0x000F]);
      reg = (ushort)((reg >> 4) ^ crc_table[(reg ^ (d >> 4)) & 0x000F]);
      crc = reg;
    }

    private int slip_msgdelim(byte[] addr, int offset)
    {
      addr[offset] = 0xc0;
      return 1;
    }

    public bool portSend(byte[] data, UInt16 size, byte code)
    {
      int i, offset = 0;
      byte[] ptr = new byte[16 * 1024];
      byte[] hdr = new byte[4];
      ushort txmsg_crc = CRC_INIT;
      int rw;

      offset += slip_msgdelim(ptr, offset);
      hdr[0] = code;
      putUInt16BE(hdr, 2, size);
      hdr[1] = (byte)(~(hdr[0] + hdr[2] + hdr[3]));

      /* Put header */
      for (i = 0; i < 4; i++)
      {
        offset += slip_one_byte(ptr, hdr[i], offset);
        crc_update(ref txmsg_crc, hdr[i]);
      }
      /* Put payload */
      for (i = 0; i < size; i++)
      {
        offset += slip_one_byte(ptr, data[i], offset);
        crc_update(ref txmsg_crc, data[i]);
      }
      /* Put CRC */
      offset += slip_one_byte(ptr, (byte)(txmsg_crc >> 8), offset);
      offset += slip_one_byte(ptr, (byte)(txmsg_crc), offset);
      bool res = portWriteNative(ptr, offset, out rw);
      if (rw != offset) res = false;
      return res;
    }

    private int slip_one_byte(byte[] addr, byte c, int offset)
    {
      int ret = 2;

      switch (c)
      {
        case 0xc0:
          addr[offset] = 0xdb;
          addr[offset + 1] = 0xdc;
          break;
        case 0xdb:
          addr[offset] = 0xdb;
          addr[offset + 1] = 0xdd;
          break;
        default:
          addr[offset] = c;
          ret = 1;
          break;
      }
      return ret;
    }

    private void unslip_one_byte(byte b)
    {
      switch (rx_esc_state)
      {
        case (byte)rx_esc_s.BCSP_ESCSTATE_NOESC:
          switch (b)
          {
            case 0xdb:
              rx_esc_state = (byte)rx_esc_s.BCSP_ESCSTATE_ESC;
              break;
            default:
              unslip[ofs++] = b;
              if (rx_state != (byte)rx_s.BCSP_W4_CRC)
                crc_update(ref message_crc, b);
              rx_count--;
              break;
          }
          break;
        case (byte)rx_esc_s.BCSP_ESCSTATE_ESC:
          switch (b)
          {
            case 0xdc:
              unslip[ofs++] = 0xc0;
              if (rx_state != (byte)rx_s.BCSP_W4_CRC)
                crc_update(ref message_crc, 0xc0);
              rx_esc_state = (byte)rx_esc_s.BCSP_ESCSTATE_NOESC;
              rx_count--;
              break;
            case 0xdd:
              unslip[ofs++] = 0xdb;
              if (rx_state != (byte)rx_s.BCSP_W4_CRC)
                crc_update(ref message_crc, 0xdb);
              rx_esc_state = (byte)rx_esc_s.BCSP_ESCSTATE_NOESC;
              rx_count--;
              break;
            default:
              rx_state = (byte)rx_s.BCSP_W4_PKT_START;
              rx_count = 0;
              break;
          }
          break;
      }
    }

    private void doRecv(byte[] data, int size)
    {
      for (int i = 0; i < size; i++)
      {
        byte ch = data[i];
        recv_cont:
        if (rx_count != 0)
        {
          if (ch == 0xC0)
          {
            rx_state = (byte)rx_s.BCSP_W4_PKT_START;
            rx_count = 0;
          }
          else
          {
            unslip_one_byte(ch);
          }
          if (rx_count != 0) continue;
        }
        ofs = 0;

        switch (rx_state)
        {
          case (byte)rx_s.BCSP_W4_BCSP_HDR:
            if (((byte)~(hdr[0] + hdr[2] + hdr[3])) != hdr[1])
            {
              rx_state = (byte)rx_s.BCSP_W4_PKT_DELIMITER;
              continue;
            }
            rx_count = (int)getUInt16BE(hdr, 2);
            if (rx_count != 0)
            {
              rx_state = (byte)rx_s.BCSP_W4_DATA;
              unslip = as_buff;
              continue;
            }
            goto case (byte)rx_s.BCSP_W4_DATA;
          case (byte)rx_s.BCSP_W4_DATA:
            rx_state = (byte)rx_s.BCSP_W4_CRC;
            unslip = crc;
            rx_count = 2;
            continue;
          case (byte)rx_s.BCSP_W4_CRC:
            if (message_crc != ((crc[0] << 8) + crc[1]))
            {
              rx_state = (byte)rx_s.BCSP_W4_PKT_DELIMITER;
              continue;
            }
            int type = hdr[0];
            int opbs = getUInt16BE(hdr, 2);
            byte[] opb;
            if (opbs > 0)
            {
              opb = new byte[opbs];
              par.CopyBytes(opb, 0, as_buff, 0, opbs);
            }
            else
            {
              opb = null;
            }
            postComRx(type, opb, opbs);
            rx_state = (byte)rx_s.BCSP_W4_PKT_DELIMITER;
            continue;
          case (byte)rx_s.BCSP_W4_PKT_DELIMITER:
            switch (ch)
            {
              case 0xc0:
                rx_state = (byte)rx_s.BCSP_W4_PKT_START;
                break;
              default:
                break;
            }
            break;
          case (byte)rx_s.BCSP_W4_PKT_START:
            switch (ch)
            {
              case 0xc0:
                break;
              default:
                rx_state = (byte)rx_s.BCSP_W4_BCSP_HDR;
                rx_count = 4;
                unslip = hdr;
                rx_esc_state = (byte)rx_esc_s.BCSP_ESCSTATE_NOESC;
                message_crc = CRC_INIT;
                goto recv_cont;
            }
            break;
        }
      }
    }

    private void postComRx(int type, byte[] data, int size)
    {
      if (par == null || par.IsDisposed || !par.IsHandleCreated) return;
      try
      {
        par.BeginInvoke(par.comRxImpl, new Object[] { type, data, size });
      }
      catch (InvalidOperationException)
      {
      }
    }

    private void postComCon(string pn)
    {
      if (par == null || par.IsDisposed || !par.IsHandleCreated) return;
      try
      {
        par.BeginInvoke(par.comConImpl, new Object[] { pn });
      }
      catch (InvalidOperationException)
      {
      }
    }

    public void Run()
    {
      bool res;
      byte[] iob;
      string pn;
      int modemStat;
      int rw, state;

      iob = new byte[16 * 1024];
      state = modemStat = 0;
      par.dbg("COM process started" + Environment.NewLine);
      while (running)
      {
        // check port lost
        if (state > 0)
        {
          res = GetCommModemStatus(fHandle, ref modemStat);
          if (!res)
          {
            portPurge();
            portCloseNative();
            postComCon(null);
            par.dbg("COM lost and closed" + Environment.NewLine);
            state = 0;
          }
        }
        if (state == 0)
        { // wait for port up and open it
          pn = comPortEnum();
          if (pn != null)
          {
            res = portOpenNative(pn);
            if (res)
            {
              PurgeComm(fHandle, 0x000C); // RXCLR & TXCLR
              postComCon(pn);
              state++;
            }
          }
        }
        else if (state == 1)
        { // RX data
          res = portReadNative(iob, 16 * 1024, out rw);
          if (res && rw > 0)
            doRecv(iob, rw);
        }
        Thread.Sleep(50);
      }
      if (state > 0)
      {
        portPurge();
        portCloseNative();
      }
      par.dbg("COM process terminated" + Environment.NewLine);
    }

    public string comPortEnum()
    {
      string s = null;
      try
      {
        ManagementObjectCollection mbsList = null;
        ManagementObjectSearcher mbs = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Name like 'Silicon Labs CP210x%'");
        mbsList = mbs.Get();
        if (mbsList.Count == 0) return null;
        foreach (ManagementObject mo in mbsList)
        {
          s = mo["Name"].ToString();
          int si = s.IndexOf("(COM");
          if (si < 0) return null;
          int ei = s.IndexOf(")", si);
          if (ei < 0) return null;
          s = s.Substring(si + 1, ei - si - 1);
          return s;
        }
      }
      catch (Exception)
      {
      }
      return s;
    }

    #region Native comm staff
    [StructLayout(LayoutKind.Sequential)]
    private struct Dcb
    {
      public uint DCBlength;
      public uint BaudRate;
      public uint Flags;
      public ushort wReserved;
      public ushort XonLim;
      public ushort XoffLim;
      public byte ByteSize;
      public byte Parity;
      public byte StopBits;
      public byte XonChar;
      public byte XoffChar;
      public byte ErrorChar;
      public byte EofChar;
      public byte EvtChar;
      public ushort wReserved1;
    }
    [StructLayout(LayoutKind.Sequential)]
    private struct COMMTIMEOUTS
    {
      public int ReadIntervalTimeout;
      public int ReadTotalTimeoutMultiplier;
      public int ReadTotalTimeoutConstant;
      public int WriteTotalTimeoutMultiplier;
      public int WriteTotalTimeoutConstant;
    }
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool PurgeComm(SafeFileHandle hFile, int dwFlags);
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool GetCommState(SafeFileHandle hFile, ref Dcb lpDcb);
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool SetCommState(SafeFileHandle hFile, ref Dcb lpDcb);
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern SafeFileHandle CreateFile(string lpFileName, int dwDesiredAccess, int dwShareMode, IntPtr securityAttrs, int dwCreationDisposition, int dwFlagsAndAttributes, IntPtr hTemplateFile);
    [DllImport("kernel32", SetLastError = true)]
    unsafe private static extern bool ReadFile(SafeFileHandle hFile, void* lpBuffer, int nBytesToRead, out int nBytesRead, IntPtr overlapped);
    [DllImport("kernel32", SetLastError = true)]
    unsafe private static extern bool WriteFile(SafeFileHandle hFile, void* lpBuffer, int nBytesToWrite, out int nBytesWritten, IntPtr overlapped);
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool SetCommTimeouts(SafeFileHandle hFile, ref COMMTIMEOUTS lpCommTimeouts);
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool GetCommModemStatus(SafeFileHandle hFile, ref int modemStat);

    const int GENERIC_READ_WRITE = unchecked((int)(0xC0000000));
    const int OPEN_EXISTING = 3;
    const int MAXDWORD = unchecked((int)(0xFFFFFFFF));
    private SafeFileHandle fHandle;

    private bool portOpenNative(string portName)
    {
      portName = "\\\\.\\" + portName;
      SafeFileHandle hFile = CreateFile(portName, GENERIC_READ_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
      if (hFile.IsInvalid)
      {
        fHandle = null;
        return false;
      }
      else
      {
        fHandle = hFile;
        InitializeDcb();
        InitializeTmos();
        return true;
      }
    }

    unsafe private bool portReadNative(byte[] buff, int size, out int rw)
    {
      int nb;
      bool res;

      if (fHandle == null)
      {
        rw = 0;
        return false;
      }
      fixed (void* p = buff)
      {
        res = ReadFile(fHandle, p, size, out nb, IntPtr.Zero);
      }
      rw = nb;
      return res;
    }

    unsafe private bool portWriteNative(byte[] buff, int size, out int rw)
    {
      int nb;
      bool res;

      if (fHandle == null)
      {
        rw = 0;
        return false;
      }
      fixed (void* p = buff)
      {
        res = WriteFile(fHandle, p, size, out nb, IntPtr.Zero);
      }
      rw = nb;
      return res;
    }

    private void portPurge()
    {
      if (fHandle != null)
        PurgeComm(fHandle, 0x000F);
    }

    private void portCloseNative()
    {
      if (fHandle == null) return;
      fHandle.Close();
      fHandle = null;
    }

    private bool InitializeDcb()
    {
      Dcb dcb = new Dcb();
      bool res = GetCommState(fHandle, ref dcb);
      if (!res) return false;
      dcb.BaudRate = 460800;
      dcb.ByteSize = 8;
      dcb.Parity = 0;
      dcb.StopBits = 0;
      dcb.Flags = 1;
      //dcb.Flags |= (1 << 2); // fOutxCtsFlow
      res = SetCommState(fHandle, ref dcb);
      if (!res) return false;
      return true;
    }

    private void InitializeTmos()
    {
      COMMTIMEOUTS tmos = new COMMTIMEOUTS();
      tmos.ReadIntervalTimeout = MAXDWORD;
      tmos.ReadTotalTimeoutMultiplier = 0;
      tmos.ReadTotalTimeoutConstant = 0;
      tmos.WriteTotalTimeoutConstant = 0;
      tmos.WriteTotalTimeoutMultiplier = 0;
      SetCommTimeouts(fHandle, ref tmos);
    }

    #endregion
  }
}
