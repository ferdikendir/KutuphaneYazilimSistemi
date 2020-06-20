using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane
{
    public partial class OduncVerme : Form
    {
        public OduncVerme()
        {
            InitializeComponent();
        }

        Dbislem db = new Dbislem();
        public static Boolean yetki;
        
        private static int kitID;
        private void OduncVerme_Load(object sender, EventArgs e)
        {
            label1.Text = main.ad;
            db.datatable7.Clear();
            db.VerilmisKitaplar();
            dataGridView1.DataSource = db.datatable7;

            db.datatable8.Clear();
            db.VerilmemisKitaplar();
            dataGridView2.DataSource = db.datatable8;

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                kitID = Convert.ToInt32(dataGridView1[0, e.RowIndex].Value.ToString());
                textBox3.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            }
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                kitID = Convert.ToInt32(dataGridView2[0, e.RowIndex].Value.ToString());
                textBox2.Text = dataGridView2[1, e.RowIndex].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e) //kitap verme
        {
            if (textBox1.Text != "" && textBox2.Text != "" && db.OgrenciGetir(Convert.ToInt32(textBox1.Text.ToString())))
            {
                DialogResult secenek = MessageBox.Show(
                    "İşlemi onaylıyor musunuz?\n" + db.dataSet14.Tables[0].Rows[0][1].ToString() + " " + db.dataSet14.Tables[0].Rows[0][2].ToString() + "\n" + db.dataSet14.Tables[0].Rows[0][9].ToString(),
                    "Bilgilendirme Penceresi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (secenek == DialogResult.Yes)
                {
                    db.OduncVer(Convert.ToInt32(textBox1.Text.ToString()), kitID);

                    db.datatable8.Clear();
                    db.VerilmemisKitaplar();
                    dataGridView2.DataSource = db.datatable8;

                    db.datatable7.Clear();
                    db.VerilmisKitaplar();
                    dataGridView1.DataSource = db.datatable7;
                }

            }
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "" && db.OgrenciGetir(Convert.ToInt32(textBox4.Text.ToString())))
            {
                DialogResult secenek = MessageBox.Show(
                    "İşlemi onaylıyor musunuz?\n" + db.dataSet14.Tables[0].Rows[0][1].ToString() + " " + db.dataSet14.Tables[0].Rows[0][2].ToString() + "\n" + db.dataSet14.Tables[0].Rows[0][9].ToString(),
                    "Bilgilendirme Penceresi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (secenek == DialogResult.Yes)
                {
                    db.KitapAl(Convert.ToInt32(textBox4.Text.ToString()), kitID);

                    db.datatable7.Clear();
                    db.VerilmisKitaplar();
                    dataGridView1.DataSource = db.datatable7;

                    db.datatable8.Clear();
                    db.VerilmemisKitaplar();
                    dataGridView2.DataSource = db.datatable8;
                }
            }
            textBox4.Text = "";
        }



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
