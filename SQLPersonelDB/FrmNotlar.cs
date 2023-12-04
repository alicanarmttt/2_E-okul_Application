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
using System.Runtime.ConstrainedExecution;

namespace SQLPersonelDB
{
    public partial class FrmNotlar : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=D15\SQLEXPRESS;Initial Catalog=Personel;Integrated Security=True");
        public FrmNotlar()
        {
            InitializeComponent();
        }

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt1 = new SqlCommand("Select distinct DERS from TBLNOTLAR", baglanti);
            SqlDataReader dr = kmt1.ExecuteReader();
            while (dr.Read())
            {
                DersBox.Items.Add(dr["DERS"]);

            }
            baglanti.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void NOTLIST()
        {
            baglanti.Open();
            SqlCommand kmt = new SqlCommand(@"SELECT * FROM TBLNOTDUZENLEME
                                    WHERE (@ders IS NULL OR DERS = @ders) 
                                    AND ((@ad IS NULL OR UPPER(OGRAD) = UPPER(@ad)) 
                                    AND (@soyad IS NULL OR UPPER(OGRSOYAD) = UPPER(@soyad)))
                                    ORDER BY DERS ASC", baglanti);

            if (string.IsNullOrEmpty(DersBox.Text))
            {
                kmt.Parameters.AddWithValue("@ders", DBNull.Value);
            }
            else
            {
                kmt.Parameters.AddWithValue("@ders", DersBox.Text);
            }

            if (string.IsNullOrEmpty(TxtAd.Text))
            {
                kmt.Parameters.AddWithValue("@ad", DBNull.Value);
            }
            else
            {
                kmt.Parameters.AddWithValue("@ad", TxtAd.Text);
            }

            if (string.IsNullOrEmpty(TxtSoyad.Text))
            {
                kmt.Parameters.AddWithValue("@soyad", DBNull.Value);
            }
            else
            {
                kmt.Parameters.AddWithValue("@soyad", TxtSoyad.Text);
            }

            SqlDataAdapter da = new SqlDataAdapter(kmt);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewOgr.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Listelendi.");
            }
            else
                MessageBox.Show("Listelendi");

            baglanti.Close();
        }
        private void BtnListele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt1 = new SqlCommand(@"Select * from TBLNOTDUZENLEME", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(kmt1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewOgr.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Listelendi.");
            }
            else
                MessageBox.Show("Listelendi");

            baglanti.Close();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt2 = new SqlCommand(@"Update TBLNOTDUZENLEME set  OGRAD=@2, OGRSOYAD=@3, DERS=@4, SINAV1=@5,
                                             SINAV2=@6, SINAV3=@7, ORTALAMA=@8, DURUM=@9 where SIRA=@1", baglanti);
            //Textboxlara string olarak kaydettiğimiz değerleri sütunların veritiplerine göre atamak için dönüşüm uygularız.
            byte tinyIntValue = byte.Parse(UpdSIRA.Text);
            byte tinyIntValue1 = byte.Parse(UpdDERS.Text);

            kmt2.Parameters.AddWithValue("@1", tinyIntValue); 
            kmt2.Parameters.AddWithValue("@2", UpdOGRAD.Text);
            kmt2.Parameters.AddWithValue("@3", UpdOGSOYAD.Text);
            kmt2.Parameters.AddWithValue("@4", tinyIntValue1);
            kmt2.Parameters.AddWithValue("@5", short.Parse(UpdSINAV1.Text));
            kmt2.Parameters.AddWithValue("@6", short.Parse(UpdSINAV2.Text));
            kmt2.Parameters.AddWithValue("@7", short.Parse(UpdSINAV3.Text));
            kmt2.Parameters.AddWithValue("@8", decimal.Parse(UpdORTALAMA.Text));
            kmt2.Parameters.AddWithValue("@9", bool.Parse(UpdDURUM.Text));
            kmt2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncellendi.");


        }

        private void dataGridViewOgr_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdSIRA.Text = dataGridViewOgr.Rows[e.RowIndex].Cells[0].Value.ToString();
            UpdOGRAD.Text = dataGridViewOgr.Rows[e.RowIndex].Cells[1].Value.ToString();
            UpdOGSOYAD.Text = dataGridViewOgr.Rows[e.RowIndex].Cells[2].Value.ToString();
            UpdDERS.Text = dataGridViewOgr.Rows[e.RowIndex].Cells[3].Value.ToString();
            UpdSINAV1.Text = dataGridViewOgr.Rows[e.RowIndex].Cells[4].Value.ToString();
            UpdSINAV2.Text = dataGridViewOgr.Rows[e.RowIndex].Cells[5].Value.ToString();
            UpdSINAV3.Text = dataGridViewOgr.Rows[e.RowIndex].Cells[6].Value.ToString();
            UpdORTALAMA.Text = dataGridViewOgr.Rows[e.RowIndex].Cells[7].Value.ToString();
            UpdDURUM.Text = dataGridViewOgr.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void TxtAd_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            NOTLIST();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt3 = new SqlCommand(@"delete from TBLNOTDUZENLEME Where SIRA=@1", baglanti);
            kmt3.Parameters.AddWithValue("@1", UpdSIRA.Text);
            kmt3.ExecuteNonQuery();
            MessageBox.Show("Silindi.");
            baglanti.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kmt4 = new SqlCommand(@"insert into TBLNOTDUZENLEME (OGRAD,OGRSOYAD,DERS,SINAV1,SINAV2,SINAV3,
                                             ORTALAMA,DURUM) Values (@2,@3,@4,@5,@6,@7,@8,@9)", baglanti);

            
            byte tinyIntValue1 = byte.Parse(UpdDERS.Text);

            kmt4.Parameters.AddWithValue("@2", UpdOGRAD.Text);
            kmt4.Parameters.AddWithValue("@3", UpdOGSOYAD.Text);
            kmt4.Parameters.AddWithValue("@4", tinyIntValue1);
            kmt4.Parameters.AddWithValue("@5", short.Parse(UpdSINAV1.Text));
            kmt4.Parameters.AddWithValue("@6", short.Parse(UpdSINAV2.Text));
            kmt4.Parameters.AddWithValue("@7", short.Parse(UpdSINAV3.Text));
            kmt4.Parameters.AddWithValue("@8", decimal.Parse(UpdORTALAMA.Text));
            kmt4.Parameters.AddWithValue("@9", bool.Parse(UpdDURUM.Text));
            kmt4.ExecuteNonQuery();
            MessageBox.Show("Kaydedildi.");
            baglanti.Close();



        }

        private void DersBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
