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
    public partial class FormSil : Form
    {
        public FormSil()
        {
            InitializeComponent();
        }

        OleDbConnection Baglanti = new OleDbConnection();
        OleDbCommand Sil = new OleDbCommand();
        DataSet ds = new DataSet();
        

        private void button3_Click(object sender, EventArgs e)
        {
            FormAna frmana = new FormAna();
            frmana.Show();
            this.Hide();

        }

        private void FormSil_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            button2_Click(sender, e);



            //string sorgu, bağlantı;
            //bağlantı = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Sera.accdb";
            //sorgu = "Select * From seratablo";
            //OleDbConnection bağlan = new OleDbConnection(bağlantı);
            //OleDbDataAdapter getir = new OleDbDataAdapter(sorgu, bağlan);
            //bağlan.Open();
            //DataSet göster = new DataSet();
            //getir.Fill(göster, "seratablo");
            //dataGridView1.DataSource = göster.Tables["seratablo"];
            //getir.Dispose();
            //bağlan.Close();
        }
        
   


        private void button1_Click(object sender, EventArgs e)
        {


            if (textBox1.Text=="")
            {
                MessageBox.Show("Lütfen silmek istediğiniz serayı seçiniz","Uyarı");
            }
            else
            {

            
                DialogResult soru;
            soru = MessageBox.Show("Sera silinsin mi?", "SİL", MessageBoxButtons.YesNo);
            if (soru == DialogResult.Yes)
            {
            Baglanti.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Sera.accdb";
            Baglanti.Open();

            Sil = Baglanti.CreateCommand();
            Sil.CommandText = "delete from seratablo where [Sera_ad]='" +textBox1.Text + "'";
            
            if (Sil.ExecuteNonQuery()==1)
            {
                MessageBox.Show("Kayıt Silindi","Silindi");
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
                
                textBox1.Text = "";
                textBox1.Focus();
               
                
                
                
            }
            else
            {
                MessageBox.Show("Böyle bir sera mevcut değil","Uyarı");
            }

            Baglanti.Close();
            }
            }


            //    DialogResult sor;
            //sor = MessageBox.Show("KAYIT SİLİNSİN Mİ?", "SİL", MessageBoxButtons.YesNo);
            //if (sor == DialogResult.Yes)
            //{
            //    string sorgu, bağlantı;
            //    bağlantı = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Sera.accdb";
            //    sorgu = "Delete From seratablo Where [Sera_id]='" + textBox1.Text + "'";
            //    OleDbConnection bağlan = new OleDbConnection(bağlantı);
            //    OleDbCommand yeni = new OleDbCommand(sorgu, bağlan);
            //    bağlan.Open();
            //    yeni.ExecuteNonQuery();
            //    MessageBox.Show("Kayıt Silindi!!!");

            //    bağlan.Close();
                   


                
            //}
        }

       
        
        private void button2_Click(object sender, EventArgs e)
        {
            ds.Clear();
            Baglanti.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Sera.accdb";
            Baglanti.Open();

            string Goster = "Select * from seratablo";
            OleDbDataAdapter Adaptor = new OleDbDataAdapter(Goster, Baglanti);
            Adaptor.Fill(ds, "seratablo");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "seratablo";

           
            dataGridView1.Columns["Sera_ad"].HeaderText = "Sera Adı";




            Baglanti.Close();
            ds.Dispose();
            Adaptor.Dispose();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Selectedvalue = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[Selectedvalue].Cells["Sera_ad"].Value.ToString();
        }
    }
}
