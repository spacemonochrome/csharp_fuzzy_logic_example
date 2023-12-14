using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _213302070_Hasan_Firat_Keskin_Yapay_Zeka_Vize_Odevi
{
    public partial class Form4 : Form
    {
        public double[,] Ca_aralik1 = new double[0, 0];
        public double[,] Ca_aralik2 = new double[0, 0];
        public Form4(double[,] Ca_aralik11, double[,] Ca_aralik22, string harf, string birim, string[] uyelik_f, bool[,] Ca_aralikd)
        {
            InitializeComponent();
            label1.Text = harf + "+" + birim;
            Ca_aralik1 = Ca_aralik11;
            Ca_aralik2 = Ca_aralik22;
            chart1.Series.Clear();
            for (int i = 0; i < uyelik_f.Length; i++)
            {
                chart1.Series.Add(uyelik_f[i]);
                chart1.Series[uyelik_f[i]].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.Series[uyelik_f[i]].BorderWidth = 5;
                chart1.Series[uyelik_f[i]].MarkerColor = Color.FromArgb(150, 150, 150);

                //chart1.Series[uyelik_f[i]].Points.AddXY(alt_aralik, Ca_aralik2[i, 0]);
                for (int r = 0; r < Ca_aralik1.GetLength(1); r++)
                {
                    if (Ca_aralikd[i, r] == true)
                    {
                        chart1.Series[uyelik_f[i]].Points.AddXY(Ca_aralik2[i, r], Ca_aralik1[i, r]);
                    }
                }
                //chart1.Series[uyelik_f[i]].Points.AddXY(ust_aralik, Ca_aralik2[i, son]);
            }
        }
    }
}
