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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        public string ogretmenMail;
        DataTable tablo = new DataTable();
        DataTable tablo2 = new DataTable();

        public SqlConnection conn1 = new SqlConnection(@"Data Source=ErkanK;Initial Catalog=DTS;Integrated Security=True;");

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 dersler = new Form3();
            dersler.Show();
            this.Hide();
        }


        private void Form5_Load(object sender, EventArgs e)
        {
            conn1.Open();
            string sqlSorguDers= "SELECT dersAd FROM tbl_Dersler inner join tbl_Ogretmen on tbl_Dersler.ogretmenNo=tbl_Ogretmen.ogretmenNo where ogretmenMail='"+ogretmenMail.ToString().Trim()+"'";
            SqlCommand komutders = new SqlCommand(sqlSorguDers,conn1);
            SqlDataReader dersreader = komutders.ExecuteReader();

            while (dersreader.Read())
            {
                cmb_verilenDersler.Items.Add(dersreader["dersAd"].ToString());
            }
            dersreader.Close();
            conn1.Close();

            pnlBilgiler.Visible = false;
            pnlDerslerim.Visible = true;
            pnlOgrenciler.Visible = false;
            tablo.Columns.Add("Öğrenci Ad", typeof(string));
            tablo.Columns.Add("Öğrenci Soyad", typeof(string));
            tablo.Columns.Add("Öğrenci Numara", typeof(int));
            tablo.Columns.Add("Öğrenci Öğrenim Tür", typeof(string));
            tablo.Columns.Add("Öğrenci Dönem", typeof(int));
            tablo.Columns.Add("Öğrenci Ders", typeof(string));
            tablo.Columns.Add("Öğrenci Bölüm Numara", typeof(string));
            tablo2.Columns.Add("Derslerim", typeof(string));
            tablo2.Columns.Add("Dersin Kontenjanı", typeof(string));
            tablo2.Columns.Add("Dersin Kredisi", typeof(string));
            tablo2.Columns.Add("Dersin Dönemi", typeof(string));
            tablo2.Columns.Add("Sınıf Mevcudu ", typeof(string));
            dataGridView1.DataSource = tablo;

            string SqlSorgu3 = "select * from tbl_Dersler where ogretmenNo=(select ogretmenNo from tbl_Ogretmen where ogretmenMail='" + ogretmenMail.ToString().Trim() + "')";
            SqlCommand sqlCommand3 = new SqlCommand(SqlSorgu3, conn1);
            conn1.Open();
            SqlDataReader reader3 = sqlCommand3.ExecuteReader();

            while (reader3.Read())
            {
                tablo2.Rows.Add(reader3["dersAd"], reader3["dersKontenjan"], reader3["dersKredi"], reader3["donem"], reader3["ogrenciSayisi"]);
            }

            dataGridView2.DataSource = tablo2;
            conn1.Close();

        }
        private void bİLGİLERİMToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string sqlBilgi = "SELECT * From tbl_Ogretmen  where ogretmenMail="+ "'"+ogretmenMail+"'";
            string sqlBolum = "SELECT bolumAd FROM tbl_Bolum WHERE bolumNo=(SELECT bolumNo FROM tbl_Ogretmen WHERE ogretmenMail='"+ ogretmenMail+"')";
            SqlCommand sqlCommand1 = new SqlCommand(sqlBilgi, conn1);
            SqlCommand sqlCommand2 = new SqlCommand(sqlBolum, conn1);
            conn1.Open();
            SqlDataReader reader = sqlCommand1.ExecuteReader();

            if (reader.Read())
            {
                lblOgretmenAdSoyad.Text = "Merhaba" + " " + reader["ogretmenAd"].ToString();
                lblMail.Text = reader["ogretmenMail"].ToString();
                reader.Close();
            }

            SqlDataReader reader2 = sqlCommand2.ExecuteReader();
            if (reader2.Read())
            {
                lblBolumNo.Text = reader2["bolumAd"].ToString();
                
                reader2.Close();
            }
            conn1.Close();
            
            pnlBilgiler.Visible = true;
            pnlDerslerim.Visible = false;
            pnlOgrenciler.Visible = false;
            lblVerDers.Visible = false;
            cmb_verilenDersler.Visible = false;
        }

        private void öĞRENCİLERİMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tablo.Rows.Clear();
            string sqlTumAlanlar="SELECT * FROM tbl_Ogrenci inner join tbl_ogrenciDers on tbl_Ogrenci.ogrenciNo = tbl_OgrenciDers.ogrenciNo" +
            " join tbl_Dersler on tbl_Dersler.dersNo = tbl_ogrenciDers.dersNo"+
            " join tbl_Ogretmen on tbl_Ogretmen.ogretmenNo = tbl_Dersler.ogretmenNo"+
            " where ogretmenMail ='" + ogretmenMail + "' ORDER BY dersAd";
            SqlCommand sqlCommand3 = new SqlCommand(sqlTumAlanlar, conn1);
            conn1.Open();
            SqlDataReader reader1 = sqlCommand3.ExecuteReader();

            while (reader1.Read())
            {
                tablo.Rows.Add(reader1["ogrenciAd"], reader1["ogrenciSoyad"], reader1["ogrenciNo"], reader1["ogrenciOgrenimTur"], reader1["donem"], reader1["dersAd"],reader1["ogrenciBolumNo"]);
            }
            reader1.Close();
            conn1.Close();
            
            cmb_verilenDersler.Text = "";
            pnlOgrenciler.Visible = true;
            pnlBilgiler.Visible = false;
            pnlDerslerim.Visible = false;
            lblVerDers.Visible = true;
            cmb_verilenDersler.Visible = true;
        }

        private void dERSLERİMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tablo2.Rows.Clear();
            pnlBilgiler.Visible = false;
            pnlDerslerim.Visible = true;
            pnlOgrenciler.Visible = false;
            lblVerDers.Visible = false;
            cmb_verilenDersler.Visible = false;
            string SqlSorgu3 = "select * from tbl_Dersler where ogretmenNo=(select ogretmenNo from tbl_Ogretmen where ogretmenMail='" + ogretmenMail.ToString().Trim() + "')";
            SqlCommand sqlCommand3 = new SqlCommand(SqlSorgu3, conn1);
            conn1.Open();
            SqlDataReader reader3 = sqlCommand3.ExecuteReader();

            while (reader3.Read())
            {
                tablo2.Rows.Add(reader3["dersAd"], reader3["dersKontenjan"], reader3["dersKredi"], reader3["donem"], reader3["ogrenciSayisi"]);
            }
            dataGridView2.DataSource = tablo2;
            conn1.Close();
        }

        private void cmb_verilenDersler_SelectedValueChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible=true;
            tablo.Clear(); 
            string SqlSorgu2 = "EXEC OgrArama '" + ogretmenMail + "','" + cmb_verilenDersler.SelectedItem.ToString() + "'"; //arama ve filtreleme store procedure1 
                
                    //PROCEDUREDEKI OGRENCI SORGU
                    /*"SELECT * FROM tbl_Ogrenci inner join tbl_ogrenciDers on tbl_Ogrenci.ogrenciNo = tbl_OgrenciDers.ogrenciNo" +
                    " join tbl_Dersler on tbl_Dersler.dersNo = tbl_ogrenciDers.dersNo"+
                    " join tbl_Ogretmen on tbl_Ogretmen.ogretmenNo = tbl_Dersler.ogretmenNo"+
                    " where ogretmenMail ='" + ogretmenMail + "' and dersAd ='" + cmb_verilenDersler.SelectedItem.ToString() + "'";*/

            SqlCommand sqlCommand2 = new SqlCommand(SqlSorgu2, conn1);
            conn1.Open();
            SqlDataReader reader2 = sqlCommand2.ExecuteReader();

            while (reader2.Read())
            {
                tablo.Rows.Add(reader2["ogrenciAd"], reader2["ogrenciSoyad"], reader2["ogrenciNo"], reader2["ogrenciOgrenimTur"], reader2["donem"],reader2["dersAd"],reader2["ogrenciBolumNo"]);
            }
            reader2.Close();
            dataGridView1.DataSource = tablo;

            conn1.Close();
        }

        private void btn_Ara_Click(object sender, EventArgs e)
        {
            if (txt_OgrenciNoAra.Text!="")
            {
                dataGridView1.Visible = true;
                tablo.Clear();
                string SqlSorgu2 = "EXEC OgrNumaraArama '"+ogretmenMail+"','"+cmb_verilenDersler.SelectedItem.ToString()+"',"+txt_OgrenciNoAra.Text; 
                
                    //PROCEDUREDEKI NUMARA ARAMA SORGUSU    
                    /* "SELECT * FROM tbl_Ogrenci inner join tbl_ogrenciDers on tbl_Ogrenci.ogrenciNo = tbl_OgrenciDers.ogrenciNo" +
                    " join tbl_Dersler on tbl_Dersler.dersNo = tbl_ogrenciDers.dersNo" +
                    " join tbl_Ogretmen on tbl_Ogretmen.ogretmenNo = tbl_Dersler.ogretmenNo" +
                    " where ogretmenMail ='" + ogretmenMail + "' and dersAd ='" + cmb_verilenDersler.SelectedItem.ToString() +
                    "' and tbl_Ogrenci.ogrenciNo=" + txt_OgrenciNoAra.Text;*/

                SqlCommand sqlCommand2 = new SqlCommand(SqlSorgu2, conn1);
                conn1.Open();
                SqlDataReader reader2 = sqlCommand2.ExecuteReader();

                while (reader2.Read())
                {
                    tablo.Rows.Add(reader2["ogrenciAd"], reader2["ogrenciSoyad"], reader2["ogrenciNo"], reader2["ogrenciOgrenimTur"], reader2["donem"], reader2["dersAd"], reader2["ogrenciBolumNo"]);
                }
                reader2.Close();
                dataGridView1.DataSource = tablo;

                conn1.Close();
            }
            
        }
    }
}
