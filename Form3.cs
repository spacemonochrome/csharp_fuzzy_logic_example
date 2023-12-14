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

namespace _213302070_Hasan_Firat_Keskin_Yapay_Zeka_Vize_Odevi
{
    public partial class Form3 : Form
    {
        public bool dogru;
        public double[] araliklar1 = new double[0];
        public double[] araliklar2 = new double[0];
        public bool[] araliklard = new bool[0];

        public Form3(string isime, string harf, string birim, bool dogruluk, double[,] Ca_aralik1, double[,] Ca_aralik2, int indexnumarasi, bool[,] Ca_aralikd)
        {
            InitializeComponent();
            dogru = dogruluk;
            label2.Text = isime;
            label5.Text = birim;
            for (int i = 0; i < Ca_aralik1.GetLength(1); i++)
            {
                if (Ca_aralikd[indexnumarasi, i] == true)
                {
                    listBox2.Items.Add(Ca_aralik1[indexnumarasi, i]);
                    listBox1.Items.Add(Ca_aralik2[indexnumarasi, i]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 frm2 = new Form2(false);
                frm2.ShowDialog();
                if (frm2.isim != "" && frm2.dogru == true)
                {
                    listBox2.Items.Add(frm2.isim);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 frm2 = new Form2(false);
                frm2.ShowDialog();
                if (frm2.isim != "" && frm2.dogru == true)
                {
                    listBox1.Items.Add(frm2.isim);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count == listBox1.Items.Count)
            {
                Array.Resize(ref araliklar1, listBox1.Items.Count);
                Array.Resize(ref araliklar2, listBox1.Items.Count);
                Array.Resize(ref araliklard, listBox1.Items.Count);

                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    araliklar1[i] = (Convert.ToDouble(listBox2.Items[i]));
                }
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    araliklar2[i] = (Convert.ToDouble(listBox1.Items[i]));
                }
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    araliklard[i] = true;
                }

                dogru = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Eşit sayıda küme yok. lütfen her iki tarafa da eşit sayıda küme girin.");
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == -1)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                button4.Enabled = false;
            }
            else
            {
                button4.Enabled = true;
            }
        }
    }
}
