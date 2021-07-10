using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Sera
{
    public partial class Formiletisim : Form
    {  
        public Formiletisim()
        {
            InitializeComponent();
        }

        OleDbConnection Baglanti = new OleDbConnection();
        OleDbCommand Ekle = new OleDbCommand();
        DataSet ds = new DataSet();

        private void button2_Click(object sender, EventArgs e)
        {
            FormAna frmana = new FormAna();
            frmana.Show();
            this.Hide();
        }

        private void Formiletisim_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == ""||comboBox1.Text=="")
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz , hiç bir alan boş geçilemez", "Uyarı");
                textBox1.Focus();
            }
            else
            {

           
            Baglanti.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Sera.accdb";
            Baglanti.Open();
            try
            {
                Ekle = Baglanti.CreateCommand();
                Ekle.CommandText = "INSERT into iletisim ([Ad],[Soyad],[Konu],[Mesaj],[Mail]) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + comboBox1.Text + "')";

                if (Ekle.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Mesajınız gönderildi", "İletildi");
                    #region
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    comboBox1.Text = "";
                    textBox1.Focus();
                    #endregion

                }


            }
            catch (Exception hata)
            {

                MessageBox.Show("Hata : " + hata.ToString());
            }

            Baglanti.Close();


            }
            
        }
    }
}
