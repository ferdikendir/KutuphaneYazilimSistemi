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
    public partial class yazargrup : Form
    {
        public yazargrup()
        {
            InitializeComponent();
        }
        iTextSharp.text.Document pdfDosya = new iTextSharp.text.Document();
        Dbislem db = new Dbislem();
        public static DataSet yazarGrup = new DataSet();
        private void yazargrup_Load(object sender, EventArgs e)
        {
            db.YazaraGoreGrup();
            for (int i = 0; i < yazarGrup.Tables[0].Rows.Count; i++)
            {
                richTextBox1.Text = richTextBox1.Text + "   " +
                    yazarGrup.Tables[0].Rows[i][0].ToString() + " numaralı yazar " +
                    yazarGrup.Tables[0].Rows[i][1].ToString() + " ismiyle " +
                    yazarGrup.Tables[0].Rows[i][2].ToString() + " yayın evinde çalışmaktadır ve  " +
                    yazarGrup.Tables[0].Rows[i][3].ToString() + " adet kitabı bulunmaktadır. ";
                richTextBox1.Text = richTextBox1.Text + "\n";


            }

            richTextBox1.Text = richTextBox1.Text + "\n";
            richTextBox1.Text = richTextBox1.Text + " " + main.ad;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("C:YazarBilgi.pdf"))
                File.Delete("C:YazarBilgi.pdf");
            //Kutuphane\Kutuphane\bin\Debug
            PdfWriter.GetInstance(pdfDosya, new FileStream("C:YazarBilgi.pdf", FileMode.Create));
            pdfDosya.Open();

            pdfDosya.AddCreator(main.ad); //Oluşturan kişinin isminin eklenmesi
            pdfDosya.AddHeader("PDF UYGULAMASI OLUSTUR", null);
            Paragraph eklenecekMetin = new Paragraph(richTextBox1.Text);
            pdfDosya.Add(eklenecekMetin);
            pdfDosya.Close();
            RaporEkle re = new RaporEkle();
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
