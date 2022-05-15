using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneRandevuSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tckimlikno = textBox1.Text;
            string adi = textBox2.Text;
            string soyadi=textBox3.Text;
            string klinik=comboBox1.SelectedItem.ToString();
            string tarih=dateTimePicker1.Value.ToShortDateString();
            string saat=comboBox2.SelectedItem.ToString();

            string satir = tckimlikno + "*" + adi + "*" + soyadi + "*" + klinik + "*" + tarih + "*" + saat;
            
            try
            {
                if (Randevu.RandevuVarMi(klinik, tarih, saat) == true)
                    MessageBox.Show("Seçtiğiniz Bölümde seçtiğiniz saat ve tarih dolu");
                
                else
                    Randevu.Ekle(satir);
            }

            catch {
                MessageBox.Show("EKLENEMEDİ");
            }

            //textBox4.Text += satir+Environment.NewLine;

            //Environment.NewLine=Bir alt satıra geçmesi için kullanılan komut satırıdır.(/n ile aynı işlev)
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ricerik = Randevu.tumRandevular();
            textBox4.Text = ricerik;
        }
    }
}
