using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev
{
    public partial class FRMNOTDETAY : Form
    {
        public FRMNOTDETAY()
        {
            InitializeComponent();
        }
        public string detay;
        private void FRMNOTDETAY_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = detay;
        }
    }
}
