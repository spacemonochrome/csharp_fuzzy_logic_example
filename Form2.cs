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
    public partial class Form2 : Form
    {
        public string isim;
        public bool dogru;
        public Form2(bool dogruluk)
        {
            InitializeComponent();
            dogru = dogruluk;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isim = textBox1.Text;
            if (isim != "") { dogru = true; this.Close(); }
            else { MessageBox.Show("Lütfen bir uygun bir girin"); }
        }
    }
}
