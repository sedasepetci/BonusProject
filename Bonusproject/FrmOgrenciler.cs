using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Bonusproject
{
    public partial class FrmOgrenciler : Form
    {
        public FrmOgrenciler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MSI;Initial Catalog=BonusOkul;Integrated Security=True");
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        DataSet1TableAdapters.DataTable1TableAdapter ds=new DataSet1TableAdapters.DataTable1TableAdapter();
        private void FrmOgrenciler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            
            SqlCommand komut = new SqlCommand("Select * From Tbl_Kulupler",baglanti);
           SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbKulup.DisplayMember = "kulupad";
            CmbKulup.ValueMember = "kulupid";
            CmbKulup.DataSource = dt;

        }
        string c = "";
        private void BtnEkle_Click(object sender, EventArgs e)
        {
           
          
            ds.OgrenciEkle(TxtAd.Text,TxtSoyad.Text,byte.Parse(CmbKulup.SelectedValue.ToString()),c);
            MessageBox.Show("Öğrenci ekleme yapıldı");
        }

        private void Btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(Txtid.Text));
            MessageBox.Show("Öğrenci silme işlemi gerçekleşti");
           
        }
        public string kulup;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
           label7.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            CmbKulup.Text = label7.Text;
            label8.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
           if(label8.Text=="Kız")
            {
                RdKiz.Checked = true;
            }
           if(label8.Text=="Erkek")
            {
                RdErkek.Checked = true;
            }

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(TxtAd.Text,TxtSoyad.Text,byte.Parse(CmbKulup.SelectedValue.ToString()),c,int.Parse(Txtid.Text));
            MessageBox.Show("Öğrenci bilgileri güncellenmiştir");
        }

        private void RdKiz_CheckedChanged(object sender, EventArgs e)
        {
            if (RdKiz.Checked == true)
            {
                c = "Kız";
            }
           
        }

        private void RdErkek_CheckedChanged(object sender, EventArgs e)
        {
           
            if (RdErkek.Checked == true)
            {
                c = "Erkek";
            }
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource=ds.OgrenciGetir(TxtAra.Text);
        }
    }
}
