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
    public partial class FRM_STOKLAR : Form
    {
        public FRM_STOKLAR()
        {
            InitializeComponent();
        }
        OracleBaglanti con = new OracleBaglanti();
        
        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void FRM_STOKLAR_Load(object sender, EventArgs e)
        {
            
            OracleDataAdapter da = new OracleDataAdapter("Select URUN_AD , SUM(ADET) As Miktar From TBL_URUNLER  group by URUN_AD ", con.Baglanti());

            DataTable dt = new DataTable(); // data table olusturdum

            da.Fill(dt); // data table ı data adapterden gelenlerle doldur.
            dataGridView1.DataSource = dt; // grid kontrol dt yle dolsun

            // charta deger yazdırmqa
           OracleCommand komut = new OracleCommand("Select URUN_AD,Sum(ADET) As Miktar From TBL_URUNLER  group by URUN_AD ", con.Baglanti());
            OracleDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Series1"].Points.AddXY(dr[0], dr[1]);




            }
            con.Baglanti().Close();
            /// chart 2 il listeleme
            OracleCommand komut2 = new OracleCommand("Select IL,Count(*)  From TBL_FIRMALAR  group by IL ", con.Baglanti());
            OracleDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Series1"].Points.AddXY(dr2[0], dr2[1]);


            }

            
            con.Baglanti().Close();
        }
    }
}
