using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using System.Xml;
namespace Odev
{
    public partial class Form1 : Form
    {
        OracleBaglanti baglan = new OracleBaglanti();

        public Form1()
        {
            InitializeComponent();
        }
        void stoklistele()
        {

            OracleDataAdapter da = new OracleDataAdapter("Select URUN_AD,Sum(ADET) From TBL_URUNLER  group by URUN_AD having Sum(ADET) <=150 order by Sum(ADET) ", baglan.Baglanti());

            DataTable dt = new DataTable(); // data table olusturdum

            da.Fill(dt); // data table ı data adapterden gelenlerle doldur
            dataGridView1.DataSource = dt; // grid kontrol dt yle dolsun



        }
        void firmahareketler()
        {
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter("SELECT HAREKET_ID,URUN_AD,TBL_FIRMAHAREKETLER.ADET,(TBL_PERSONELLER.AD || ' ' || TBL_PERSONELLER.SOYAD) AS PERSONEL ,TBL_FIRMAHAREKETLER.FIYAT, TBL_FIRMALAR.FIRMA_ADI FROM TBL_FIRMAHAREKETLER INNER JOIN TBL_URUNLER ON  TBL_FIRMAHAREKETLER.URUN_ID = TBL_URUNLER.ID INNER JOIN TBL_FIRMALAR ON  TBL_FIRMAHAREKETLER.FIRMA_ID = TBL_FIRMALAR.ID INNER JOIN TBL_PERSONELLER ON TBL_FIRMAHAREKETLER.PERSONEL = TBL_PERSONELLER.ID ", baglan.Baglanti());// ÖNEMLİ
            da.Fill(dt);
            dataGridView7.DataSource = dt;




        }
        void fihrist()
        {
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter("Select FIRMA_ADI, TELEFON FROM TBL_FIRMALAR", baglan.Baglanti());// ÖNEMLİ
            da.Fill(dt);
            dataGridView10.DataSource = dt;



        }
        void ajanda()
        {
            OracleDataAdapter da = new OracleDataAdapter("Select  TARIH,SAAT,BASLIK From TBL_NOTLAR  order by id desc fetch  first 10 rows only", baglan.Baglanti());

            DataTable dt = new DataTable(); // data table olusturdum

            da.Fill(dt); // data table ı data adapterden gelenlerle doldur
            dataGridView5.DataSource = dt; // grid kontrol dt yle dolsun




        }
        void haberler()
        {
            XmlTextReader xmlOku = new XmlTextReader("http://www.hurriyet.com.tr/rss/anasayfa");
            while (xmlOku.Read())
            {
                if (xmlOku.Name == "title")
                {
                    listBox1.Items.Add(xmlOku.ReadString());

                }


            }


        }
        public string ad;
        private void Form1_Load(object sender, EventArgs e)
        {
            lblaktifkull.Text = ad;
            //MUSTERİ SEHİR SAYISI

            OracleCommand komut7 = new OracleCommand("Select Count(Distinct(IL)) From TBL_MUSTERILER ", baglan.Baglanti());
            OracleDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {

                lblSehir2.Text = dr7[0].ToString();
                lblSehir2.Refresh();

            }
            baglan.Baglanti().Close();
            this.Refresh();
            //TOPLAM TUTAR
            OracleCommand komut = new OracleCommand("Select Sum(TUTAR) From TBL_FATURADETAY", baglan.Baglanti());
            OracleDataReader dr1 = komut.ExecuteReader();
            while (dr1.Read())
            {

                lblToplamTutar.Text = dr1[0].ToString() + "TL";


            }
            baglan.Baglanti().Close();


            //SON AYIN FATURALARI
            OracleCommand komut2 = new OracleCommand("Select (ELEKTRIK+SU+DOGALGAZ+INTERNET+EXTRA) From TBL_GİDERLER order by ID asc", baglan.Baglanti());
            OracleDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {

                lblOdemeler.Text = dr2[0].ToString() + "TL";


            }
            baglan.Baglanti().Close();


            //müşteri sayısı
            OracleCommand komut4 = new OracleCommand("Select Count(*) From TBL_MUSTERILER ", baglan.Baglanti());
            OracleDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {

                lblMusteriSayısı1.Text = dr4[0].ToString();


            }
            baglan.Baglanti().Close();
            //FİRMA SAYISI
            OracleCommand komut5 = new OracleCommand("Select Count(*) From TBL_FIRMALAR ", baglan.Baglanti());
            OracleDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {

                lblFirmaSayısı.Text = dr5[0].ToString();


            }
            baglan.Baglanti().Close();


            //FİRMa ŞEHİR SAYISI
            OracleCommand komut6 = new OracleCommand("Select Count(Distinct(IL)) From TBL_FIRMALAR ", baglan.Baglanti());
            OracleDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {

                lblSehirSayısı.Text = dr6[0].ToString();


            }
            baglan.Baglanti().Close();

            //PERSONEL SAYISI
            OracleCommand komut8 = new OracleCommand("Select Count(*) From TBL_PERSONELLER ", baglan.Baglanti());
            OracleDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {

                lblPersonel.Text = dr8[0].ToString();


            }
            baglan.Baglanti().Close();
            //STOK SAYISI

            OracleCommand komut9 = new OracleCommand("Select Sum(ADET) From TBL_URUNLER ", baglan.Baglanti());
            OracleDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {

                lblStok.Text = dr9[0].ToString();


            }
            baglan.Baglanti().Close();





            // bankagetir();
            stoklistele();
            ajanda();
            firmahareketler();
            fihrist();
           webBrowser1.Navigate("https://www.tcmb.gov.tr/wps/wcm/connect/tr/tcmb+tr/main+page+site+area/bugun");
            haberler();




        }

