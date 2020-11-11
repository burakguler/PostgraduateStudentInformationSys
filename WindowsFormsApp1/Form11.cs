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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        public SqlConnection conn1 = new SqlConnection(@"Data Source=ErkanK;Initial Catalog=DTS;Integrated Security=True;");
        public int id;
        private void Form11_Load(object sender, EventArgs e)
        {
            doldur();
        }
        void doldur()
        {
            listView2.Items.Clear();
            conn1.Open();
            SqlCommand komut = new SqlCommand("Select * from tbl_Admin where yetkiDerecesi!=3", conn1);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["kullaniciAdi"].ToString());
                ekle.SubItems.Add(oku["sifre"].ToString());
                ekle.SubItems.Add(oku["adminAd"].ToString());
                ekle.SubItems.Add(oku["adminSoyad"].ToString());
                ekle.SubItems.Add(oku["yetkiDerecesi"].ToString());
                listView2.Items.Add(ekle);
            }
            oku.Close();
            conn1.Close();
        }
        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView2.SelectedItems[0].SubItems[0].Text);
            txtKullaniciAdi.Text = listView2.SelectedItems[0].SubItems[1].Text;
            txtSifre.Text = listView2.SelectedItems[0].SubItems[2].Text;
            txtAd.Text = listView2.SelectedItems[0].SubItems[3].Text;
            txtSoyad.Text = listView2.SelectedItems[0].SubItems[4].Text;
            if (listView2.SelectedItems[0].SubItems[5].Text == "1")
            {
                comboBox1.Text = "Ekleme (1)";
            }
            else if (listView2.SelectedItems[0].SubItems[5].Text == "2")
            {
                comboBox1.Text = "Güncelleme/Silme/Ekleme (2)";

            }
        
        }
        int yetki;
        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text== "Ekleme (1)")
            {
                yetki = 1;
            }
            else if (comboBox1.Text == "Güncelleme/Silme/Ekleme (2)")
            {
                yetki = 2;
            }
      

            conn1.Open();
            SqlCommand komut = new SqlCommand("update tbl_Admin set kullaniciAdi='" + txtKullaniciAdi.Text.ToString() + "',sifre='" + txtSifre.Text.ToString() + "',adminAd='" + txtAd.Text.ToString() + "', adminSoyad='" + txtSoyad.Text.ToString() + "',yetkiDerecesi="+yetki+" where id =" + id + "", conn1);
            komut.ExecuteNonQuery();
            conn1.Close();
            txtSoyad.Text = "";
            txtAd.Text = "";
            txtSifre.Text = "";
            txtKullaniciAdi.Text = "";
            comboBox1.Text = "Seçim Yapınız";
            doldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from tbl_Admin where id =(" + id + ")", conn1);
            conn1.Open();
            komut.ExecuteNonQuery();
            conn1.Close();
            txtSoyad.Text = "";
            txtAd.Text = "";
            txtSifre.Text = "";
            txtKullaniciAdi.Text = "";
            comboBox1.Text = "Seçim Yapınız";
            doldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Ekleme (1)")
            {
                yetki = 1;
            }
            else if (comboBox1.Text == "Güncelleme/Silme/Ekleme (2)")
            {
                yetki = 2;
            }

            conn1.Open();
            SqlCommand komut = new SqlCommand("Insert into tbl_Admin (kullaniciAdi,sifre,adminAd,adminSoyad,yetkiDerecesi) Values ('" + txtKullaniciAdi.Text.ToString() + "' , '" + txtSifre.Text.ToString() + "' , '" + txtAd.Text.ToString() + "' , '" + txtSoyad.Text.ToString() + "',"+yetki+")", conn1);

            komut.ExecuteNonQuery();
            conn1.Close();
            txtSoyad.Text = "";
            txtAd.Text = "";
            txtSifre.Text = "";
            txtKullaniciAdi.Text = "";
            comboBox1.Text = "Seçim Yapınız";
            doldur();

            MessageBox.Show("Eğitmen Ekleme İşlemi Başarılı");



        }
    }
}
