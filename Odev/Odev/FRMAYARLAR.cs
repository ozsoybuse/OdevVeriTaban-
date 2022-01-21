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
    public partial class FRMAYARLAR : Form
    {
        OracleBaglanti con = new OracleBaglanti();
        public FRMAYARLAR()
        {
            InitializeComponent();
        }
        void listele()
        {
            DataTable dt = new DataTable(); // data table olusturdum
            OracleDataAdapter da = new OracleDataAdapter("Select * From TBL_ADMIN", con.Baglanti()); //sorguyu bağlantıya yolladım
            da.Fill(dt); // data table ı data adapterden gelenlerle doldur
            dataGridView1.DataSource = dt; // grid kontrol dt yle dolsun



        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if(checkBox1.CheckState == CheckState.Unchecked)
            //{
            //    Txtsifre.UseSystemPasswordChar = true;


            //}
            //else if (checkBox1.CheckState == CheckState.Checked)
            //{

            //    Txtsifre.UseSystemPasswordChar = false;

            //}
        }

        private void FRMAYARLAR_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           OracleCommand komut = new OracleCommand("insert into TBL_ADMIN(KULLANICI_AD,SIFRE) values(:p1,:p2)", con.Baglanti());
            komut.Parameters.Add(":p1", txtkullad.Text);
            komut.Parameters.Add(":p2", Txtsifre.Text);
            komut.ExecuteNonQuery();
            con.Baglanti().Close();
            MessageBox.Show("Kullanıcı eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }


        private void button4_Click(object sender, EventArgs e)
        {
            OracleCommand komut2 = new OracleCommand("update TBL_ADMIN set KULLANICI_AD=:p1  ,SIFRE=:p2 where id= :p3", con.Baglanti());
            komut2.Parameters.Add(":p1", txtkullad.Text);
            komut2.Parameters.Add(":p2", Txtsifre.Text);
            komut2.Parameters.Add(":p3", TxtID.Text);
            komut2.ExecuteNonQuery();
            con.Baglanti().Close();
            MessageBox.Show("Kullanıcı güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            TxtID.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            txtkullad.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
            Txtsifre.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
           
        }
    }
}
