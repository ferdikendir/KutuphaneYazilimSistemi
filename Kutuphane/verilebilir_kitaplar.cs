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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Kutuphane
{
    public partial class verilebilir_kitaplar : Form
    {
        iTextSharp.text.Document pdfDosya = new iTextSharp.text.Document();
        public static DataSet datasett = new DataSet();
        public verilebilir_kitaplar()
        {
            InitializeComponent();
        }

        private void İptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void verilebilir_kitaplar_Load(object sender, EventArgs e)
        {
            int index = 1;
            richTextBox1.Text = richTextBox1.Text + "Verilebilir " + satinAlma.counter_true + " adet kitap bulunmaktadır.\n";
            for (int i = 0; i < datasett.Tables[0].Rows.Count; i++, index++)
            {

                if (Convert.ToBoolean(datasett.Tables[0].Rows[i][4].ToString()))
                {
                    richTextBox1.Text = richTextBox1.Text + "   " +
                        index + " -- " +
                        datasett.Tables[0].Rows[i][1].ToString() + " -- " +
                        datasett.Tables[0].Rows[i][2].ToString() + " -- " +
                        datasett.Tables[0].Rows[i][3].ToString();
                    richTextBox1.Text = richTextBox1.Text + " -- (Verilebilir!!!)\n";
                }

            }

            richTextBox1.Text = richTextBox1.Text + "\n";
            richTextBox1.Text = richTextBox1.Text + " " + main.ad;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("C:verilebilir_kitaplar.pdf"))
                File.Delete("C:verilebilir_kitaplar.pdf");
            //Kutuphane\Kutuphane\bin\Debug
            PdfWriter.GetInstance(pdfDosya, new FileStream("C:verilebilir_kitaplar.pdf", FileMode.Create));
            pdfDosya.Open();

            Paragraph eklenecekMetin = new Paragraph(richTextBox1.Text);
            pdfDosya.Add(eklenecekMetin);
            pdfDosya.Close();
            RaporEkle re = new RaporEkle();
            button1.Enabled = false;
            re.ShowDialog();
        }

    }
}
