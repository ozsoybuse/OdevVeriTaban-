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
    public partial class FRMNOTLAR : Form
    {
        OracleBaglanti con= new OracleBaglanti();
        void listele()
        {
            DataTable dt = new DataTable(); // data table olusturdum
            OracleDataAdapter da = new OracleDataAdapter("Select * From TBL_NOTLAR",con.Baglanti()); //sorguyu bağlantıya yolladım
            da.Fill(dt); // data table ı data adapterden gelenlerle doldur
            dataGridView1.DataSource = dt; // grid kontrol dt yle dolsun



        }
        public FRMNOTLAR()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void MskYil_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void FRMNOTLAR_Load(object sender, EventArgs e)
        {
            listele();
        }
        void temizle()
        {
            MskTarih.Text = "";
            MskSaat.Text = "";
            TxtBaslık.Text = "";
            RchDetay.Text = "";
            TxtOlusturan.Text = "";
            TxtHitap.Text = "";
            TxtID.Text = "";


        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
           TxtID.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            MskTarih.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
            MskSaat.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
            TxtBaslık.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
            RchDetay.Text = dataGridView1.Rows[sec].Cells[4].Value.ToString();
            TxtOlusturan.Text = dataGridView1.Rows[sec].Cells[5].Value.ToString();
           
            TxtHitap.Text = dataGridView1.Rows[sec].Cells[6].Value.ToString();
           
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand komut = new OracleCommand("insert into TBL_NOTLAR(TARIH,SAAT,BASLIK,DETAY,OLUSTURAN,HITAP )" +
                "values(:p1,:p2,:p3,:p4,:p5,:p6)", con.Baglanti()); // komutu gönderdim
            komut.Parameters.Add(":p1", MskTarih.Text);
            komut.Parameters.Add(":p2", MskSaat.Text);
            komut.Parameters.Add(":p3", TxtBaslık.Text);
            komut.Parameters.Add(":p4", RchDetay.Text);
            komut.Parameters.Add(":p5", TxtOlusturan.Text);
            komut.Parameters.Add(":p6", TxtHitap.Text);

            komut.ExecuteNonQuery();
            con.Baglanti().Close();
            MessageBox.Show("Not sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand komutsil = new OracleCommand("Delete  From TBL_NOTLAR where id = :p1", con.Baglanti());
            komutsil.Parameters.Add(":p1", TxtID.Text);
            komutsil.ExecuteNonQuery();
           con.Baglanti().Close();
            MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OracleCommand komut = new OracleCommand("update TBL_NOTLAR set TARIH=:p1 , SAAT =:p2,BASLIK =:p3,DETAY = :p4," +
                "OLUSTURAN=:p5, HITAP=:p6 where ID = :p7", con.Baglanti());
            komut.Parameters.Add(":p1", MskTarih.Text);
            komut.Parameters.Add(":p2", MskSaat.Text);
            komut.Parameters.Add(":p3", TxtBaslık.Text);
            komut.Parameters.Add(":p4", RchDetay.Text);
            komut.Parameters.Add(":p5", TxtOlusturan.Text);
            komut.Parameters.Add(":p6", TxtHitap.Text);

            komut.Parameters.Add(":p7",TxtID.Text);
            komut.ExecuteNonQuery();
            con.Baglanti().Close();
            MessageBox.Show("Not bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            FRMNOTDETAY FRM = new FRMNOTDETAY();

            int sec = dataGridView1.SelectedCells[0].RowIndex;

            if (sec != null)
            {

                FRM.detay = dataGridView1.Rows[sec].Cells[4].Value.ToString();

            }
            FRM.Show();
        }
    }
}
