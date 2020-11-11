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
    

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public SqlConnection conn1 = new SqlConnection(@"Data Source=ErkanK;Initial Catalog=DTS;Integrated Security=True;");
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;
            pictureBox6.BackColor = Color.Transparent;
            pbAdmin.BackColor = Color.Transparent;
            pbEgitmen.BackColor = Color.Transparent;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void txtOgrenciNo_Click(object sender, EventArgs e)
        {
            txtOgrenciNo.Text = "";
        }

        private void txtOgrenciNo_TextChanged(object sender, EventArgs e)
        {

        }

 
        private void txtSifre_Click_1(object sender, EventArgs e)
        {
            txtSifre.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (txtOgrenciNo.Text=="" || txtOgrenciNo.Text == "Öğrenci Numarası" || txtOgrenciNo.Text.Length<1)
            {
                MessageBox.Show("Öğrenci Numara kısmı boş kalamaz!","Uyarı Mesajı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                if (txtSifre.Text == ""  || txtSifre.Text == "Şifre" || txtSifre.Text.Length < 11)
                {
                    MessageBox.Show("Kimlik Numara kısmını eksik girdiniz veya boş!", "Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        conn1.Open();
                        string Sqlque1 = "SELECT * FROM dbo.tbl_Ogrenci WHERE ogrenciNo=@ogrNum AND ogrenciKimlikNo=@kmlNum";
                        SqlParameter sqlParameterogr1 = new SqlParameter("ogrNum", txtOgrenciNo.Text.Trim());
                        SqlParameter sqlParameterogr2 = new SqlParameter("kmlNum", txtSifre.Text.Trim());
                        SqlCommand sqlCommand1 = new SqlCommand(Sqlque1, conn1);
                        sqlCommand1.Parameters.Add(sqlParameterogr1);
                        sqlCommand1.Parameters.Add(sqlParameterogr2);
                        DataTable dataTableOgr1 = new DataTable();
                        SqlDataAdapter ogrDa = new SqlDataAdapter(sqlCommand1);
                        ogrDa.Fill(dataTableOgr1);
                        if (dataTableOgr1.Rows.Count > 0)
                        {
                            
                            Form2 dersler = new Form2();
                            dersler.ogrenciNumara = txtOgrenciNo.Text;
                            dersler.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Yanlış Öğrenci Adı ve ya Kimlik Numarası!", "Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Form1 dersler = new Form1();
                            dersler.Show();
                            this.Hide();
                            conn1.Close();
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void pbEgitmen_Click(object sender, EventArgs e)
        {
            Form3 dersler = new Form3();
            dersler.Show();
            this.Hide();
        }

        private void pbAdmin_Click(object sender, EventArgs e)
        {
            Form4 dersler = new Form4();
            dersler.Show();
            this.Hide();
        }

        private void pbEgitmen_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pbEgitmen, "Eğitmen Girişi");
        }

        private void pbAdmin_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pbAdmin, "Admin Girişi");
        }

        private void txtOgrenciNo_KeyDown(object sender, KeyEventArgs e)
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
                this.ActiveControl = txtOgrenciNo;
            }
        }
    }
}
