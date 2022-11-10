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
    public partial class Ürün : Form
    {
        public Ürün()
        {
            InitializeComponent();
        }
        Satış_TakipEntities db = new Satış_TakipEntities();

        public void Listele()
        {
            var goster = dataGridView1.DataSource = (from x in db.tbl_urun
                                        select new
                                        {
                                            x.UrunID,
                                            x.Urunad,
                                            x.Marka,
                                            x.UrunFiyat,
                                            x.UrunStok,
                                            x.tbl_kategori.KategoriAd
                                        }).ToList();
            comboBox1.ValueMember = "KategoriID";
            comboBox1.DisplayMember = "KategoriAd";
            comboBox1.DataSource = goster;
            dataGridView1.DataSource = goster;
        }
        private void Ürün_Load(object sender, EventArgs e)
        {
            Listele();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            tbl_urun urun = new tbl_urun();
            urun.Urunad = textBox2.Text;
            urun.Marka = textBox6.Text;
            urun.UrunFiyat = int.Parse(textBox5.Text);
            urun.UrunStok = int.Parse(textBox4.Text);
            urun.Kategori = comboBox1.SelectedIndex+1;

            db.tbl_urun.Add(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün eklenmiştir.");
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var bul = db.tbl_urun.Find(id);
            db.tbl_urun.Remove(bul);
            db.SaveChanges();
            MessageBox.Show("Ürün silinmiştir.");
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var bul = db.tbl_urun.Find(id);
            bul.Urunad = textBox2.Text;
            bul.Marka = textBox6.Text;
            bul.UrunFiyat = int.Parse(textBox5.Text);
            bul.UrunStok = int.Parse(textBox4.Text);
            bul.Kategori = int.Parse(comboBox1.Text);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
