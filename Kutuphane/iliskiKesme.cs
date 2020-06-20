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
    public partial class iliskiKesme : Form
    {
        public iliskiKesme()
        {
            InitializeComponent();
        }

        Dbislem db = new Dbislem();
        public static DateTime tarih;
        public static Boolean yetki;
        
        private void iliskiKesme_Load(object sender, EventArgs e)
        {
            label2.Text = main.ad;
            db.Ogrenci();
            dataGridView1.DataSource = db.datatable6;
            if (yetki)
            {
                label1.Visible = true;
                panel1.Visible = true;
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DialogResult secenek = MessageBox.Show(
                                   "Kaydı veritabanından silmek istiyor musunuz?",
                                   "Bilgilendirme Penceresi",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Information);

                if (secenek == DialogResult.Yes)
                {
                    tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                   
                    if (db.VerilmemisKitap(Convert.ToInt32(dataGridView1[0, e.RowIndex].Value.ToString())))
                    {
                        MessageBox.Show("Verilmemiş kitabınız var. Lütfen Ödünç verme bölümüne gidiniz...");
                    }
                    else
                    {
                        db.OgrenciSil(Convert.ToInt32(dataGridView1[0, e.RowIndex].Value.ToString()));
                        db.datatable6.Clear();
                        db.Ogrenci();
                        dataGridView1.DataSource = db.datatable6;
                    }

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tumOgrenciler to = new tumOgrenciler();
            to.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mevzunOgrenciler mo = new mevzunOgrenciler();
            mo.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MevzunOlamayanlar mnoto = new MevzunOlamayanlar();
            mnoto.Show();
        }
    }
}
