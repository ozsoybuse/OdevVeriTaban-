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
    public partial class FRMREHBER : Form
    {
       
        public FRMREHBER()
        {
            InitializeComponent();
        }
        OracleBaglanti con = new OracleBaglanti();

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FRMREHBER_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable(); // data table olusturdum
            OracleDataAdapter da = new OracleDataAdapter("Select  AD,SOYAD, TELEFON,MAIL From TBL_MUSTERILER", con.Baglanti()); //sorguyu bağlantıya yolladım
            da.Fill(dt); // data table ı data adapterden gelenlerle doldur
            dataGridView1.DataSource = dt; // grid kontrol dt yle dolsun

            DataTable dt1 = new DataTable(); // data table olusturdum
            OracleDataAdapter da1 = new OracleDataAdapter("Select  FIRMA_ADI,YETKILI_ADSOYAD, TELEFON,MAIL,FAX From TBL_FIRMALAR", con.Baglanti()); //sorguyu bağlantıya yolladım
            da1.Fill(dt1); // data table ı data adapterden gelenlerle doldur
            dataGridView2.DataSource = dt1; // grid kontrol dt yle dolsun
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            FRM_MAİL FRM = new FRM_MAİL();

            int sec = dataGridView1.SelectedCells[0].RowIndex;

            if (sec != null)
            {

                FRM.mail = dataGridView1.Rows[sec].Cells[3].Value.ToString();

            }
            FRM.Show();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            FRM_MAİL FRM = new FRM_MAİL();

            int sec = dataGridView2.SelectedCells[0].RowIndex;

            if (sec != null)
            {

                FRM.mail = dataGridView2.Rows[sec].Cells[3].Value.ToString();

            }
            FRM.Show();

        }
    }
}
