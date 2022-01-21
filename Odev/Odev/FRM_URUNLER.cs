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
namespace Odev
{
    public partial class FRM_URUNLER : Form
    {
        public FRM_URUNLER()
        {
            InitializeComponent();
        }
        OracleBaglanti baglan = new OracleBaglanti();
        void listele()
        {
            DataTable dt = new DataTable(); // data table olusturdum
            OracleDataAdapter da = new OracleDataAdapter("Select * From TBL_URUNLER",baglan.Baglanti()); //sorguyu bağlantıya yolladım
            da.Fill(dt); // data table ı data adapterden gelenlerle doldur
            dataGridView1.DataSource = dt; // grid kontrol dt yle dolsun



        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {// verileri kaydetme/ekleme
            //int p1 = Int32.Parse();
                
           OracleCommand komut = new OracleCommand("insert into TBL_URUNLER(URUN_AD,MARKA,MODELL,YIL,ADET,ALIS_FIYAT,SATIS_FIYAT,DETAY)" +
                " values(:p1,:p2,:p3,:p4,:p5,:p6,:p7,:p8)", baglan.Baglanti()); // komutu gönderdim
          //  komut.Parameters.Add(":p0", TxtID.Text);
            komut.Parameters.Add(":p1", TxtAd.Text);
            komut.Parameters.Add(":p2", TxtMarka.Text);
            komut.Parameters.Add(":p3", TxtModel.Text);
            komut.Parameters.Add(":p4", MskYil.Text);
            komut.Parameters.Add(":p5", NudAdet.Text);
            komut.Parameters.Add(":p6", TxtAlisFiyat.Text);
           komut.Parameters.Add(":p7", TxtSatisFiyat.Text);
            komut.Parameters.Add(":p8", RchDetay.Text);

            komut.ExecuteNonQuery();
            baglan.Baglanti().Close();
            MessageBox.Show("Ürün sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();    
            
            
            //yaklaşık 3 saatim


            // verileri kaydetme/ekleme
            //OracleCommand komut = new OracleCommand("INSERT INTO TBL_URUNLER(id,URUN_AD,MARKA,MODELL,YIL,ADET,ALIS_FIYAT,SATIS_FIYAT,DETAY)" +
            // " values('" + TxtID.Text + "','" + TxtAd.Text+ "','" + TxtMarka.Text + "','" + TxtModel.Text + "','" + MskYil.Text + "' ,'" + int.Parse((NudAdet.Text).ToString()) + "','" + int.Parse(TxtAlisFiyat.Text) + "','" + int.Parse(TxtSatisFiyat.Text) + "','" + RchDetay.Text + "')", baglan.Baglanti());
            // komutu gönderdim
            //komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            //komut.Parameters.AddWithValue("@p2", TxtMarka.Text);
            //komut.Parameters.AddWithValue("@p3", TxtModel.Text);
            //komut.Parameters.AddWithValue("@p4", MskYil.Text);
            //komut.Parameters.AddWithValue("@p5", int.Parse((NudAdet.Value).ToString()));
            //komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtAlisFiyat.Text));
            //komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtSatisFiyat.Text));
            //komut.Parameters.AddWithValue("@p8", RchDetay.Text);
            //,ADET,ALIS_FIYAT,SATIS_FIYAT,DETAY
            // ,'" + int.Parse((NudAdet.Text).ToString()) + "','" + int.Parse(TxtAlisFiyat.Text) + "','" + int.Parse(TxtSatisFiyat.Text) + "','" + RchDetay.Text + "'
           // komut.ExecuteNonQuery();
            //baglan.Baglanti().Close();
            //MessageBox.Show("Ürün sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //listele();
           // temizle();
        }

        private void FRM_URUNLER_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        void temizle()
        {
            TxtID.Text = "";
            TxtAd.Text = "";
            TxtMarka.Text = "";
            TxtModel.Text = "";
            MskYil.Text = "";
            TxtAlisFiyat.Text = "";
            TxtSatisFiyat.Text = "";
            RchDetay.Text = "";
            NudAdet.Text = "0";
            // decimal degeri nullamaya bak

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand komutsil = new OracleCommand("Delete  From TBL_URUNLER where id = :p1",baglan.Baglanti());
            komutsil.Parameters.Add(":p1", TxtID.Text);
            komutsil.ExecuteNonQuery();
            baglan.Baglanti().Close();
            MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataRow dr = dataGridView1.GetDataRow(dataGridView1.FocusedRowHandle); // grid view de neye tıklanırsa onu getiren nesne 
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OracleCommand komut = new OracleCommand("update TBL_URUNLER set URUN_AD=:p1,MARKA =:p2,MODELL=:p3,YIL = :p4," +
                "ADET=:p5, ALIS_FIYAT=:p6, SATIS_FIYAT= :p7, DETAY =:p8 where id = :p9",baglan.Baglanti());
           
            komut.Parameters.Add(":p1", TxtAd.Text);
            komut.Parameters.Add(":p2", TxtMarka.Text);
            komut.Parameters.Add(":p3", TxtModel.Text);
            komut.Parameters.Add(":p4", MskYil.Text);
            komut.Parameters.Add(":p5", NudAdet.Text);
            komut.Parameters.Add(":p6", TxtAlisFiyat.Text);
            komut.Parameters.Add(":p7", TxtSatisFiyat.Text);
            komut.Parameters.Add(":p8", RchDetay.Text);
            komut.Parameters.Add(":p9", TxtID.Text);
            komut.ExecuteNonQuery();
            baglan.Baglanti().Close();
            MessageBox.Show("Ürün bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            TxtID.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
            TxtMarka.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
            TxtModel.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
            MskYil.Text = dataGridView1.Rows[sec].Cells[4].Value.ToString();
            NudAdet.Text = dataGridView1.Rows[sec].Cells[5].Value.ToString();
            TxtAlisFiyat.Text = dataGridView1.Rows[sec].Cells[6].Value.ToString();
            TxtSatisFiyat.Text = dataGridView1.Rows[sec].Cells[7].Value.ToString();
            RchDetay.Text = dataGridView1.Rows[sec].Cells[8].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string P1 = TxtAd.Text;
          
            DataTable dt = new DataTable(); // data table olusturdum
            OracleDataAdapter da = new OracleDataAdapter("Select * From TBL_URUNLER Where URUN_AD LIKE '" + P1 + "'", baglan.Baglanti()); //sorguyu bağlantıya yolladım
            da.Fill(dt); // data table ı data adapterden gelenlerle doldur
            dataGridView1.DataSource = dt; // grid kontrol dt yle dolsun

           // komut.ExecuteNonQuery();
            baglan.Baglanti().Close();
            MessageBox.Show("Aradığnız ürün bulundu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //listele();
            temizle();
        }
    }
}
