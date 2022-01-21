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
    public partial class FRMFİRMALAR : Form
    {
        OracleBaglanti con = new OracleBaglanti();
        void listele()
        {
            DataTable dt = new DataTable(); // data table olusturdum
            OracleDataAdapter da = new OracleDataAdapter("Select * From TBL_FIRMALAR", con.Baglanti()); //sorguyu bağlantıya yolladım
            da.Fill(dt); // data table ı data adapterden gelenlerle doldur
            dataGridView1.DataSource = dt; // grid kontrol dt yle dolsun

        }
        void SehirListesi()
        {
            OracleCommand komut = new OracleCommand("Select ISIM From ILLER", con.Baglanti());
            OracleDataReader rd = komut.ExecuteReader();
            while (rd.Read())
            {
                Cmbil.Items.Add(rd[0]); // okuduğunun 0.  indeksini kaydet

            }
            con.Baglanti().Close();

        }
        public FRMFİRMALAR()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            textId.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            textAd.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
            textYetkiliGorev.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
            textYetkili.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
            MskYetkiliTc.Text = dataGridView1.Rows[sec].Cells[4].Value.ToString();
            msktel.Text = dataGridView1.Rows[sec].Cells[5].Value.ToString();
            txtMail.Text = dataGridView1.Rows[sec].Cells[6].Value.ToString();
            mskfax.Text = dataGridView1.Rows[sec].Cells[7].Value.ToString();
            Cmbil.Text = dataGridView1.Rows[sec].Cells[8].Value.ToString();
            Cmbilce.Text = dataGridView1.Rows[sec].Cells[9].Value.ToString();
            RchAdres.Text = dataGridView1.Rows[sec].Cells[10].Value.ToString();
           
            txtKod1.Text = dataGridView1.Rows[sec].Cells[11].Value.ToString();
            textSektor.Text = dataGridView1.Rows[sec].Cells[12].Value.ToString();
        }

        private void FRMFİRMALAR_Load(object sender, EventArgs e)
        {
            listele();
            SehirListesi();
        }
        void temizle()    // giridileri temizliyoruz

        {
            textId.Text = "";
            textAd.Text = "";
            textYetkili.Text = "";
            textYetkiliGorev.Text = "";
            MskYetkiliTc.Text = "";
            textSektor.Text = "";
            msktel.Text = "";
           
            txtMail.Text = "";
            mskfax.Text = "";
            Cmbil.Text = "";
            Cmbilce.Text = "";
            
            RchAdres.Text = "";
            txtKod1.Text = "";
            
            //textAd.Focus();//imleci odakladı
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand komut = new OracleCommand("insert into TBL_FIRMALAR(FIRMA_ADI,YETKILI_STATU,YETKILI_ADSOYAD,TELEFON," +
                "MAIL,FAX,IL,ILCE,ADRES,YETKILI_TC,ÖZEL_KOD,SEKTOR)" +
                " values(:p1,:p2,:p3,:p4,:p7,:p8,:p9,:p10,:p12,:p13,:p14,:p17)", con.Baglanti()); // komutu gönderdim
          //  komut.Parameters.Add(":p0", textId.Text);
            komut.Parameters.Add(":p1", textAd.Text);
            komut.Parameters.Add(":p2", textYetkiliGorev.Text);
            komut.Parameters.Add(":p3", textYetkili.Text);
            komut.Parameters.Add(":p4", msktel.Text);
            
            komut.Parameters.Add(":p7", txtMail.Text);
            komut.Parameters.Add(":p8", mskfax.Text);
            komut.Parameters.Add(":p9", Cmbil.Text);
            komut.Parameters.Add(":p10", Cmbilce.Text);
           
            komut.Parameters.Add(":p12", RchAdres.Text);
            komut.Parameters.Add(":p13", MskYetkiliTc.Text);
            komut.Parameters.Add(":p14", txtKod1.Text);
         
            komut.Parameters.Add(":p17", textSektor.Text);
            komut.ExecuteNonQuery();
            con.Baglanti().Close();
            MessageBox.Show("Firma sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle(); // girdileri temizler
        }

        private void button2_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand komutsil = new OracleCommand("delete  From TBL_FIRMALAR where id = :p1", con.Baglanti());
            komutsil.Parameters.Add(":p1", textId.Text);
            komutsil.ExecuteNonQuery();
            con.Baglanti().Close();
            MessageBox.Show("Müşteri silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OracleCommand komut = new OracleCommand("update TBL_FIRMALAR set FIRMA_ADI=:p1 , YETKILI_STATU =:p2,YETKILI_ADSOYAD= :p3,TELEFON =:p4," +
                "MAIL =:p7,FAX=:p8,IL=:p9,ILCE=:p10,ADRES=:p12,YETKILI_TC=:p13," +
                "ÖZEL_KOD=:p14,SEKTOR=:p17 WHERE id = :p18", con.Baglanti());
            
            komut.Parameters.Add(":p1", textAd.Text);
            komut.Parameters.Add(":p2", textYetkiliGorev.Text);
            komut.Parameters.Add(":p3", textYetkili.Text);
            komut.Parameters.Add(":p4", msktel.Text);

            komut.Parameters.Add(":p7", txtMail.Text);
            komut.Parameters.Add(":p8", mskfax.Text);
            komut.Parameters.Add(":p9", Cmbil.Text);
            komut.Parameters.Add(":p10", Cmbilce.Text);

            komut.Parameters.Add(":p12", RchAdres.Text);
            komut.Parameters.Add(":p13", MskYetkiliTc.Text);
            komut.Parameters.Add(":p14", txtKod1.Text);

            komut.Parameters.Add(":p17", textSektor.Text);
            komut.Parameters.Add(":p18", textId.Text);
            komut.ExecuteNonQuery();
            con.Baglanti().Close();
            MessageBox.Show("Firma bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle(); // girdileri temizler
        }

        private void Cmbilce_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void Cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cmbilce.Items.Clear(); // ÖNCEKİ İLCELERİ TEMİZLER
            OracleCommand komut = new OracleCommand("Select ISIM From ILCELER where IL_NO =:p1", con.Baglanti());
            komut.Parameters.Add(":p1", Cmbil.SelectedIndex +1 ); // sehir indeksi secildiginde
            OracleDataReader rd = komut.ExecuteReader(); // okuma komutu
            while (rd.Read())
            {
                Cmbilce.Items.Add(rd[0]); // okuduğunun 0.  indeksini kaydet / yaz

            }
            con.Baglanti().Close();
        }
    }
}
