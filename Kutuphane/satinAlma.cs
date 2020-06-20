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
    public partial class satinAlma : Form
    {
        public static string isim;
        public static int counter_true;
        public static int counter_false;
        public static Boolean yetki;
        Dbislem db = new Dbislem();
        public satinAlma()
        {
            InitializeComponent();

        }
        private void satinAlma_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kutuphaneDataSet67.Tur' table. You can move, or remove it, as needed.
            this.turTableAdapter2.Fill(this.kutuphaneDataSet67.Tur);
            // TODO: This line of code loads data into the 'kutuphaneDataSet.Tur' table. You can move, or remove it, as needed.
            this.turTableAdapter1.Fill(this.kutuphaneDataSet.Tur);
            // TODO: This line of code loads data into the 'kutuphaneDataSet3.Tur' table. You can move, or remove it, as needed.
            this.turTableAdapter.Fill(this.kutuphaneDataSet3.Tur);
            // TODO: This line of code loads data into the 'kutuphaneDataSet2.YayinEvi' table. You can move, or remove it, as needed.
            this.yayinEviTableAdapter1.Fill(this.kutuphaneDataSet2.YayinEvi);
            // TODO: This line of code loads data into the 'kutuphaneDataSet1.YayinEvi' table. You can move, or remove it, as needed.
            this.yayinEviTableAdapter.Fill(this.kutuphaneDataSet1.YayinEvi);
            label1.Text = main.ad;
            db.datatable1.Clear();
            db.YayinEvi();
            dataGridView1.DataSource = db.datatable1;
            db.datatable2.Clear();
            db.Yazar();
            dataGridView2.DataSource = db.datatable2;
            db.datatable3.Clear();
            db.Kitap();
            dataGridView3.DataSource = db.datatable3;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/mm/dd";
            db.comboDoldur();
            comboBox4.DataSource = db.datatable4;
            comboBox4.DisplayMember = "tamad";
            comboBox4.ValueMember = "yazarID";
            comboBox6.DataSource = db.datatable4;
            comboBox6.DisplayMember = "tamad";
            comboBox6.ValueMember = "yazarID";
            if(yetki == true){
                panel7.Visible = true;
                label26.Visible = true;

            }
            counter_false = 0;
            counter_true = 0;
            for (int i = 0; i < tumKitap.dase.Tables[0].Rows.Count; i++)
            {

                if (Convert.ToBoolean(tumKitap.dase.Tables[0].Rows[i][4].ToString()))
                {
                    counter_true++;
                }
                else
                {
                    counter_false++;
                }

            }
        }
        public static string yayinevi;
        public static string yazarad, yazarsoyad;
        public static int id;
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
                    db.YayinSil(dataGridView1[0, e.RowIndex].Value.ToString());
                    db.datatable1.Clear();
                    db.YayinEvi();
                    dataGridView1.DataSource = db.datatable1;
                    textBox2.Text = "";
                }
                else if (secenek == DialogResult.No)
                {
                    DialogResult secenek1 = MessageBox.Show("Kaydı veritabanında değişikliğe uğratmak istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (secenek1 == DialogResult.Yes)
                    {
                        yayinevi = dataGridView1[0, e.RowIndex].Value.ToString();
                        textBox2.Text = yayinevi;
                    }
                    else if (secenek1 == DialogResult.No)
                    {
                        //Hayır seçeneğine tıklandığında çalıştırılacak kodlar
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e) //yayinekleme butonu
        {
            if (textBox1.Text != "")
            {
                db.YayinEkle(textBox1.Text, dateTimePicker1.Value);
                db.datatable1.Clear();
                db.YayinEvi();
                dataGridView1.DataSource = db.datatable1;
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show(
                   "Eksiksiz veri giriniz",
                   "Hata Penceresi",
                   MessageBoxButtons.OK
                   );
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e) //yayin guncelleme butonu
        {
            if (textBox2.Text != "")
            {
                db.YayinGuncelle(textBox2.Text);
                db.datatable1.Clear();
                db.YayinEvi();
                dataGridView1.DataSource = db.datatable1;
            }
            else
            {
                MessageBox.Show(
                   "Eksiksiz veri giriniz",
                   "Hata Penceresi",
                   MessageBoxButtons.OK
                   );
                textBox2.Text = "";
            }

        }


        private void button3_Click(object sender, EventArgs e) //yazar ekleme butonu
        {
            if (textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                db.YazarEkle(
                    textBox3.Text,
                    textBox4.Text,
                    textBox5.Text,
                    Convert.ToInt32(textBox6.Text),
                    Convert.ToInt32(comboBox3.SelectedValue)
                    );
                db.datatable2.Clear();
                db.Yazar();
                dataGridView1.DataSource = db.datatable2;
            }
            else
            {
                MessageBox.Show(
                   "Eksiksiz veri giriniz",
                   "Hata Penceresi",
                   MessageBoxButtons.OK
                   );
            }
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
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
                    db.YazarSil(dataGridView2[0, e.RowIndex].Value.ToString(),
                        dataGridView2[1, e.RowIndex].Value.ToString());
                    db.datatable2.Clear();
                    db.Yazar();
                    dataGridView2.DataSource = db.datatable2;
                }
                else if (secenek == DialogResult.No)
                {
                    DialogResult secenek1 = MessageBox.Show("Kaydı veritabanında değişikliğe uğratmak istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (secenek1 == DialogResult.Yes)
                    {
                        yazarad = dataGridView2[0, e.RowIndex].Value.ToString();
                        yazarsoyad = dataGridView2[1, e.RowIndex].Value.ToString();
                        textBox10.Text = dataGridView2[0, e.RowIndex].Value.ToString();
                        textBox9.Text = dataGridView2[1, e.RowIndex].Value.ToString();
                        textBox8.Text = dataGridView2[2, e.RowIndex].Value.ToString();
                        textBox7.Text = dataGridView2[3, e.RowIndex].Value.ToString();
                        comboBox1.SelectedItem = dataGridView2[4, e.RowIndex].Value.ToString();
                    }
                    else if (secenek1 == DialogResult.No)
                    {
                        //Hayır seçeneğine tıklandığında çalıştırılacak kodlar
                    }
                }

            }
        }

        private void button4_Click(object sender, EventArgs e) //yazar guncelleme butonu
        {
            if (textBox9.Text != "" && textBox8.Text != "" && textBox7.Text != "" && textBox10.Text != "")
            {
                db.YazarGüncelle(
                    textBox10.Text,
                    textBox9.Text,
                    textBox8.Text,
                    Convert.ToInt32(textBox7.Text),
                    Convert.ToInt32(comboBox1.SelectedValue.ToString()));
                db.datatable2.Clear();
                db.Yazar();
                dataGridView2.DataSource = db.datatable2;
            }
            else
            {
                MessageBox.Show(
                   "Eksiksiz veri giriniz",
                   "Hata Penceresi",
                   MessageBoxButtons.OK
                   );
            }
            textBox9.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            textBox10.Text = "";
        }

        private void button5_Click(object sender, EventArgs e) //kitap ekleme butonu
        {
            if (textBox11.Text != "")
            {
                db.KitapEkle(
                    textBox11.Text,
                    Convert.ToInt32(comboBox2.SelectedValue.ToString()),
                    Convert.ToInt32(comboBox4.SelectedValue.ToString())
                    );
                db.datatable3.Clear();
                db.Kitap();
                dataGridView3.DataSource = db.datatable3;
            }
            else
            {
                MessageBox.Show(
                   "Eksiksiz veri giriniz",
                   "Hata Penceresi",
                   MessageBoxButtons.OK
                   );
            }
            textBox11.Text = "";
        }

        private void dataGridView3_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DialogResult secenek = MessageBox.Show(
                    "Kaydı veritabanından silmek istiyor musunuz?",
                    "Bilgilendirme Penceresi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                string [] yazarcik = dataGridView3[2, e.RowIndex].Value.ToString().Split(' ');
                id = Convert.ToInt32(dataGridView3[0, e.RowIndex].Value.ToString());
                if (secenek == DialogResult.Yes)
                {
                    db.KitapSil();
                    db.datatable3.Clear();
                    db.Kitap();
                    dataGridView3.DataSource = db.datatable3;
                }
                else if (secenek == DialogResult.No)
                {
                    DialogResult secenek1 = MessageBox.Show("Kaydı veritabanında değişikliğe uğratmak istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (secenek1 == DialogResult.Yes)
                    {
                        textBox12.Text = dataGridView3[1, e.RowIndex].Value.ToString();

                    }
                    else if (secenek1 == DialogResult.No)
                    {
                        //Hayır seçeneğine tıklandığında çalıştırılacak kodlar
                    }
                }

            }
        }

        private void button6_Click(object sender, EventArgs e) //kitap guncelleme butonu
        {
            if (textBox12.Text != "")
            {
                db.KitapGuncelle(textBox12.Text,Convert.ToInt32(comboBox5.SelectedValue.ToString()),Convert.ToInt32(comboBox6.SelectedValue.ToString()));
                db.datatable3.Clear();
                db.Kitap();
                dataGridView3.DataSource = db.datatable3;
                textBox12.Text = "";
            }

        }

        private void button7_Click(object sender, EventArgs e) //tumKitap raporlama butonu
        {
            tumKitap tk = new tumKitap();
            tk.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            verilemez_kitaplar vnk = new verilemez_kitaplar();
            vnk.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            verilebilir_kitaplar vk = new verilebilir_kitaplar();
            vk.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            yazargrup yg = new yazargrup();
            yg.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            TurGrupla tg = new TurGrupla();
            tg.Show();
        }





    }
}
