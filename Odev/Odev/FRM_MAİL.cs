using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Odev
{
    public partial class FRM_MAİL : Form
    {
        public FRM_MAİL()
        {
            InitializeComponent();
        }
        public string mail; // mail diye bi değişken atadım dışarıdan alacağım için public
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void FRM_MAİL_Load(object sender, EventArgs e)
        {
            TxtMailAdresi.Text = mail;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage mesaj = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("ozsoyybuse@gmail.com", "PEKMEZbu1$");
            istemci.Port = 587;
            istemci.Host = "smtp.gmail.com"; //  smtp.live.com
            istemci.EnableSsl = true;
            mesaj.To.Add(TxtMailAdresi.Text);
            mesaj.From = new MailAddress("ozsoyybuse@gmail.com");
            mesaj.Subject = txtkonu.Text;
            mesaj.Body = RchNotlar.Text;
            istemci.Send(mesaj);
            MessageBox.Show("Mesaj gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //FRM_MAİL  frm = new FRM_MAİL();

            //frm.Close();
            this.Close();
           // Application.Exit();
        }
    }
}
