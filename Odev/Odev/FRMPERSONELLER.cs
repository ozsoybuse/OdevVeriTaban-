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
    public partial class FRMPERSONELLER : Form
    {
        OracleBaglanti con = new OracleBaglanti();
        void listele()
        {
            DataTable dt = new DataTable(); // data table olusturdum
            OracleDataAdapter da = new OracleDataAdapter("Select * From TBL_PERSONELLER", con.Baglanti()); //sorguyu bağlantıya yolladım
            da.Fill(dt); // data table ı data adapterden gelenlerle doldur
            dataGridView1.DataSource = dt; // grid kontrol dt yle dolsun

        }
        public FRMPERSONELLER()
        {
            InitializeComponent();
        }

        private void FRMPERSONELLER_Load(object sender, EventArgs e)
        {
            listele();
            SehirListesi();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand komut = new OracleCommand("insert into TBL_PERSONELLER(AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV)" +
                    " values(:p1,:p2,:p3,:p5,:p6,:p7,:p8,:p9,:p10)", con.Baglanti()); // komutu gönderdim
           // komut.Parameters.Add(":p0", txtId.Text);
            komut.Parameters.Add(":p1", TxtAd.Text);
            komut.Parameters.Add(":p2", TxtSoyad.Text);
            komut.Parameters.Add(":p3", MskTel1.Text);

            komut.Parameters.Add(":p5", MskTc.Text);
            komut.Parameters.Add(":p6", TxtMail.Text);
            komut.Parameters.Add(":p7", Cmbil.Text);
            komut.Parameters.Add(":p8", Cmbilce.Text);
            komut.Parameters.Add(":p9", RchAdres.Text);
            komut.Parameters.Add(":p10", TxtPerGorev.Text);
            komut.ExecuteNonQuery();
            con.Baglanti().Close();
            MessageBox.Show("Personel sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
             temizle();
        }
        void temizle()
        {
            txtId.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            MskTel1.Text = "";
            MskTc.Text = "";
            TxtMail.Text = "";
            Cmbil.Text = "";
            Cmbilce.Text = "";
            RchAdres.Text = "";
            TxtPerGorev.Text = "";


        }
        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand komutsil = new OracleCommand("Delete  From TBL_PERSONELLER where id = :p1", con.Baglanti());
            komutsil.Parameters.Add(":p1", txtId.Text);
            komutsil.ExecuteNonQuery();
            con.Baglanti().Close();
            MessageBox.Show("Müşteri silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            temizle();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OracleCommand komut = new OracleCommand("update TBL_PERSONELLER set AD=:p1 , SOYAD =:p2,TELEFON =:p3," +
                "TC=:p5, MAIL=:p6, IL= :p7,ILCE =:p8 ,ADRES =:p9,GOREV =:p10 where id = :p0", con.Baglanti());

            komut.Parameters.Add(":p1", TxtAd.Text);
            komut.Parameters.Add(":p2", TxtSoyad.Text);
            komut.Parameters.Add(":p3", MskTel1.Text);

            komut.Parameters.Add(":p5", MskTc.Text);
            komut.Parameters.Add(":p6", TxtMail.Text);
            komut.Parameters.Add(":p7", Cmbil.Text);
            komut.Parameters.Add(":p8", Cmbilce.Text);
            komut.Parameters.Add(":p9", RchAdres.Text);
           
            komut.Parameters.Add(":p10", TxtPerGorev.Text);
            komut.Parameters.Add(":p0", txtId.Text);
            komut.ExecuteNonQuery();
            con.Baglanti().Close();
            MessageBox.Show("Müşteri bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
            MskTel1.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
            MskTc.Text = dataGridView1.Rows[sec].Cells[4].Value.ToString();
            TxtMail.Text = dataGridView1.Rows[sec].Cells[5].Value.ToString();
            Cmbil.Text = dataGridView1.Rows[sec].Cells[6].Value.ToString();
            Cmbilce.Text = dataGridView1.Rows[sec].Cells[7].Value.ToString();
            RchAdres.Text = dataGridView1.Rows[sec].Cells[8].Value.ToString();
            TxtPerGorev.Text = dataGridView1.Rows[sec].Cells[9].Value.ToString();
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
        { //Cmbilce.Items.Clear(); // ÖNCEKİ İLCELERİ TEMİZLER
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

