using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sera
{
    public partial class FormAna : Form
    {
        public FormAna()
        {
            InitializeComponent();
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEkle frmekle = new FormEkle();
            frmekle.Show();
            this.Hide();
            
        }

        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGuncelle frmguncelle = new FormGuncelle();
            frmguncelle.Show();
            this.Hide();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult exit;
            exit = MessageBox.Show("Çıkış yapmak istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo);
            if (exit==DialogResult.Yes)
            {
                MessageBox.Show("İyi günler","HOŞÇAKALIN");
                Close();
            }
            
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSil frmsil = new FormSil();
            frmsil.Show();
            this.Hide();
        }

        private void yönetimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formislem frmislem = new Formislem();
            frmislem.Show();
            this.Hide();
        }

        private void iletişimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formiletisim frmiletisim = new Formiletisim();
            frmiletisim.Show();
            this.Hide();
        }

        private void kayıtlarıGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FormAna_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        
    }
}
