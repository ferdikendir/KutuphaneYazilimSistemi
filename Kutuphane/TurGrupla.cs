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
    public partial class TurGrupla : Form
    {
        public TurGrupla()
        {
            InitializeComponent();
        }
        Dbislem db = new Dbislem();
        iTextSharp.text.Document pdfDosya = new iTextSharp.text.Document();
        public static DataSet turGrup = new DataSet();
        private void TurGrupla_Load(object sender, EventArgs e)
        {
            db.TureGoreGrup();
            for (int i = 0; i < turGrup.Tables[0].Rows.Count; i++)
            {
                    richTextBox1.Text = richTextBox1.Text + "   " +
                        turGrup.Tables[0].Rows[i][0].ToString() + " isimli yazarın " +
                        turGrup.Tables[0].Rows[i][1].ToString() + " isimli kitabı " +
                        turGrup.Tables[0].Rows[i][2].ToString() + " türündedir. ";
                    richTextBox1.Text = richTextBox1.Text + "\n";
            }

            richTextBox1.Text = richTextBox1.Text + "\n";
            richTextBox1.Text = richTextBox1.Text + " " + main.ad;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists("C:TurGruplari.pdf")) //dosya daha once olusmus mu
                File.Delete("C:TurGruplari.pdf"); //olusmussa sil
            //Kutuphane\Kutuphane\bin\Debug
            PdfWriter.GetInstance(pdfDosya, new FileStream("C:TurGruplari.pdf", FileMode.Create));
            pdfDosya.Open();

            pdfDosya.AddCreator(main.ad); //Oluşturan kişinin isminin eklenmesi
            pdfDosya.AddHeader("PDF UYGULAMASI OLUSTUR", null);
            Paragraph eklenecekMetin = new Paragraph(richTextBox1.Text);
            pdfDosya.Add(eklenecekMetin);
            pdfDosya.Close();
            RaporEkle re = new RaporEkle();
            button1.Enabled = false;
            re.ShowDialog();
        }
    }
}
