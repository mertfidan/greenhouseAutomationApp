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
    public partial class FormGuncelle : Form
    {
        public FormGuncelle()
        {
            InitializeComponent();
        }

        OleDbConnection Baglanti = new OleDbConnection();
        OleDbCommand Guncelle = new OleDbCommand();
        DataSet ds = new DataSet();

        private void button2_Click(object sender, EventArgs e)
        {
            FormAna frmana = new FormAna();
            frmana.Show();
            this.Hide();
        }

        private void FormGuncelle_Load(object sender, EventArgs e)
        {
            btnListele_Click(sender, e);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text=="")
            {
                MessageBox.Show("Lütfen bir sera seçiniz","Uyarı");
            }
            else
            {

            Baglanti.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Sera.accdb";
            Baglanti.Open();

            try
            {
                Guncelle = Baglanti.CreateCommand();

                Guncelle.CommandText = "UPDATE seratablo SET [Sera_ad]='" + textBox4.Text + "',[Sebze]='" + textBox1.Text + "',[Gece_sicaklik]='" + comboBox2.Text + "',[Gündüz_sicaklik]='" + comboBox3.Text + "',[cim_sicaklik]='" + comboBox4.Text + "',[Nem]='" + textBox6.Text + "',[dikim_olcusu]='" + textBox3.Text + "',[isiklanma]='" + comboBox5.Text + "',[usume_donma]='" + comboBox1.Text + "',[dikim_mesafesi]='" + textBox2.Text + "',[ekim_tarihi]='" + dateTimePicker1.Text + "',[bitis_tarihi]='" + dateTimePicker2.Text + "' Where [Sera_ad]='" + textBox4.Text + "'";

                if (Guncelle.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Güncelleme İşlemi Başarılı", "Güncellendi");
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
                MessageBox.Show("Güncelleme işlemi başarısız","Hata");
                MessageBox.Show("Hata : "+hata.ToString());
            }
            Baglanti.Close();

            }

            //string bağlantı, sql;
            //bağlantı = "Provider=Microsoft.ACE.OleDb.12.0;Data Source=Sera.accdb";
            //sql = "UPDATE seratablo SET [Sera_ad]='" + textBox4.Text + "',[Sebze]='" + textBox1.Text + "',[Gece_sicaklik]='" + comboBox2.Text + "',[Gündüz_sicaklik]='" + comboBox3.Text + "',[cim_sicaklik]='" + comboBox4.Text + "',[Nem]='" + textBox6.Text + "',[dikim_olcusu]='" + textBox3.Text + "',[isiklanma]='" + comboBox5.Text + "',[usume_donma]='" + comboBox1.Text + "',[dikim_mesafesi]='" + textBox2.Text + "',[ekim_tarihi]='" + dateTimePicker1.Text + "',[bitis_tarihi]='" + dateTimePicker2.Text + "' Where [Sera_ad]='" + double.Parse(textBox4.Text) + "'";
            //OleDbConnection bağlan = new OleDbConnection(bağlantı);
            //bağlan.Open();
            //OleDbCommand kaydet = new OleDbCommand(sql, bağlan);
            //kaydet.ExecuteNonQuery();
            //MessageBox.Show("Güncelleme İşlemi Başarıyla Gerçekleştirilmiştir");
            //bağlan.Close();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

          

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            ds.Clear();
            Baglanti.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Sera.accdb";
            Baglanti.Open();

            string Goster = "Select * from seratablo";
            OleDbDataAdapter Adaptor = new OleDbDataAdapter(Goster, Baglanti);
            Adaptor.Fill(ds, "seratablo");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "seratablo";

            //Stun isimlerini yeniden adlandırma
            dataGridView1.Columns["Sera_ad"].HeaderText = "Sera Adı";




            Baglanti.Close();
            ds.Dispose();
            Adaptor.Dispose();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int Selectedvalue = dataGridView1.CurrentRow.Index;
            textBox4.Text = dataGridView1.Rows[Selectedvalue].Cells["Sera_ad"].Value.ToString();
            textBox1.Text = dataGridView1.Rows[Selectedvalue].Cells["Sebze"].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[Selectedvalue].Cells["Gece_sicaklik"].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[Selectedvalue].Cells["Gündüz_sicaklik"].Value.ToString();
            comboBox4.Text = dataGridView1.Rows[Selectedvalue].Cells["cim_sicaklik"].Value.ToString();
            textBox6.Text = dataGridView1.Rows[Selectedvalue].Cells["Nem"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[Selectedvalue].Cells["dikim_olcusu"].Value.ToString();
            comboBox5.Text = dataGridView1.Rows[Selectedvalue].Cells["isiklanma"].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[Selectedvalue].Cells["usume_donma"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[Selectedvalue].Cells["dikim_mesafesi"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[Selectedvalue].Cells["ekim_tarihi"].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[Selectedvalue].Cells["bitis_tarihi"].Value.ToString();
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
