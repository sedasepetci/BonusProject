using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bonusproject
{
    public partial class FrmOgretmenler : Form
    {
        public FrmOgretmenler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDersler frm=new FrmDersler();
            frm.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frmkulupler frmkulupler = new Frmkulupler();
            frmkulupler.Show();
        }

     
        private void button5_Click(object sender, EventArgs e)
        {
            FrmOgrenciler frm=new FrmOgrenciler();
            frm.Show();
        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            FrmSinavNotlar frm=new FrmSinavNotlar();
            frm.Show();
        }
    }
}
