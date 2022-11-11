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
    public partial class Satış : Form
    {
        public Satış()
        {
            InitializeComponent();
        }
        Satış_TakipEntities db = new Satış_TakipEntities();

        
        public void Listele()
        {
            

            var urun = (from x in db.tbl_urun
                                        select new
                                        {
                                           x.UrunID,
                                           x.Urunad,
                                          
                                        }).ToList();


            var must = (from y in db.tbl_musteri
                                        select new
                                       {
                                           y.MusteriID,
                                           y.MusteriAdsoyad

                                        }).ToList();

            dataGridView1.DataSource = (from z in db.tbl_satis
                                        select new
                                        {
                                            z.SatisID,
                                            z.SatisFiyat,
                                            z.SatisAdet,
                                            z.SatisTarih,
                                            z.tbl_urun.Urunad,
                                            z.tbl_musteri.MusteriAdsoyad

                                        }).ToList();

            comboBox1.ValueMember = "UrunID";
            comboBox1.DisplayMember = "Urunad";
            comboBox1.DataSource = urun;

            comboBox2.ValueMember = "MusteriID";
            comboBox2.DisplayMember = "MusteriAdsoyad";
            comboBox2.DataSource = must;

        }
        private void Satış_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbl_satis sat = new tbl_satis();
            sat.SatisFiyat = Convert.ToDecimal(textBox2.Text);
            sat.SatisAdet = Convert.ToInt32(textBox6.Text);
            sat.SatisTarih = Convert.ToDateTime(maskedTextBox1.Text);
            sat.Urun = Convert.ToInt32(comboBox1.SelectedValue);
            sat.Musteri= Convert.ToInt32(comboBox2.SelectedValue);
            
            
            db.tbl_satis.Add(sat);
            db.SaveChanges();
            MessageBox.Show("Satış eklenmiştir.");
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int id = int.Parse(textBox1.Text);
            var bul = db.tbl_satis.Find(id);
            db.tbl_satis.Remove(bul);
            db.SaveChanges();
            MessageBox.Show("Satış silinmiştir.");
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var sat = db.tbl_satis.Find(id);
            sat.SatisFiyat = Convert.ToDecimal(textBox2.Text);
            sat.SatisAdet = Convert.ToInt32(textBox6.Text);
            sat.SatisTarih = Convert.ToDateTime(maskedTextBox1.Text);
            sat.Urun = Convert.ToInt32(comboBox1.SelectedValue);
            sat.Musteri = Convert.ToInt32(comboBox2.SelectedValue);
            db.SaveChanges();
            MessageBox.Show("Satış güncellenmiştir.");
            Listele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(comboBox1.SelectedValue);
            var fiyat = db.tbl_urun.Where( x => x.UrunID == id).Select (y =>y.UrunFiyat).FirstOrDefault();

            textBox2.Text = fiyat.ToString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            if(textBox6.Text != "")
            {
                int id = Convert.ToInt32(comboBox1.SelectedValue);
                var fiyat = db.tbl_urun.Where(x => x.UrunID == id).Select(y => y.UrunFiyat).FirstOrDefault();

                textBox2.Text = (decimal.Parse(textBox6.Text) * fiyat).ToString();
            }
            else
            {
                textBox2.Text = "0";
            }



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
