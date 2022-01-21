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
    public partial class FRM_FATURADETAY : Form
    {
        public FRM_FATURADETAY()
        {
            InitializeComponent();
        }
        OracleBaglanti con = new OracleBaglanti();
        
        public string id;
        void listele()
        {
            DataTable dt = new DataTable();
           OracleDataAdapter da = new OracleDataAdapter("Select * From TBL_FATURADETAY where FATURAID ='" + id + "'", con.Baglanti());// ÖNEMLİ
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void FRM_FATURADETAY_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            FRMFATURADÜZENLEME frm1 = new FRMFATURADÜZENLEME();
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            if (sec != null)
            {

                frm1.urunId= dataGridView1.Rows[sec].Cells[0].Value.ToString();

            }
            frm1.Show();



          
        }
    }
}
