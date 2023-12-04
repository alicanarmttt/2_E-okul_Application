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

namespace SQLPersonelDB
{
    public partial class FrmEokul : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=D15\SQLEXPRESS;Initial Catalog=Personel;Integrated Security=True");
        bool sideBarExpand = true;

        public FrmEokul()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void SideBarTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (sideBarExpand) 
                {
                    //if sidebar is expand, minimize
                    flowLayoutPanel1.Width -= 10;
                    if (flowLayoutPanel1.Width == flowLayoutPanel1.MinimumSize.Width)
                    {
                        sideBarExpand = false;
                        SideBarTimer.Stop();
                       
                        
                    }
                }
                else
                {
                    SideBarTimer.Start();
                    flowLayoutPanel1.Width += 10;
                    if (flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
                    {
                            
                            sideBarExpand = true;
                            SideBarTimer.Stop();
                            
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            try
            {
               
                SideBarTimer.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }
        
        //Form Getir adlı metod ile Menüdeki tüm tıklamalarda ilgili formu kolayca içeride açabiliriz.
        private void FormGetir(Form Frm)
        {
            anaPanel.Controls.Clear(); 
            Frm.MdiParent = this;
            Frm.FormBorderStyle = FormBorderStyle.None;
            Frm.TopLevel = false;
            Frm.Dock = DockStyle.Fill;
            anaPanel.Controls.Add(Frm);
            Frm.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FrmOgrenciler frmOgrenciler = new FrmOgrenciler();
            FormGetir(frmOgrenciler);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FrmNotlar formNotlar = new FrmNotlar();
           FormGetir(formNotlar);

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmAnaliz analiz = new FrmAnaliz();
            FormGetir(analiz);
        }

        private void anaPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
