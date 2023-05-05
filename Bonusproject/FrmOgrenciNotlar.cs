using System;
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
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=MSI;Initial Catalog=BonusOkul;Integrated Security=True");
        public string numara;
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select Dersad,Sinav1,Sinav2,Sinav3,Proje,Ortalama,Durum From Tbl_Notlar INNER JOIN Tbl_Dersler ON Tbl_Notlar.Dersid=Tbl_Dersler.Dersid where ogrenciid=@p1",baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
           // this.Text=numara.ToString();
           SqlDataAdapter da=new SqlDataAdapter(komut);
            DataTable dt=new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

      
    }
}
