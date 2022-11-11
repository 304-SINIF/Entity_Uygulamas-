using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity__Uygulaması
{
    public partial class Bilgi : Form
    {
        public Bilgi()
        {
            InitializeComponent();
        }
        Satış_TakipEntities db = new Satış_TakipEntities();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Bilgi_Load(object sender, EventArgs e)
        {
            label2.Text = db.tbl_kategori.Count().ToString();
            label3.Text = db.tbl_urun.Count().ToString();
            label5.Text = db.tbl_urun.Sum(y => y.UrunStok).ToString();
            label7.Text = db.tbl_urun.Max(z => z.UrunFiyat).ToString();
            label9.Text = db.tbl_urun.Min(x => x.UrunFiyat).ToString();
            label11.Text = db.tbl_urun.Count(t => t.Kategori == 4).ToString();
            label13.Text = (from z in db.tbl_musteri select z.Sehir).Distinct().Count().ToString();
            label15.Text = db.tbl_satis.Sum(t => t.SatisFiyat).ToString();
            label17.Text = db.Urungetir().FirstOrDefault();
            label19.Text = db.tbl_urun.Count(z => z.Urunad == "Ütü").ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new Form1();
            form.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
