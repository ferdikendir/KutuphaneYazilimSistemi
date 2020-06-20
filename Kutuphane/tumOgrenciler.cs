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
    public partial class tumOgrenciler : Form
    {
        public tumOgrenciler()
        {
            InitializeComponent();
        }
        Dbislem db = new Dbislem();
        iTextSharp.text.Document pdfDosya = new iTextSharp.text.Document();
        public static DataSet tumOgrencilerr = new DataSet();
        private void tumOgrenciler_Load(object sender, EventArgs e)
        {
            db.Tumogrenciler();
            for (int i = 0; i < tumOgrencilerr.Tables[0].Rows.Count; i++)
            {
                richTextBox1.Text = richTextBox1.Text + ""+
                    tumOgrencilerr.Tables[0].Rows[i][0].ToString() + " numaralı  " +
                    tumOgrencilerr.Tables[0].Rows[i][1].ToString() + " isimli öğrenci " +
                    tumOgrencilerr.Tables[0].Rows[i][2].ToString()+" bölümünde "+
                    tumOgrencilerr.Tables[0].Rows[i][3].ToString()+" fakültesindedir.";

                if (Convert.ToBoolean(tumOgrencilerr.Tables[0].Rows[i][4].ToString()))
                {
                    richTextBox1.Text = richTextBox1.Text + " -- (Muvzun!!!)\n";
                }
                else
                {
                    richTextBox1.Text = richTextBox1.Text + " -- (Muvzun değil!!!)\n";
                }

            }

            richTextBox1.Text = richTextBox1.Text + "\n";
            richTextBox1.Text = richTextBox1.Text + " " + main.ad;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("C:TumOgrenciler.pdf")) //dosya daha once olusmus mu
                File.Delete("C:TumOgrenciler.pdf"); //olusmussa sil
            //Kutuphane\Kutuphane\bin\Debug
            PdfWriter.GetInstance(pdfDosya, new FileStream("C:TumOgrenciler.pdf", FileMode.Create));
            pdfDosya.Open();

            pdfDosya.AddCreator(main.ad); //Oluşturan kişinin isminin eklenmesi
            pdfDosya.AddHeader("PDF UYGULAMASI OLUSTUR", null);
            Paragraph eklenecekMetin = new Paragraph(richTextBox1.Text);
            pdfDosya.Add(eklenecekMetin);
            pdfDosya.Close();
            button1.Enabled = false;
            RaporEkle re = new RaporEkle();
            re.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
