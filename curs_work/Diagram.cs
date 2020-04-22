using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace curs_work
{
    public partial class Diagram : Form
    {
        public Diagram(string[] xValues, int[] yValues)
        {
            InitializeComponent();
            chart1.Series.Clear();
            chart1.BackColor = Color.Gray;
            chart1.BackSecondaryColor = Color.WhiteSmoke;
            chart1.BackGradientStyle = GradientStyle.DiagonalRight;

            chart1.BorderlineDashStyle = ChartDashStyle.Solid;
            chart1.BorderlineColor = Color.Gray;
            chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            chart1.ChartAreas[0].BackColor = Color.Wheat;

            chart1.Titles.Add("Діаграма прийнятих транспортних засобів");
            chart1.Titles[0].Font = new Font("Utopia", 16);

            chart1.Series.Add(new Series("ColumnSeries")
            {
                ChartType = SeriesChartType.Pie
            });
            chart1.Series["ColumnSeries"].Points.DataBindXY(xValues, yValues);
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
        }
    }
}
