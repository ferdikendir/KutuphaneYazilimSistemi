using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane
{
    public partial class main : Form
    {
        
        public main()
        {
            InitializeComponent();
            panel1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            panel2.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
        }

        public static string ad;
        public static string kullaniciadi;
        public static int id;

        Dbislem db = new Dbislem();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                db.KitapGetir(textBox1.Text);

                if (db.dataSet1.Tables[0].Rows.Count > 0)
                {
                    label2.Text = db.dataSet1.Tables[0].Rows[0][1].ToString(); //kitap ismi

                    label3.Text = db.dataSet1.Tables[0].Rows[0][6].ToString() + " " + db.dataSet1.Tables[0].Rows[0][7].ToString(); //yazar ismi

                    label4.Text = db.dataSet1.Tables[0].Rows[0][12].ToString(); //yayin evi

                    label5.Text = db.dataSet1.Tables[0].Rows[0][15].ToString(); //kitap turu

                    panel1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    if (Convert.ToBoolean(db.dataSet1.Tables[0].Rows[0][4].ToString()) == false)
                        label6.Text = "Kitap Şuan başka bir öğrencide."+Environment.NewLine+ "Lütfen daha sonra tekrar kontrol edin!!";
                    else
                        label6.Text = "İlgili personelden kitabı alabilirsiniz....";

                }
                else
                {
                    MessageBox.Show(
                    "Böyle bir kitap bulunamadı..",
                    "Hata Penceresi",
                    MessageBoxButtons.OK
                    );
                    textBox1.Text = "";
                }

            }
            else
            {
                MessageBox.Show(
                    "Lütfen kitap adını giriniz...",
                    "Bilgilendirme Penceresi",
                    MessageBoxButtons.OK
                    );
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            button2.Visible = false;
            button4.Visible = true;
            button3.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            panel2.Visible = false;
            button4.Visible = false;
            button2.Visible = true;
            button3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OduncVerme od = new OduncVerme();
            iliskiKesme ik = new iliskiKesme();
            satinAlma sa = new satinAlma();
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                if (db.Giris(textBox2.Text, textBox3.Text))
                {
                    ad = db.dataSet5.Tables[0].Rows[0][1] + " " + db.dataSet5.Tables[0].Rows[0][2];
                    id = Convert.ToInt32(db.dataSet5.Tables[0].Rows[0][0].ToString());
                    kullaniciadi = db.dataSet5.Tables[0].Rows[0][3].ToString();
                    switch (Convert.ToInt32(db.dataSet5.Tables[0].Rows[0][5]))
                    {
                        case 1:
                            OduncVerme.yetki = Convert.ToBoolean(db.dataSet5.Tables[0].Rows[0][6].ToString());
                            od.ShowDialog();
                            break;
                        case 2:
                            iliskiKesme.yetki = Convert.ToBoolean(db.dataSet5.Tables[0].Rows[0][6].ToString());
                            ik.ShowDialog();
                            break;
                        case 3:
                            satinAlma.yetki = Convert.ToBoolean(db.dataSet5.Tables[0].Rows[0][6].ToString());
                            sa.ShowDialog();
                            break;
                    }
                    this.Close();
                    
                }
                else
                {

                    MessageBox.Show(
                    "Kullanıcı bulunamadı.. Tekrar deneyiniz",
                    "Hata Penceresi",
                    MessageBoxButtons.OK
                    );
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }
            else
            {
                MessageBox.Show(
                    "Eksiksiz veri giriniz",
                    "Hata Penceresi",
                    MessageBoxButtons.OK
                    );
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
