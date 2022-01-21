using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
namespace Odev
{
    public partial class FRMHAREKETLERR : Form
    {
        public FRMHAREKETLERR()
        {
            InitializeComponent();
        }
        OracleBaglanti con = new OracleBaglanti();
        void firmahareketler()
        {
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter("SELECT HAREKET_ID,URUN_AD,TBL_FIRMAHAREKETLER.ADET,(TBL_PERSONELLER.AD || ' ' || TBL_PERSONELLER.SOYAD) AS PERSONEL ,TBL_FIRMAHAREKETLER.FIYAT,TBL_FIRMAHAREKETLER.TOPLAM, TBL_FIRMALAR.FIRMA_ADI,TBL_FIRMAHAREKETLER.TARIH FROM TBL_FIRMAHAREKETLER INNER JOIN TBL_URUNLER ON  TBL_FIRMAHAREKETLER.URUN_ID = TBL_URUNLER.ID INNER JOIN TBL_FIRMALAR ON  TBL_FIRMAHAREKETLER.FIRMA_ID = TBL_FIRMALAR.ID INNER JOIN TBL_PERSONELLER ON TBL_FIRMAHAREKETLER.PERSONEL = TBL_PERSONELLER.ID ", con.Baglanti());// ÖNEMLİ
            da.Fill(dt);
            dataGridView2.DataSource = dt;




        }
        void musterihareketler()
        {
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter("SELECT HAREKET_ID,URUN_AD,TBL_MUSTERIHAREKETLER.ADET," +
                "(TBL_MUSTERILER.AD || ' ' || TBL_MUSTERILER.SOYAD) AS AD_SOYAD, TBL_MUSTERIHAREKETLER.FIYAT," +
                " TBL_MUSTERIHAREKETLER.TOPLAM, TBL_MUSTERIHAREKETLER.FATURA_ID," +
                "TBL_MUSTERIHAREKETLER.TARIH,(TBL_PERSONELLER.AD || ' ' || TBL_PERSONELLER.SOYAD) AS PERSONEL" +
                " FROM TBL_MUSTERIHAREKETLER" +
                " INNER JOIN TBL_URUNLER" +
                " ON" +
                " TBL_MUSTERIHAREKETLER.URUN_ID = TBL_URUNLER.ID" +
                " INNER JOIN TBL_MUSTERILER " +
                "ON" +
                " TBL_MUSTERIHAREKETLER.MUSTERI = TBL_MUSTERILER.ID " +
                "INNER JOIN TBL_PERSONELLER " +
                "ON " +
                "TBL_MUSTERIHAREKETLER.PERSONEL = TBL_PERSONELLER.ID  ", con.Baglanti());// ÖNEMLİ
            da.Fill(dt);
            dataGridView1.DataSource = dt;




        }

        private void FRMHAREKETLERR_Load(object sender, EventArgs e)
        {
            musterihareketler();
            firmahareketler();

        }
    }
}
