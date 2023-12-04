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

namespace SQLPersonelDB
{
    public partial class FrmOgrenciler : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=D15\SQLEXPRESS;Initial Catalog=Personel;Integrated Security=True");

        public FrmOgrenciler()
        {
            InitializeComponent();
        }
            
            
        private void timer1_Tick(object sender, EventArgs e)
        {

    
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {

           
            baglanti.Open();
            SqlCommand kmt1 = new SqlCommand(@"select * from TBLOGRENCILER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(kmt1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewOgr.DataSource = dt;
            baglanti.Close();
            
        }

        private void dataGridViewOgr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtID.Text = dataGridViewOgr.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridViewOgr.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridViewOgr.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtCins.Text = dataGridViewOgr.Rows[e.RowIndex].Cells[3].Value.ToString();  
            TxtKulup.Text = dataGridViewOgr.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSehir.Text = dataGridViewOgr.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand(@"update TBLOGRENCILER set OGRAD=@2,OGRSOYAD=@3,OGRCINSIYET=@4,OGRKULUP=@5,OGRSEHIR=@6 where OGRID=@1", baglanti);
            kmt.Parameters.AddWithValue("@1",TxtID.Text);
            kmt.Parameters.AddWithValue("@2",TxtAd.Text);
            kmt.Parameters.AddWithValue("@3", TxtSoyad.Text);
            kmt.Parameters.AddWithValue("@4",TxtCins.Text);
            kmt.Parameters.AddWithValue("@5",TxtKulup.Text);
            kmt.Parameters.AddWithValue("@6",TxtSehir.Text);
            kmt.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncellendi.");
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt2 = new SqlCommand(@"insert into TBLOGRENCILER(OGRAD,OGRSOYAD,OGRCINSIYET,OGRKULUP,OGRSEHIR) values (@2,@3,@4,@5,@6)",baglanti);
            kmt2.Parameters.AddWithValue("@2", TxtAd.Text);
            kmt2.Parameters.AddWithValue("@3", TxtSoyad.Text);
            kmt2.Parameters.AddWithValue("@4", TxtCins.Text);
            kmt2.Parameters.AddWithValue("@5", TxtKulup.Text);
            kmt2.Parameters.AddWithValue("@6", TxtSehir.Text);
            kmt2.ExecuteNonQuery();
            MessageBox.Show("Kaydedildi.");
            baglanti.Close();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt3 = new SqlCommand(@"Delete from TBLOGRENCILER where OGRID=@1", baglanti);
            kmt3.Parameters.AddWithValue("@1", TxtID.Text);
            kmt3.ExecuteNonQuery();
            MessageBox.Show("Silindi.");
            baglanti.Close();
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt4 = new SqlCommand(@"select * from TBLOGRENCILER Where OGRAD=@1", baglanti);
            kmt4.Parameters.AddWithValue("@1",TxtAd.Text);
            kmt4.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(kmt4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewOgr.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bulundu.");
            }
            else
                MessageBox.Show("Bulunamadı");

            baglanti.Close();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
