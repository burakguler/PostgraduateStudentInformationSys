using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        public SqlConnection conn1 = new SqlConnection(@"Data Source=ErkanK;Initial Catalog=DTS;Integrated Security=True;");


        private void txtKullaniciAdi_Click(object sender, EventArgs e)
        {
            txtKullaniciAdi.Text = "";
        }

        private void txtSifre_Click(object sender, EventArgs e)
        {
            txtSifre.Text = "";
        }

        private void pbOgrenci_Click(object sender, EventArgs e)
        {
            Form1 dersler = new Form1();
            dersler.Show();
            this.Hide();
        }

        private void pbEgitmen_Click(object sender, EventArgs e)
        {
            Form3 dersler = new Form3();
            dersler.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;
            pictureBox6.BackColor = Color.Transparent;
            pbEgitmen.BackColor = Color.Transparent;
            pbOgrenci.BackColor = Color.Transparent;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "" || txtKullaniciAdi.Text == "Kullanıcı Adı")
            {
                MessageBox.Show("Kullanıcı Adı kısmı boş kalamaz!", "Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtSifre.Text == "" || txtSifre.Text == "Şifre")
                {
                    MessageBox.Show("Şifre kısmı boş kalamaz!", "Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                   // try
                   // {
                        conn1.Open();
                        string Sqlque2 = "SELECT * FROM tbl_Admin WHERE kullaniciAdi=@adminNick AND sifre=@adminSifre";
                        SqlParameter sqlParameteradmin1 = new SqlParameter("adminNick", txtKullaniciAdi.Text.Trim());
                        SqlParameter sqlParameteradmin2 = new SqlParameter("adminSifre", txtSifre.Text.Trim());
                        SqlCommand sqlCommand1 = new SqlCommand(Sqlque2, conn1);
                        sqlCommand1.Parameters.Add(sqlParameteradmin1);
                        sqlCommand1.Parameters.Add(sqlParameteradmin2);
                        DataTable dataTableAdmin1 = new DataTable();
                        SqlDataAdapter adminDa = new SqlDataAdapter(sqlCommand1);
                        adminDa.Fill(dataTableAdmin1);
                        if (dataTableAdmin1.Rows.Count > 0)
                        {
                            Form6 dersler = new Form6();
                            dersler.kullaniciAdi = txtKullaniciAdi.Text;
                            dersler.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Yanlış Kullanıcı Adı veya Şifre!", "Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            conn1.Close();
                        }
                   // }
                   // catch (Exception)
                   // {
                     
                   // }
                }
            } 
        }

        private void pbEgitmen_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pbEgitmen, "Eğitmen Girişi");
        }

        private void pbOgrenci_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pbOgrenci, "Öğrenci Girişi");
        }

        private void txtKullaniciAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                this.ActiveControl = txtSifre;
            }
        }

        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                this.ActiveControl = txtKullaniciAdi;
            }
        }
    }
}
