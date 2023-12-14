using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _213302070_Hasan_Firat_Keskin_Yapay_Zeka_Vize_Odevi
{
    //çıkarılan item silinmeli.
    //bir tane combobox eklenmeli ağırlıklı ve maks ortalamasını bulabilmesi için. bunları hesaplayan kod da yazılmalı
    //sayısal değere göre sıralaması olmalı. karışık sıra girilse bile kendisi düzenleyebilmeli
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public double[,] Ca_aralik1 = new double[0,0];
        public double[,] Ca_aralik2 = new double[0,0];
        public bool[,] Ca_aralikd = new bool[0, 0];

        public double[,] Ru_aralik1 = new double[0, 0];
        public double[,] Ru_aralik2 = new double[0, 0];
        public bool[,] Ru_aralikd = new bool[0, 0];

        public double[,] Ha_aralik1 = new double[0, 0];
        public double[,] Ha_aralik2 = new double[0, 0];
        public bool[,] Ha_aralikd = new bool[0, 0];

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 frm2 = new Form2(false);
                frm2.ShowDialog();
                if(frm2.isim != "" && frm2.dogru == true)
                {
                    listBox1.Items.Add(frm2.isim);
                    Ca_aralik1 = ResizeArray(Ca_aralik1, Ca_aralik1.GetLength(0) + 1, Ca_aralik1.GetLength(1));
                    Ca_aralik2 = ResizeArray(Ca_aralik2, Ca_aralik2.GetLength(0) + 1, Ca_aralik2.GetLength(1));
                    Ca_aralikd = ResizeArray(Ca_aralikd, Ca_aralikd.GetLength(0) + 1, Ca_aralikd.GetLength(1));
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Ca_aralik1.GetLength(1); i++)
            {
                Ca_aralik1[listBox1.SelectedIndex, i] = Ca_aralik1[listBox1.SelectedIndex + 1, i];
                Ca_aralik2[listBox1.SelectedIndex, i] = Ca_aralik2[listBox1.SelectedIndex + 1, i];
                Ca_aralikd[listBox1.SelectedIndex, i] = Ca_aralikd[listBox1.SelectedIndex + 1, i];

                Ca_aralik1[listBox1.SelectedIndex + 1, i] = 0;
                Ca_aralik2[listBox1.SelectedIndex + 1, i] = 0;
                Ca_aralikd[listBox1.SelectedIndex + 1, i] = false;
            }
            listBox1.Items.Remove(listBox1.SelectedItem);            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 frm2 = new Form2(false);
                frm2.ShowDialog();
                if (frm2.isim != "" && frm2.dogru == true)
                {
                    listBox2.Items.Add(frm2.isim);
                    Ru_aralik1 = ResizeArray(Ru_aralik1, Ru_aralik1.GetLength(0) + 1, Ru_aralik1.GetLength(1));
                    Ru_aralik2 = ResizeArray(Ru_aralik2, Ru_aralik2.GetLength(0) + 1, Ru_aralik2.GetLength(1));
                    Ru_aralikd = ResizeArray(Ru_aralikd, Ru_aralikd.GetLength(0) + 1, Ru_aralikd.GetLength(1));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(listBox1.SelectedItem.ToString(), "V", "ppm", false, Ca_aralik1, Ca_aralik2, listBox1.SelectedIndex, Ca_aralikd);
            frm3.ShowDialog();
            if (frm3.dogru == true)
            {
                if (frm3.araliklar1.Length > Ca_aralik1.GetLength(1))
                {
                    Ca_aralik1 = ResizeArray(Ca_aralik1, listBox1.Items.Count, frm3.araliklar1.Length);
                    Ca_aralik2 = ResizeArray(Ca_aralik2, listBox1.Items.Count, frm3.araliklar2.Length);
                    Ca_aralikd = ResizeArray(Ca_aralikd, listBox1.Items.Count, frm3.araliklard.Length);
                }
                else
                {
                    Ca_aralik1 = ResizeArray(Ca_aralik1, listBox1.Items.Count, Ca_aralik1.GetLength(1));
                    Ca_aralik2 = ResizeArray(Ca_aralik2, listBox1.Items.Count, Ca_aralik1.GetLength(1));
                    Ca_aralikd = ResizeArray(Ca_aralikd, listBox1.Items.Count, Ca_aralik1.GetLength(1));
                }

                for (int i = 0; i < Ca_aralik1.GetLength(1); i++)
                {
                    Ca_aralik1[listBox1.SelectedIndex, i] = 0;
                    Ca_aralik2[listBox1.SelectedIndex, i] = 0;
                    Ca_aralikd[listBox1.SelectedIndex, i] = false;
                }
                
                for (int i = 0; i < frm3.araliklar1.Length; i++)
                {
                    Ca_aralik1[listBox1.SelectedIndex, i] = frm3.araliklar1[i];
                }
                for (int i = 0; i < frm3.araliklar2.Length; i++)
                {
                    Ca_aralik2[listBox1.SelectedIndex, i] = frm3.araliklar2[i];
                }
                for (int i = 0; i < frm3.araliklard.Length; i++)
                {
                    Ca_aralikd[listBox1.SelectedIndex, i] = frm3.araliklard[i];
                }
            }
        }

        T[,] ResizeArray<T>(T[,] original, int rows, int cols)
        {
            var newArray = new T[rows, cols];
            int minRows = Math.Min(rows, original.GetLength(0));
            int minCols = Math.Min(cols, original.GetLength(1));
            for (int i = 0; i < minRows; i++)
                for (int j = 0; j < minCols; j++)
                    newArray[i, j] = original[i, j];
            return newArray;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(listBox2.SelectedItem.ToString(), "R", "(m/s)", false, Ru_aralik1, Ru_aralik2, listBox2.SelectedIndex, Ru_aralikd);
            frm3.ShowDialog();
            if (frm3.dogru == true)
            {
                if (frm3.araliklar1.Length > Ru_aralik1.GetLength(1))
                {
                    Ru_aralik1 = ResizeArray(Ru_aralik1, listBox2.Items.Count, frm3.araliklar1.Length);
                    Ru_aralik2 = ResizeArray(Ru_aralik2, listBox2.Items.Count, frm3.araliklar2.Length);
                    Ru_aralikd = ResizeArray(Ru_aralikd, listBox2.Items.Count, frm3.araliklard.Length);
                }
                else
                {
                    Ru_aralik1 = ResizeArray(Ru_aralik1, listBox2.Items.Count, Ru_aralik1.GetLength(1));
                    Ru_aralik2 = ResizeArray(Ru_aralik2, listBox2.Items.Count, Ru_aralik1.GetLength(1));
                    Ru_aralikd = ResizeArray(Ru_aralikd, listBox2.Items.Count, Ru_aralik1.GetLength(1));
                }

                for (int i = 0; i < Ru_aralik1.GetLength(1); i++)
                {
                    Ru_aralik1[listBox2.SelectedIndex, i] = 0;
                    Ru_aralik2[listBox2.SelectedIndex, i] = 0;
                    Ru_aralikd[listBox2.SelectedIndex, i] = false;
                }

                for (int i = 0; i < frm3.araliklar1.Length; i++)
                {
                    Ru_aralik1[listBox2.SelectedIndex, i] = frm3.araliklar1[i];
                }
                for (int i = 0; i < frm3.araliklar2.Length; i++)
                {
                    Ru_aralik2[listBox2.SelectedIndex, i] = frm3.araliklar2[i];
                }
                for (int i = 0; i < frm3.araliklard.Length; i++)
                {
                    Ru_aralikd[listBox2.SelectedIndex, i] = frm3.araliklard[i];
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string[] uyelik_fonk_isimleri = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                uyelik_fonk_isimleri[i] = listBox1.Items[i].ToString();
            }
            Form4 frm4 = new Form4(Ca_aralik1, Ca_aralik2, "V", "ppm", uyelik_fonk_isimleri, Ca_aralikd);
            frm4.ShowDialog();
        }

        public void uyartim_fonk1()
        {
            try
            {
                if (listBox1.SelectedIndex == -1)
                {
                    button5.Enabled = false;
                    button2.Enabled = false;
                }
                else
                {
                    button2.Enabled = true;
                    button5.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("lütfen uygun değer girin");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            uyartim_fonk1();
            uyartim_mamdani();
        }

        public void uyartim_mamdani()
        {
            if (listBox2.SelectedIndex != -1 && listBox1.SelectedIndex != -1 && listBox3.SelectedIndex != -1)
            {
                button13.Enabled = true;
            }
            else
            {
                button13.Enabled = false;
            }
        }

        public void uyartim_fonk2()
        {
            try
            {
                if (listBox2.SelectedIndex == -1)
                {
                    button6.Enabled = false;
                    button3.Enabled = false;
                }
                else
                {
                    button6.Enabled = true;
                    button3.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("lütfen uygun değer girin");
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            uyartim_fonk2();
            uyartim_mamdani();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string[] uyelik_fonk_isimleri = new string[listBox2.Items.Count];
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                uyelik_fonk_isimleri[i] = listBox2.Items[i].ToString();
            }
            Form4 frm4 = new Form4(Ru_aralik1, Ru_aralik2, "R", "(m/s)", uyelik_fonk_isimleri, Ru_aralikd);
            frm4.ShowDialog();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1 && listBox1.SelectedIndex != -1 && listBox3.SelectedIndex != -1)
            {
                listBox4.Items.Add("Eğer Karbon Miktarı " + listBox1.SelectedItem + " VE Rüzgar Hızı " + listBox2.SelectedItem + " ise o halde Havalandırma Çıkış Değeri " + listBox3.SelectedItem);
            }
            else
            {
                MessageBox.Show("Lütfen 2 giriş ve bir çıkış fonksiyonu seçin.");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            listBox4.Items.Remove(listBox4.SelectedItem);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox3.Items.Remove(listBox3.SelectedItem);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 frm2 = new Form2(false);
                frm2.ShowDialog();
                if (frm2.isim != "" && frm2.dogru == true)
                {
                    listBox3.Items.Add(frm2.isim);
                    Ha_aralik1 = ResizeArray(Ha_aralik1, Ha_aralik1.GetLength(0) + 1, Ha_aralik1.GetLength(1));
                    Ha_aralik2 = ResizeArray(Ha_aralik2, Ha_aralik2.GetLength(0) + 1, Ha_aralik2.GetLength(1));
                    Ha_aralikd = ResizeArray(Ha_aralikd, Ha_aralikd.GetLength(0) + 1, Ha_aralikd.GetLength(1));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void uyartim_fonk3()
        {
            try
            {
                if (listBox3.SelectedIndex == -1)
                {
                    button10.Enabled = false;
                    button11.Enabled = false;
                }
                else
                {
                    button10.Enabled = true;
                    button11.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("lütfen uygun değer girin");
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            uyartim_fonk3();
            uyartim_mamdani();
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox4.SelectedIndex == -1)
            {
                button14.Enabled = false;
            }
            else
            {
                button14.Enabled = true;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }
    }
}
