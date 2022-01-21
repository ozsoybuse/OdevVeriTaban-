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
    public partial class FRMBANKALAR : Form
    {
        OracleBaglanti con = new OracleBaglanti();
        public FRMBANKALAR()
        {
            InitializeComponent();
        }
        void listele()
        {
            DataTable dt = new DataTable(); // data table olusturdum
            OracleDataAdapter da = new OracleDataAdapter("Select * From TBL_BANKALAR", con.Baglanti()); //sorguyu bağlantıya yolladım
            da.Fill(dt); // data table ı data adapterden gelenlerle doldur
            dataGridView1.DataSource = dt; // grid kontrol dt yle dolsun



        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            TxtBankaAd.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
            Cmbil.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
          Cmbilce.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
            TxtSube.Text = dataGridView1.Rows[sec].Cells[4].Value.ToString();
            TxtIban.Text = dataGridView1.Rows[sec].Cells[5].Value.ToString();
            TxtHesapNo.Text = dataGridView1.Rows[sec].Cells[6].Value.ToString();
            TxtYetkili.Text = dataGridView1.Rows[sec].Cells[7].Value.ToString();
            MskTel.Text = dataGridView1.Rows[sec].Cells[8].Value.ToString();
           MskTarih.Text = dataGridView1.Rows[sec].Cells[9].Value.ToString();
        
        }

        void firmaListele()
        {
            DataTable dt = new DataTable(); //firma kısmına liste şeklşnde getiricez o yüzden data table
            OracleDataAdapter da = new OracleDataAdapter("Select id,FIRMA_ADI From TBL_FIRMALAR", con.Baglanti());
            da.Fill(dt);
           
            cmbfirma.ValueMember = "id";
            cmbfirma.DisplayMember = "FIRMA_ADI";
            cmbfirma.DataSource = dt;



        }

        private void FRMBANKALAR_Load(object sender, EventArgs e)
        {
            listele();
            firmaListele();
            SehirListesi();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand komut = new OracleCommand("insert into TBL_BANKALAR(BANKA_ADI,İL,İLCE, SUBE, İBAN,HESAP_NO,YETKILI,TELEFON,TARIH,FIRMA_ID)" +
                " values(:p1,:p2,:p3,:p4,:p5,:p6,:p7,:p8,:p9,:p11)", con.Baglanti()); // komutu gönderdim
            komut.Parameters.Add(":p1", TxtBankaAd.Text);
            komut.Parameters.Add(":p2", Cmbil.Text);
            komut.Parameters.Add(":p3", Cmbilce.Text);
            komut.Parameters.Add(":p4", TxtSube.Text);
            komut.Parameters.Add(":p5", TxtIban.Text);
            komut.Parameters.Add(":p6", TxtHesapNo.Text);
            komut.Parameters.Add(":p7", TxtYetkili.Text);
            komut.Parameters.Add(":p8", MskTel.Text);
            komut.Parameters.Add(":p9", MskTarih.Text);
           
            komut.Parameters.Add(":p11", cmbfirma.Text); /// secilen ıd karşılaştırdık
            komut.ExecuteNonQuery();
            con.Baglanti().Close();
            MessageBox.Show("Banka bilgisi sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }
        void temizle()
        {
            txtId.Text = "";
            TxtBankaAd.Text = "";
            Cmbil.Text = "";
            Cmbilce.Text = "";
            TxtSube.Text = "";
            TxtIban.Text = "";
            TxtHesapNo.Text = "";
            TxtYetkili.Text = "";
            MskTel.Text = "";
            MskTarih.Text = "";
           
            cmbfirma.Text = "";



        }

        private void button2_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand komutsil = new OracleCommand("Delete  From TBL_BANKALAR where id = :p1", con.Baglanti());
            komutsil.Parameters.Add(":p1", txtId.Text);
            komutsil.ExecuteNonQuery();
            con.Baglanti().Close();
            MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           OracleCommand komut = new OracleCommand("update TBL_BANKALAR set BANKA_ADI=:p1 , İL =:p2,İLCE =:p3,SUBE = :p4," +
                "İBAN=:p5, HESAP_NO=:p6, YETKILI= :p7,TELEFON =:p8 ,TARIH =:p9, FIRMA_ID=:p11 where id = :p12", con.Baglanti());
            komut.Parameters.Add(":p1", TxtBankaAd.Text);
            komut.Parameters.Add(":p2", Cmbil.Text);
            komut.Parameters.Add(":p3", Cmbilce.Text);
            komut.Parameters.Add(":p4", TxtSube.Text);
            komut.Parameters.Add(":p5", TxtIban.Text);
            komut.Parameters.Add(":p6", TxtHesapNo.Text);
            komut.Parameters.Add(":p7", TxtYetkili.Text);
            komut.Parameters.Add(":p8", MskTel.Text);
            komut.Parameters.Add(":p9", MskTarih.Text);

            komut.Parameters.Add(":p11", cmbfirma.Text);
            komut.Parameters.Add(":p12", txtId.Text);
            komut.ExecuteNonQuery();
            con.Baglanti().Close();
            MessageBox.Show("Banka bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
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

        private void Cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cmbilce.Items.Clear(); // ÖNCEKİ İLCELERİ TEMİZLER
            OracleCommand komut = new OracleCommand("Select ISIM From ILCELER where IL_NO =:p1", con.Baglanti());
            komut.Parameters.Add(":p1", Cmbil.SelectedIndex + 1); // sehir indeksi secildiginde
            OracleDataReader rd = komut.ExecuteReader(); // okuma komutu
            while (rd.Read())
            {
                Cmbilce.Items.Add(rd[0]); // okuduğunun 0.  indeksini kaydet / yaz

            }
            con.Baglanti().Close();
        }
    }
}
