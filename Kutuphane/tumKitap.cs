using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace Kutuphane
{
    public partial class tumKitap : Form
    {
        iTextSharp.text.Document pdfDosya = new iTextSharp.text.Document();
        public tumKitap()
        {
            InitializeComponent();
        }
        Dbislem db = new Dbislem();
        public static DataSet dase = new DataSet();
        private void tumKitap_Load(object sender, EventArgs e)
        {
            int index = 1;

            richTextBox1.Text = richTextBox1.Text + "Kütüphanemizde toplam " + dase.Tables[0].Rows.Count + " adet kitap vardır. ";
            richTextBox1.Text = richTextBox1.Text + "Bu kitaplardan " + satinAlma.counter_true + " adet kitap ödünç alınmamıştır. ";
            richTextBox1.Text = richTextBox1.Text + "Bu kitaplardan " + satinAlma.counter_false + " adet kitap ödünç alınmıştır. Bu Kitaplar; \n";
            for (int i = 0; i < dase.Tables[0].Rows.Count; i++, index++)
            {
                richTextBox1.Text = richTextBox1.Text + "   " +
                    index + " -- " +
                    dase.Tables[0].Rows[i][1].ToString() + " -- " +
                    dase.Tables[0].Rows[i][2].ToString() + " -- " +
                    dase.Tables[0].Rows[i][3].ToString();

                if (Convert.ToBoolean(dase.Tables[0].Rows[i][4].ToString()))
                {
                    richTextBox1.Text = richTextBox1.Text + " -- (Verilebilir!!!)\n";
                }
                else
                {
                    richTextBox1.Text = richTextBox1.Text + " -- (Verilemez!!!)\n";
                }

            }

            richTextBox1.Text = richTextBox1.Text + "\n";
            richTextBox1.Text = richTextBox1.Text + " " + main.ad;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("C:tum_kitap.pdf"))
                File.Delete("C:tum_kitap.pdf");
            //Kutuphane\Kutuphane\bin\Debug
            PdfWriter.GetInstance(pdfDosya, new FileStream("C:tum_kitap.pdf", FileMode.Create));
            pdfDosya.Open();
            Paragraph eklenecekMetin = new Paragraph(richTextBox1.Text);
            pdfDosya.Add(eklenecekMetin);
            pdfDosya.Close();
            RaporEkle re = new RaporEkle();
            button2.Enabled = false;
            re.ShowDialog();
        }

    }
}
