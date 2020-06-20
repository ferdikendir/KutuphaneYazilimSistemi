using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kutuphane
{
    class Dbislem
    {
        public string dosyaYolu = "C:\\Error.txt";
        #region Dataset and Dataadapter

        public SqlConnection baglanti = new SqlConnection();
        //-----------------------------------------------------
        public SqlDataAdapter dataAdapter1 = new SqlDataAdapter();//kullaniliyor
        public SqlCommand SelectCommand1 = new SqlCommand();
        public DataSet dataSet1 = new DataSet();

        public SqlDataAdapter dataAdapter2 = new SqlDataAdapter();//kullaniliyor
        public SqlCommand SelectCommand2 = new SqlCommand();
        public DataTable datatable2 = new DataTable();

        public SqlDataAdapter dataAdapter3 = new SqlDataAdapter();
        public SqlCommand SelectCommand3 = new SqlCommand();
        public DataSet dataSet3 = new DataSet();

        public SqlDataAdapter dataAdapter4 = new SqlDataAdapter(); //kulaniliyor
        public SqlCommand SelectCommand4 = new SqlCommand();
        public DataSet dataSet4 = new DataSet();

        public SqlDataAdapter dataAdapter5 = new SqlDataAdapter();//kullaniliyor
        public SqlCommand SelectCommand5 = new SqlCommand();
        public DataSet dataSet5 = new DataSet();

        public SqlDataAdapter dataAdapter6 = new SqlDataAdapter();//kullaniliyor
        public SqlCommand SelectCommand6 = new SqlCommand();
        public DataTable datatable1 = new DataTable();


        public SqlDataAdapter dataAdapter7 = new SqlDataAdapter(); //kullaniliyor
        public SqlCommand SelectCommand7 = new SqlCommand();
        public DataSet dataSet6 = new DataSet();

        public SqlDataAdapter dataAdapter8 = new SqlDataAdapter();//kullaniliyor
        public SqlCommand SelectCommand8 = new SqlCommand();
        public DataTable datatable3 = new DataTable();

        public SqlDataAdapter dataAdapter9 = new SqlDataAdapter();//kullaniliyor
        public SqlCommand SelectCommand9 = new SqlCommand();
        public DataTable datatable4 = new DataTable();

        public SqlDataAdapter dataAdapter10 = new SqlDataAdapter(); //kullaniliyor
        public SqlCommand SelectCommand10 = new SqlCommand();
        public DataSet dataSet7 = new DataSet();

        public SqlDataAdapter dataAdapter11 = new SqlDataAdapter(); //kullaniliyor
        public SqlCommand SelectCommand11 = new SqlCommand();
        public DataSet dataSet8 = new DataSet();

        public SqlDataAdapter dataAdapter12 = new SqlDataAdapter(); //kullaniliyor
        public SqlCommand SelectCommand12 = new SqlCommand();
        public DataSet dataSet9 = new DataSet();

        public SqlDataAdapter dataAdapter13 = new SqlDataAdapter();//kullaniliyor
        public SqlCommand SelectCommand13 = new SqlCommand();
        public DataTable datatable5 = new DataTable();

        public SqlDataAdapter dataAdapter14 = new SqlDataAdapter();//kullaniliyor
        public SqlCommand SelectCommand14 = new SqlCommand();
        public DataTable datatable6 = new DataTable();

        public SqlDataAdapter dataAdapter15 = new SqlDataAdapter(); //kullaniliyor
        public SqlCommand SelectCommand15 = new SqlCommand();
        public DataSet dataSet10 = new DataSet();

        public SqlDataAdapter dataAdapter16 = new SqlDataAdapter(); //kullaniliyor
        public SqlCommand SelectCommand16 = new SqlCommand();
        public DataSet dataSet11 = new DataSet();

        public SqlDataAdapter dataAdapter17 = new SqlDataAdapter(); //kullaniliyor
        public SqlCommand SelectCommand17 = new SqlCommand();
        public DataTable datatable7 = new DataTable();

        public SqlDataAdapter dataAdapter18 = new SqlDataAdapter(); //kullaniliyor
        public SqlCommand SelectCommand18 = new SqlCommand();
        public DataTable datatable8 = new DataTable();

        public SqlDataAdapter dataAdapter19 = new SqlDataAdapter(); //kullaniliyor
        public SqlCommand SelectCommand19 = new SqlCommand();
        public DataSet dataSet12 = new DataSet();

        public SqlDataAdapter dataAdapter20 = new SqlDataAdapter(); //kullaniliyor
        public SqlCommand SelectCommand20 = new SqlCommand();
        public DataSet dataSet13 = new DataSet();

        public SqlDataAdapter dataAdapter21 = new SqlDataAdapter(); //kullaniliyor
        public SqlCommand SelectCommand21 = new SqlCommand();
        public DataSet dataSet14 = new DataSet();

        public DataSet dataSet15 = new DataSet();

        public SqlDataAdapter dataAdapter22 = new SqlDataAdapter(); //kullaniliyor
        public SqlCommand SelectCommand22 = new SqlCommand();

        public SqlDataAdapter dataAdapter23 = new SqlDataAdapter(); //kullaniliyor
        public SqlCommand SelectCommand23 = new SqlCommand();

        public SqlDataAdapter dataAdapter24 = new SqlDataAdapter(); //kullaniliyor
        public SqlCommand SelectCommand24 = new SqlCommand();

        public SqlDataAdapter dataAdapter25 = new SqlDataAdapter(); //kullaniliyor
        public SqlCommand SelectCommand25 = new SqlCommand();

        public SqlDataAdapter dataAdapter26 = new SqlDataAdapter(); //kullaniliyor
        public SqlCommand SelectCommand26 = new SqlCommand();

        public SqlDataAdapter dataAdapter27 = new SqlDataAdapter(); //kullaniliyor
        public SqlCommand SelectCommand27 = new SqlCommand();
        public DataSet dataSet16 = new DataSet();

        #endregion

        public Boolean Giris(string kullaniciadi, string sifre)//kullanici girisi icin gerekli metod
        {
            ac();
            try
            {
                dataSet5.Clear();
                dataAdapter5.SelectCommand.CommandText = "select personelID,adi,soyadi,kullaniciadi,sifre,kutuphanebolumID,yetki from Personel where kullaniciadi = '" + kullaniciadi + "' and sifre = '" + sifre + "'";
                dataAdapter5.Fill(dataSet5);
                if (dataSet5.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        public void comboDoldur() //kitap satinalma ekranindaki combobox datasource icin gerekli metod
        {
            ac();
            try
            {
                dataAdapter9.SelectCommand.CommandText = "select yazarID , concat(adi,' ', soyadi) as tamad from yazar";
                dataAdapter9.Fill(datatable4);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        public void RaporEkle(string konu, string gerekce, string kullaniciadi)//rapor ekleme (SP)
        {
            ac();
            try
            {
                SqlCommand cmd = new SqlCommand("raporInsert", baglanti);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("konu", SqlDbType.NVarChar, 50).Value = konu;
                cmd.Parameters.Add("gerekce", SqlDbType.NVarChar, 500).Value = gerekce;
                cmd.Parameters.Add("personel", SqlDbType.NVarChar, 20).Value = kullaniciadi;
                cmd.Parameters.Add("tarih", SqlDbType.DateTime).Value = DateTime.Now.ToLongDateString();

                cmd.ExecuteNonQuery();


            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }

        #region Ogrenci islemleri

        public void MevzunOlanlar()//raporlama ekraninda mevzun olanlar
        {
            ac();
            try
            {
                dataAdapter25.SelectCommand.CommandText = "select Ogrenci.ogrenciID , concat(Ogrenci.adi,' ', Ogrenci.soyadi) as ogrenciisim, " +
                   "Bolum.bolum, Fakulte.fakulte ,Ogrenci.mevzuniyet_tarihi from (( Ogrenci " +
                   " inner join Bolum on Bolum.bolumID = Ogrenci.bolumID) inner join Fakulte on Fakulte.fakulteID = Bolum.fakulteID )" +
                   " group by Ogrenci.ogrenciID ,Ogrenci.adi, Ogrenci.soyadi,Bolum.bolum," +
                   " Fakulte.fakulte,Ogrenci.mevzuniyet_tarihi,Ogrenci.mevzun having Ogrenci.mevzun = 1 ";
                dataAdapter25.Fill(mevzunOgrenciler.mevzunlar);

            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }

        }

        public void MevzunOlmayanlar()//raporlama ekraninda mevzun olmayanlar
        {
            ac();
            try
            {
                dataAdapter26.SelectCommand.CommandText = "select Ogrenci.ogrenciID , concat(Ogrenci.adi,' ', Ogrenci.soyadi) as ogrenciisim," +
                                " Bolum.bolum, Fakulte.fakulte ,Ogrenci.mevzun from" +
                                 "(( Ogrenci  inner join Bolum on Bolum.bolumID = Ogrenci.bolumID)" +
                                 "inner join Fakulte on Fakulte.fakulteID = Bolum.fakulteID )" +
                                 "group by Ogrenci.ogrenciID ,Ogrenci.adi, Ogrenci.soyadi,Ogrenci.mevzun, Bolum.bolum, Fakulte.fakulte " +
                                " having Ogrenci.mevzun = 0";
                dataAdapter26.Fill(MevzunOlamayanlar.notmevzunlar);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                
                kapat();
            }

        }
        public void Tumogrenciler()//raporlama ekranin da odunc verilen kitaplar
        {
            ac();
            try
            {
                dataAdapter24.SelectCommand.CommandText = "select Ogrenci.ogrenciID , concat(Ogrenci.adi,' ', Ogrenci.soyadi) as ogrenciisim," +
                                " Bolum.bolum, Fakulte.fakulte,Ogrenci.mevzun  from" +
                                " (( Ogrenci  inner join Bolum on Bolum.bolumID = Ogrenci.bolumID)" +
                                " inner join Fakulte on Fakulte.fakulteID = Bolum.fakulteID )" +
                                " group by Ogrenci.ogrenciID ,Ogrenci.adi, Ogrenci.soyadi,Bolum.bolum, Ogrenci.mevzun,Fakulte.fakulte";
                dataAdapter24.Fill(tumOgrenciler.tumOgrencilerr);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }

        }
        public Boolean OgrenciGetir(int ogrid)//ödünç verirken adı soyad getir
        {
            ac();
            try
            {
                dataSet14.Clear();
                dataAdapter21.SelectCommand.CommandText = "select *from Ogrenci inner join Bolum on Bolum.bolumID = Ogrenci.bolumID where ogrenciID = '" + ogrid + "'";
                dataAdapter21.Fill(dataSet14);
                if (dataSet14.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        public void Ogrenci() //mevzun olmayan ogrenciler icin gerekli metod
        {
            ac();
            try
            {
                dataAdapter14.SelectCommand.CommandText = "select ogrenciID, adi , soyadi ,kayitYili ,Bolum.bolum , Fakulte.fakulte from  (Ogrenci inner Join Bolum on Ogrenci.bolumID = Bolum.bolumID inner join Fakulte on Bolum.fakulteID = Fakulte.fakulteID) where mevzun = 0";
                dataAdapter14.Fill(datatable6);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        public void OgrenciSil(int ogrenciID)//ogrenci silme icin gerekli metod (aslında silme yok Trigger var)
        {
            ac();
            try
            {
                dataSet10.Clear();
                dataAdapter15.SelectCommand.CommandText = "delete from Ogrenci where ogrenciID = '" + ogrenciID + "'";
                dataAdapter15.Fill(dataSet10);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        #endregion


        #region Kitap islemleri



        public void TureGoreGrup()//raporlama ekranin da ture gore gruplama
        {
            dataAdapter23.SelectCommand.CommandText = "select  concat(Yazar.adi,' ', Yazar.soyadi) as yazarisim,Kitap.baslik , " +
                "Tur.tur from ((Kitap inner join Tur on Tur.turID = Kitap.turID) inner join Yazar on Yazar.yazarID = Kitap.yazarID)" +
                " group by Kitap.baslik, Tur.tur,Yazar.adi, Yazar.soyadi";
            dataAdapter23.Fill(TurGrupla.turGrup);
        }
        public void YazaraGoreGrup()//raporlama ekrani icin kullanilacak
        {
            dataAdapter22.SelectCommand.CommandText = "select Kitap.yazarID , concat(Yazar.adi,' ', Yazar.soyadi) as yazarisim," +
                " YayinEvi.yayinevi_ad , COUNT(baslik) as kitap_sayisi from (( Kitap  inner join Yazar on Kitap.yazarID = Yazar.yazarID)" +
                " inner join YayinEvi on Yazar.yayineviID = YayinEvi.yayineviID)" +
                " group by Kitap.yazarID ,Yazar.adi, Yazar.soyadi, YayinEvi.yayinevi_ad";
            dataAdapter22.Fill(yazargrup.yazarGrup);
        }

        public void VerilmisKitaplar()//odunc verme icin 
        {
            ac();
            try
            {
                dataAdapter17.SelectCommand.CommandText = "select Kitap.kitapID, Kitap.baslik , Concat(Yazar.adi, ' ', Yazar.soyadi)as yazar , Tur.tur from Kitap,Yazar, Tur Where Tur.turID = Kitap.turID and Yazar.yazarID = Kitap.yazarID and Kitap.durum = 0";
                dataAdapter17.Fill(datatable7);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        public void VerilmemisKitaplar()//odunc verme icin
        {
            ac();
            try
            {
                dataAdapter18.SelectCommand.CommandText = "select Kitap.kitapID, Kitap.baslik , Concat(Yazar.adi, ' ', Yazar.soyadi)as yazar , Tur.tur from Kitap,Yazar, Tur Where Tur.turID = Kitap.turID and Yazar.yazarID = Kitap.yazarID and Kitap.durum = 1";
                dataAdapter18.Fill(datatable8);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        public void KitapGetir(string kitapAd) //aranan kitabın bilgilerini getiren metod
        {
            ac();
            try
            {
                dataSet1.Clear();
                dataAdapter1.SelectCommand.CommandText = "select * from (((Kitap inner join Yazar on Yazar.yazarID = Kitap.yazarID) inner join YayinEvi on YayinEvi.yayineviID = Yazar.yayineviID) inner join Tur on Kitap.turID = Tur.turID) where Kitap.baslik = '" + kitapAd + "'";
                dataAdapter1.Fill(dataSet1);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        public void KitapEkle(string baslik, int turID, int yazarID) //kitap ekleme metodu
        {
            ac();
            try
            {
                dataSet7.Clear();
                dataAdapter10.SelectCommand.CommandText = "insert into Kitap (baslik,turID, yazarID, durum) values ('" + baslik + "','" + turID + "','" + yazarID + "' , 0)";
                dataAdapter10.Fill(dataSet7);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        public void Kitap() //kitap yazar ve yayinevi bilgisini getiren metod
        {
            ac();
            try
            {
                dataSet15.Clear();
                datatable3.Clear();
                dataAdapter8.SelectCommand.CommandText = "  select Kitap.kitapID, Kitap.baslik, CONCAT(Yazar.adi,' ', Yazar.soyadi) as yazar, Tur.tur,Kitap.durum from Kitap, Yazar, Tur where Kitap.yazarID = Yazar.yazarID and Kitap.turID = Tur.turID";
                dataAdapter8.Fill(datatable3);
                dataAdapter8.Fill(tumKitap.dase);
                dataAdapter8.Fill(verilebilir_kitaplar.datasett);
                dataAdapter8.Fill(verilemez_kitaplar.datasett);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        public void KitapSil() // kitap silme metodu
        {
            ac();
            try
            {
                dataSet8.Clear();
                dataAdapter11.SelectCommand.CommandText = "delete from Kitap where kitapID='" + satinAlma.id + "'";
                dataAdapter11.Fill(dataSet8);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        public void KitapGuncelle(string baslik, int turID, int yazarID) //kitap guncelleme metodu
        {
            ac();
            try
            {
                dataSet9.Clear();
                dataAdapter12.SelectCommand.CommandText = "update Kitap set baslik = '" + baslik + "' , turID = '" + turID + "' , yazarID = '" + yazarID + "' where kitapID = '" + satinAlma.id + "'";
                dataAdapter12.Fill(dataSet9);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        public Boolean VerilmemisKitap(int ogrNo)//iliski kesilirken kitap varsa!
        {
            ac();
            try
            {
                dataSet11.Clear();
                dataAdapter16.SelectCommand.CommandText = "select * from OgrenciKitapPersonel where ogrenciID = '" + ogrNo + "'  and geri_geldimi = 0";
                dataAdapter16.Fill(dataSet11);
                if (dataSet11.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        public void KitapAl(int ogrid, int kitapid)//odunc verilen kitabı geri alma metodu
        {
            ac();
            try
            {
                dataSet13.Clear();
                dataAdapter20.SelectCommand.CommandText = "update OgrenciKitapPersonel set geri_geldimi = 1 where ogrenciID = '" + ogrid + "' and kitapID = '" + kitapid + "' and geri_geldimi = 0";
                GuncelleAlma(kitapid);
                dataAdapter20.Fill(dataSet13);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        public void OduncVer(int ogrid, int kitapid) //arkada trigger var (oduncverupdate)
        {
            ac();
            try
            {
                dataSet12.Clear();
                dataAdapter19.SelectCommand.CommandText = "insert into OgrenciKitapPersonel (ogrenciID, kitapID, personelID,alma_tarihi,verme_tarihi,geri_geldimi) values ('" + ogrid + "','" + kitapid + "','" + main.id + "','" + DateTime.Now + "','" + DateTime.Now.AddDays(5) + "',0)";
                GuncelleVerme(kitapid);
                dataAdapter19.Fill(dataSet12);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        public void GuncelleVerme(int kitapID)
        {
            dataSet16.Clear();
            dataAdapter27.SelectCommand.CommandText = "update Kitap set durum = 0 where KitapID = '"+kitapID+"'";
            dataAdapter27.Fill(dataSet16);
        }

        public void GuncelleAlma(int kitapID)
        {
            dataSet16.Clear();
            dataAdapter27.SelectCommand.CommandText = "update Kitap set durum = 1 where KitapID = '" + kitapID + "'";
            dataAdapter27.Fill(dataSet16);
        }
        #endregion


        #region Yazar islemleri
        public void YazarEkle(string ad, string soyad, string tel, int yas, int yayin) //yazar ekleme metodu (SP)
        {
            ac();
            try
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("YazarEkle", baglanti);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("adi", SqlDbType.NVarChar, 50).Value = ad; //Stored proceduredeki parametrelere
                cmd.Parameters.Add("soyadi", SqlDbType.NVarChar, 50).Value = soyad; // textboxlardan değerleri
                cmd.Parameters.Add("tel", SqlDbType.NVarChar, 50).Value = tel; //alıyoruz.
                cmd.Parameters.Add("yas", SqlDbType.Int).Value = yas;
                cmd.Parameters.Add("yayinid", SqlDbType.Int).Value = yayin;
                cmd.ExecuteNonQuery();
                baglanti.Close();
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        public void Yazar()// yazar ve yayinevini getiren metod
        {
            ac();
            try
            {
                dataAdapter2.SelectCommand.CommandText = " select Yazar.adi,Yazar.soyadi , Yazar.telefon, Yazar.yas ,YayinEvi.yayinevi_ad from (Yazar inner join YayinEvi on Yazar.yayineviID = YayinEvi.yayineviID) ";
                dataAdapter2.Fill(datatable2);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        public void YazarSil(string ad, string soyad) //yazar silme islemi icin gerekli metod
        {
            ac();
            try
            {
                dataSet4.Clear();
                dataAdapter4.SelectCommand.CommandText = "delete from Yazar where yazarID = (select yazarID from Yazar where adi = '" + ad + "' and soyadi = '" + soyad + "')";
                dataAdapter4.Fill(dataSet4);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        public void YazarGüncelle(string adi, string soyadi, string telefon, int yas, int yayinid) //yazar guncelleme icin gerekli metod
        {
            ac();
            try
            {
                dataSet3.Clear();
                dataAdapter3.SelectCommand.CommandText = "update Yazar set adi = '" + adi + "' , soyadi = '" + soyadi + "' , telefon = '" + telefon + "' , yas ='" + yas + "' , yayineviID = '" + yayinid + "' where yazarID = (select yazarID from Yazar where adi = '" + satinAlma.yazarad + "' and soyadi = '" + satinAlma.yazarsoyad + "')  ";
                dataAdapter3.Fill(dataSet3);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }

        #endregion

        #region YayinEvi islemleri
        public void YayinEkle(string ad, DateTime tarih) //yayinvi ekleyen metod
        {
            ac();
            try
            {
                dataSet6.Clear();
                dataAdapter7.SelectCommand.CommandText = "insert into YayinEvi (yayinevi_ad, kurulus) values ('" + ad + "','" + tarih + "')";
                dataAdapter7.Fill(dataSet6);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        public void YayinEvi() //yayinevlerini getiren metod
        {
            ac();
            try
            {
                dataAdapter6.SelectCommand.CommandText = "select yayinevi_ad, kurulus from YayinEvi";
                dataAdapter6.Fill(datatable1);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        public void YayinSil(string ad) //yayinevi silen metod
        {
            ac();
            try
            {
                dataSet6.Clear();
                dataAdapter6.SelectCommand.CommandText = "delete from YayinEvi where yayinevi_ad = '" + ad + "'";
                dataAdapter6.Fill(dataSet6);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }
        public void YayinGuncelle(string ad) //yayinevi guncelleyen metod
        {
            ac();
            try
            {
                dataSet5.Clear();
                dataAdapter5.SelectCommand.CommandText = "update YayinEvi set yayinevi_ad = '" + ad + "' where yayinevi_ad = '" + satinAlma.yayinevi + "'";
                dataAdapter5.Fill(dataSet5);
            }
            catch (Exception e)
            {
                dosyaYaz(dosyaYolu, e);
                throw;
            }
            finally
            {
                kapat();
            }
        }

        #endregion


        public Dbislem() //nesne olustugunda baglanti ve diger islemlerin olusması
        {
            dataAdapter1.SelectCommand = SelectCommand1;
            SelectCommand1.Connection = baglanti;

            dataAdapter2.SelectCommand = SelectCommand2;
            SelectCommand2.Connection = baglanti;

            dataAdapter3.SelectCommand = SelectCommand3;
            SelectCommand3.Connection = baglanti;

            dataAdapter4.SelectCommand = SelectCommand4;
            SelectCommand4.Connection = baglanti;

            dataAdapter5.SelectCommand = SelectCommand5;
            SelectCommand5.Connection = baglanti;

            dataAdapter6.SelectCommand = SelectCommand6;
            SelectCommand6.Connection = baglanti;

            dataAdapter7.SelectCommand = SelectCommand7;
            SelectCommand7.Connection = baglanti;

            dataAdapter8.SelectCommand = SelectCommand8;
            SelectCommand8.Connection = baglanti;

            dataAdapter9.SelectCommand = SelectCommand9;
            SelectCommand9.Connection = baglanti;

            dataAdapter10.SelectCommand = SelectCommand10;
            SelectCommand10.Connection = baglanti;

            dataAdapter11.SelectCommand = SelectCommand11;
            SelectCommand11.Connection = baglanti;

            dataAdapter12.SelectCommand = SelectCommand12;
            SelectCommand12.Connection = baglanti;

            dataAdapter13.SelectCommand = SelectCommand13;
            SelectCommand13.Connection = baglanti;

            dataAdapter14.SelectCommand = SelectCommand14;
            SelectCommand14.Connection = baglanti;

            dataAdapter15.SelectCommand = SelectCommand15;
            SelectCommand15.Connection = baglanti;

            dataAdapter16.SelectCommand = SelectCommand16;
            SelectCommand16.Connection = baglanti;

            dataAdapter17.SelectCommand = SelectCommand17;
            SelectCommand17.Connection = baglanti;

            dataAdapter18.SelectCommand = SelectCommand18;
            SelectCommand18.Connection = baglanti;

            dataAdapter19.SelectCommand = SelectCommand19;
            SelectCommand19.Connection = baglanti;

            dataAdapter20.SelectCommand = SelectCommand20;
            SelectCommand20.Connection = baglanti;

            dataAdapter21.SelectCommand = SelectCommand21;
            SelectCommand21.Connection = baglanti;

            dataAdapter22.SelectCommand = SelectCommand22;
            SelectCommand22.Connection = baglanti;

            dataAdapter23.SelectCommand = SelectCommand23;
            SelectCommand23.Connection = baglanti;

            dataAdapter24.SelectCommand = SelectCommand24;
            SelectCommand24.Connection = baglanti;

            dataAdapter25.SelectCommand = SelectCommand25;
            SelectCommand25.Connection = baglanti;

            dataAdapter26.SelectCommand = SelectCommand26;
            SelectCommand26.Connection = baglanti;

            dataAdapter27.SelectCommand = SelectCommand27;
            SelectCommand27.Connection = baglanti;

            //veri tabani baglantisi
            string connection_string = "Data Source=10.194.45.152;Initial Catalog=Kutuphane;Persist Security Info=True;User ID=admin;Password=1234";
            baglanti.ConnectionString = connection_string;
        }
        #region Close- Open
        public void kapat()  // baglanti kapat
        {
            baglanti.Close();
        }
        public void ac() //baglanti ac
        {
            baglanti.Open();
        }
        #endregion

        public void dosyaYaz(string dosyaYolu, Exception e)
        {
            using (StreamWriter writer = new StreamWriter(dosyaYolu, true))
            {
                writer.WriteLine("---------------");
                writer.WriteLine("date : " + DateTime.Now.ToString());
                writer.WriteLine("");

                if (e != null)
                {
                    writer.WriteLine(e.GetType().FullName);
                    writer.WriteLine("Message : " + e.Message);
                }
            }
        }


    }
}
