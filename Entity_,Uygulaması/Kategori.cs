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
    public partial class Kategori : Form
    {
        public Kategori()
        {
            InitializeComponent();
        }
        Satış_TakipEntities db = new Satış_TakipEntities();

        public void Listele()
        {
            dataGridView1.DataSource = (from x in db.tbl_kategori
                                        select new
                                        {
                                            x.KategoriID,
                                            x.KategoriAd

                                        }).ToList();
        }

        private void Kategori_Load(object sender, EventArgs e)
        {

            Listele();

            //comboBox1.ValueMember = "KategoriID";
            //comboBox1.DisplayMember = "KategoriAd";
            //comboBox1.DataSource = ürün;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbl_kategori ekle = new tbl_kategori();
            ekle.KategoriAd = textBox2.Text;
            db.tbl_kategori.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("Kategori eklenmiştir.");
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var bul = db.tbl_kategori.Find(id);
            db.tbl_kategori.Remove(bul);
            db.SaveChanges();
            MessageBox.Show("Kategori silinmiştir.");
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var bul = db.tbl_kategori.Find(id);
            bul.KategoriAd = textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori güncellenmiştir.");
            Listele();
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
