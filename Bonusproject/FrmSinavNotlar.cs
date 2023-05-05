﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Bonusproject
{
    public partial class FrmSinavNotlar : Form
    {
        public FrmSinavNotlar()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.Tbl_NotlarTableAdapter();
        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource =ds.NotListesi(int.Parse(Txtid.Text));
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MSI;Initial Catalog=BonusOkul;Integrated Security=True");
        private void FrmSinavNotlar_Load(object sender, EventArgs e)
        {
            
            SqlCommand komut = new SqlCommand("Select * From Tbl_Dersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbDers.DisplayMember = "Dersad";
            CmbDers.ValueMember = "Dersid";
            CmbDers.DataSource = dt;
        }
        int notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid =int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            Txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
          

        }
        int sinav1, sinav2, sinav3, proje;

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            ds.NotSil(byte.Parse(Txtid.Text));
            MessageBox.Show("Öğrenci bilgileri silindi");
          

        }

        double ortalama;
        private void BtnHesapla_Click(object sender, EventArgs e)
        {
           
          //  string durum;
            sinav1 = Convert.ToInt32(TxtSinav1.Text);
            sinav2 = Convert.ToInt32(TxtSinav2.Text);
            sinav3 = Convert.ToInt32(TxtSinav3.Text);
            proje = Convert.ToInt32(TxtProje.Text);
           
            ortalama=(sinav1+sinav2+sinav3+proje)/4;
            TxtOrtalama.Text=ortalama.ToString();
            if (ortalama >= 50)
            {
                TxtDurum.Text = "True";
            
               
            }
            else
               TxtDurum.Text = "False";
             
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(CmbDers.SelectedValue.ToString()), int.Parse(Txtid.Text),byte.Parse(TxtSinav1.Text), byte.Parse(TxtSinav2.Text), byte.Parse(TxtSinav3.Text), byte.Parse(TxtProje.Text), decimal.Parse(TxtOrtalama.Text), bool.Parse(TxtDurum.Text),notid);
        }
    }
}
