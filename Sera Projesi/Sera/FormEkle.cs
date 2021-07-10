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
    public partial class FormEkle : Form
    {
        public FormEkle()
        {
            InitializeComponent();
        }
        OleDbConnection Baglanti = new OleDbConnection();
        OleDbCommand Ekle = new OleDbCommand();
        DataSet ds = new DataSet();


        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void dosyaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAna frmana = new FormAna();
            frmana.Show();
            this.Hide();
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text=="")
            {
                MessageBox.Show("Sera adı boş geçilemez","Uyarı");
            }
            else
            {

            

            Baglanti.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Sera.accdb";
            Baglanti.Open();
            try
            {
                Ekle = Baglanti.CreateCommand();
                Ekle.CommandText = "INSERT into seratablo ([Sera_ad],[Sebze],[Gece_sicaklik],[Gündüz_sicaklik],[cim_sicaklik],[Nem],[dikim_olcusu],[isiklanma],[usume_donma],[dikim_mesafesi],[ekim_tarihi],[bitis_tarihi]) VALUES ('" + textBox4.Text + "','" + textBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + textBox6.Text + "','" + textBox3.Text + "','" + comboBox5.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "')";

                if (Ekle.ExecuteNonQuery()==1)
                {
                    MessageBox.Show("Ekleme İşlemi Başarılı", "Eklendi");
                    #region
                    textBox4.Text = "";
                    textBox1.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    comboBox4.Text = "";
                    textBox6.Text = "";
                    textBox3.Text = "";
                    comboBox5.Text = "";
                    comboBox1.Text = "";
                    textBox2.Text = "";
                    textBox4.Focus();
                    #endregion
                    #region
                    ds.Clear();
                    string Goster = "Select * from seratablo";
                    OleDbDataAdapter Adaptor = new OleDbDataAdapter(Goster, Baglanti);
                    Adaptor.Fill(ds, "seratablo");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "seratablo";

                    //Stun isimlerini yeniden adlandırma
                    dataGridView1.Columns["Sera_ad"].HeaderText = "Sera Adı";
                    #endregion

      

                }
                

            }
            catch (Exception hata)
            {
                MessageBox.Show("Eklemek istediğiniz kayıt zaten var","Hata");
                //MessageBox.Show("Hata : " + hata.ToString());
            }

            Baglanti.Close();
            }


            
            
        }

        private void FormEkle_Load(object sender, EventArgs e)
        {
            btnListele_Click(sender, e);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            ds.Clear();
            Baglanti.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Sera.accdb";
            Baglanti.Open();

            string Goster = "Select * from seratablo";
            OleDbDataAdapter Adaptor = new OleDbDataAdapter(Goster,Baglanti);
            Adaptor.Fill(ds, "seratablo");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "seratablo";

            //Stun isimlerini yeniden adlandırma
            dataGridView1.Columns["Sera_ad"].HeaderText = "Sera Adı";




            Baglanti.Close();
            ds.Dispose();
            Adaptor.Dispose();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            textBox6.Text = "";
            textBox3.Text = "";
            comboBox5.Text = "";
            comboBox1.Text = "";
            textBox2.Text = "";
            textBox4.Focus();
        }

       

      
    }
}
