namespace tfm400_pc
{
  partial class Form1
  {
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте 
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabelCom = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabelB1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabelRSSI = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabelB2 = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabelTemp = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabelB3 = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.startRssiLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.stopRssiLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparatorLog = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.refToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tabControl = new System.Windows.Forms.TabControl();
      this.tabPageParComm = new System.Windows.Forms.TabPage();
      this.comboBoxTxPwr = new System.Windows.Forms.ComboBox();
      this.comboBoxLostPkt = new System.Windows.Forms.ComboBox();
      this.comboBoxBERtst = new System.Windows.Forms.ComboBox();
      this.comboBoxMode = new System.Windows.Forms.ComboBox();
      this.buttonUserParWr = new System.Windows.Forms.Button();
      this.buttonUserParRd = new System.Windows.Forms.Button();
      this.numericUpDownID = new System.Windows.Forms.NumericUpDown();
      this.numericUpDownBW = new System.Windows.Forms.NumericUpDown();
      this.numericUpDownBaseFreq = new System.Windows.Forms.NumericUpDown();
      this.labelTxPwr = new System.Windows.Forms.Label();
      this.labelLostPkt = new System.Windows.Forms.Label();
      this.labelBERtst = new System.Windows.Forms.Label();
      this.labelMode = new System.Windows.Forms.Label();
      this.labelID = new System.Windows.Forms.Label();
      this.labelBW = new System.Windows.Forms.Label();
      this.labelBaseFreq = new System.Windows.Forms.Label();
      this.tabPageKeys = new System.Windows.Forms.TabPage();
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.listViewKeys = new System.Windows.Forms.ListView();
      this.columnHeaderKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeaderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.tabPageDevice = new System.Windows.Forms.TabPage();
      this.groupBoxFWupd = new System.Windows.Forms.GroupBox();
      this.labelFWsize = new System.Windows.Forms.Label();
      this.labelFWver = new System.Windows.Forms.Label();
      this.labelFWsizeL = new System.Windows.Forms.Label();
      this.labelFWverL = new System.Windows.Forms.Label();
      this.checkBoxBootMode = new System.Windows.Forms.CheckBox();
      this.textBoxFWfile = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.buttonFileSel = new System.Windows.Forms.Button();
      this.buttonFWupd = new System.Windows.Forms.Button();
      this.groupBoxDevStat = new System.Windows.Forms.GroupBox();
      this.labelRFstat = new System.Windows.Forms.Label();
      this.labelDevBER = new System.Windows.Forms.Label();
      this.labelDevErr = new System.Windows.Forms.Label();
      this.labelRFstatL = new System.Windows.Forms.Label();
      this.labelDevBerL = new System.Windows.Forms.Label();
      this.labelDevEL = new System.Windows.Forms.Label();
      this.groupBoxDevInfo = new System.Windows.Forms.GroupBox();
      this.labelDevNameLbl = new System.Windows.Forms.Label();
      this.labelDevFWVerLbl = new System.Windows.Forms.Label();
      this.labelDevName = new System.Windows.Forms.Label();
      this.labelDevFWVer = new System.Windows.Forms.Label();
      this.labelDevSN = new System.Windows.Forms.Label();
      this.labelDevSNLbl = new System.Windows.Forms.Label();
      this.tabPageChat = new System.Windows.Forms.TabPage();
      this.buttonMsgTx = new System.Windows.Forms.Button();
      this.buttonChatClean = new System.Windows.Forms.Button();
      this.labelChat = new System.Windows.Forms.Label();
      this.labelMsg = new System.Windows.Forms.Label();
      this.textBoxChat = new System.Windows.Forms.TextBox();
      this.textBoxMsg = new System.Windows.Forms.TextBox();
      this.tabPageParFact = new System.Windows.Forms.TabPage();
      this.buttonCarrTxOff = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.buttonCarrPtt = new System.Windows.Forms.Button();
      this.buttonFactParWr = new System.Windows.Forms.Button();
      this.buttonFactParRd = new System.Windows.Forms.Button();
      this.groupBoxTxCtl = new System.Windows.Forms.GroupBox();
      this.checkBoxPTT = new System.Windows.Forms.CheckBox();
      this.labelPwrSel = new System.Windows.Forms.Label();
      this.comboBoxPwrSel = new System.Windows.Forms.ComboBox();
      this.groupBoxTcorr = new System.Windows.Forms.GroupBox();
      this.labelTcmx = new System.Windows.Forms.Label();
      this.labelTpam = new System.Windows.Forms.Label();
      this.numericUpDownTcmx = new System.Windows.Forms.NumericUpDown();
      this.numericUpDownTpam = new System.Windows.Forms.NumericUpDown();
      this.groupBoxFreqOfs = new System.Windows.Forms.GroupBox();
      this.numericUpDownFcorr = new System.Windows.Forms.NumericUpDown();
      this.groupBoxTxPwr = new System.Windows.Forms.GroupBox();
      this.checkBox470 = new System.Windows.Forms.CheckBox();
      this.checkBox460 = new System.Windows.Forms.CheckBox();
      this.checkBox450 = new System.Windows.Forms.CheckBox();
      this.checkBox440 = new System.Windows.Forms.CheckBox();
      this.checkBox430 = new System.Windows.Forms.CheckBox();
      this.checkBox420 = new System.Windows.Forms.CheckBox();
      this.checkBox410 = new System.Windows.Forms.CheckBox();
      this.checkBox400 = new System.Windows.Forms.CheckBox();
      this.numericUpDown470H = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown460H = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown450H = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown440H = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown430H = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown420H = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown410H = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown400H = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown470M = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown460M = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown450M = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown440M = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown430M = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown420M = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown410M = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown400M = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown470L = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown460L = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown450L = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown440L = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown430L = new System.Windows.Forms.NumericUpDown();
      this.label470 = new System.Windows.Forms.Label();
      this.numericUpDown420L = new System.Windows.Forms.NumericUpDown();
      this.label460 = new System.Windows.Forms.Label();
      this.numericUpDown410L = new System.Windows.Forms.NumericUpDown();
      this.label450 = new System.Windows.Forms.Label();
      this.numericUpDown400L = new System.Windows.Forms.NumericUpDown();
      this.label440 = new System.Windows.Forms.Label();
      this.labelTxFlg = new System.Windows.Forms.Label();
      this.label430 = new System.Windows.Forms.Label();
      this.labelPwrHi = new System.Windows.Forms.Label();
      this.label420 = new System.Windows.Forms.Label();
      this.labelPwrMed = new System.Windows.Forms.Label();
      this.label410 = new System.Windows.Forms.Label();
      this.labelPwrLow = new System.Windows.Forms.Label();
      this.label400 = new System.Windows.Forms.Label();
      this.numericUpDownCarrFreq = new System.Windows.Forms.NumericUpDown();
      this.numericUpDownCarrPwr = new System.Windows.Forms.NumericUpDown();
      this.openFileDialogFWupd = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialogRssiLog = new System.Windows.Forms.SaveFileDialog();
      this.statusStrip.SuspendLayout();
      this.menuStrip.SuspendLayout();
      this.tabControl.SuspendLayout();
      this.tabPageParComm.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownID)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBW)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBaseFreq)).BeginInit();
      this.tabPageKeys.SuspendLayout();
      this.tabPageDevice.SuspendLayout();
      this.groupBoxFWupd.SuspendLayout();
      this.groupBoxDevStat.SuspendLayout();
      this.groupBoxDevInfo.SuspendLayout();
      this.tabPageChat.SuspendLayout();
      this.tabPageParFact.SuspendLayout();
      this.groupBoxTxCtl.SuspendLayout();
      this.groupBoxTcorr.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTcmx)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTpam)).BeginInit();
      this.groupBoxFreqOfs.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFcorr)).BeginInit();
      this.groupBoxTxPwr.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown470H)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown460H)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown450H)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown440H)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown430H)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown420H)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown410H)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown400H)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown470M)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown460M)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown450M)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown440M)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown430M)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown420M)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown410M)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown400M)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown470L)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown460L)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown450L)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown440L)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown430L)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown420L)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown410L)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown400L)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCarrFreq)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCarrPwr)).BeginInit();
      this.SuspendLayout();
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCom,
            this.toolStripStatusLabelB1,
            this.toolStripStatusLabelRSSI,
            this.toolStripStatusLabelB2,
            this.toolStripStatusLabelTemp,
            this.toolStripStatusLabelB3,
            this.toolStripStatusLabelStatus});
      this.statusStrip.Location = new System.Drawing.Point(0, 406);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(581, 22);
      this.statusStrip.TabIndex = 0;
      // 
      // toolStripStatusLabelCom
      // 
      this.toolStripStatusLabelCom.AutoSize = false;
      this.toolStripStatusLabelCom.BackColor = System.Drawing.Color.IndianRed;
      this.toolStripStatusLabelCom.Name = "toolStripStatusLabelCom";
      this.toolStripStatusLabelCom.Size = new System.Drawing.Size(60, 17);
      this.toolStripStatusLabelCom.Text = "COM";
      this.toolStripStatusLabelCom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStripStatusLabelCom_MouseDown);
      // 
      // toolStripStatusLabelB1
      // 
      this.toolStripStatusLabelB1.AutoSize = false;
      this.toolStripStatusLabelB1.Name = "toolStripStatusLabelB1";
      this.toolStripStatusLabelB1.Size = new System.Drawing.Size(5, 17);
      // 
      // toolStripStatusLabelRSSI
      // 
      this.toolStripStatusLabelRSSI.AutoSize = false;
      this.toolStripStatusLabelRSSI.BackColor = System.Drawing.Color.LightBlue;
      this.toolStripStatusLabelRSSI.Name = "toolStripStatusLabelRSSI";
      this.toolStripStatusLabelRSSI.Size = new System.Drawing.Size(65, 17);
      this.toolStripStatusLabelRSSI.Text = "RSSI";
      this.toolStripStatusLabelRSSI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // toolStripStatusLabelB2
      // 
      this.toolStripStatusLabelB2.AutoSize = false;
      this.toolStripStatusLabelB2.Name = "toolStripStatusLabelB2";
      this.toolStripStatusLabelB2.Size = new System.Drawing.Size(5, 17);
      // 
      // toolStripStatusLabelTemp
      // 
      this.toolStripStatusLabelTemp.AutoSize = false;
      this.toolStripStatusLabelTemp.BackColor = System.Drawing.Color.LightBlue;
      this.toolStripStatusLabelTemp.Name = "toolStripStatusLabelTemp";
      this.toolStripStatusLabelTemp.Size = new System.Drawing.Size(110, 17);
      this.toolStripStatusLabelTemp.Text = "Temp";
      this.toolStripStatusLabelTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // toolStripStatusLabelB3
      // 
      this.toolStripStatusLabelB3.AutoSize = false;
      this.toolStripStatusLabelB3.Name = "toolStripStatusLabelB3";
      this.toolStripStatusLabelB3.Size = new System.Drawing.Size(5, 17);
      // 
      // toolStripStatusLabelStatus
      // 
      this.toolStripStatusLabelStatus.BackColor = System.Drawing.Color.LightGray;
      this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
      this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(316, 17);
      this.toolStripStatusLabelStatus.Spring = true;
      this.toolStripStatusLabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.refToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(581, 24);
      this.menuStrip.TabIndex = 1;
      this.menuStrip.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startRssiLogToolStripMenuItem,
            this.stopRssiLogToolStripMenuItem,
            this.toolStripSeparatorLog,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
      this.fileToolStripMenuItem.Text = "&Файл";
      // 
      // startRssiLogToolStripMenuItem
      // 
      this.startRssiLogToolStripMenuItem.Name = "startRssiLogToolStripMenuItem";
      this.startRssiLogToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
      this.startRssiLogToolStripMenuItem.Text = "Начать лог RSSI...";
      this.startRssiLogToolStripMenuItem.Click += new System.EventHandler(this.startRssiLogToolStripMenuItem_Click);
      // 
      // stopRssiLogToolStripMenuItem
      // 
      this.stopRssiLogToolStripMenuItem.Enabled = false;
      this.stopRssiLogToolStripMenuItem.Name = "stopRssiLogToolStripMenuItem";
      this.stopRssiLogToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
      this.stopRssiLogToolStripMenuItem.Text = "Остановить лог RSSI";
      this.stopRssiLogToolStripMenuItem.Click += new System.EventHandler(this.stopRssiLogToolStripMenuItem_Click);
      // 
      // toolStripSeparatorLog
      // 
      this.toolStripSeparatorLog.Name = "toolStripSeparatorLog";
      this.toolStripSeparatorLog.Size = new System.Drawing.Size(217, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
      this.exitToolStripMenuItem.Text = "&Выход";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // refToolStripMenuItem
      // 
      this.refToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
      this.refToolStripMenuItem.Name = "refToolStripMenuItem";
      this.refToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
      this.refToolStripMenuItem.Text = "&Справка";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
      this.aboutToolStripMenuItem.Text = "&О программе";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.tabPageParComm);
      this.tabControl.Controls.Add(this.tabPageKeys);
      this.tabControl.Controls.Add(this.tabPageDevice);
      this.tabControl.Controls.Add(this.tabPageChat);
      this.tabControl.Controls.Add(this.tabPageParFact);
      this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.tabControl.Location = new System.Drawing.Point(0, 24);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(581, 382);
      this.tabControl.TabIndex = 2;
      // 
      // tabPageParComm
      // 
      this.tabPageParComm.Controls.Add(this.comboBoxTxPwr);
      this.tabPageParComm.Controls.Add(this.comboBoxLostPkt);
      this.tabPageParComm.Controls.Add(this.comboBoxBERtst);
      this.tabPageParComm.Controls.Add(this.comboBoxMode);
      this.tabPageParComm.Controls.Add(this.buttonUserParWr);
      this.tabPageParComm.Controls.Add(this.buttonUserParRd);
      this.tabPageParComm.Controls.Add(this.numericUpDownID);
      this.tabPageParComm.Controls.Add(this.numericUpDownBW);
      this.tabPageParComm.Controls.Add(this.numericUpDownBaseFreq);
      this.tabPageParComm.Controls.Add(this.labelTxPwr);
      this.tabPageParComm.Controls.Add(this.labelLostPkt);
      this.tabPageParComm.Controls.Add(this.labelBERtst);
      this.tabPageParComm.Controls.Add(this.labelMode);
      this.tabPageParComm.Controls.Add(this.labelID);
      this.tabPageParComm.Controls.Add(this.labelBW);
      this.tabPageParComm.Controls.Add(this.labelBaseFreq);
      this.tabPageParComm.Location = new System.Drawing.Point(4, 25);
      this.tabPageParComm.Name = "tabPageParComm";
      this.tabPageParComm.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageParComm.Size = new System.Drawing.Size(573, 353);
      this.tabPageParComm.TabIndex = 0;
      this.tabPageParComm.Text = "Общие настройки";
      this.tabPageParComm.UseVisualStyleBackColor = true;
      // 
      // comboBoxTxPwr
      // 
      this.comboBoxTxPwr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxTxPwr.FormattingEnabled = true;
      this.comboBoxTxPwr.Items.AddRange(new object[] {
            "Высокая",
            "Средняя",
            "Низкая"});
      this.comboBoxTxPwr.Location = new System.Drawing.Point(252, 112);
      this.comboBoxTxPwr.Name = "comboBoxTxPwr";
      this.comboBoxTxPwr.Size = new System.Drawing.Size(170, 24);
      this.comboBoxTxPwr.TabIndex = 3;
      this.comboBoxTxPwr.SelectionChangeCommitted += new System.EventHandler(this.comboBoxTxPwr_SelectionChangeCommitted);
      // 
      // comboBoxLostPkt
      // 
      this.comboBoxLostPkt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxLostPkt.FormattingEnabled = true;
      this.comboBoxLostPkt.Items.AddRange(new object[] {
            "Принимать",
            "Отбрасывать"});
      this.comboBoxLostPkt.Location = new System.Drawing.Point(252, 202);
      this.comboBoxLostPkt.Name = "comboBoxLostPkt";
      this.comboBoxLostPkt.Size = new System.Drawing.Size(170, 24);
      this.comboBoxLostPkt.TabIndex = 3;
      // 
      // comboBoxBERtst
      // 
      this.comboBoxBERtst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxBERtst.FormattingEnabled = true;
      this.comboBoxBERtst.Items.AddRange(new object[] {
            "Запретить",
            "Разрешить"});
      this.comboBoxBERtst.Location = new System.Drawing.Point(252, 172);
      this.comboBoxBERtst.Name = "comboBoxBERtst";
      this.comboBoxBERtst.Size = new System.Drawing.Size(170, 24);
      this.comboBoxBERtst.TabIndex = 3;
      // 
      // comboBoxMode
      // 
      this.comboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxMode.FormattingEnabled = true;
      this.comboBoxMode.Items.AddRange(new object[] {
            "Сервисный",
            "ППРЧ 16FSK ведущий",
            "ППРЧ 16FSK ведомый",
            "FDMA TX",
            "FDMA RX",
            "ППРЧ 4FSK ведущий",
            "ППРЧ 4FSK ведомый"});
      this.comboBoxMode.Location = new System.Drawing.Point(252, 142);
      this.comboBoxMode.Name = "comboBoxMode";
      this.comboBoxMode.Size = new System.Drawing.Size(170, 24);
      this.comboBoxMode.TabIndex = 3;
      this.comboBoxMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxMode_SelectedIndexChanged);
      // 
      // buttonUserParWr
      // 
      this.buttonUserParWr.Location = new System.Drawing.Point(342, 244);
      this.buttonUserParWr.Name = "buttonUserParWr";
      this.buttonUserParWr.Size = new System.Drawing.Size(80, 30);
      this.buttonUserParWr.TabIndex = 2;
      this.buttonUserParWr.Text = "ЗАПИСЬ";
      this.buttonUserParWr.UseVisualStyleBackColor = true;
      this.buttonUserParWr.Click += new System.EventHandler(this.buttonUserParWr_Click);
      // 
      // buttonUserParRd
      // 
      this.buttonUserParRd.Location = new System.Drawing.Point(20, 244);
      this.buttonUserParRd.Name = "buttonUserParRd";
      this.buttonUserParRd.Size = new System.Drawing.Size(80, 30);
      this.buttonUserParRd.TabIndex = 2;
      this.buttonUserParRd.Text = "ЧТЕНИЕ";
      this.buttonUserParRd.UseVisualStyleBackColor = true;
      this.buttonUserParRd.Click += new System.EventHandler(this.buttonUserParRd_Click);
      // 
      // numericUpDownID
      // 
      this.numericUpDownID.Location = new System.Drawing.Point(253, 83);
      this.numericUpDownID.Maximum = new decimal(new int[] {
            16776960,
            0,
            0,
            0});
      this.numericUpDownID.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericUpDownID.Name = "numericUpDownID";
      this.numericUpDownID.Size = new System.Drawing.Size(170, 23);
      this.numericUpDownID.TabIndex = 1;
      this.numericUpDownID.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // numericUpDownBW
      // 
      this.numericUpDownBW.Location = new System.Drawing.Point(253, 51);
      this.numericUpDownBW.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
      this.numericUpDownBW.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericUpDownBW.Name = "numericUpDownBW";
      this.numericUpDownBW.Size = new System.Drawing.Size(170, 23);
      this.numericUpDownBW.TabIndex = 1;
      this.numericUpDownBW.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
      // 
      // numericUpDownBaseFreq
      // 
      this.numericUpDownBaseFreq.DecimalPlaces = 6;
      this.numericUpDownBaseFreq.Increment = new decimal(new int[] {
            125,
            0,
            0,
            262144});
      this.numericUpDownBaseFreq.Location = new System.Drawing.Point(253, 19);
      this.numericUpDownBaseFreq.Maximum = new decimal(new int[] {
            480,
            0,
            0,
            0});
      this.numericUpDownBaseFreq.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            0});
      this.numericUpDownBaseFreq.Name = "numericUpDownBaseFreq";
      this.numericUpDownBaseFreq.Size = new System.Drawing.Size(170, 23);
      this.numericUpDownBaseFreq.TabIndex = 1;
      this.numericUpDownBaseFreq.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
      // 
      // labelTxPwr
      // 
      this.labelTxPwr.AutoSize = true;
      this.labelTxPwr.Location = new System.Drawing.Point(20, 115);
      this.labelTxPwr.Name = "labelTxPwr";
      this.labelTxPwr.Size = new System.Drawing.Size(101, 17);
      this.labelTxPwr.TabIndex = 0;
      this.labelTxPwr.Text = "Мощность TX:";
      // 
      // labelLostPkt
      // 
      this.labelLostPkt.AutoSize = true;
      this.labelLostPkt.Location = new System.Drawing.Point(20, 205);
      this.labelLostPkt.Name = "labelLostPkt";
      this.labelLostPkt.Size = new System.Drawing.Size(154, 17);
      this.labelLostPkt.TabIndex = 0;
      this.labelLostPkt.Text = "Поврежденный пакет:";
      // 
      // labelBERtst
      // 
      this.labelBERtst.AutoSize = true;
      this.labelBERtst.Location = new System.Drawing.Point(20, 175);
      this.labelBERtst.Name = "labelBERtst";
      this.labelBERtst.Size = new System.Drawing.Size(89, 17);
      this.labelBERtst.TabIndex = 0;
      this.labelBERtst.Text = "BER тестер:";
      // 
      // labelMode
      // 
      this.labelMode.AutoSize = true;
      this.labelMode.Location = new System.Drawing.Point(20, 145);
      this.labelMode.Name = "labelMode";
      this.labelMode.Size = new System.Drawing.Size(108, 17);
      this.labelMode.TabIndex = 0;
      this.labelMode.Text = "Режим работы:";
      // 
      // labelID
      // 
      this.labelID.AutoSize = true;
      this.labelID.Location = new System.Drawing.Point(21, 85);
      this.labelID.Name = "labelID";
      this.labelID.Size = new System.Drawing.Size(107, 17);
      this.labelID.TabIndex = 0;
      this.labelID.Text = "ID  устройства:";
      // 
      // labelBW
      // 
      this.labelBW.AutoSize = true;
      this.labelBW.Location = new System.Drawing.Point(19, 53);
      this.labelBW.Name = "labelBW";
      this.labelBW.Size = new System.Drawing.Size(200, 17);
      this.labelBW.TabIndex = 0;
      this.labelBW.Text = "Ширина полосы ППРЧ (МГц):";
      // 
      // labelBaseFreq
      // 
      this.labelBaseFreq.AutoSize = true;
      this.labelBaseFreq.Location = new System.Drawing.Point(19, 21);
      this.labelBaseFreq.Name = "labelBaseFreq";
      this.labelBaseFreq.Size = new System.Drawing.Size(208, 17);
      this.labelBaseFreq.TabIndex = 0;
      this.labelBaseFreq.Text = "Базовая частота ППРЧ (МГц):";
      // 
      // tabPageKeys
      // 
      this.tabPageKeys.Controls.Add(this.button2);
      this.tabPageKeys.Controls.Add(this.button1);
      this.tabPageKeys.Controls.Add(this.listViewKeys);
      this.tabPageKeys.Location = new System.Drawing.Point(4, 25);
      this.tabPageKeys.Name = "tabPageKeys";
      this.tabPageKeys.Size = new System.Drawing.Size(573, 353);
      this.tabPageKeys.TabIndex = 2;
      this.tabPageKeys.Text = "Ключи";
      this.tabPageKeys.UseVisualStyleBackColor = true;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(10, 316);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(95, 23);
      this.button2.TabIndex = 1;
      this.button2.Text = "ГЕН. КЛЮЧ";
      this.button2.UseVisualStyleBackColor = true;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(490, 316);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "ЗАПИСЬ";
      this.button1.UseVisualStyleBackColor = true;
      // 
      // listViewKeys
      // 
      this.listViewKeys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderKey,
            this.columnHeaderID});
      this.listViewKeys.FullRowSelect = true;
      this.listViewKeys.GridLines = true;
      this.listViewKeys.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.listViewKeys.HideSelection = false;
      this.listViewKeys.LabelEdit = true;
      this.listViewKeys.Location = new System.Drawing.Point(10, 10);
      this.listViewKeys.MultiSelect = false;
      this.listViewKeys.Name = "listViewKeys";
      this.listViewKeys.Size = new System.Drawing.Size(555, 284);
      this.listViewKeys.TabIndex = 0;
      this.listViewKeys.UseCompatibleStateImageBehavior = false;
      this.listViewKeys.View = System.Windows.Forms.View.Details;
      // 
      // columnHeaderKey
      // 
      this.columnHeaderKey.Text = "Ключи (64 HEX символов)";
      this.columnHeaderKey.Width = 500;
      // 
      // columnHeaderID
      // 
      this.columnHeaderID.Text = "ID";
      this.columnHeaderID.Width = 40;
      // 
      // tabPageDevice
      // 
      this.tabPageDevice.Controls.Add(this.groupBoxFWupd);
      this.tabPageDevice.Controls.Add(this.groupBoxDevStat);
      this.tabPageDevice.Controls.Add(this.groupBoxDevInfo);
      this.tabPageDevice.Location = new System.Drawing.Point(4, 25);
      this.tabPageDevice.Name = "tabPageDevice";
      this.tabPageDevice.Size = new System.Drawing.Size(573, 353);
      this.tabPageDevice.TabIndex = 3;
      this.tabPageDevice.Text = "Устройство";
      this.tabPageDevice.UseVisualStyleBackColor = true;
      // 
      // groupBoxFWupd
      // 
      this.groupBoxFWupd.Controls.Add(this.labelFWsize);
      this.groupBoxFWupd.Controls.Add(this.labelFWver);
      this.groupBoxFWupd.Controls.Add(this.labelFWsizeL);
      this.groupBoxFWupd.Controls.Add(this.labelFWverL);
      this.groupBoxFWupd.Controls.Add(this.checkBoxBootMode);
      this.groupBoxFWupd.Controls.Add(this.textBoxFWfile);
      this.groupBoxFWupd.Controls.Add(this.label1);
      this.groupBoxFWupd.Controls.Add(this.buttonFileSel);
      this.groupBoxFWupd.Controls.Add(this.buttonFWupd);
      this.groupBoxFWupd.Location = new System.Drawing.Point(14, 223);
      this.groupBoxFWupd.Name = "groupBoxFWupd";
      this.groupBoxFWupd.Size = new System.Drawing.Size(545, 114);
      this.groupBoxFWupd.TabIndex = 1;
      this.groupBoxFWupd.TabStop = false;
      this.groupBoxFWupd.Text = "Обновление встроенного ПО";
      // 
      // labelFWsize
      // 
      this.labelFWsize.AutoSize = true;
      this.labelFWsize.Location = new System.Drawing.Point(490, 81);
      this.labelFWsize.Name = "labelFWsize";
      this.labelFWsize.Size = new System.Drawing.Size(33, 17);
      this.labelFWsize.TabIndex = 4;
      this.labelFWsize.Text = "-----";
      // 
      // labelFWver
      // 
      this.labelFWver.AutoSize = true;
      this.labelFWver.Location = new System.Drawing.Point(490, 59);
      this.labelFWver.Name = "labelFWver";
      this.labelFWver.Size = new System.Drawing.Size(33, 17);
      this.labelFWver.TabIndex = 4;
      this.labelFWver.Text = "-----";
      // 
      // labelFWsizeL
      // 
      this.labelFWsizeL.AutoSize = true;
      this.labelFWsizeL.Location = new System.Drawing.Point(320, 81);
      this.labelFWsizeL.Name = "labelFWsizeL";
      this.labelFWsizeL.Size = new System.Drawing.Size(171, 17);
      this.labelFWsizeL.TabIndex = 4;
      this.labelFWsizeL.Text = "Размер актуального ПО:";
      // 
      // labelFWverL
      // 
      this.labelFWverL.AutoSize = true;
      this.labelFWverL.Location = new System.Drawing.Point(320, 59);
      this.labelFWverL.Name = "labelFWverL";
      this.labelFWverL.Size = new System.Drawing.Size(170, 17);
      this.labelFWverL.TabIndex = 4;
      this.labelFWverL.Text = "Версия актуального ПО:";
      // 
      // checkBoxBootMode
      // 
      this.checkBoxBootMode.AutoSize = true;
      this.checkBoxBootMode.Location = new System.Drawing.Point(13, 55);
      this.checkBoxBootMode.Name = "checkBoxBootMode";
      this.checkBoxBootMode.Size = new System.Drawing.Size(113, 21);
      this.checkBoxBootMode.TabIndex = 3;
      this.checkBoxBootMode.Text = "BOOT режим";
      this.checkBoxBootMode.UseVisualStyleBackColor = true;
      // 
      // textBoxFWfile
      // 
      this.textBoxFWfile.Location = new System.Drawing.Point(84, 24);
      this.textBoxFWfile.Name = "textBoxFWfile";
      this.textBoxFWfile.Size = new System.Drawing.Size(416, 23);
      this.textBoxFWfile.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 27);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(74, 17);
      this.label1.TabIndex = 1;
      this.label1.Text = "Файл ПО:";
      // 
      // buttonFileSel
      // 
      this.buttonFileSel.Location = new System.Drawing.Point(506, 24);
      this.buttonFileSel.Name = "buttonFileSel";
      this.buttonFileSel.Size = new System.Drawing.Size(32, 23);
      this.buttonFileSel.TabIndex = 0;
      this.buttonFileSel.Text = "...";
      this.buttonFileSel.UseVisualStyleBackColor = true;
      this.buttonFileSel.Click += new System.EventHandler(this.buttonFileSel_Click);
      // 
      // buttonFWupd
      // 
      this.buttonFWupd.Location = new System.Drawing.Point(13, 82);
      this.buttonFWupd.Name = "buttonFWupd";
      this.buttonFWupd.Size = new System.Drawing.Size(121, 23);
      this.buttonFWupd.TabIndex = 0;
      this.buttonFWupd.Text = "ОБНОВИТЬ ПО";
      this.buttonFWupd.UseVisualStyleBackColor = true;
      this.buttonFWupd.Click += new System.EventHandler(this.buttonFWupd_Click);
      // 
      // groupBoxDevStat
      // 
      this.groupBoxDevStat.Controls.Add(this.labelRFstat);
      this.groupBoxDevStat.Controls.Add(this.labelDevBER);
      this.groupBoxDevStat.Controls.Add(this.labelDevErr);
      this.groupBoxDevStat.Controls.Add(this.labelRFstatL);
      this.groupBoxDevStat.Controls.Add(this.labelDevBerL);
      this.groupBoxDevStat.Controls.Add(this.labelDevEL);
      this.groupBoxDevStat.Location = new System.Drawing.Point(14, 120);
      this.groupBoxDevStat.Name = "groupBoxDevStat";
      this.groupBoxDevStat.Size = new System.Drawing.Size(545, 97);
      this.groupBoxDevStat.TabIndex = 0;
      this.groupBoxDevStat.TabStop = false;
      this.groupBoxDevStat.Text = "Состояние";
      // 
      // labelRFstat
      // 
      this.labelRFstat.AutoSize = true;
      this.labelRFstat.Location = new System.Drawing.Point(151, 70);
      this.labelRFstat.Name = "labelRFstat";
      this.labelRFstat.Size = new System.Drawing.Size(33, 17);
      this.labelRFstat.TabIndex = 0;
      this.labelRFstat.Text = "-----";
      // 
      // labelDevBER
      // 
      this.labelDevBER.AutoSize = true;
      this.labelDevBER.Location = new System.Drawing.Point(151, 47);
      this.labelDevBER.Name = "labelDevBER";
      this.labelDevBER.Size = new System.Drawing.Size(33, 17);
      this.labelDevBER.TabIndex = 0;
      this.labelDevBER.Text = "-----";
      // 
      // labelDevErr
      // 
      this.labelDevErr.AutoSize = true;
      this.labelDevErr.Location = new System.Drawing.Point(151, 24);
      this.labelDevErr.Name = "labelDevErr";
      this.labelDevErr.Size = new System.Drawing.Size(33, 17);
      this.labelDevErr.TabIndex = 0;
      this.labelDevErr.Text = "-----";
      // 
      // labelRFstatL
      // 
      this.labelRFstatL.AutoSize = true;
      this.labelRFstatL.Location = new System.Drawing.Point(10, 68);
      this.labelRFstatL.Name = "labelRFstatL";
      this.labelRFstatL.Size = new System.Drawing.Size(57, 17);
      this.labelRFstatL.TabIndex = 0;
      this.labelRFstatL.Text = "Статус:";
      // 
      // labelDevBerL
      // 
      this.labelDevBerL.AutoSize = true;
      this.labelDevBerL.Location = new System.Drawing.Point(10, 47);
      this.labelDevBerL.Name = "labelDevBerL";
      this.labelDevBerL.Size = new System.Drawing.Size(40, 17);
      this.labelDevBerL.TabIndex = 0;
      this.labelDevBerL.Text = "BER:";
      // 
      // labelDevEL
      // 
      this.labelDevEL.AutoSize = true;
      this.labelDevEL.Location = new System.Drawing.Point(10, 24);
      this.labelDevEL.Name = "labelDevEL";
      this.labelDevEL.Size = new System.Drawing.Size(91, 17);
      this.labelDevEL.TabIndex = 0;
      this.labelDevEL.Text = "Код ошибки:";
      // 
      // groupBoxDevInfo
      // 
      this.groupBoxDevInfo.Controls.Add(this.labelDevNameLbl);
      this.groupBoxDevInfo.Controls.Add(this.labelDevFWVerLbl);
      this.groupBoxDevInfo.Controls.Add(this.labelDevName);
      this.groupBoxDevInfo.Controls.Add(this.labelDevFWVer);
      this.groupBoxDevInfo.Controls.Add(this.labelDevSN);
      this.groupBoxDevInfo.Controls.Add(this.labelDevSNLbl);
      this.groupBoxDevInfo.Location = new System.Drawing.Point(14, 14);
      this.groupBoxDevInfo.Name = "groupBoxDevInfo";
      this.groupBoxDevInfo.Size = new System.Drawing.Size(545, 100);
      this.groupBoxDevInfo.TabIndex = 0;
      this.groupBoxDevInfo.TabStop = false;
      this.groupBoxDevInfo.Text = "Информация";
      // 
      // labelDevNameLbl
      // 
      this.labelDevNameLbl.AutoSize = true;
      this.labelDevNameLbl.Location = new System.Drawing.Point(10, 25);
      this.labelDevNameLbl.Name = "labelDevNameLbl";
      this.labelDevNameLbl.Size = new System.Drawing.Size(76, 17);
      this.labelDevNameLbl.TabIndex = 0;
      this.labelDevNameLbl.Text = "Название:";
      // 
      // labelDevFWVerLbl
      // 
      this.labelDevFWVerLbl.AutoSize = true;
      this.labelDevFWVerLbl.Location = new System.Drawing.Point(10, 74);
      this.labelDevFWVerLbl.Name = "labelDevFWVerLbl";
      this.labelDevFWVerLbl.Size = new System.Drawing.Size(129, 17);
      this.labelDevFWVerLbl.TabIndex = 0;
      this.labelDevFWVerLbl.Text = "Версия прошивки:";
      // 
      // labelDevName
      // 
      this.labelDevName.AutoSize = true;
      this.labelDevName.Location = new System.Drawing.Point(151, 25);
      this.labelDevName.Name = "labelDevName";
      this.labelDevName.Size = new System.Drawing.Size(33, 17);
      this.labelDevName.TabIndex = 0;
      this.labelDevName.Text = "-----";
      // 
      // labelDevFWVer
      // 
      this.labelDevFWVer.AutoSize = true;
      this.labelDevFWVer.Location = new System.Drawing.Point(151, 74);
      this.labelDevFWVer.Name = "labelDevFWVer";
      this.labelDevFWVer.Size = new System.Drawing.Size(33, 17);
      this.labelDevFWVer.TabIndex = 0;
      this.labelDevFWVer.Text = "-----";
      // 
      // labelDevSN
      // 
      this.labelDevSN.AutoSize = true;
      this.labelDevSN.Location = new System.Drawing.Point(151, 48);
      this.labelDevSN.Name = "labelDevSN";
      this.labelDevSN.Size = new System.Drawing.Size(33, 17);
      this.labelDevSN.TabIndex = 0;
      this.labelDevSN.Text = "-----";
      // 
      // labelDevSNLbl
      // 
      this.labelDevSNLbl.AutoSize = true;
      this.labelDevSNLbl.Location = new System.Drawing.Point(10, 48);
      this.labelDevSNLbl.Name = "labelDevSNLbl";
      this.labelDevSNLbl.Size = new System.Drawing.Size(124, 17);
      this.labelDevSNLbl.TabIndex = 0;
      this.labelDevSNLbl.Text = "Серийный номер:";
      // 
      // tabPageChat
      // 
      this.tabPageChat.Controls.Add(this.buttonMsgTx);
      this.tabPageChat.Controls.Add(this.buttonChatClean);
      this.tabPageChat.Controls.Add(this.labelChat);
      this.tabPageChat.Controls.Add(this.labelMsg);
      this.tabPageChat.Controls.Add(this.textBoxChat);
      this.tabPageChat.Controls.Add(this.textBoxMsg);
      this.tabPageChat.Location = new System.Drawing.Point(4, 25);
      this.tabPageChat.Name = "tabPageChat";
      this.tabPageChat.Size = new System.Drawing.Size(573, 353);
      this.tabPageChat.TabIndex = 4;
      this.tabPageChat.Text = "Чат";
      this.tabPageChat.UseVisualStyleBackColor = true;
      // 
      // buttonMsgTx
      // 
      this.buttonMsgTx.Location = new System.Drawing.Point(520, 316);
      this.buttonMsgTx.Name = "buttonMsgTx";
      this.buttonMsgTx.Size = new System.Drawing.Size(42, 25);
      this.buttonMsgTx.TabIndex = 4;
      this.buttonMsgTx.Text = "TX";
      this.buttonMsgTx.UseVisualStyleBackColor = true;
      this.buttonMsgTx.Click += new System.EventHandler(this.buttonMsgTx_Click);
      // 
      // buttonChatClean
      // 
      this.buttonChatClean.Location = new System.Drawing.Point(474, 6);
      this.buttonChatClean.Name = "buttonChatClean";
      this.buttonChatClean.Size = new System.Drawing.Size(88, 23);
      this.buttonChatClean.TabIndex = 3;
      this.buttonChatClean.Text = "ОЧИСТКА";
      this.buttonChatClean.UseVisualStyleBackColor = true;
      this.buttonChatClean.Click += new System.EventHandler(this.buttonChatClean_Click);
      // 
      // labelChat
      // 
      this.labelChat.AutoSize = true;
      this.labelChat.Location = new System.Drawing.Point(8, 12);
      this.labelChat.Name = "labelChat";
      this.labelChat.Size = new System.Drawing.Size(37, 17);
      this.labelChat.TabIndex = 2;
      this.labelChat.Text = "Чат:";
      // 
      // labelMsg
      // 
      this.labelMsg.AutoSize = true;
      this.labelMsg.Location = new System.Drawing.Point(8, 297);
      this.labelMsg.Name = "labelMsg";
      this.labelMsg.Size = new System.Drawing.Size(88, 17);
      this.labelMsg.TabIndex = 2;
      this.labelMsg.Text = "Сообщение:";
      // 
      // textBoxChat
      // 
      this.textBoxChat.Location = new System.Drawing.Point(10, 32);
      this.textBoxChat.Multiline = true;
      this.textBoxChat.Name = "textBoxChat";
      this.textBoxChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.textBoxChat.Size = new System.Drawing.Size(552, 260);
      this.textBoxChat.TabIndex = 1;
      // 
      // textBoxMsg
      // 
      this.textBoxMsg.Location = new System.Drawing.Point(10, 317);
      this.textBoxMsg.Name = "textBoxMsg";
      this.textBoxMsg.Size = new System.Drawing.Size(504, 23);
      this.textBoxMsg.TabIndex = 1;
      this.textBoxMsg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMsg_KeyPress);
      // 
      // tabPageParFact
      // 
      this.tabPageParFact.Controls.Add(this.buttonCarrTxOff);
      this.tabPageParFact.Controls.Add(this.label3);
      this.tabPageParFact.Controls.Add(this.label2);
      this.tabPageParFact.Controls.Add(this.buttonCarrPtt);
      this.tabPageParFact.Controls.Add(this.buttonFactParWr);
      this.tabPageParFact.Controls.Add(this.buttonFactParRd);
      this.tabPageParFact.Controls.Add(this.groupBoxTxCtl);
      this.tabPageParFact.Controls.Add(this.groupBoxTcorr);
      this.tabPageParFact.Controls.Add(this.groupBoxFreqOfs);
      this.tabPageParFact.Controls.Add(this.groupBoxTxPwr);
      this.tabPageParFact.Controls.Add(this.numericUpDownCarrFreq);
      this.tabPageParFact.Controls.Add(this.numericUpDownCarrPwr);
      this.tabPageParFact.Location = new System.Drawing.Point(4, 25);
      this.tabPageParFact.Name = "tabPageParFact";
      this.tabPageParFact.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageParFact.Size = new System.Drawing.Size(573, 353);
      this.tabPageParFact.TabIndex = 1;
      this.tabPageParFact.Text = "Заводские настройки";
      this.tabPageParFact.UseVisualStyleBackColor = true;
      // 
      // buttonCarrTxOff
      // 
      this.buttonCarrTxOff.Location = new System.Drawing.Point(333, 310);
      this.buttonCarrTxOff.Name = "buttonCarrTxOff";
      this.buttonCarrTxOff.Size = new System.Drawing.Size(43, 30);
      this.buttonCarrTxOff.TabIndex = 5;
      this.buttonCarrTxOff.Text = "OFF";
      this.buttonCarrTxOff.UseVisualStyleBackColor = true;
      this.buttonCarrTxOff.Click += new System.EventHandler(this.buttonCarrTxOff_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 314);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(67, 17);
      this.label3.TabIndex = 4;
      this.label3.Text = "Частота:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(170, 314);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(50, 17);
      this.label2.TabIndex = 4;
      this.label2.Text = "Моща:";
      // 
      // buttonCarrPtt
      // 
      this.buttonCarrPtt.Location = new System.Drawing.Point(294, 310);
      this.buttonCarrPtt.Name = "buttonCarrPtt";
      this.buttonCarrPtt.Size = new System.Drawing.Size(37, 30);
      this.buttonCarrPtt.TabIndex = 3;
      this.buttonCarrPtt.Text = "ON";
      this.buttonCarrPtt.UseVisualStyleBackColor = true;
      this.buttonCarrPtt.Click += new System.EventHandler(this.buttonCarrPtt_Click);
      // 
      // buttonFactParWr
      // 
      this.buttonFactParWr.Location = new System.Drawing.Point(482, 310);
      this.buttonFactParWr.Name = "buttonFactParWr";
      this.buttonFactParWr.Size = new System.Drawing.Size(80, 30);
      this.buttonFactParWr.TabIndex = 2;
      this.buttonFactParWr.Text = "ЗАПИСЬ";
      this.buttonFactParWr.UseVisualStyleBackColor = true;
      this.buttonFactParWr.Click += new System.EventHandler(this.buttonFactParWr_Click);
      // 
      // buttonFactParRd
      // 
      this.buttonFactParRd.Location = new System.Drawing.Point(382, 310);
      this.buttonFactParRd.Name = "buttonFactParRd";
      this.buttonFactParRd.Size = new System.Drawing.Size(80, 30);
      this.buttonFactParRd.TabIndex = 2;
      this.buttonFactParRd.Text = "ЧТЕНИЕ";
      this.buttonFactParRd.UseVisualStyleBackColor = true;
      this.buttonFactParRd.Click += new System.EventHandler(this.buttonFactParRd_Click);
      // 
      // groupBoxTxCtl
      // 
      this.groupBoxTxCtl.Controls.Add(this.checkBoxPTT);
      this.groupBoxTxCtl.Controls.Add(this.labelPwrSel);
      this.groupBoxTxCtl.Controls.Add(this.comboBoxPwrSel);
      this.groupBoxTxCtl.Location = new System.Drawing.Point(382, 160);
      this.groupBoxTxCtl.Name = "groupBoxTxCtl";
      this.groupBoxTxCtl.Size = new System.Drawing.Size(180, 139);
      this.groupBoxTxCtl.TabIndex = 1;
      this.groupBoxTxCtl.TabStop = false;
      this.groupBoxTxCtl.Text = "Передача";
      // 
      // checkBoxPTT
      // 
      this.checkBoxPTT.Appearance = System.Windows.Forms.Appearance.Button;
      this.checkBoxPTT.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
      this.checkBoxPTT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.checkBoxPTT.Location = new System.Drawing.Point(12, 82);
      this.checkBoxPTT.Name = "checkBoxPTT";
      this.checkBoxPTT.Size = new System.Drawing.Size(150, 39);
      this.checkBoxPTT.TabIndex = 2;
      this.checkBoxPTT.Text = "PTT";
      this.checkBoxPTT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.checkBoxPTT.UseVisualStyleBackColor = true;
      this.checkBoxPTT.CheckedChanged += new System.EventHandler(this.checkBoxPTT_CheckedChanged);
      // 
      // labelPwrSel
      // 
      this.labelPwrSel.AutoSize = true;
      this.labelPwrSel.Location = new System.Drawing.Point(9, 24);
      this.labelPwrSel.Name = "labelPwrSel";
      this.labelPwrSel.Size = new System.Drawing.Size(79, 17);
      this.labelPwrSel.TabIndex = 1;
      this.labelPwrSel.Text = "Мощность:";
      // 
      // comboBoxPwrSel
      // 
      this.comboBoxPwrSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxPwrSel.FormattingEnabled = true;
      this.comboBoxPwrSel.Items.AddRange(new object[] {
            "Высокая",
            "Средняя",
            "Низкая"});
      this.comboBoxPwrSel.Location = new System.Drawing.Point(12, 47);
      this.comboBoxPwrSel.Name = "comboBoxPwrSel";
      this.comboBoxPwrSel.Size = new System.Drawing.Size(150, 24);
      this.comboBoxPwrSel.TabIndex = 0;
      // 
      // groupBoxTcorr
      // 
      this.groupBoxTcorr.Controls.Add(this.labelTcmx);
      this.groupBoxTcorr.Controls.Add(this.labelTpam);
      this.groupBoxTcorr.Controls.Add(this.numericUpDownTcmx);
      this.groupBoxTcorr.Controls.Add(this.numericUpDownTpam);
      this.groupBoxTcorr.Location = new System.Drawing.Point(382, 78);
      this.groupBoxTcorr.Name = "groupBoxTcorr";
      this.groupBoxTcorr.Size = new System.Drawing.Size(180, 80);
      this.groupBoxTcorr.TabIndex = 1;
      this.groupBoxTcorr.TabStop = false;
      this.groupBoxTcorr.Text = "Сдвиг температуры (°С)";
      // 
      // labelTcmx
      // 
      this.labelTcmx.AutoSize = true;
      this.labelTcmx.Location = new System.Drawing.Point(88, 22);
      this.labelTcmx.Name = "labelTcmx";
      this.labelTcmx.Size = new System.Drawing.Size(69, 17);
      this.labelTcmx.TabIndex = 1;
      this.labelTcmx.Text = "RX (cmx):";
      // 
      // labelTpam
      // 
      this.labelTpam.AutoSize = true;
      this.labelTpam.Location = new System.Drawing.Point(9, 22);
      this.labelTpam.Name = "labelTpam";
      this.labelTpam.Size = new System.Drawing.Size(71, 17);
      this.labelTpam.TabIndex = 1;
      this.labelTpam.Text = "TX (pam):";
      // 
      // numericUpDownTcmx
      // 
      this.numericUpDownTcmx.Location = new System.Drawing.Point(91, 42);
      this.numericUpDownTcmx.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
      this.numericUpDownTcmx.Name = "numericUpDownTcmx";
      this.numericUpDownTcmx.Size = new System.Drawing.Size(73, 23);
      this.numericUpDownTcmx.TabIndex = 0;
      // 
      // numericUpDownTpam
      // 
      this.numericUpDownTpam.Location = new System.Drawing.Point(12, 42);
      this.numericUpDownTpam.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
      this.numericUpDownTpam.Name = "numericUpDownTpam";
      this.numericUpDownTpam.Size = new System.Drawing.Size(73, 23);
      this.numericUpDownTpam.TabIndex = 0;
      // 
      // groupBoxFreqOfs
      // 
      this.groupBoxFreqOfs.Controls.Add(this.numericUpDownFcorr);
      this.groupBoxFreqOfs.Location = new System.Drawing.Point(382, 10);
      this.groupBoxFreqOfs.Name = "groupBoxFreqOfs";
      this.groupBoxFreqOfs.Size = new System.Drawing.Size(180, 65);
      this.groupBoxFreqOfs.TabIndex = 1;
      this.groupBoxFreqOfs.TabStop = false;
      this.groupBoxFreqOfs.Text = "Сдвиг частоты (Гц)";
      // 
      // numericUpDownFcorr
      // 
      this.numericUpDownFcorr.Location = new System.Drawing.Point(14, 28);
      this.numericUpDownFcorr.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.numericUpDownFcorr.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
      this.numericUpDownFcorr.Name = "numericUpDownFcorr";
      this.numericUpDownFcorr.Size = new System.Drawing.Size(150, 23);
      this.numericUpDownFcorr.TabIndex = 0;
      // 
      // groupBoxTxPwr
      // 
      this.groupBoxTxPwr.Controls.Add(this.checkBox470);
      this.groupBoxTxPwr.Controls.Add(this.checkBox460);
      this.groupBoxTxPwr.Controls.Add(this.checkBox450);
      this.groupBoxTxPwr.Controls.Add(this.checkBox440);
      this.groupBoxTxPwr.Controls.Add(this.checkBox430);
      this.groupBoxTxPwr.Controls.Add(this.checkBox420);
      this.groupBoxTxPwr.Controls.Add(this.checkBox410);
      this.groupBoxTxPwr.Controls.Add(this.checkBox400);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown470H);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown460H);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown450H);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown440H);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown430H);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown420H);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown410H);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown400H);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown470M);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown460M);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown450M);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown440M);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown430M);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown420M);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown410M);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown400M);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown470L);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown460L);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown450L);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown440L);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown430L);
      this.groupBoxTxPwr.Controls.Add(this.label470);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown420L);
      this.groupBoxTxPwr.Controls.Add(this.label460);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown410L);
      this.groupBoxTxPwr.Controls.Add(this.label450);
      this.groupBoxTxPwr.Controls.Add(this.numericUpDown400L);
      this.groupBoxTxPwr.Controls.Add(this.label440);
      this.groupBoxTxPwr.Controls.Add(this.labelTxFlg);
      this.groupBoxTxPwr.Controls.Add(this.label430);
      this.groupBoxTxPwr.Controls.Add(this.labelPwrHi);
      this.groupBoxTxPwr.Controls.Add(this.label420);
      this.groupBoxTxPwr.Controls.Add(this.labelPwrMed);
      this.groupBoxTxPwr.Controls.Add(this.label410);
      this.groupBoxTxPwr.Controls.Add(this.labelPwrLow);
      this.groupBoxTxPwr.Controls.Add(this.label400);
      this.groupBoxTxPwr.Location = new System.Drawing.Point(10, 10);
      this.groupBoxTxPwr.Name = "groupBoxTxPwr";
      this.groupBoxTxPwr.Size = new System.Drawing.Size(366, 289);
      this.groupBoxTxPwr.TabIndex = 0;
      this.groupBoxTxPwr.TabStop = false;
      this.groupBoxTxPwr.Text = "Мощность TX";
      // 
      // checkBox470
      // 
      this.checkBox470.AutoSize = true;
      this.checkBox470.Location = new System.Drawing.Point(325, 253);
      this.checkBox470.Name = "checkBox470";
      this.checkBox470.Size = new System.Drawing.Size(15, 14);
      this.checkBox470.TabIndex = 2;
      this.checkBox470.UseVisualStyleBackColor = true;
      // 
      // checkBox460
      // 
      this.checkBox460.AutoSize = true;
      this.checkBox460.Location = new System.Drawing.Point(325, 224);
      this.checkBox460.Name = "checkBox460";
      this.checkBox460.Size = new System.Drawing.Size(15, 14);
      this.checkBox460.TabIndex = 2;
      this.checkBox460.UseVisualStyleBackColor = true;
      // 
      // checkBox450
      // 
      this.checkBox450.AutoSize = true;
      this.checkBox450.Location = new System.Drawing.Point(325, 195);
      this.checkBox450.Name = "checkBox450";
      this.checkBox450.Size = new System.Drawing.Size(15, 14);
      this.checkBox450.TabIndex = 2;
      this.checkBox450.UseVisualStyleBackColor = true;
      // 
      // checkBox440
      // 
      this.checkBox440.AutoSize = true;
      this.checkBox440.Location = new System.Drawing.Point(325, 166);
      this.checkBox440.Name = "checkBox440";
      this.checkBox440.Size = new System.Drawing.Size(15, 14);
      this.checkBox440.TabIndex = 2;
      this.checkBox440.UseVisualStyleBackColor = true;
      // 
      // checkBox430
      // 
      this.checkBox430.AutoSize = true;
      this.checkBox430.Location = new System.Drawing.Point(325, 137);
      this.checkBox430.Name = "checkBox430";
      this.checkBox430.Size = new System.Drawing.Size(15, 14);
      this.checkBox430.TabIndex = 2;
      this.checkBox430.UseVisualStyleBackColor = true;
      // 
      // checkBox420
      // 
      this.checkBox420.AutoSize = true;
      this.checkBox420.Location = new System.Drawing.Point(325, 108);
      this.checkBox420.Name = "checkBox420";
      this.checkBox420.Size = new System.Drawing.Size(15, 14);
      this.checkBox420.TabIndex = 2;
      this.checkBox420.UseVisualStyleBackColor = true;
      // 
      // checkBox410
      // 
      this.checkBox410.AutoSize = true;
      this.checkBox410.Location = new System.Drawing.Point(325, 80);
      this.checkBox410.Name = "checkBox410";
      this.checkBox410.Size = new System.Drawing.Size(15, 14);
      this.checkBox410.TabIndex = 2;
      this.checkBox410.UseVisualStyleBackColor = true;
      // 
      // checkBox400
      // 
      this.checkBox400.AutoSize = true;
      this.checkBox400.Location = new System.Drawing.Point(325, 51);
      this.checkBox400.Name = "checkBox400";
      this.checkBox400.Size = new System.Drawing.Size(15, 14);
      this.checkBox400.TabIndex = 2;
      this.checkBox400.UseVisualStyleBackColor = true;
      // 
      // numericUpDown470H
      // 
      this.numericUpDown470H.Location = new System.Drawing.Point(238, 248);
      this.numericUpDown470H.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown470H.Name = "numericUpDown470H";
      this.numericUpDown470H.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown470H.TabIndex = 1;
      // 
      // numericUpDown460H
      // 
      this.numericUpDown460H.Location = new System.Drawing.Point(238, 219);
      this.numericUpDown460H.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown460H.Name = "numericUpDown460H";
      this.numericUpDown460H.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown460H.TabIndex = 1;
      // 
      // numericUpDown450H
      // 
      this.numericUpDown450H.Location = new System.Drawing.Point(238, 190);
      this.numericUpDown450H.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown450H.Name = "numericUpDown450H";
      this.numericUpDown450H.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown450H.TabIndex = 1;
      // 
      // numericUpDown440H
      // 
      this.numericUpDown440H.Location = new System.Drawing.Point(238, 161);
      this.numericUpDown440H.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown440H.Name = "numericUpDown440H";
      this.numericUpDown440H.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown440H.TabIndex = 1;
      // 
      // numericUpDown430H
      // 
      this.numericUpDown430H.Location = new System.Drawing.Point(238, 132);
      this.numericUpDown430H.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown430H.Name = "numericUpDown430H";
      this.numericUpDown430H.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown430H.TabIndex = 1;
      // 
      // numericUpDown420H
      // 
      this.numericUpDown420H.Location = new System.Drawing.Point(238, 103);
      this.numericUpDown420H.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown420H.Name = "numericUpDown420H";
      this.numericUpDown420H.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown420H.TabIndex = 1;
      // 
      // numericUpDown410H
      // 
      this.numericUpDown410H.Location = new System.Drawing.Point(238, 75);
      this.numericUpDown410H.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown410H.Name = "numericUpDown410H";
      this.numericUpDown410H.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown410H.TabIndex = 1;
      // 
      // numericUpDown400H
      // 
      this.numericUpDown400H.Location = new System.Drawing.Point(238, 46);
      this.numericUpDown400H.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown400H.Name = "numericUpDown400H";
      this.numericUpDown400H.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown400H.TabIndex = 1;
      // 
      // numericUpDown470M
      // 
      this.numericUpDown470M.Location = new System.Drawing.Point(167, 248);
      this.numericUpDown470M.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown470M.Name = "numericUpDown470M";
      this.numericUpDown470M.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown470M.TabIndex = 1;
      // 
      // numericUpDown460M
      // 
      this.numericUpDown460M.Location = new System.Drawing.Point(167, 219);
      this.numericUpDown460M.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown460M.Name = "numericUpDown460M";
      this.numericUpDown460M.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown460M.TabIndex = 1;
      // 
      // numericUpDown450M
      // 
      this.numericUpDown450M.Location = new System.Drawing.Point(167, 190);
      this.numericUpDown450M.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown450M.Name = "numericUpDown450M";
      this.numericUpDown450M.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown450M.TabIndex = 1;
      // 
      // numericUpDown440M
      // 
      this.numericUpDown440M.Location = new System.Drawing.Point(167, 161);
      this.numericUpDown440M.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown440M.Name = "numericUpDown440M";
      this.numericUpDown440M.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown440M.TabIndex = 1;
      // 
      // numericUpDown430M
      // 
      this.numericUpDown430M.Location = new System.Drawing.Point(167, 132);
      this.numericUpDown430M.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown430M.Name = "numericUpDown430M";
      this.numericUpDown430M.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown430M.TabIndex = 1;
      // 
      // numericUpDown420M
      // 
      this.numericUpDown420M.Location = new System.Drawing.Point(167, 103);
      this.numericUpDown420M.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown420M.Name = "numericUpDown420M";
      this.numericUpDown420M.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown420M.TabIndex = 1;
      // 
      // numericUpDown410M
      // 
      this.numericUpDown410M.Location = new System.Drawing.Point(167, 75);
      this.numericUpDown410M.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown410M.Name = "numericUpDown410M";
      this.numericUpDown410M.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown410M.TabIndex = 1;
      // 
      // numericUpDown400M
      // 
      this.numericUpDown400M.Location = new System.Drawing.Point(167, 46);
      this.numericUpDown400M.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown400M.Name = "numericUpDown400M";
      this.numericUpDown400M.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown400M.TabIndex = 1;
      // 
      // numericUpDown470L
      // 
      this.numericUpDown470L.Location = new System.Drawing.Point(96, 248);
      this.numericUpDown470L.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown470L.Name = "numericUpDown470L";
      this.numericUpDown470L.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown470L.TabIndex = 1;
      // 
      // numericUpDown460L
      // 
      this.numericUpDown460L.Location = new System.Drawing.Point(96, 219);
      this.numericUpDown460L.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown460L.Name = "numericUpDown460L";
      this.numericUpDown460L.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown460L.TabIndex = 1;
      // 
      // numericUpDown450L
      // 
      this.numericUpDown450L.Location = new System.Drawing.Point(96, 190);
      this.numericUpDown450L.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown450L.Name = "numericUpDown450L";
      this.numericUpDown450L.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown450L.TabIndex = 1;
      // 
      // numericUpDown440L
      // 
      this.numericUpDown440L.Location = new System.Drawing.Point(96, 161);
      this.numericUpDown440L.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown440L.Name = "numericUpDown440L";
      this.numericUpDown440L.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown440L.TabIndex = 1;
      // 
      // numericUpDown430L
      // 
      this.numericUpDown430L.Location = new System.Drawing.Point(96, 132);
      this.numericUpDown430L.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown430L.Name = "numericUpDown430L";
      this.numericUpDown430L.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown430L.TabIndex = 1;
      // 
      // label470
      // 
      this.label470.AutoSize = true;
      this.label470.Location = new System.Drawing.Point(15, 250);
      this.label470.Name = "label470";
      this.label470.Size = new System.Drawing.Size(75, 17);
      this.label470.TabIndex = 0;
      this.label470.Text = "470+ МГц:";
      // 
      // numericUpDown420L
      // 
      this.numericUpDown420L.Location = new System.Drawing.Point(96, 103);
      this.numericUpDown420L.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown420L.Name = "numericUpDown420L";
      this.numericUpDown420L.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown420L.TabIndex = 1;
      // 
      // label460
      // 
      this.label460.AutoSize = true;
      this.label460.Location = new System.Drawing.Point(15, 221);
      this.label460.Name = "label460";
      this.label460.Size = new System.Drawing.Size(75, 17);
      this.label460.TabIndex = 0;
      this.label460.Text = "460+ МГц:";
      // 
      // numericUpDown410L
      // 
      this.numericUpDown410L.Location = new System.Drawing.Point(96, 75);
      this.numericUpDown410L.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown410L.Name = "numericUpDown410L";
      this.numericUpDown410L.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown410L.TabIndex = 1;
      // 
      // label450
      // 
      this.label450.AutoSize = true;
      this.label450.Location = new System.Drawing.Point(15, 192);
      this.label450.Name = "label450";
      this.label450.Size = new System.Drawing.Size(75, 17);
      this.label450.TabIndex = 0;
      this.label450.Text = "450+ МГц:";
      // 
      // numericUpDown400L
      // 
      this.numericUpDown400L.Location = new System.Drawing.Point(96, 46);
      this.numericUpDown400L.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDown400L.Name = "numericUpDown400L";
      this.numericUpDown400L.Size = new System.Drawing.Size(65, 23);
      this.numericUpDown400L.TabIndex = 1;
      // 
      // label440
      // 
      this.label440.AutoSize = true;
      this.label440.Location = new System.Drawing.Point(15, 163);
      this.label440.Name = "label440";
      this.label440.Size = new System.Drawing.Size(75, 17);
      this.label440.TabIndex = 0;
      this.label440.Text = "440+ МГц:";
      // 
      // labelTxFlg
      // 
      this.labelTxFlg.AutoSize = true;
      this.labelTxFlg.Location = new System.Drawing.Point(301, 26);
      this.labelTxFlg.Name = "labelTxFlg";
      this.labelTxFlg.Size = new System.Drawing.Size(62, 17);
      this.labelTxFlg.TabIndex = 0;
      this.labelTxFlg.Text = "TX флаг";
      // 
      // label430
      // 
      this.label430.AutoSize = true;
      this.label430.Location = new System.Drawing.Point(15, 134);
      this.label430.Name = "label430";
      this.label430.Size = new System.Drawing.Size(75, 17);
      this.label430.TabIndex = 0;
      this.label430.Text = "430+ МГц:";
      // 
      // labelPwrHi
      // 
      this.labelPwrHi.AutoSize = true;
      this.labelPwrHi.Location = new System.Drawing.Point(236, 24);
      this.labelPwrHi.Name = "labelPwrHi";
      this.labelPwrHi.Size = new System.Drawing.Size(65, 17);
      this.labelPwrHi.TabIndex = 0;
      this.labelPwrHi.Text = "Высокая";
      // 
      // label420
      // 
      this.label420.AutoSize = true;
      this.label420.Location = new System.Drawing.Point(15, 105);
      this.label420.Name = "label420";
      this.label420.Size = new System.Drawing.Size(75, 17);
      this.label420.TabIndex = 0;
      this.label420.Text = "420+ МГц:";
      // 
      // labelPwrMed
      // 
      this.labelPwrMed.AutoSize = true;
      this.labelPwrMed.Location = new System.Drawing.Point(166, 24);
      this.labelPwrMed.Name = "labelPwrMed";
      this.labelPwrMed.Size = new System.Drawing.Size(65, 17);
      this.labelPwrMed.TabIndex = 0;
      this.labelPwrMed.Text = "Средняя";
      // 
      // label410
      // 
      this.label410.AutoSize = true;
      this.label410.Location = new System.Drawing.Point(15, 77);
      this.label410.Name = "label410";
      this.label410.Size = new System.Drawing.Size(75, 17);
      this.label410.TabIndex = 0;
      this.label410.Text = "410+ МГц:";
      // 
      // labelPwrLow
      // 
      this.labelPwrLow.AutoSize = true;
      this.labelPwrLow.Location = new System.Drawing.Point(98, 24);
      this.labelPwrLow.Name = "labelPwrLow";
      this.labelPwrLow.Size = new System.Drawing.Size(56, 17);
      this.labelPwrLow.TabIndex = 0;
      this.labelPwrLow.Text = "Низкая";
      // 
      // label400
      // 
      this.label400.AutoSize = true;
      this.label400.Location = new System.Drawing.Point(15, 48);
      this.label400.Name = "label400";
      this.label400.Size = new System.Drawing.Size(75, 17);
      this.label400.TabIndex = 0;
      this.label400.Text = "400+ МГц:";
      // 
      // numericUpDownCarrFreq
      // 
      this.numericUpDownCarrFreq.DecimalPlaces = 6;
      this.numericUpDownCarrFreq.Increment = new decimal(new int[] {
            125,
            0,
            0,
            262144});
      this.numericUpDownCarrFreq.Location = new System.Drawing.Point(73, 313);
      this.numericUpDownCarrFreq.Maximum = new decimal(new int[] {
            480,
            0,
            0,
            0});
      this.numericUpDownCarrFreq.Minimum = new decimal(new int[] {
            400,
            0,
            0,
            0});
      this.numericUpDownCarrFreq.Name = "numericUpDownCarrFreq";
      this.numericUpDownCarrFreq.Size = new System.Drawing.Size(91, 23);
      this.numericUpDownCarrFreq.TabIndex = 1;
      this.numericUpDownCarrFreq.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
      // 
      // numericUpDownCarrPwr
      // 
      this.numericUpDownCarrPwr.Location = new System.Drawing.Point(223, 313);
      this.numericUpDownCarrPwr.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
      this.numericUpDownCarrPwr.Name = "numericUpDownCarrPwr";
      this.numericUpDownCarrPwr.Size = new System.Drawing.Size(65, 23);
      this.numericUpDownCarrPwr.TabIndex = 1;
      // 
      // openFileDialogFWupd
      // 
      this.openFileDialogFWupd.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
      // 
      // saveFileDialogRssiLog
      // 
      this.saveFileDialogRssiLog.DefaultExt = "csv";
      this.saveFileDialogRssiLog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
      this.saveFileDialogRssiLog.Title = "Сохранить лог RSSI";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(581, 428);
      this.Controls.Add(this.tabControl);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.menuStrip);
      this.DoubleBuffered = true;
      this.MainMenuStrip = this.menuStrip;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.tabControl.ResumeLayout(false);
      this.tabPageParComm.ResumeLayout(false);
      this.tabPageParComm.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownID)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBW)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBaseFreq)).EndInit();
      this.tabPageKeys.ResumeLayout(false);
      this.tabPageDevice.ResumeLayout(false);
      this.groupBoxFWupd.ResumeLayout(false);
      this.groupBoxFWupd.PerformLayout();
      this.groupBoxDevStat.ResumeLayout(false);
      this.groupBoxDevStat.PerformLayout();
      this.groupBoxDevInfo.ResumeLayout(false);
      this.groupBoxDevInfo.PerformLayout();
      this.tabPageChat.ResumeLayout(false);
      this.tabPageChat.PerformLayout();
      this.tabPageParFact.ResumeLayout(false);
      this.tabPageParFact.PerformLayout();
      this.groupBoxTxCtl.ResumeLayout(false);
      this.groupBoxTxCtl.PerformLayout();
      this.groupBoxTcorr.ResumeLayout(false);
      this.groupBoxTcorr.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTcmx)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTpam)).EndInit();
      this.groupBoxFreqOfs.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFcorr)).EndInit();
      this.groupBoxTxPwr.ResumeLayout(false);
      this.groupBoxTxPwr.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown470H)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown460H)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown450H)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown440H)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown430H)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown420H)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown410H)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown400H)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown470M)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown460M)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown450M)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown440M)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown430M)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown420M)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown410M)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown400M)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown470L)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown460L)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown450L)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown440L)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown430L)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown420L)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown410L)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown400L)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCarrFreq)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCarrPwr)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCom;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelB1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRSSI;
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem startRssiLogToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem stopRssiLogToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparatorLog;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem refToolStripMenuItem;
    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage tabPageParComm;
    private System.Windows.Forms.TabPage tabPageParFact;
    private System.Windows.Forms.NumericUpDown numericUpDownBW;
    private System.Windows.Forms.NumericUpDown numericUpDownBaseFreq;
    private System.Windows.Forms.Label labelBW;
    private System.Windows.Forms.Label labelBaseFreq;
    private System.Windows.Forms.NumericUpDown numericUpDownID;
    private System.Windows.Forms.Label labelID;
    private System.Windows.Forms.Button buttonUserParWr;
    private System.Windows.Forms.Button buttonUserParRd;
    private System.Windows.Forms.Label labelMode;
    private System.Windows.Forms.ComboBox comboBoxMode;
    private System.Windows.Forms.TabPage tabPageKeys;
    private System.Windows.Forms.ComboBox comboBoxTxPwr;
    private System.Windows.Forms.Label labelTxPwr;
    private System.Windows.Forms.GroupBox groupBoxTxPwr;
    private System.Windows.Forms.Label label400;
    private System.Windows.Forms.Button buttonFactParWr;
    private System.Windows.Forms.Button buttonFactParRd;
    private System.Windows.Forms.GroupBox groupBoxTxCtl;
    private System.Windows.Forms.GroupBox groupBoxFreqOfs;
    private System.Windows.Forms.NumericUpDown numericUpDown400H;
    private System.Windows.Forms.NumericUpDown numericUpDown400M;
    private System.Windows.Forms.NumericUpDown numericUpDown400L;
    private System.Windows.Forms.Label labelTxFlg;
    private System.Windows.Forms.Label labelPwrHi;
    private System.Windows.Forms.Label labelPwrMed;
    private System.Windows.Forms.Label labelPwrLow;
    private System.Windows.Forms.CheckBox checkBox400;
    private System.Windows.Forms.NumericUpDown numericUpDownFcorr;
    private System.Windows.Forms.Label labelPwrSel;
    private System.Windows.Forms.ComboBox comboBoxPwrSel;
    private System.Windows.Forms.CheckBox checkBox470;
    private System.Windows.Forms.CheckBox checkBox460;
    private System.Windows.Forms.CheckBox checkBox450;
    private System.Windows.Forms.CheckBox checkBox440;
    private System.Windows.Forms.CheckBox checkBox430;
    private System.Windows.Forms.CheckBox checkBox420;
    private System.Windows.Forms.CheckBox checkBox410;
    private System.Windows.Forms.NumericUpDown numericUpDown470H;
    private System.Windows.Forms.NumericUpDown numericUpDown460H;
    private System.Windows.Forms.NumericUpDown numericUpDown450H;
    private System.Windows.Forms.NumericUpDown numericUpDown440H;
    private System.Windows.Forms.NumericUpDown numericUpDown430H;
    private System.Windows.Forms.NumericUpDown numericUpDown420H;
    private System.Windows.Forms.NumericUpDown numericUpDown410H;
    private System.Windows.Forms.NumericUpDown numericUpDown470M;
    private System.Windows.Forms.NumericUpDown numericUpDown460M;
    private System.Windows.Forms.NumericUpDown numericUpDown450M;
    private System.Windows.Forms.NumericUpDown numericUpDown440M;
    private System.Windows.Forms.NumericUpDown numericUpDown430M;
    private System.Windows.Forms.NumericUpDown numericUpDown420M;
    private System.Windows.Forms.NumericUpDown numericUpDown410M;
    private System.Windows.Forms.NumericUpDown numericUpDown470L;
    private System.Windows.Forms.NumericUpDown numericUpDown460L;
    private System.Windows.Forms.NumericUpDown numericUpDown450L;
    private System.Windows.Forms.NumericUpDown numericUpDown440L;
    private System.Windows.Forms.NumericUpDown numericUpDown430L;
    private System.Windows.Forms.Label label470;
    private System.Windows.Forms.NumericUpDown numericUpDown420L;
    private System.Windows.Forms.Label label460;
    private System.Windows.Forms.NumericUpDown numericUpDown410L;
    private System.Windows.Forms.Label label450;
    private System.Windows.Forms.Label label440;
    private System.Windows.Forms.Label label430;
    private System.Windows.Forms.Label label420;
    private System.Windows.Forms.Label label410;
    private System.Windows.Forms.CheckBox checkBoxPTT;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelB2;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTemp;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelB3;
    private System.Windows.Forms.TabPage tabPageDevice;
    private System.Windows.Forms.GroupBox groupBoxDevStat;
    private System.Windows.Forms.GroupBox groupBoxDevInfo;
    private System.Windows.Forms.Label labelDevEL;
    private System.Windows.Forms.Label labelDevNameLbl;
    private System.Windows.Forms.Label labelDevFWVerLbl;
    private System.Windows.Forms.Label labelDevName;
    private System.Windows.Forms.Label labelDevFWVer;
    private System.Windows.Forms.Label labelDevSN;
    private System.Windows.Forms.Label labelDevSNLbl;
    private System.Windows.Forms.Label labelDevErr;
    private System.Windows.Forms.Label labelDevBER;
    private System.Windows.Forms.Label labelDevBerL;
    private System.Windows.Forms.GroupBox groupBoxTcorr;
    private System.Windows.Forms.NumericUpDown numericUpDownTpam;
    private System.Windows.Forms.ListView listViewKeys;
    private System.Windows.Forms.ColumnHeader columnHeaderKey;
    private System.Windows.Forms.ColumnHeader columnHeaderID;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button buttonCarrPtt;
    private System.Windows.Forms.NumericUpDown numericUpDownCarrPwr;
    private System.Windows.Forms.NumericUpDown numericUpDownCarrFreq;
    private System.Windows.Forms.NumericUpDown numericUpDownTcmx;
    private System.Windows.Forms.Label labelTcmx;
    private System.Windows.Forms.Label labelTpam;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button buttonCarrTxOff;
    private System.Windows.Forms.ComboBox comboBoxBERtst;
    private System.Windows.Forms.Label labelBERtst;
    private System.Windows.Forms.ComboBox comboBoxLostPkt;
    private System.Windows.Forms.Label labelLostPkt;
    private System.Windows.Forms.TabPage tabPageChat;
    private System.Windows.Forms.Label labelMsg;
    private System.Windows.Forms.TextBox textBoxMsg;
    private System.Windows.Forms.Label labelChat;
    private System.Windows.Forms.TextBox textBoxChat;
    private System.Windows.Forms.Button buttonChatClean;
    private System.Windows.Forms.Button buttonMsgTx;
    private System.Windows.Forms.GroupBox groupBoxFWupd;
    private System.Windows.Forms.Label labelRFstat;
    private System.Windows.Forms.Label labelRFstatL;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBoxFWfile;
    private System.Windows.Forms.Button buttonFWupd;
    private System.Windows.Forms.CheckBox checkBoxBootMode;
    private System.Windows.Forms.OpenFileDialog openFileDialogFWupd;
    private System.Windows.Forms.SaveFileDialog saveFileDialogRssiLog;
    private System.Windows.Forms.Button buttonFileSel;
    private System.Windows.Forms.Label labelFWver;
    private System.Windows.Forms.Label labelFWverL;
    private System.Windows.Forms.Label labelFWsize;
    private System.Windows.Forms.Label labelFWsizeL;
  }
}

