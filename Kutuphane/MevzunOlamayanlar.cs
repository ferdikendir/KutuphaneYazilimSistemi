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
    public partial class MevzunOlamayanlar : Form
    {

        public MevzunOlamayanlar()
        {
            InitializeComponent();
        }
        public static DataSet notmevzunlar = new DataSet();
        iTextSharp.text.Document pdfDosya = new iTextSharp.text.Document();
        Dbislem db = new Dbislem();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MevzunOlamayanlar_Load(object sender, EventArgs e)
        {
            db.MevzunOlmayanlar();
            for (int i = 0; i < notmevzunlar.Tables[0].Rows.Count; i++)
            {
                richTextBox1.Text = richTextBox1.Text + "   " +
                    notmevzunlar.Tables[0].Rows[i][0].ToString() + " numaralı  " +
                    notmevzunlar.Tables[0].Rows[i][1].ToString() + " ismili ogrenci  " +
                    notmevzunlar.Tables[0].Rows[i][2].ToString() + " bölümü  " +
                    notmevzunlar.Tables[0].Rows[i][3].ToString() + " fakültesinde okumaktadır. ";
                richTextBox1.Text = richTextBox1.Text + "\n";


            }
            richTextBox1.Text = richTextBox1.Text + notmevzunlar.Tables[0].Rows.Count + " tane öğrenci mevzun olmamıştır..\n";
            richTextBox1.Text = richTextBox1.Text + "\n";
            richTextBox1.Text = richTextBox1.Text + " " + main.ad;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("C:mezunOlmayanOgrenciler.pdf"))
                File.Delete("C:mezunOlmayanOgrenciler.pdf");
            //Kutuphane\Kutuphane\bin\Debug
            PdfWriter.GetInstance(pdfDosya, new FileStream("C:mezunOlmayanOgrenciler.pdf", FileMode.Create));
            pdfDosya.Open();

            pdfDosya.AddCreator(main.ad); //Oluşturan kişinin isminin eklenmesi
            pdfDosya.AddHeader("PDF UYGULAMASI OLUSTUR", null);
            Paragraph eklenecekMetin = new Paragraph(richTextBox1.Text);
            pdfDosya.Add(eklenecekMetin);
            pdfDosya.Close();
            button1.Enabled = false;
            RaporEkle rp = new RaporEkle();
            rp.ShowDialog();
        }
    }
}
