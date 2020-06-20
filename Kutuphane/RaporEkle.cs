using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane
{
    public partial class RaporEkle : Form
    {
        public RaporEkle()
        {
            InitializeComponent();
        }
        Dbislem db = new Dbislem();
        private void RaporEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                db.RaporEkle(textBox1.Text, textBox2.Text, main.kullaniciadi);
               
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            button1.Enabled = false;
            //MessageBox.Show("Raporunuz oluşturulmuştur");
            this.Hide();
            
        }
    }
}
