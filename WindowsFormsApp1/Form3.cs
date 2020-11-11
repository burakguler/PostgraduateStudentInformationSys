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

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;
            pictureBox6.BackColor = Color.Transparent;
            pbAdmin.BackColor = Color.Transparent;
            pbOgrenci.BackColor = Color.Transparent;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void txtMail_Click(object sender, EventArgs e)
        {
            txtMail.Text = "";
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSifre_Click(object sender, EventArgs e)
        {
            txtSifre.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 dersler = new Form5();
            dersler.Show();
            this.Hide();
        }

        private void pbOgrenci_Click(object sender, EventArgs e)
        {
            Form1 dersler = new Form1();
            dersler.Show();
            this.Hide();

        }

        private void pbAdmin_Click(object sender, EventArgs e)
        {
            Form4 dersler = new Form4();
            dersler.Show();
            this.Hide();
        }

        public SqlConnection conn1 = new SqlConnection(@"Data Source=ErkanK;Initial Catalog=DTS;Integrated Security=True;");


        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (txtMail.Text == "" || txtMail.Text == "Mail Adresi" )
            {
                MessageBox.Show("Öğretmen Mail kısmı boş kalamaz!", "Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtSifre.Text == "" || txtSifre.Text == "Şifre")
                {
                    MessageBox.Show("Şifre kısmını eksik girdiniz ve ya boş!", "Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   
                }
                else
                {
                    try
                    {
                        conn1.Open();
                        string sql = "Select * from tbl_Ogretmen where ogretmenMail=@mail AND ogretmenSifre=@sifre";
                        SqlParameter prm3 = new SqlParameter("mail", txtMail.Text.Trim());
                        SqlParameter prm4 = new SqlParameter("sifre", txtSifre.Text.Trim());
                        SqlCommand komut = new SqlCommand(sql, conn1);
                        komut.Parameters.Add(prm3);
                        komut.Parameters.Add(prm4);
                        DataTable dt2 = new DataTable();
                        SqlDataAdapter da2 = new SqlDataAdapter(komut);
                        da2.Fill(dt2);
                        if (dt2.Rows.Count > 0)
                        {
                            Form5 yeni = new Form5();
                            yeni.ogretmenMail = txtMail.Text;
                            yeni.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Yanlış Kullanıcı Adı veya Şifre!", "Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            conn1.Close();
                        }

                    }
                    catch (Exception)
                    {

                    }
                }
            }
              
        }

        private void pbOgrenci_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pbOgrenci, "Öğrenci Girişi");
        }

        private void pbAdmin_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pbAdmin, "Admin Girişi");
        }

        private void txtMail_KeyDown(object sender, KeyEventArgs e)
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
                this.ActiveControl = txtMail;
            }
        }
    }
}
