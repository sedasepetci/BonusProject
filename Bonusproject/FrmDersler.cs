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
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.Tbl_DerslerTableAdapter ds = new DataSet1TableAdapters.Tbl_DerslerTableAdapter();
        private void Btnlistele_MouseLeave(object sender, EventArgs e)
        {
            Btnlistele.BackColor = Color.Transparent;
        }

      
        private void Btnlistele_MouseMove(object sender, MouseEventArgs e)
        {
            Btnlistele.BackColor = Color.DeepSkyBlue;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnGuncelle_MouseLeave(object sender, EventArgs e)
        {
            BtnGuncelle.BackColor = Color.Transparent;
        }

        private void BtnGuncelle_MouseMove(object sender, MouseEventArgs e)
        {
            BtnGuncelle.BackColor = Color.DeepSkyBlue;
        }

        private void BtnEkle_MouseLeave(object sender, EventArgs e)
        {
            BtnEkle.BackColor = Color.Transparent;
        }

        private void BtnEkle_MouseMove(object sender, MouseEventArgs e)
        {
            BtnEkle.BackColor = Color.DeepSkyBlue;
        }

        private void BtnSil_MouseMove(object sender, MouseEventArgs e)
        {
            BtnSil.BackColor = Color.DeepSkyBlue;
        }

        private void BtnSil_MouseLeave(object sender, EventArgs e)
        {
            BtnSil.BackColor = Color.Transparent;
        }

        private void FrmDersler_Load(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource= ds.DersListesi();   
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(TxtAd.Text);
            MessageBox.Show("Ders Ekleme İşlemi Yapılmıştır.");
        }

        private void Btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(Txtid.Text));
            MessageBox.Show("Ders Silme İşlemi Yapılmıştır.");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(TxtAd.Text,byte.Parse(Txtid.Text));
            MessageBox.Show("Güncelleme İşlemi Yapılmıştır.");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

    }
}
