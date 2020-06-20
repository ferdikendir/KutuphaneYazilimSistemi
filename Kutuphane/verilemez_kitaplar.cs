using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane
{
    public partial class verilemez_kitaplar : Form
    {
        
        iTextSharp.text.Document pdfDosya = new iTextSharp.text.Document();
        public static DataSet datasett = new DataSet();
        public verilemez_kitaplar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void verilmemis_kitaplar_Load(object sender, EventArgs e)
        {
            
            richTextBox1.Text = richTextBox1.Text + "Kütüphanemizde " + satinAlma.counter_false + " adet verilmemiş kitap bulunmaktadır. Bunlar;\n";

            for (int i = 0; i < datasett.Tables[0].Rows.Count; i++)
            {

                if (Convert.ToBoolean(datasett.Tables[0].Rows[i][4].ToString()) == false)
                {
                    richTextBox1.Text = richTextBox1.Text + "   " +
                        datasett.Tables[0].Rows[i][0].ToString() + " -- " +
                        datasett.Tables[0].Rows[i][1].ToString() + " -- " +
                        datasett.Tables[0].Rows[i][2].ToString() + " -- " +
                        datasett.Tables[0].Rows[i][3].ToString();
                    richTextBox1.Text = richTextBox1.Text + " -- (Verilemez!!!)\n";
                }

            }

            richTextBox1.Text = richTextBox1.Text + "\n";
            richTextBox1.Text = richTextBox1.Text + " " + main.ad;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("C:verilmemis_kitap.pdf"))
                File.Delete("C:verilmemis_kitap.pdf");
            //Kutuphane\Kutuphane\bin\Debug
            PdfWriter.GetInstance(pdfDosya, new FileStream("C:verilmemis_kitap.pdf", FileMode.Create));
            pdfDosya.Open();

            pdfDosya.AddCreator(main.ad); //Oluşturan kişinin isminin eklenmesi
            pdfDosya.AddHeader("PDF UYGULAMASI OLUSTUR", null);
            Paragraph eklenecekMetin = new Paragraph(richTextBox1.Text);
            pdfDosya.Add(eklenecekMetin);
            pdfDosya.Close();
            RaporEkle re = new RaporEkle();
            button2.Enabled = false;
            re.ShowDialog();
        }
    }
}
