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
    public partial class Formislem : Form
    {
        public Formislem()
        {
            InitializeComponent();
            timer1.Interval = 100;
            timer2.Interval = 100;
            timer3.Interval = 100;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text=="")
            {
                MessageBox.Show("Lütfen bir sera seçiniz", "Uyarı");
            }
            else
            {

            
            DialogResult soru;
            soru = MessageBox.Show(textBox4.Text+" adlı sera için sulama başlatılsınmı?", "Sulama", MessageBoxButtons.YesNo);
            if (soru == DialogResult.Yes)
            {
                button3.Enabled = true;
                button1.Enabled = false;
                timer1.Enabled = true;



                //timer1.Start();
            }

            }
            
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button3.Enabled = false;
            timer1.Enabled = false;
            MessageBox.Show("Su vanaları kapatıldı","Kapatıldı!");

            //timer1.Stop();
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            int sayi = Convert.ToInt32(textBox1.Text);
            sayi++;
            textBox1.Text = sayi.ToString();


          
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Lütfen bir sera seçiniz", "Uyarı");
            }
            else
            {
                DialogResult soru;
                soru = MessageBox.Show(textBox4.Text + " adlı sera için kaloriferler açılsınmı?", "Isıtma", MessageBoxButtons.YesNo);
                if (soru == DialogResult.Yes)
                {
                    button5.Enabled = true;
                    button4.Enabled = false;



                    timer2.Start();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Lütfen bir sera seçiniz","Uyarı");
            }
            else
            {
                DialogResult soru;
                soru = MessageBox.Show(textBox4.Text + " adlı sera için pencereler açılsınmı?", "Havalandırma", MessageBoxButtons.YesNo);
                if (soru == DialogResult.Yes)
                {
                    button7.Enabled = true;
                    button6.Enabled = false;



                    timer3.Start();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            button5.Enabled = false;



            timer2.Stop();
            MessageBox.Show("Kaloriferler kapatıldı","Kapatıldı!");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button6.Enabled = true;
            button7.Enabled = false;



            timer3.Stop();
            MessageBox.Show("Pencereler kapatıldı", "Kapatıldı!");

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Formislem_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            button3.Enabled = false;
            button5.Enabled = false;
            button7.Enabled = false;



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

        private void timer2_Tick(object sender, EventArgs e)
        {
            int sayi = Convert.ToInt32(textBox2.Text);
            sayi++;
            textBox2.Text = sayi.ToString();

           
            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            int sayi = Convert.ToInt32(textBox3.Text);
            sayi++;
            textBox3.Text = sayi.ToString();

            
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Text = "0";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox3.Text = "0";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Selectedvalue = dataGridView1.CurrentRow.Index;
            textBox4.Text = dataGridView1.Rows[Selectedvalue].Cells["Sera_ad"].Value.ToString();
        }
    }
}
