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
    public partial class mevzunOgrenciler : Form
    {
        iTextSharp.text.Document pdfDosya = new iTextSharp.text.Document();
        public static DataSet mevzunlar = new DataSet();
        Dbislem db = new Dbislem();
        public mevzunOgrenciler()
        {
            InitializeComponent();
        }

        private void mevzunOgrenciler_Load(object sender, EventArgs e)
        {
            DateTime mevzuntarih;
            db.MevzunOlanlar();
            for (int i = 0; i < mevzunlar.Tables[0].Rows.Count; i++)
            {
                mevzuntarih = Convert.ToDateTime(mevzunlar.Tables[0].Rows[i][4].ToString());
                richTextBox1.Text = richTextBox1.Text + "   " +
                    mevzunlar.Tables[0].Rows[i][0].ToString() + " numaralı  " +
                    mevzunlar.Tables[0].Rows[i][1].ToString() + " ismili ogrenci  " +
                    mevzunlar.Tables[0].Rows[i][2].ToString() + " bölümü  " +
                    mevzunlar.Tables[0].Rows[i][3].ToString() + " fakültesinden " +
                    mevzuntarih.Year.ToString() +"- " + mevzuntarih.Month.ToString() + "- " + mevzuntarih.Day.ToString() + " " + "tarihinde mevzun olmuştur.";
                richTextBox1.Text = richTextBox1.Text + "\n";


            }
            richTextBox1.Text = richTextBox1.Text + mevzunlar.Tables[0].Rows.Count + " tane öğrenci mevzun olmuştur.\n";
            richTextBox1.Text = richTextBox1.Text + "\n";
            richTextBox1.Text = richTextBox1.Text + " " + main.ad;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("C:mezunOgrenciler.pdf"))
                File.Delete("C:mezunOgrenciler.pdf");
            //Kutuphane\Kutuphane\bin\Debug
            PdfWriter.GetInstance(pdfDosya, new FileStream("C:mezunOgrenciler.pdf", FileMode.Create));
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
