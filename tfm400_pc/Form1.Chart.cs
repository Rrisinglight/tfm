using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace tfm400_pc
{
  public partial class Form1 : Form
  {
    private struct TelemetrySample
    {
      public DateTime Time;
      public double Rssi;
      public double Ber;
      public double Ttx;
      public double Trx;
      public int RfStat;
    }

    private readonly List<TelemetrySample> chartSamples = new List<TelemetrySample>();
    private DateTime chartStart;
    private int chartWindowSec = 60;
    private bool chartPaused;

    private TabPage tabPageChart;
    private Chart chartTelemetry;
    private Series seriesRssi;
    private Series seriesBer;
    private Series seriesTtx;
    private Series seriesTrx;

    private ComboBox comboBoxChartWindow;
    private Button buttonChartPause;
    private Button buttonChartClear;
    private CheckBox checkBoxShowRssi;
    private CheckBox checkBoxShowBer;
    private CheckBox checkBoxShowTtx;
    private CheckBox checkBoxShowTrx;
    private Label labelStatRssi;
    private Label labelStatBer;
    private Label labelStatTemp;

    private void BuildChartTab()
    {
      tabPageChart = new TabPage();
      tabPageChart.Name = "tabPageChart";
      tabPageChart.Text = "Графики";
      tabPageChart.UseVisualStyleBackColor = true;

      TableLayoutPanel layout = new TableLayoutPanel();
      layout.Dock = DockStyle.Fill;
      layout.ColumnCount = 1;
      layout.RowCount = 2;
      layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
      layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
      layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

      FlowLayoutPanel controls = new FlowLayoutPanel();
      controls.Dock = DockStyle.Fill;
      controls.WrapContents = true;
      controls.AutoScroll = false;
      controls.Padding = new Padding(3);

      Label windowLbl = new Label();
      windowLbl.Text = "Окно:";
      windowLbl.AutoSize = true;
      windowLbl.Margin = new Padding(3, 7, 3, 3);

      comboBoxChartWindow = new ComboBox();
      comboBoxChartWindow.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBoxChartWindow.Width = 70;
      comboBoxChartWindow.Items.AddRange(new object[] { "30 с", "60 с", "120 с", "300 с" });
      comboBoxChartWindow.SelectedIndex = 1;
      comboBoxChartWindow.SelectedIndexChanged += comboBoxChartWindow_SelectedIndexChanged;

      buttonChartPause = new Button();
      buttonChartPause.Text = "Пауза";
      buttonChartPause.AutoSize = true;
      buttonChartPause.Click += buttonChartPause_Click;

      buttonChartClear = new Button();
      buttonChartClear.Text = "Очистить";
      buttonChartClear.AutoSize = true;
      buttonChartClear.Click += buttonChartClear_Click;

      checkBoxShowRssi = MakeSeriesCheckBox("RSSI", true);
      checkBoxShowBer = MakeSeriesCheckBox("BER", true);
      checkBoxShowTtx = MakeSeriesCheckBox("Ttx", true);
      checkBoxShowTrx = MakeSeriesCheckBox("Trx", true);

      controls.Controls.Add(windowLbl);
      controls.Controls.Add(comboBoxChartWindow);
      controls.Controls.Add(buttonChartPause);
      controls.Controls.Add(buttonChartClear);
      controls.Controls.Add(checkBoxShowRssi);
      controls.Controls.Add(checkBoxShowBer);
      controls.Controls.Add(checkBoxShowTtx);
      controls.Controls.Add(checkBoxShowTrx);

      labelStatRssi = MakeStatLabel();
      labelStatBer = MakeStatLabel();
      labelStatTemp = MakeStatLabel();
      controls.Controls.Add(labelStatRssi);
      controls.Controls.Add(labelStatBer);
      controls.Controls.Add(labelStatTemp);

      chartTelemetry = new Chart();
      chartTelemetry.Dock = DockStyle.Fill;

      ChartArea area = new ChartArea("main");
      area.AxisX.Title = "время, с";
      area.AxisX.MajorGrid.LineColor = Color.Gainsboro;
      area.AxisY.Title = "RSSI, дБ / T, °C";
      area.AxisY.MajorGrid.LineColor = Color.Gainsboro;
      area.AxisY2.Title = "BER, %";
      area.AxisY2.Enabled = AxisEnabled.True;
      area.AxisY2.MajorGrid.Enabled = false;
      chartTelemetry.ChartAreas.Add(area);

      Legend legend = new Legend("legend");
      legend.Docking = Docking.Top;
      chartTelemetry.Legends.Add(legend);

      seriesRssi = MakeSeries("RSSI", area, AxisType.Primary, Color.RoyalBlue);
      seriesTtx = MakeSeries("Ttx", area, AxisType.Primary, Color.OrangeRed);
      seriesTrx = MakeSeries("Trx", area, AxisType.Primary, Color.SeaGreen);
      seriesBer = MakeSeries("BER", area, AxisType.Secondary, Color.MediumOrchid);
      chartTelemetry.Series.Add(seriesRssi);
      chartTelemetry.Series.Add(seriesTtx);
      chartTelemetry.Series.Add(seriesTrx);
      chartTelemetry.Series.Add(seriesBer);

      layout.Controls.Add(controls, 0, 0);
      layout.Controls.Add(chartTelemetry, 0, 1);
      tabPageChart.Controls.Add(layout);

      tabControl.TabPages.Add(tabPageChart);
      ResetChart();
    }

    private CheckBox MakeSeriesCheckBox(string text, bool isChecked)
    {
      CheckBox cb = new CheckBox();
      cb.Text = text;
      cb.Checked = isChecked;
      cb.AutoSize = true;
      cb.Margin = new Padding(8, 6, 3, 3);
      cb.CheckedChanged += seriesVisibility_CheckedChanged;
      return cb;
    }

    private Label MakeStatLabel()
    {
      Label l = new Label();
      l.AutoSize = true;
      l.Margin = new Padding(10, 7, 3, 3);
      l.Text = "";
      return l;
    }

    private Series MakeSeries(string name, ChartArea area, AxisType yAxis, Color color)
    {
      Series s = new Series(name);
      s.ChartArea = area.Name;
      s.Legend = "legend";
      s.ChartType = SeriesChartType.FastLine;
      s.YAxisType = yAxis;
      s.Color = color;
      s.BorderWidth = 2;
      s.XValueType = ChartValueType.Double;
      return s;
    }

    private void PushTelemetry(Int16 rssi, decimal ber, Int16 Ttx, Int16 Trx, int rfstat)
    {
      if (chartTelemetry == null || chartPaused) return;

      DateTime now = DateTime.Now;
      if (chartSamples.Count == 0)
        chartStart = now;

      double x = (now - chartStart).TotalSeconds;
      TelemetrySample sample = new TelemetrySample
      {
        Time = now,
        Rssi = rssi,
        Ber = (double)ber,
        Ttx = Ttx,
        Trx = Trx,
        RfStat = rfstat
      };
      chartSamples.Add(sample);

      seriesRssi.Points.AddXY(x, sample.Rssi);
      seriesTtx.Points.AddXY(x, sample.Ttx);
      seriesTrx.Points.AddXY(x, sample.Trx);
      seriesBer.Points.AddXY(x, sample.Ber);

      TrimChart(x);
      RescaleAxisX(x);
      UpdateChartStats();
    }

    private void TrimChart(double latestX)
    {
      double minX = latestX - chartWindowSec;
      int removed = 0;
      while (chartSamples.Count > 0 && (chartSamples[0].Time - chartStart).TotalSeconds < minX)
      {
        chartSamples.RemoveAt(0);
        removed++;
      }
      if (removed > 0)
      {
        TrimSeries(seriesRssi, removed);
        TrimSeries(seriesTtx, removed);
        TrimSeries(seriesTrx, removed);
        TrimSeries(seriesBer, removed);
      }
    }

    private void TrimSeries(Series s, int count)
    {
      int n = Math.Min(count, s.Points.Count);
      for (int i = 0; i < n; i++)
        s.Points.RemoveAt(0);
    }

    private void RescaleAxisX(double latestX)
    {
      ChartArea area = chartTelemetry.ChartAreas[0];
      if (latestX <= chartWindowSec)
      {
        area.AxisX.Minimum = 0;
        area.AxisX.Maximum = chartWindowSec;
      }
      else
      {
        area.AxisX.Minimum = Math.Floor(latestX - chartWindowSec);
        area.AxisX.Maximum = Math.Ceiling(latestX);
      }
    }

    private void UpdateChartStats()
    {
      if (labelStatRssi == null) return;
      if (chartSamples.Count == 0)
      {
        labelStatRssi.Text = "RSSI: нет данных";
        labelStatBer.Text = "";
        labelStatTemp.Text = "";
        return;
      }

      double rMin, rMax, rAvg, rStd, rCur;
      double bMin, bMax, bAvg, bStd, bCur;
      ComputeStats(s => s.Rssi, out rCur, out rMin, out rMax, out rAvg, out rStd);
      ComputeStats(s => s.Ber, out bCur, out bMin, out bMax, out bAvg, out bStd);

      TelemetrySample last = chartSamples[chartSamples.Count - 1];

      labelStatRssi.Text = string.Format(CultureInfo.InvariantCulture,
        "RSSI, дБ: тек {0:0} / мин {1:0} / макс {2:0} / сред {3:0.0} / σ {4:0.0}",
        rCur, rMin, rMax, rAvg, rStd);
      labelStatBer.Text = string.Format(CultureInfo.InvariantCulture,
        "BER, %: тек {0:0.0} / макс {1:0.0} / сред {2:0.0}",
        bCur, bMax, bAvg);
      labelStatTemp.Text = string.Format(CultureInfo.InvariantCulture,
        "Темп, °C: Ttx {0:0} / Trx {1:0}",
        last.Ttx, last.Trx);
    }

    private void ComputeStats(Func<TelemetrySample, double> selector,
      out double cur, out double min, out double max, out double avg, out double std)
    {
      cur = min = max = avg = std = 0;
      int n = chartSamples.Count;
      if (n == 0) return;

      double sum = 0;
      min = double.MaxValue;
      max = double.MinValue;
      for (int i = 0; i < n; i++)
      {
        double v = selector(chartSamples[i]);
        sum += v;
        if (v < min) min = v;
        if (v > max) max = v;
      }
      avg = sum / n;
      cur = selector(chartSamples[n - 1]);

      double sqSum = 0;
      for (int i = 0; i < n; i++)
      {
        double d = selector(chartSamples[i]) - avg;
        sqSum += d * d;
      }
      std = Math.Sqrt(sqSum / n);
    }

    private void ResetChart()
    {
      chartSamples.Clear();
      if (seriesRssi != null) seriesRssi.Points.Clear();
      if (seriesTtx != null) seriesTtx.Points.Clear();
      if (seriesTrx != null) seriesTrx.Points.Clear();
      if (seriesBer != null) seriesBer.Points.Clear();
      chartStart = DateTime.Now;
      if (chartTelemetry != null)
        RescaleAxisX(0);
      UpdateChartStats();
    }

    private void comboBoxChartWindow_SelectedIndexChanged(object sender, EventArgs e)
    {
      switch (comboBoxChartWindow.SelectedIndex)
      {
        case 0: chartWindowSec = 30; break;
        case 1: chartWindowSec = 60; break;
        case 2: chartWindowSec = 120; break;
        case 3: chartWindowSec = 300; break;
        default: chartWindowSec = 60; break;
      }
      double latestX = chartSamples.Count > 0
        ? (chartSamples[chartSamples.Count - 1].Time - chartStart).TotalSeconds
        : 0;
      TrimChart(latestX);
      RescaleAxisX(latestX);
      UpdateChartStats();
    }

    private void buttonChartPause_Click(object sender, EventArgs e)
    {
      chartPaused = !chartPaused;
      buttonChartPause.Text = chartPaused ? "Продолжить" : "Пауза";
    }

    private void buttonChartClear_Click(object sender, EventArgs e)
    {
      ResetChart();
    }

    private void seriesVisibility_CheckedChanged(object sender, EventArgs e)
    {
      if (seriesRssi != null) seriesRssi.Enabled = checkBoxShowRssi.Checked;
      if (seriesBer != null) seriesBer.Enabled = checkBoxShowBer.Checked;
      if (seriesTtx != null) seriesTtx.Enabled = checkBoxShowTtx.Checked;
      if (seriesTrx != null) seriesTrx.Enabled = checkBoxShowTrx.Checked;
    }
  }
}
