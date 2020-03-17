using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AD_Sensor_SM9001A
{
    public partial class UCHome : UserControl
    {
        private int startPosition;
        private int endPosition;
        private void Init()
        {
            chart1.Series.Clear();
            //chart1.ChartAreas[0].AxisX.Interval = 400;
            chart1.ChartAreas[0].AxisX.Maximum = endPosition;
            chart1.ChartAreas[0].AxisX.Minimum = startPosition;

            chart1.ChartAreas[0].AxisY.Interval = 10;
            chart1.ChartAreas[0].AxisY.Maximum = 160;
            chart1.ChartAreas[0].AxisY.Minimum = -20;

            //chart1.ChartAreas[0].AxisX.TitleForeColor = Color.SteelBlue;
            //chart1.ChartAreas[0].AxisY.TitleForeColor = Color.SteelBlue;


            series_NowTemp.Color = Color.Yellow;
            series_NowTemp.BorderWidth = 2;
            //series_NowTemp.ChartType = SeriesChartType.Spline;
            series_NowTemp.ChartType = SeriesChartType.Line;
        }

        Series series_NowTemp = new Series("实时温度");
        public UCHome(int startPosition, int endPosition)
        {
            this.startPosition = startPosition;
            this.endPosition = endPosition;
            InitializeComponent();
            Init();
            chart1.Series.Add(series_NowTemp);
            timer1.Start();
            DrawLine();
        }

        private void timer1_Tick(object sender, EventArgs e)//产生随机数
        {
            DrawLine();
        }

        private void DrawLine()
        {
            try
            {
                //series_NowTemp.Points.AddXY(i, nowTemp[i]);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        Point tempPoint = new Point();
        ToolTip toolTip = new ToolTip();
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);
            if (tempPoint != point)
            {
                var result = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(point, true);
                    chart1.ChartAreas[0].CursorY.SetCursorPixelPosition(point, true);
                    int i = result.PointIndex;
                    DataPoint dataPoint = result.Series.Points[i];
                    toolTip.AutoPopDelay = 5000;
                    toolTip.SetToolTip(chart1, "温度" + dataPoint.YValues[0].ToString() + "℃\r\n" + "距离" + i * 100 + "米");
                }
            }
        }
    }
}
