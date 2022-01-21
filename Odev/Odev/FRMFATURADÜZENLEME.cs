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
    public partial class FRMFATURADÜZENLEME : Form
    {
        public FRMFATURADÜZENLEME()
        {
            InitializeComponent();
        }
        OracleBaglanti con = new OracleBaglanti();
        public string urunId;
        private void FRMFATURADÜZENLEME_Load(object sender, EventArgs e)
        {
            txturunıd.Text = urunId;
            OracleCommand komut = new OracleCommand("Select * From TBL_FATURADETAY where FATURAURUNID=:p1", con.Baglanti());
            komut.Parameters.Add(":p1", urunId);
            OracleDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtfiyat.Text = dr[3].ToString();
                Txtmiktar.Text = dr[2].ToString();
                txttutar.Text = dr[4].ToString();
                Txturunad.Text = dr[1].ToString();
                con.Baglanti().Close();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand komutsil = new OracleCommand("Delete  From TBL_URUNLER where id = :p1", con.Baglanti());
            komutsil.Parameters.Add(":p1", txturunıd.Text);
            komutsil.ExecuteNonQuery();
            con.Baglanti().Close();
            MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            OracleCommand komut = new OracleCommand("update TBL_FATURADETAY set URUN_AD=:p1, MIKTAR=:p2, FIYAT=:p3,TUTAR=:p4 where" +
             " FATURAID = :p5", con.Baglanti());
            komut.Parameters.Add(":p1",Txturunad.Text);
            komut.Parameters.Add(":p2", Convert.ToInt32(Txtmiktar.Text));
            komut.Parameters.Add(":p3",Convert.ToInt32(txtfiyat.Text));
            komut.Parameters.Add(":p4", Convert.ToInt32(txttutar.Text));
            komut.Parameters.Add(":p5", txturunıd.Text);
            komut.ExecuteNonQuery();
            con.Baglanti().Close();
            MessageBox.Show("Fatura detay bilgisi güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
