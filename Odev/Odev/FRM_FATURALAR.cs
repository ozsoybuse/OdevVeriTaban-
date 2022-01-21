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
    public partial class FRM_FATURALAR : Form
    {
        public FRM_FATURALAR()
        {
            InitializeComponent();
        }
        OracleBaglanti con = new OracleBaglanti();
        void listele()
        {
            DataTable dt = new DataTable(); // data table olusturdum
            OracleDataAdapter da = new OracleDataAdapter("Select * From TBL_FATURALAR", con.Baglanti()); //sorguyu bağlantıya yolladım
            da.Fill(dt); // data table ı data adapterden gelenlerle doldur
            dataGridView1.DataSource = dt; // grid kontrol dt yle dolsun



        }
        void temizle()
        {
            textId.Text = "";
            TxtSeri.Text = "";
            TxtSıraNo.Text = "";
            MskTarih.Text = "";
          //  MskSaat.Text = "";
           
            TxtAlıcı.Text = "";
            TxtTeslimEden.Text = "";
            TxtTeslimAlan.Text = "";
            TxtUrunId.Text = "";
            TxtUrunAd.Text = "";
            TxtMiktar.Text = "";
            TxtFiyat.Text = "";
            TxtTutar.Text = "";
            TxtTeslimEden.Text = "";
            TxtTeslimAlan.Text = "";
            TxtFaturaId.Text = "";


        }
        private void MskYetkiliTc_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtAlıcı_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void FRM_FATURALAR_Load(object sender, EventArgs e)
        {
            listele();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            textId.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            TxtSeri.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
           TxtSıraNo.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
            MskTarih.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
           // MskSaat.Text = dataGridView1.Rows[sec].Cells[4].Value.ToString();
            TxtAlıcı.Text = dataGridView1.Rows[sec].Cells[4].Value.ToString();

            TxtTeslimEden.Text = dataGridView1.Rows[sec].Cells[5].Value.ToString();
            TxtTeslimAlan.Text = dataGridView1.Rows[sec].Cells[6].Value.ToString();
        }

        private void MskTarih_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void BTNKAYDET_Click(object sender, EventArgs e)
        {
            if (TxtFaturaId.Text == "")
            {
                OracleCommand komut = new OracleCommand("insert into TBL_FATURALAR(SERI,SIRA_NO,TARIH,ALICI," +
                    "TESLIM_EDEN,TESLIM_ALAN) values(:p1,:p2,:p3,:p6,:p7,:p8)", con.Baglanti()); // komutu gönderdim

                komut.Parameters.Add(":p1", TxtSeri.Text);
                komut.Parameters.Add(":p2", TxtSıraNo.Text);
                komut.Parameters.Add(":p3", MskTarih.Text);
              //  komut.Parameters.Add("@p4", MskSaat.Text);
              //  komut.Parameters.Add("@p5", txtVergiDairesi.Text);
                komut.Parameters.Add(":p6", TxtAlıcı.Text);
                komut.Parameters.Add(":p7", TxtTeslimEden.Text);
                komut.Parameters.Add(":p8", TxtTeslimAlan.Text);

                komut.ExecuteNonQuery();
                con.Baglanti().Close();
                MessageBox.Show("Fatura bilgisi sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                temizle();

            }

            if (TxtFaturaId.Text != "")
            {
                double miktar, tutar, fiyat;
               
                fiyat = Convert.ToInt32(TxtFiyat.Text);
                miktar = Convert.ToInt32(TxtMiktar.Text);
                tutar = fiyat * miktar;
                TxtTutar.Text = tutar.ToString();

                OracleCommand komut2 = new OracleCommand("insert into TBL_FATURADETAY(URUN_AD,MIKTAR,FIYAT,TUTAR,FATURAID) values(:p1,:p2,:p3,:p4,:p5)", con.Baglanti()); // komutu gönderdim

                komut2.Parameters.Add(":p1", TxtUrunAd.Text);
                komut2.Parameters.Add(":p2", TxtMiktar.Text);
                komut2.Parameters.Add(":p3", TxtFiyat.Text);
                komut2.Parameters.Add(":p4", TxtTutar.Text);
                komut2.Parameters.Add(":p5", TxtFaturaId.Text);
                komut2.ExecuteNonQuery();
                con.Baglanti().Close();
                MessageBox.Show("Fatura detay bilgisi sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                temizle();



            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
         

            FRM_FATURADETAY FRM = new FRM_FATURADETAY();

            int sec = dataGridView1.SelectedCells[0].RowIndex;

            if (sec != null)
            {

                FRM.id = dataGridView1.Rows[sec].Cells[0].Value.ToString();

            }
            FRM.Show();




        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand komutsil = new OracleCommand("Delete  From TBL_FATURALAR where id = :p1", con.Baglanti());
            komutsil.Parameters.Add(":p1", textId.Text);
            komutsil.ExecuteNonQuery();
            con.Baglanti().Close();
            MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OracleCommand komut = new OracleCommand("update TBL_FATURALAR set SERI=:p1,SIRA_NO=:p2,TARIH=:p3,ALICI=:p6," +
                    "TESLIM_EDEN=:p7,TESLIM_ALAN=:p8 where id=:p9 ",con.Baglanti());

            komut.Parameters.Add(":p1", TxtSeri.Text);
            komut.Parameters.Add(":p2", TxtSıraNo.Text);
            komut.Parameters.Add(":p3", MskTarih.Text);
            komut.Parameters.Add(":p6", TxtAlıcı.Text);
            komut.Parameters.Add(":p7", TxtTeslimEden.Text);
            komut.Parameters.Add(":p8", TxtTeslimAlan.Text);
            komut.Parameters.Add(":p9", textId.Text);
            komut.ExecuteNonQuery();
            con.Baglanti().Close();

            MessageBox.Show("Fatura bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
