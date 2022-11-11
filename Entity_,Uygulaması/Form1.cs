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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kategori k = new Kategori();
            k.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Müşteri k = new Müşteri();
            k.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ürün k = new Ürün();
            k.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Satış k = new Satış();
            k.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bilgi k = new Bilgi();
            k.Show();
            this.Hide();
        }
    }
}
