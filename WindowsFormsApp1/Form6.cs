using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        int bolumno = 0;
        ErrorProvider errorProvider1 = new ErrorProvider();
        public string kullaniciAdi;
        private void verilerigoster()
        {
            lvDersler.Items.Clear();
            conn1.Open();
            SqlCommand komut = new SqlCommand("Select * from tbl_Dersler  inner join tbl_Bolum b1 on tbl_Dersler.bolumNo=b1.bolumNo inner join tbl_Ogretmen o1 on tbl_Dersler.ogretmenNo=o1.ogretmenNo", conn1);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["dersNo"].ToString();
                ekle.SubItems.Add(oku["dersAd"].ToString());
                ekle.SubItems.Add(oku["dersKontenjan"].ToString());
                ekle.SubItems.Add(oku["dersKredi"].ToString());
                ekle.SubItems.Add(oku["bolumAd"].ToString());
                ekle.SubItems.Add(oku["donem"].ToString());
                ekle.SubItems.Add(oku["ogrenciSayisi"].ToString());
                ekle.SubItems.Add(oku["ogretmenAd"].ToString());

                lvDersler.Items.Add(ekle);
            }
            oku.Close();
            conn1.Close();
        }
        private void verilerigoster2()
        {
            listView2.Items.Clear();
            conn1.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM tbl_Ogretmen ogt1 inner join tbl_Bolum blm1 " +
                                                "on ogt1.bolumNo = blm1.bolumNo ", conn1);
            SqlDataReader oku = komut.ExecuteReader(); 
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ogretmenNo"].ToString();
                ekle.SubItems.Add(oku["ogretmenMail"].ToString());
                ekle.SubItems.Add(oku["ogretmenSifre"].ToString());
                ekle.SubItems.Add(oku["ogretmenAd"].ToString());
                ekle.SubItems.Add(oku["bolumAd"].ToString());
                listView2.Items.Add(ekle);
           
            }
           
            oku.Close();
            conn1.Close();
        }
        private void verilerigoster3()
        {
           
            lvOgrenci.Items.Clear();
            conn1.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM tbl_Ogrenci ogt1 inner join tbl_Bolum blm1 " +
                                                "on ogt1.ogrenciBolumNo = blm1.bolumNo ", conn1);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ogrenciNo"].ToString();
                ekle.SubItems.Add(oku["ogrenciAd"].ToString());
                ekle.SubItems.Add(oku["ogrenciSoyad"].ToString());
                ekle.SubItems.Add(oku["ogrenciDogumTarih"].ToString().Substring(0,10));
                ekle.SubItems.Add(oku["ogrenciKimlikNo"].ToString());
                ekle.SubItems.Add(oku["ogrenciKredi"].ToString());
                ekle.SubItems.Add(oku["ogrenciOgrenimTur"].ToString());
                ekle.SubItems.Add(oku["donem"].ToString());
                ekle.SubItems.Add(oku["bolumAd"].ToString());
                lvOgrenci.Items.Add(ekle);
            }
            oku.Close();
            conn1.Close();
        }
        public SqlConnection conn1 = new SqlConnection(@"Data Source=ErkanK;Initial Catalog=DTS;Integrated Security=SSPI;");

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form4 dersler = new Form4();
            dersler.Show();
            this.Hide();
        }

        private void dERSLERİMToolStripMenuItem_Click(object sender, EventArgs e)
        {

            pnlOgretmen.Visible = false;
            pnlOgretmenEkle.Visible = false;
            pnlOgrenciler.Visible = false;
            pnlOgrenciEkle.Visible = false;
            pnlDersler.Visible = true;
            pnlDersEkle.Visible = false;

            conn1.Close();

            cbxBolum.Items.Clear();
            cbEgitmen.Items.Clear();

            string Sqlsorgu1 = "SELECT * FROM tbl_Bolum";
            SqlCommand sqlCommand1 = new SqlCommand(Sqlsorgu1, conn1);
            conn1.Open();
            SqlDataReader reader = sqlCommand1.ExecuteReader();

            while (reader.Read())
            {
                cbxBolum.Items.Add(reader["bolumAd"]);
            }
            reader.Close();

            string Sqlsorgu2 = "SELECT * FROM tbl_Ogretmen";
            SqlCommand sqlCommand2 = new SqlCommand(Sqlsorgu2, conn1);
            SqlDataReader reader2 = sqlCommand2.ExecuteReader();

            while (reader2.Read())
            {
                cbEgitmen.Items.Add(reader2["ogretmenAd"]);
            }
            reader2.Close();

            conn1.Close();
       
            verilerigoster();
        }

        private void öĞRENCİLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            pnlOgretmen.Visible = false;
            pnlOgretmenEkle.Visible = false;
            pnlOgrenciler.Visible = true;
            pnlOgrenciEkle.Visible = false;
            pnlDersler.Visible = false;
            pnlDersEkle.Visible = false;
            
            Ogrenci();

        }

        private void eĞİTMENLERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            pnlOgretmen.Visible = true;
            pnlOgretmenEkle.Visible = false;
            pnlOgrenciler.Visible = false;
            pnlOgrenciEkle.Visible = false;
            pnlDersler.Visible = false;
            pnlDersEkle.Visible = false;


            Egitmen();

        }
        void Egitmen()
        {

            comboBox1.Text = "Bölüm Seçiniz";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "Select * from tbl_Bolum";
            string SqlSorgu = "SELECT bolumAd From tbl_Bolum Inner Join tbl_Ogretmen on tbl_Bolum.bolumNo=tbl_Ogretmen.bolumNo where ogretmenNo=" + ogretmenNo;
            komut.Connection = conn1;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            conn1.Close();
            conn1.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["bolumAd"]);
            }
            dr.Close();
            conn1.Close();
            verilerigoster2();
        }
        void Ogrenci()
        {
            cbbBolum.Items.Clear();
            string Sqlsorgu1 = "SELECT * FROM tbl_Bolum";
            SqlCommand sqlCommand1 = new SqlCommand(Sqlsorgu1, conn1);
            conn1.Close();
            conn1.Open();
            SqlDataReader reader = sqlCommand1.ExecuteReader();

            while (reader.Read())
            {
                cbbBolum.Items.Add(reader["bolumAd"]);
            }
            reader.Close();
            conn1.Close();
            verilerigoster3();
        }
        //void Ders()
        //{
        //    cbxBolum.Text = "Bölüm Seçiniz";
        //    cbEgitmen.Text = "Eğitmen Seçiniz";
        //    SqlCommand komut = new SqlCommand();
        //    komut.CommandText = "Select * from tbl_Bolum";
        //    string SqlSorgu = "SELECT bolumAd From tbl_Bolum Inner Join tbl_Ogrenci on tbl_Bolum.bolumNo=tbl_Ogrenci.ogrenciBolumNo where ogrenciNo=" + ogrenciNo;
        //    komut.Connection = conn1;
        //    komut.CommandType = CommandType.Text;
        //    SqlDataReader dr;
        //    conn1.Open();
        //    dr = komut.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        cbxBolum.Items.Add(dr["bolumAd"]);
        //    }
        //    dr.Close();
        //    conn1.Close();
        //    verilerigoster();
        //}
       

        private void button2_Click(object sender, EventArgs e)
        {
            //SqlCommand komut = new SqlCommand("Delete from tbl_Ogretmen where ogretmenNo =(" + ogretmenNo + ")", conn1);
            //conn1.Open();
            //komut.ExecuteNonQuery();
            //conn1.Close();
            //txtEgitmenAd.Text = "";
            //comboBox1.Text = "";
            //txtEgitmenMail.Text = "";
            //txtEgitmenSifre.Text = "";
            //verilerigoster();
            //verilerigoster2();
            //comboBox1.Text = "Bölüm Seçiniz";

        }
        int ogretmenNo = 0;
        int dersNo = 0;
        int ogrenciNo = 0;
        int bolumNo;
        private void button3_Click(object sender, EventArgs e)
        {
            //conn1.Open();

            //string sqlBilgi = "SELECT * From tbl_Bolum where bolumAd='" + comboBox1.Text.ToString() + "'";

            //SqlCommand sqlCommand1 = new SqlCommand(sqlBilgi, conn1);
            //SqlDataReader reader = sqlCommand1.ExecuteReader();

            //if (reader.Read())
            //{
            //     bolumNo =Convert.ToInt32( reader["bolumNo"]);
            //    reader.Close();
            //}
            //MessageBox.Show(bolumNo.ToString());
            //    SqlCommand komut = new SqlCommand("update tbl_Ogretmen set ogretmenMail='" + txtEgitmenMail.Text.ToString() + "',ogretmenSifre='" + txtEgitmenSifre.Text.ToString() + "',ogretmenAd='" + txtEgitmenAd.Text.ToString() + "', bolumNo="+bolumNo+" where ogretmenNo =" + ogretmenNo + "", conn1);
            //komut.ExecuteNonQuery();
            //conn1.Close();
            //txtEgitmenAd.Text = "";
            //txtEgitmenMail.Text = "";
            //txtEgitmenSifre.Text = "";
            //comboBox1.Text ="Bölüm Seçiniz";
            //verilerigoster2();
            //reader.Close();


        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            //conn1.Open();
            //SqlCommand komut2 = new SqlCommand("SELECT bolumNo FROM tbl_Bolum WHERE bolumAd='" + comboBox2.Text + "'", conn1);
            //SqlDataReader kmt2dr = komut2.ExecuteReader();
            //if (kmt2dr.Read())
            //{
            //    bolumno = Convert.ToInt32(kmt2dr["bolumNo"]);
            //}
            //kmt2dr.Close();

            //SqlCommand komut = new SqlCommand("Insert into tbl_Ogretmen (ogretmenMail,ogretmenSifre,ogretmenAd,bolumNo) Values ('" + textBox3.Text.ToString() + "' , '" + textBox2.Text.ToString() + "' , '" + textBox1.Text.ToString() + "' , '" + bolumno + "')", conn1);

            //komut.ExecuteNonQuery();
            //conn1.Close();
            //verilerigoster2();

            //txtEgitmenAd.Clear();
            //comboBox1.Text = "";
            //txtEgitmenMail.Clear();
            //txtEgitmenSifre.Clear();
            //comboBox1.Text = "Bölüm Seçiniz";
        }

        private void listView2_Click(object sender, EventArgs e)
        {

        }

        private void listView2_DoubleClick_1(object sender, EventArgs e)
        {
            ogretmenNo = int.Parse(listView2.SelectedItems[0].SubItems[0].Text);
            txtEgitmenMail.Text = listView2.SelectedItems[0].SubItems[1].Text;
            txtEgitmenSifre.Text = listView2.SelectedItems[0].SubItems[2].Text;
            txtEgitmenAd.Text = listView2.SelectedItems[0].SubItems[3].Text;
            comboBox1.Text = listView2.SelectedItems[0].SubItems[4].Text;
        }

        private void button3_Click_1(object sender, EventArgs e)//ÖĞRETMEN GÜNCELLEME BUTONU
        {
            conn1.Open();

            string sqlBilgi = "SELECT * From tbl_Bolum where bolumAd='" + comboBox1.Text.ToString() + "'";

            SqlCommand sqlCommand1 = new SqlCommand(sqlBilgi, conn1);
            SqlDataReader reader = sqlCommand1.ExecuteReader();

            if (reader.Read())
            {
                bolumNo = Convert.ToInt32(reader["bolumNo"]);
                reader.Close();
            }
            SqlCommand komut = new SqlCommand("update tbl_Ogretmen set ogretmenMail='" + txtEgitmenMail.Text.ToString() + "',ogretmenSifre='" + txtEgitmenSifre.Text.ToString() + "',ogretmenAd='" + txtEgitmenAd.Text.ToString() + "', bolumNo=" + bolumNo + " where ogretmenNo =" + ogretmenNo + "", conn1);
            komut.ExecuteNonQuery();
            conn1.Close();
            txtEgitmenAd.Text = "";
            txtEgitmenMail.Text = "";
            txtEgitmenSifre.Text = "";
            comboBox1.Text = "Bölüm Seçiniz";
            verilerigoster2();
            reader.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)//ÖĞRETMEN SİLME BUTONU
        {
            SqlCommand komut = new SqlCommand("Delete from tbl_Ogretmen where ogretmenNo =(" + ogretmenNo + ")", conn1);
            conn1.Open();
            komut.ExecuteNonQuery();
            conn1.Close();
            txtEgitmenAd.Text = "";
            comboBox1.Text = "";
            txtEgitmenMail.Text = "";
            txtEgitmenSifre.Text = "";
            verilerigoster();
            verilerigoster2();
            comboBox1.Text = "";

        }

        private void btnEkle_Click_1(object sender, EventArgs e)//ÖĞRETMEN EKLEME BUTONU
        {

            
                conn1.Open();
                SqlCommand komut2 = new SqlCommand("SELECT bolumNo FROM tbl_Bolum WHERE bolumAd='" + cBBolum.Text + "'", conn1);
                SqlDataReader kmt2dr = komut2.ExecuteReader();
                if (kmt2dr.Read())
                {
                    bolumno = Convert.ToInt32(kmt2dr["bolumNo"]);
                }
                kmt2dr.Close();

                SqlCommand komut = new SqlCommand("Insert into tbl_Ogretmen (ogretmenMail,ogretmenSifre,ogretmenAd,bolumNo) Values ('" + txtEkleOgretmenMail.Text.ToString() + "' , '" + txtEkleOgretmenSifre.Text.ToString() + "' , '" + txtEkleOgretmenAd.Text.ToString() + "' , '" + bolumno + "')", conn1);

                komut.ExecuteNonQuery();
                conn1.Close();
                txtEkleOgretmenMail.Clear();
                txtEkleOgretmenSifre.Clear();
                txtEkleOgretmenAd.Clear();
                cBBolum.Text = "Bölüm Seçiniz";

            MessageBox.Show("Eğitmen Ekleme İşlemi Başarılı");
            
         
    

        }

        private void eĞİTMENEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            pnlOgretmen.Visible = false;
            pnlOgretmenEkle.Visible = true;
            pnlOgrenciler.Visible = false;
            pnlOgrenciEkle.Visible = false;
            pnlDersler.Visible = false;
            pnlDersEkle.Visible = false;


            

            string Sqlsorgu1 = "SELECT * FROM tbl_Bolum";
            SqlCommand sqlCommand1 = new SqlCommand(Sqlsorgu1, conn1);
            conn1.Open();
            SqlDataReader reader = sqlCommand1.ExecuteReader();
            cBBolum.Items.Clear();
            cBBolum.Text = "Bölüm Seçiniz..";
            while (reader.Read())
            {
                cBBolum.Items.Add(reader["bolumAd"]);
            }
            
            reader.Close();
            conn1.Close();
            }
        

        private void öĞRENCİEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlOgretmen.Visible = false;
            pnlOgretmenEkle.Visible = false;
            pnlOgrenciler.Visible = false;
            pnlOgrenciEkle.Visible = true;
            pnlDersler.Visible = false;
            pnlDersEkle.Visible = false;

            cmbxEkleBolum.Items.Clear();

            cmbxEkleBolum.Text = "Bölüm Seçiniz..";
            cmbxEkleOgrenimTur.Text = "Öğrenim Türünü Seçiniz..";


            string Sqlsorgu1 = "SELECT * FROM tbl_Bolum";
            SqlCommand sqlCommand1 = new SqlCommand(Sqlsorgu1, conn1);
            conn1.Open();
            SqlDataReader reader = sqlCommand1.ExecuteReader();

            while (reader.Read())
            {
                cmbxEkleBolum.Items.Add(reader["bolumAd"]);
            }
            reader.Close();
            conn1.Close();



        }

        private void dERSEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlOgretmen.Visible = false;
            pnlOgretmenEkle.Visible = false;
            pnlOgrenciler.Visible = false;
            pnlOgrenciEkle.Visible = false;
            pnlDersler.Visible = false;
            pnlDersEkle.Visible = true;

            cmbxEkleDersBolum.Items.Clear();
            cmbxEkleDersEgitmen.Items.Clear();

            cmbxEkleDersBolum.Text = "Bölüm Seçiniz..";
            cmbxEkleDersEgitmen.Text = "Eğitmen Seçiniz..";

            string Sqlsorgu1 = "SELECT * FROM tbl_Bolum";
            SqlCommand sqlCommand1 = new SqlCommand(Sqlsorgu1, conn1);
            conn1.Open();
            SqlDataReader reader = sqlCommand1.ExecuteReader();
            while (reader.Read())
            {
                cmbxEkleDersBolum.Items.Add(reader["bolumAd"]);
            }
            reader.Close();

            string Sqlsorgu2 = "SELECT * FROM tbl_Ogretmen";
            SqlCommand sqlCommand2 = new SqlCommand(Sqlsorgu2, conn1);
            SqlDataReader reader2 = sqlCommand2.ExecuteReader();
            while (reader2.Read())
            {
                cmbxEkleDersEgitmen.Items.Add(reader2["ogretmenAd"]);
            }
            reader.Close();
            reader2.Close();

            conn1.Close();

        }

        private void btnOgrenciEkle_Click(object sender, EventArgs e)//ÖĞRENCİ EKLEME BUTONU
        {
           
          

            conn1.Open();
            SqlCommand komut2 = new SqlCommand("SELECT bolumNo FROM tbl_Bolum WHERE bolumAd='" + cmbxEkleBolum.Text + "'", conn1);
            SqlDataReader kmt2dr = komut2.ExecuteReader();
            if (kmt2dr.Read())
            {
                bolumno = Convert.ToInt32(kmt2dr["bolumNo"]);
            }
            kmt2dr.Close();
            SqlCommand komut = new SqlCommand("insert into tbl_Ogrenci (ogrenciNo,ogrenciAd,ogrenciSoyad,ogrenciDogumTarih,ogrenciKimlikNo,ogrenciKredi,ogrenciOgrenimTur,donem,ogrenciBolumNo) values ("+Convert.ToInt32(txtEkleOgrenciNumara.Text) +", '"+txtEkleOgrenciAd.Text+"', '"+txtEkleOgrenciSoyad.Text+"', '"+ dateTimePicker2.Text + "', '"+txtEkleTC.Text+"',"+Convert.ToInt32(txtEkleKredi.Text)+", '"+cmbxEkleOgrenimTur.Text+"', "+Convert.ToInt32(txtEkleDonem.Text)+","+ bolumno+")", conn1);

            komut.ExecuteNonQuery();
            conn1.Close();


            MessageBox.Show("Öğrenci Ekleme İşlemi Başarılı");

        }

        private void lvOgrenci_DoubleClick(object sender, EventArgs e)
        {
           
            txtOgrenciNo.Text = lvOgrenci.SelectedItems[0].SubItems[0].Text;
            txtOgrenciAd.Text = lvOgrenci.SelectedItems[0].SubItems[1].Text;
            txtOgrenciSoyad.Text = lvOgrenci.SelectedItems[0].SubItems[2].Text;
            dateTimePicker1.Text = lvOgrenci.SelectedItems[0].SubItems[3].Text;
            txtKimlikNo.Text = lvOgrenci.SelectedItems[0].SubItems[4].Text;
            txtKredi.Text = lvOgrenci.SelectedItems[0].SubItems[5].Text;
            cbTur.Text = lvOgrenci.SelectedItems[0].SubItems[6].Text;
            txtDonem.Text = lvOgrenci.SelectedItems[0].SubItems[7].Text;
            cbbBolum.Text = lvOgrenci.SelectedItems[0].SubItems[8].Text;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
            /*SqlCommand komut = new SqlCommand();
            komut.CommandText = "Select bolumNo from tbl_Bolum";
            komut.Connection = conn1;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            conn1.Open();
            dr = komut.ExecuteReader();
            while(dr.Read())
            {
                comboBox1.Items.Add("bolumNo");
            }
            conn1.Close();
            
            string SqlSorgu = "Select bolumNo from tbl_Bolum=" + comboBox1.Text;*/
        }

        //private void listView2_DoubleClick(object sender, EventArgs e)
        //{

        //    ogretmenNo = int.Parse(listView2.SelectedItems[0].SubItems[0].Text);
        //    txtEgitmenMail.Text = listView2.SelectedItems[0].SubItems[1].Text;
        //    txtEgitmenSifre.Text = listView2.SelectedItems[0].SubItems[2].Text;
        //    txtEgitmenAd.Text = listView2.SelectedItems[0].SubItems[3].Text;
        //    comboBox1.Text= listView2.SelectedItems[0].SubItems[4].Text;

           
        //}

        private void Form6_Load(object sender, EventArgs e)
        {

            string Sqlsorgu3 = "SELECT * FROM tbl_Admin where kullaniciAdi='" + kullaniciAdi + "'";
            SqlCommand sqlCommand3 = new SqlCommand(Sqlsorgu3, conn1);
            conn1.Open();
            SqlDataReader reader3 = sqlCommand3.ExecuteReader();

            if (reader3.Read())
            {
                if (Convert.ToInt32(reader3["yetkiDerecesi"]) == 1)
                {
                  
                    
                    dERSLERİMToolStripMenuItem.Enabled = false;
                    öĞRENCİLERToolStripMenuItem.Enabled = false;
                    eĞİTMENLERToolStripMenuItem.Enabled = false;
                    toolStripMenuItem2.Enabled = false;

                    reader3.Close();
                    conn1.Close();
                    eĞİTMENEKLEToolStripMenuItem.PerformClick();

                }
                else if (Convert.ToInt32(reader3["yetkiDerecesi"]) == 2)
                {
                  

                    eXCELEVERİAKTARToolStripMenuItem.Enabled = false;
                    eXCELDENVERİALToolStripMenuItem.Enabled = false;
                    eXCELEVERİAKTARToolStripMenuItem2.Enabled = false;
                    eXCELDENVERİALToolStripMenuItem1.Enabled = false;
                    eXCELDENVERİALToolStripMenuItem2.Enabled = false;
                    eXCELEVERİAKTARToolStripMenuItem1.Enabled = false;
                    toolStripMenuItem2.Enabled = false;
                    pbRapor.Enabled = false;
                    pbReport.Enabled = false;
                    pictureBox1.Enabled = false;
                    reader3.Close();
                    conn1.Close();

                    dERSLERİMToolStripMenuItem.PerformClick();

                }
                else if (Convert.ToInt32(reader3["yetkiDerecesi"]) == 3)
                {
                    
                    reader3.Close();
                    conn1.Close();

                    dERSLERİMToolStripMenuItem.PerformClick();

                }
            }


            

           

        }

        private void btnOgrenciGuncelle_Click(object sender, EventArgs e) //ÖĞRENCİ GÜNCELLEME BUTONU
        {
            conn1.Open();

            string sqlBilgi = "SELECT * From tbl_Bolum where bolumAd='" + cbbBolum.Text.ToString() + "'";

            SqlCommand sqlCommand1 = new SqlCommand(sqlBilgi, conn1);
            SqlDataReader reader = sqlCommand1.ExecuteReader();

            if (reader.Read())
            {
                bolumNo = Convert.ToInt32(reader["bolumNo"]);
                reader.Close();
            }
            SqlCommand komut = new SqlCommand("update tbl_Ogrenci set ogrenciAd='" + txtOgrenciAd.Text+ "',ogrenciSoyad='" + txtOgrenciSoyad.Text+ "', ogrenciDogumTarih='" + dateTimePicker1.Text +"', ogrenciKimlikNo='" + txtKimlikNo.Text+"', ogrenciKredi="+ Convert.ToInt32(txtKredi.Text)+", ogrenciOgrenimTur='"+ cbTur.Text+"', donem="+ Convert.ToInt32(txtDonem.Text)+", ogrenciBolumNo="+ bolumNo +" where ogrenciNo =" + Convert.ToInt32(txtOgrenciNo.Text), conn1);
            komut.ExecuteNonQuery();
            conn1.Close();
            
            verilerigoster3();
            reader.Close();
            txtOgrenciNo.Text = "";
            txtOgrenciAd.Text = "";
            txtOgrenciSoyad.Text = "";
            txtKimlikNo.Text = "";
            txtKredi.Text = "";
            txtDonem.Text = "";
            cbbBolum.Text = "";
            cbTur.Text = "";
        }

        private void btnOgrenciSil_Click(object sender, EventArgs e) // ÖĞRENCİ SİLME BUTONU
        {
            SqlCommand komut = new SqlCommand("Delete from tbl_Ogrenci where ogrenciNo =(" + Convert.ToInt32(txtOgrenciNo.Text) + ")", conn1);
            conn1.Open();
            komut.ExecuteNonQuery();
            conn1.Close();
            verilerigoster3();

            txtOgrenciNo.Text = "";
            txtOgrenciAd.Text = "";
            txtOgrenciSoyad.Text = "";
            txtKimlikNo.Text = "";
            txtKredi.Text = "";
            txtDonem.Text = "";
            cbbBolum.Text = "Bölüm Seçiniz";
            cbTur.Text = "";
        }
        private void button6_Click(object sender, EventArgs e) //DERS EKLEME BUTONU
        {

            string sqlBilgi = "SELECT * From tbl_Bolum where bolumAd='" + cmbxEkleDersBolum.Text.ToString() + "'";
            conn1.Open();
            SqlCommand sqlCommand1 = new SqlCommand(sqlBilgi, conn1);
            SqlDataReader reader = sqlCommand1.ExecuteReader();

            if (reader.Read())
            {
                bolumNo = Convert.ToInt32(reader["bolumNo"]);
                reader.Close();
            }

            string sqlBilgi2 = "SELECT * From tbl_Ogretmen where ogretmenAd='" + cmbxEkleDersEgitmen.Text.ToString()+"'";

            SqlCommand sqlCommand2 = new SqlCommand(sqlBilgi2, conn1);
            SqlDataReader reader2 = sqlCommand2.ExecuteReader();

            if (reader2.Read())
            {
                ogretmenNo = Convert.ToInt32(reader2["ogretmenNo"]);
                reader2.Close();
            }
            

            SqlCommand komut=new SqlCommand("INSERT INTO tbl_Dersler (dersAd,dersKontenjan,dersKredi,bolumNo,donem,ogrenciSayisi,ogretmenNo) values('"+txtEkleDersAd.Text+"',"+ Convert.ToInt32(txtEkleDersKontenjan.Text)+","+ Convert.ToInt32(txtEkleDersKredi.Text)+","+ bolumNo+","+ Convert.ToInt32(txtEkleDersDonem.Text)+","+ Convert.ToInt32(txtEkleMevcut.Text)+","+ ogretmenNo+")",conn1);
            komut.ExecuteNonQuery();
                conn1.Close();
            txtEkleDersAd.Text = "";
            txtEkleDersDonem.Text = "";
            txtEkleDersKontenjan.Text = "";
            txtEkleDersKredi.Text = "";
            txtEkleMevcut.Text = "";
            cmbxEkleDersBolum.Text = "Bölüm Seçiniz";
            cmbxEkleDersEgitmen.Text="Eğitmen Seçiniz";

            MessageBox.Show("Ders Ekleme İşlemi Başarılı");

        }
        public string dersadi;
        private void lvDersler_DoubleClick(object sender, EventArgs e)
        {           
            txtDersAd.Text = lvDersler.SelectedItems[0].SubItems[1].Text;
            dersadi = txtDersAd.Text;
            txtKontenjan.Text = lvDersler.SelectedItems[0].SubItems[2].Text;
            txtDersSilKredi.Text = lvDersler.SelectedItems[0].SubItems[3].Text;
            cbxBolum.Text = lvDersler.SelectedItems[0].SubItems[4].Text;
            txtDersSilDonem.Text = lvDersler.SelectedItems[0].SubItems[5].Text;
            txtMevcut.Text = lvDersler.SelectedItems[0].SubItems[6].Text;
            cbEgitmen.Text = lvDersler.SelectedItems[0].SubItems[7].Text;
        }
        public int ogretmenno2;
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            conn1.Open();
           
            string sqlBilgi = "SELECT * From tbl_Bolum where bolumAd='" + cbxBolum.Text.ToString() + "'";

            SqlCommand sqlCommand1 = new SqlCommand(sqlBilgi, conn1);
            SqlDataReader reader = sqlCommand1.ExecuteReader();

            if (reader.Read())
            {
                bolumNo = Convert.ToInt32(reader["bolumNo"]);
                reader.Close();
            }
            conn1.Close();
            conn1.Open();
            SqlCommand kmt = new SqlCommand("select ogretmenNo from tbl_Ogretmen where ogretmenAd='" + cbEgitmen.SelectedItem.ToString() + "'",conn1);
            SqlDataReader reader2 = kmt.ExecuteReader();
            if(reader2.Read())
            {
                 ogretmenno2 = Convert.ToInt16(reader2["ogretmenNo"].ToString());
            }
            conn1.Close();
            conn1.Open();
            SqlCommand komut = new SqlCommand("update tbl_Dersler set dersAd='"+txtDersAd.Text+"',dersKontenjan="+Convert.ToInt32(txtKontenjan.Text)+ ",dersKredi=" + Convert.ToInt32(txtDersSilKredi.Text) + ",bolumNo=" + bolumNo+ ",donem=" + Convert.ToInt32(txtDersSilDonem.Text) + ",ogrenciSayisi=" + Convert.ToInt32(txtMevcut.Text) + ",ogretmenNo=" + ogretmenno2 + " where dersAd='" + dersadi+"'", conn1);
            komut.ExecuteNonQuery();
            conn1.Close();

            verilerigoster();
            reader.Close();
            txtDersAd.Text = "";
            txtKontenjan.Text = "";
            txtDersSilKredi.Text = "";
            txtMevcut.Text = "";
            txtDersSilDonem.Text = "";
            cbxBolum.Text = "Bölüm Seçiniz";
            cbEgitmen.Text = "Eğitmen Seçiniz";
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        { conn1.Open();
            SqlCommand komut = new SqlCommand("Delete from tbl_Dersler where dersAd ='" +txtDersAd.Text + "'", conn1);
           
            komut.ExecuteNonQuery();
            conn1.Close();
            verilerigoster();

            txtDersAd.Text = "";
            txtDersSilDonem.Text = "";
            txtDersSilKredi.Text = "";
            txtKontenjan.Text = "";
            txtMevcut.Text = "";
            cbxBolum.Text = "Bölüm Seçiniz";
            cbEgitmen.Text = "Eğitmen Seçiniz";
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void sQLYEDEKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conn1.Open();
            SqlCommand backupKod = new SqlCommand("BACKUP DATABASE [DTS] TO  DISK = 'D:/Backup/dts.bak'", conn1);
            backupKod.ExecuteNonQuery();
            conn1.Close();
            MessageBox.Show("SQL Yedekleme İşlemi Başarılı");
        }

        private void sQLYÜKLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand restore = new SqlCommand("USE[Deneme] RESTORE DATABASE [DTS] FROM DISK=N'D:/Backup/dts.bak' WITH FILE=1,NOUNLOAD,STATS=5", conn1);
                conn1.Open();
                restore.ExecuteNonQuery();
                conn1.Close();
                MessageBox.Show("Restore İşlemi Başarılı.");
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Şeyler Ters Gitti!!");

                throw;
            }
        }

        private void pbReport_Click(object sender, EventArgs e)
        {
            Form7 rapor = new Form7();
            rapor.Show();
        }

        private void pbRapor_Click(object sender, EventArgs e)
        {
            Form8 rapor = new Form8();
            rapor.Show();
        }

        private void pnlOgretmen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Form9 rapor = new Form9();
            rapor.Show();

        }

        private void pbReport_MouseHover(object sender, EventArgs e)
        {

            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pbReport, "Rapor Hazırla");
        }

        private void eXCELDENVERİALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya2 = new OpenFileDialog();
            dosya2.Filter = "Excel Dosyası |*.xlsx";
            dosya2.Title = "Ders Takip Sistemi      - Excell Dosyası Seçin!";
            dosya2.ShowDialog();
            string Dosyayolu = dosya2.FileName;
            excell excel = new excell(@"" + Dosyayolu + "", 1);

            for (int i = 1; i < 100; i++)
            {
                try
                {
                    string dersAd2 = excel.ReadCell(i, 0);
                    int dersKontenjan2 = Convert.ToInt16(excel.ReadCell(i, 1));
                    int dersKredi2 = Convert.ToInt16(excel.ReadCell(i, 2));
                    int bolumNo2 = Convert.ToInt16(excel.ReadCell(i, 3));
                    int donem2 = Convert.ToInt16(excel.ReadCell(i, 4));
                    int ogrenciSayisi2 = Convert.ToInt16(excel.ReadCell(i, 5));
                    int ogretmenNo2 = Convert.ToInt16(excel.ReadCell(i, 6));


                    conn1.Open();
                    SqlCommand kmt2 = new SqlCommand("INSERT INTO tbl_Dersler (dersAd,dersKontenjan,dersKredi,bolumNo,donem,ogrenciSayisi,ogretmenNo) values('" + dersAd2 + "'," + dersKontenjan2 + "," + dersKredi2 + "," + bolumNo2 + "," + donem2 + "," + ogrenciSayisi2 + "," + ogretmenNo2 + ")", conn1);
                    kmt2.ExecuteNonQuery();
                    conn1.Close();
                }
                catch (Exception)
                {
                    dERSLERİMToolStripMenuItem.PerformClick();
                    break;
                }
            }
            dERSLERİMToolStripMenuItem.PerformClick();
            excel.kapat();

        }

        private void eXCELEVERİAKTARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            object Missing = Type.Missing;
            Workbook workbook = excel.Workbooks.Add(Missing);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            int StartCol = 1;
            int StartRow = 1;
            for (int j = 0; j < 8; j++)
            {
                Range myRange = (Range)sheet1.Cells[StartRow, StartCol + j];
                myRange.Value2 = lvDersler.Columns[j].Text;
            }
            StartRow++;
            for (int i = 0; i < lvDersler.Items.Count; i++)
            {
                for (int j = 0; j < lvDersler.Columns.Count; j++)
                {

                    Range myRange = (Range)sheet1.Cells[StartRow + i, StartCol + j];
                    myRange.Value2 = lvDersler.Items[i].SubItems[j].Text == null ? "" : lvDersler.Items[i].SubItems[j].Text;
                    myRange.Select();


                }
            }
        }

        private void eXCELEVERİAKTARToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            object Missing = Type.Missing;
            Workbook workbook = excel.Workbooks.Add(Missing);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            int StartCol = 1;
            int StartRow = 1;
            for (int j = 0; j < 9; j++)
            {
                Range myRange = (Range)sheet1.Cells[StartRow, StartCol + j];
                myRange.Value2 = lvOgrenci.Columns[j].Text;
            }
            StartRow++;
            for (int i = 0; i < lvOgrenci.Items.Count; i++)
            {
                for (int j = 0; j < lvOgrenci.Columns.Count; j++)
                {

                    Range myRange = (Range)sheet1.Cells[StartRow + i, StartCol + j];
                    myRange.Value2 = lvOgrenci.Items[i].SubItems[j].Text == null ? "" : lvOgrenci.Items[i].SubItems[j].Text;
                    myRange.Select();


                }
            }
        }

        private void eXCELDENVERİALToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya2 = new OpenFileDialog();
            dosya2.Filter = "Excel Dosyası |*.xlsx";
            dosya2.Title = "Ders Takip Sistemi      - Excell Dosyası Seçin!";
            dosya2.ShowDialog();
            string Dosyayolu = dosya2.FileName;
            excell excel = new excell(@"" + Dosyayolu + "", 1);

            for (int i = 1; i < 100; i++)
            {

                try { 
                    int ogrenciNo = Convert.ToInt32(excel.ReadCell(i, 0));
                    string ogrenciAd = excel.ReadCell(i, 1);
                    string ogrenciSoyad = excel.ReadCell(i, 2);
                    string ogrenciDogumTarihi = excel.ReadCell(i, 3).ToString();
                    string ogrenciKimlikNo = excel.ReadCell(i, 4);
                    int ogrenciKredi = Convert.ToInt16(excel.ReadCell(i, 5));
                    string ogrenciOgrenimTur = excel.ReadCell(i, 6);
                    int ogrenciDonem = Convert.ToInt16(excel.ReadCell(i,7));
                    int ogrenciBolumNo = Convert.ToInt16(excel.ReadCell(i, 8));


                    conn1.Open();
                    SqlCommand kmt2 = new SqlCommand("insert into tbl_Ogrenci (ogrenciNo,ogrenciAd,ogrenciSoyad,ogrenciDogumTarih,ogrenciKimlikNo,ogrenciKredi,ogrenciOgrenimTur,donem,ogrenciBolumNo) values (" + ogrenciNo + ", '" + ogrenciAd + "', '" + ogrenciSoyad + "', '" + ogrenciDogumTarihi.ToString() + "', '" + ogrenciKimlikNo+ "'," + ogrenciKredi + ", '" + ogrenciOgrenimTur + "', " + ogrenciDonem + "," + ogrenciBolumNo + ")", conn1);
                    kmt2.ExecuteNonQuery();
                    conn1.Close();
            }
                catch (Exception)
            {
                    öĞRENCİLERToolStripMenuItem.PerformClick();
                break;
            }
        }
            öĞRENCİLERToolStripMenuItem.PerformClick();
            excel.kapat();
        }

        private void eXCELEVERİAKTARToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            object Missing = Type.Missing;
            Workbook workbook = excel.Workbooks.Add(Missing);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            int StartCol = 1;
            int StartRow = 1;
            for (int j = 0; j < 5; j++)
            {
                Range myRange = (Range)sheet1.Cells[StartRow, StartCol + j];
                myRange.Value2 = listView2.Columns[j].Text;
            }
            StartRow++;
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                for (int j = 0; j < listView2.Columns.Count; j++)
                {

                    Range myRange = (Range)sheet1.Cells[StartRow + i, StartCol + j];
                    myRange.Value2 = listView2.Items[i].SubItems[j].Text == null ? "" : listView2.Items[i].SubItems[j].Text;
                    myRange.Select();


                }
            }
        }

        private void eXCELDENVERİALToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya2 = new OpenFileDialog();
            dosya2.Filter = "Excel Dosyası |*.xlsx";
            dosya2.Title = "Ders Takip Sistemi      - Excell Dosyası Seçin!";
            dosya2.ShowDialog();
            string Dosyayolu = dosya2.FileName;
            excell excel = new excell(@"" + Dosyayolu + "", 1);

            for (int i = 1; i < 100; i++)
            {

                try
                {
                    string ogretmenMail = excel.ReadCell(i, 0).ToString() ;
                string ogretmenSifre = excel.ReadCell(i, 1).ToString();
                    string ogretmenAd = excel.ReadCell(i, 2).ToString();         
                    int ogretmenBolumNo = Convert.ToInt16(excel.ReadCell(i, 3));

                MessageBox.Show(ogretmenMail);
                MessageBox.Show(ogretmenSifre);
                MessageBox.Show(ogretmenAd);
                MessageBox.Show(ogretmenBolumNo.ToString());
                    

                    conn1.Open();
                    SqlCommand kmt2 = new SqlCommand("Insert into tbl_Ogretmen (ogretmenMail,ogretmenSifre,ogretmenAd,bolumNo) Values ('" + ogretmenMail + "' , '" + ogretmenSifre + "' , '" + ogretmenAd + "' , " + ogretmenBolumNo + ")", conn1);
                    kmt2.ExecuteNonQuery();
                    conn1.Close();
                }
                catch (Exception)
                {
                    eĞİTMENLERToolStripMenuItem.PerformClick();
                    break;
                }
            }
            eĞİTMENLERToolStripMenuItem.PerformClick();
            excel.kapat();
        }

        private void yETKİLENDİRMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 yetki = new Form11();
            yetki.Show();
        }
    }
}
