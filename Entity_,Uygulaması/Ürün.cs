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
            var kategori = dataGridView1.DataSource = (from y in db.tbl_kategori
                                                     select new
                                                     {
                                                        y.KategoriID,
                                                        y.KategoriAd
                                                     }).ToList();

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
            comboBox1.DataSource = kategori;
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
            urun.UrunFiyat = decimal.Parse(textBox5.Text);
            urun.UrunStok = int.Parse(textBox4.Text);
            urun.Kategori = Convert.ToInt32(comboBox1.SelectedValue);

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
            bul.UrunFiyat = decimal.Parse(textBox5.Text);
            bul.UrunStok = int.Parse(textBox4.Text);
            bul.Kategori = Convert.ToInt32(comboBox1.SelectedValue);
            db.SaveChanges();
            MessageBox.Show("Ürün güncellenmiştir.");
            Listele();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form form = new Form1();
            form.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
