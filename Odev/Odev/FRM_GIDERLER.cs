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
    public partial class FRM_GIDERLER : Form
    {
        OracleBaglanti con = new OracleBaglanti();
        void listele()
        {
            DataTable dt = new DataTable(); // data table olusturdum
            OracleDataAdapter da = new OracleDataAdapter("Select * From TBL_GİDERLER", con.Baglanti()); //sorguyu bağlantıya yolladım
            da.Fill(dt); // data table ı data adapterden gelenlerle doldur
            dataGridView1.DataSource = dt; // grid kontrol dt yle dolsun



        }
        void temizle()
        {
            Cmay.Text = "";
            Cmyıl.Text = "";
            TxtElektrik.Text = "";
           TxtSu.Text = "";
           TxtDogalgaz.Text = "";
            Txtİnternet.Text = "";
            TxtEkstra.Text = "";
            TxtMaas.Text = "";
            RchNotlar.Text = "";
            txtId.Text = "";


        }
        public FRM_GIDERLER()
        {
            InitializeComponent();
        }

        private void FRM_GIDERLER_Load(object sender, EventArgs e)
        {
            listele();
                
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand komut = new OracleCommand("insert into TBL_GİDERLER(AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EXTRA,NOTLAR )" +
                               " values(:p1,:p2,:p3,:p4,:p5,:p6,:p7,:p8,:p9)", con.Baglanti()); // komutu gönderdim
            komut.Parameters.Add(":p1", Cmay.Text);
            komut.Parameters.Add(":p2", Cmyıl.Text);
            komut.Parameters.Add(":p3", TxtElektrik.Text);
            komut.Parameters.Add(":p4", TxtSu.Text);
            komut.Parameters.Add(":p5", TxtDogalgaz.Text);
            komut.Parameters.Add(":p6", Txtİnternet.Text);
            komut.Parameters.Add(":p7", TxtMaas.Text);
            komut.Parameters.Add(":p8", TxtEkstra.Text);
            komut.Parameters.Add(":p9", RchNotlar.Text);
            komut.ExecuteNonQuery();
            con.Baglanti().Close();
            MessageBox.Show("Gider bilgisi sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
           txtId.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            Cmay.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
            Cmyıl.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
            TxtElektrik.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
           TxtSu.Text = dataGridView1.Rows[sec].Cells[4].Value.ToString();
          TxtDogalgaz.Text = dataGridView1.Rows[sec].Cells[5].Value.ToString();
           Txtİnternet.Text = dataGridView1.Rows[sec].Cells[6].Value.ToString();
           TxtMaas.Text = dataGridView1.Rows[sec].Cells[7].Value.ToString();
            TxtEkstra.Text = dataGridView1.Rows[sec].Cells[8].Value.ToString();
            RchNotlar.Text = dataGridView1.Rows[sec].Cells[9].Value.ToString();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //OracleCommand komutsil = new OracleCommand("Delete  From TBL_GİDERLER where id = :p1", con.Baglanti());
            //komutsil.Parameters.Add(":p1", txtId.Text);
            //komutsil.ExecuteNonQuery();
            //con.Baglanti().Close();
            //MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //listele();
            //temizle();
           // int p1 = Int32.Parse(txtId.Text);
            OracleCommand komutsil = new OracleCommand(" Exec DELETE_GİDERLER2(:p1)", con.Baglanti());
            komutsil.CommandType = CommandType.StoredProcedure;
            komutsil.Parameters.Add(":p1", Cmay.Text);
            con.Baglanti().Close();
            MessageBox.Show("Müşteri silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OracleCommand komut = new OracleCommand("update TBL_GİDERLER set AY=:p1,YIL=:p2,ELEKTRIK=:p3,SU=:p4,DOGALGAZ=:p5" +
               ",INTERNET =:p6,MAASLAR=:p7,EXTRA=:p8,NOTLAR=:p9 where id = :p10", con.Baglanti());
            komut.Parameters.Add(":p1", Cmay.Text);
            komut.Parameters.Add(":p2", Cmyıl.Text);
            komut.Parameters.Add(":p3", TxtElektrik.Text);
            komut.Parameters.Add(":p4", TxtSu.Text);
            komut.Parameters.Add(":p5", TxtDogalgaz.Text);
            komut.Parameters.Add(":p6", Txtİnternet.Text);
            komut.Parameters.Add(":p7", TxtMaas.Text);
            komut.Parameters.Add(":p8", TxtEkstra.Text);
            komut.Parameters.Add(":p9", RchNotlar.Text);
            komut.Parameters.Add(":p10", txtId.Text);
            komut.ExecuteNonQuery();
            con.Baglanti().Close();
            MessageBox.Show("Gider bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            temizle();
                
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            

        }
    }
}