        void bankagetir()
        {


            /** DataTable dt = new DataTable(); // data table olusturdum
             OracleDataAdapter da = new OracleDataAdapter("Select * From PROPERTIES ", baglan.Baglanti()); //sorguyu bağlantıya yolladım
             da.Fill(dt); // data table ı data adapterden gelenlerle doldur
             dataGridView1.DataSource = dt; // grid kontrol dt yle dolsun
            */


        }
        

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            FRMBANKALAR FRM2 = new FRMBANKALAR();
            FRM2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FRM_URUNLER FRM2 = new FRM_URUNLER();
            FRM2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FRMMUSTERİLER FRM3 = new FRMMUSTERİLER();
            FRM3.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FRMPERSONELLER FRM4 = new FRMPERSONELLER();
            FRM4.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FRMFİRMALAR FRM5 = new FRMFİRMALAR();
            FRM5.ShowDialog();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            FRMREHBER FRM6 = new FRMREHBER();
            FRM6.ShowDialog();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            FRMNOTLAR FRM6 = new FRMNOTLAR();
            FRM6.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            FRM_GIDERLER FRM6 = new FRM_GIDERLER();
            FRM6.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FRM_STOKLAR FRM6 = new FRM_STOKLAR();
            FRM6.ShowDialog();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            FRMAYARLAR FRM6 = new FRMAYARLAR();
            FRM6.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FRM_FATURALAR FRM6 = new FRM_FATURALAR();
            FRM6.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            FRMHAREKETLERR FRM6 = new FRMHAREKETLERR();
            FRM6.ShowDialog();
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            //this.Controls.Clear();
          
            Form1 frm = new Form1();
            this.InitializeComponent();
            frm.Refresh();
          
         

        }

        private void TOPP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FRM_FATURADETAY FRM = new FRM_FATURADETAY();
            FRM.Show();
        }

        private void odemee_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FRM_GIDERLER FRM = new FRM_GIDERLER();
            FRM.Show();
        }

        private void stoksay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           FRM_STOKLAR FRM = new FRM_STOKLAR();
            FRM.Show();
        }

        private void musteri_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FRMMUSTERİLER FRM = new FRMMUSTERİLER();
            FRM.Show();

        }

        private void firmasay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FRMFİRMALAR FRM5 = new FRMFİRMALAR();
            FRM5.ShowDialog();
        }

        private void personel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FRMPERSONELLER FRM4 = new FRMPERSONELLER();
            FRM4.ShowDialog();
        }

        private void firmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FRMFİRMALAR FRM5 = new FRMFİRMALAR();
            FRM5.ShowDialog();

        }

        private void musteriil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FRMMUSTERİLER FRM3 = new FRMMUSTERİLER();
            FRM3.ShowDialog();
        }
    }
}
