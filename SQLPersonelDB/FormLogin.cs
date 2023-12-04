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

namespace SQLPersonelDB
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="") 
            {
                MessageBox.Show("Kullanıcı adını girin.");
            }
            else if(textBox2.Text=="")
            {
                MessageBox.Show("Şifreyi girin.");
            }
            else
            {
                try
                {
                    SqlConnection baglantı = new SqlConnection(@"Data Source=D15\SQLEXPRESS;Initial Catalog=Personel;Integrated Security=True");
                    baglantı.Open();
                    SqlCommand kmt = new SqlCommand(@"Select * from TBLLOGIN where Username = @username and Password = @password", baglantı);
                    kmt.Parameters.AddWithValue("@username", textBox1.Text);
                    kmt.Parameters.AddWithValue("@password",textBox2.Text);
                    SqlDataAdapter da = new SqlDataAdapter(kmt);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if(dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Giriş basarılı");
                        FrmEokul frmEokul = new FrmEokul();
                        frmEokul.Show();
                        
                    }
                    else
                    {
                        MessageBox.Show("Giriş başarısız");
                    }
                    baglantı.Close();
                }
                catch 
                { 

                }
            }


        }
    }
}
