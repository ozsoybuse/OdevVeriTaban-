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
    public partial class FRMADMİN : Form
    {
        public FRMADMİN()
        {
            InitializeComponent();
        }
        OracleBaglanti con = new OracleBaglanti();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
         
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand komut = new OracleCommand("Select * From TBL_ADMIN where KULLANICI_AD =:p1 and SIFRE=:p2", con.Baglanti());
            komut.Parameters.Add(":p1", txtKullGırıs.Text);
            komut.Parameters.Add(":p2", TxtSıfre.Text);
            OracleDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                Form1 frm = new Form1();
                frm.ad = txtKullGırıs.Text;
                frm.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("kullanıcı adı veya şifre hatalı.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            con.Baglanti().Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Unchecked)
            {
                TxtSıfre.UseSystemPasswordChar = false;


            }
            else if (checkBox1.CheckState == CheckState.Checked)
            {

                TxtSıfre.UseSystemPasswordChar = true;

            }
        }
    }
}
