using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Entity__Uygulaması
{
    public partial class Müşteri : Form
    {
        public Müşteri()
        {
            InitializeComponent();
        }
        Satış_TakipEntities db = new Satış_TakipEntities();

        public void Listele()
        {
            dataGridView1.DataSource = (from x in db.tbl_musteri
                                        select new
                                        {
                                            x.MusteriID,
                                            x.MusteriAdsoyad,
                                            x.Telno,
                                            x.TC,
                                            x.adres,
                                            x.Meslek,
                                            x.Sehir

                                        }).ToList();

        }
        private void Müşteri_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbl_musteri ekle = new tbl_musteri();
            ekle.MusteriAdsoyad = textBox2.Text;
            ekle.Telno = maskedTextBox1.Text;
            ekle.TC = maskedTextBox2.Text;
            ekle.adres = richTextBox1.Text;
            ekle.Meslek = textBox3.Text;
            ekle.Sehir = textBox4.Text;

            db.tbl_musteri.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("Müşteri eklenmiştir.");
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var bul = db.tbl_musteri.Find(id);
            db.tbl_musteri.Remove(bul);
            db.SaveChanges();
            MessageBox.Show("Müşteri silinmiştir.");
            Listele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            maskedTextBox2.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var ekle = db.tbl_musteri.Find(id);
            ekle.MusteriAdsoyad = textBox2.Text;
            ekle.Telno = maskedTextBox1.Text;
            ekle.TC = maskedTextBox2.Text;
            ekle.adres = richTextBox1.Text;
            ekle.Meslek = textBox3.Text;
            ekle.Sehir = textBox4.Text;
            db.SaveChanges();
            MessageBox.Show("Müşteri güncellenmiştir.");
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
