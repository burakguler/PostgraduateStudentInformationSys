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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string ogrenciNumara;
        SqlCommand cmd;
        public SqlConnection conn1 = new SqlConnection(@"Data Source=ErkanK;Initial Catalog=DTS;Integrated Security=True;");

        private void dERSLERİMToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 dersler = new Form1();
            dersler.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            

            lbMevcutDersler.SelectionMode = SelectionMode.MultiSimple; // Çoklu seçim
            lbSecilenDersler.SelectionMode = SelectionMode.MultiSimple;
            pnlBilgiler.Visible = false;
            panelDersSecme.Visible = false;

            dersDoldur();

        }
        void dersDoldur() {
            lvDersler.Items.Clear();
            conn1.Open();
            int i = 0;
            int kayits = 1;
            SqlCommand cmd = new SqlCommand("select count(*) from tbl_OgrenciDers", conn1);
            kayits = Convert.ToInt32(cmd.ExecuteScalar());
            int[] dersler= new int[kayits];
            string Sqlsorgu1 = "SELECT * from tbl_OgrenciDers where ogrenciNo=" + ogrenciNumara;
            SqlCommand sqlCommand1 = new SqlCommand(Sqlsorgu1, conn1);
            SqlDataReader reader = sqlCommand1.ExecuteReader();

            while (reader.Read())
            {
                dersler[i] =Convert.ToInt32(reader["dersNo"]);
                i++;
            }

            reader.Close();

            string Sqlsorgu2 = "SELECT * from tbl_Dersler inner join tbl_Ogretmen on tbl_Dersler.ogretmenNo=tbl_Ogretmen.ogretmenNo";
                SqlCommand sqlCommand2 = new SqlCommand(Sqlsorgu2, conn1);

                SqlDataReader reader2 = sqlCommand2.ExecuteReader();
                while (reader2.Read())
                {
                bool sonuc = Kontrol(Convert.ToInt32(ogrenciNumara), Convert.ToInt32(reader2["dersNo"]));

                if (sonuc == false)
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = reader2["dersAd"].ToString();
                    ekle.SubItems.Add(reader2["dersKontenjan"].ToString());
                    ekle.SubItems.Add(reader2["dersKredi"].ToString());
                    ekle.SubItems.Add(reader2["ogrenciSayisi"].ToString());
                    ekle.SubItems.Add(reader2["ogretmenAd"].ToString());
                    lvDersler.Items.Add(ekle);
                }
               
                }
                reader2.Close();

            
            conn1.Close();
        }
        //bool ogretmenKontrol(int[] dersler,int kayits)
        //{
        //    con.Open();
        //    string Sqlsorgu1 = "SELECT * from tbl_OgrenciDers";
        //    SqlCommand sqlCommand1 = new SqlCommand(Sqlsorgu1, con);

        //    SqlCommand cmd = new SqlCommand("select count(*) from tbl_OgrenciDers", con);
        //    kayitSayisi = Convert.ToInt32(cmd.ExecuteScalar());

        //    SqlDataReader reader2 = sqlCommand1.ExecuteReader();

        //    while (reader2.Read())
        //    {
        //        if (dersNo == Convert.ToInt32(reader2["dersNo"]) && ogrenciNo == Convert.ToInt32(reader2["ogrenciNo"]))
        //        {
        //            return false;
        //        }
        //    }
        //    reader2.Close();
        //    con.Close();
        //    return true;

        //}
        private void dERSSEÇMEToolStripMenuItem_Click(object sender, EventArgs e)
        {

            lbMevcutDersler.Items.Clear();
            lbSecilenDersler.Items.Clear();
            pnlBilgiler.Visible = false;
            panelDersSecme.Visible = true;
            pnlDerslerim.Visible = false;


            string Sqlsorgu1 = "SELECT * FROM tbl_Dersler Inner Join tbl_Ogrenci a1 on (tbl_Dersler.bolumNo=a1.ogrenciBolumNo)  where tbl_Dersler.donem=a1.donem and  a1.ogrenciNo=" + ogrenciNumara;
            SqlCommand sqlCommand1 = new SqlCommand(Sqlsorgu1, conn1);
            conn1.Open();
            SqlDataReader reader = sqlCommand1.ExecuteReader();

            while (reader.Read())
            {
                bool sonuc = Kontrol(Convert.ToInt32(ogrenciNumara), Convert.ToInt32(reader["dersNo"]));

                if (sonuc == true)
                {
                    lbMevcutDersler.Items.Add(reader["dersAd"].ToString());
                }
               
            }
            if (lbMevcutDersler.Items.Count == 0)
            {
                MessageBox.Show("Alabileceğiniz Ders Bulunmamaktadır !!");
            }
            reader.Close();
            conn1.Close();
            

        }
        int kayitSayisi = 1;

        bool Kontrol(int ogrenciNo, int dersNo)
        {
            SqlConnection con = new SqlConnection("Data Source=ErkanK;Initial Catalog=DTS;Integrated Security=True;");

            con.Open();
            string Sqlsorgu1 = "SELECT * from tbl_OgrenciDers";
            SqlCommand sqlCommand1 = new SqlCommand(Sqlsorgu1, con);

            SqlCommand cmd = new SqlCommand("select count(*) from tbl_OgrenciDers", con);
            kayitSayisi = Convert.ToInt32(cmd.ExecuteScalar());

            SqlDataReader reader2 = sqlCommand1.ExecuteReader();

            while (reader2.Read())
            {
                if (dersNo == Convert.ToInt32(reader2["dersNo"]) && ogrenciNo == Convert.ToInt32(reader2["ogrenciNo"]))
                {
                    return false;
                }
            }
            reader2.Close();
            con.Close();
            return true;
        }
        private void bİLGİLERİMToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string Sqlsorgu1 = "SELECT * FROM tbl_Ogrenci WHERE ogrenciNo="+ ogrenciNumara;
            string Sqlsorgu2 = "SELECT bolumAd From tbl_Bolum Inner Join tbl_Ogrenci on tbl_Bolum.bolumNo=tbl_Ogrenci.ogrenciBolumNo where ogrenciNo="+ ogrenciNumara;
            SqlCommand sqlCommand1 = new SqlCommand(Sqlsorgu1, conn1);
            SqlCommand sqlCommand2 = new SqlCommand(Sqlsorgu2, conn1);
            conn1.Open();
            SqlDataReader reader = sqlCommand1.ExecuteReader();

            if (reader.Read())
            {
                lblAdSoyad.Text = "Merhaba"+" "+reader["ogrenciAd"].ToString() + " "+reader["ogrenciSoyad"].ToString();
                lblOgrenciNo.Text = reader["ogrenciNo"].ToString();
                lblDogumTarih.Text = reader["ogrenciDogumTarih"].ToString().Substring(0,10);
                lblKimlikNo.Text = reader["ogrenciKimlikNo"].ToString();
                lblKredi.Text = reader["ogrenciKredi"].ToString();
                lblDonem.Text = reader["donem"].ToString();
                lblOgrenimTuru.Text = reader["ogrenciOgrenimTur"].ToString();
                reader.Close();
            }
            SqlDataReader reader2 = sqlCommand2.ExecuteReader();

            if (reader2.Read())
            {
                lblBolum.Text = reader2["bolumAd"].ToString();
                reader2.Close();
            }
            conn1.Close();

           
            pnlBilgiler.Visible = true;
            panelDersSecme.Visible = false;
            pnlDerslerim.Visible = false;
            
        }

        private void dERSLERİMToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            pnlBilgiler.Visible = false;
            panelDersSecme.Visible = false;
            pnlDerslerim.Visible = true;
            dersDoldur();

        }

        private void panelDersSecme_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pbEkle_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pbEkle, "Ders Ekle");
        }

        private void pbCikar_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pbCikar, "Ders Çıkar");
        }

        private void pbKaydet_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pbKaydet, "Değişiklikleri Kaydet");
        }

        private void pbEkle_Click(object sender, EventArgs e)
        {
            for (int i = lbMevcutDersler.SelectedIndices.Count - 1; i >= 0; i--)
            {
                //Seçili elemanı ikinci listeye ekle
                lbSecilenDersler.Items.Add(lbMevcutDersler.SelectedItems[i]);
                //seçili elemanı birinci listeden çıkar
                lbMevcutDersler.Items.RemoveAt(lbMevcutDersler.SelectedIndices[i]);
            }
        }

        private void pbCikar_Click(object sender, EventArgs e)
        {
            for (int i = lbSecilenDersler.SelectedIndices.Count - 1; i >= 0; i--)
            {
                //Seçili elemanı ikinci listeye ekle
                lbMevcutDersler.Items.Add(lbSecilenDersler.SelectedItems[i]);
                //seçili elemanı birinci listeden çıkar
                lbSecilenDersler.Items.RemoveAt(lbSecilenDersler.SelectedIndices[i]);
            }
        }

        private void pbKaydet_Click(object sender, EventArgs e)
        {

            int toplamkredi = 0;
            try
            {
                string Sqlsorgu1 = "SELECT dersAd,dersKredi FROM tbl_Dersler";
                SqlCommand sqlCommand1 = new SqlCommand(Sqlsorgu1, conn1);
                string Sqlsorgu2 = "SELECT ogrenciKredi FROM tbl_Ogrenci where ogrenciNo=" + ogrenciNumara;
                SqlCommand sqlCommand2 = new SqlCommand(Sqlsorgu2, conn1);
                conn1.Open();
                SqlDataReader reader = sqlCommand1.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < lbSecilenDersler.Items.Count; i++)
                    {
                        if (reader["dersAd"].ToString() == lbSecilenDersler.Items[i].ToString())
                        {
                            toplamkredi = toplamkredi + Convert.ToInt32(reader["dersKredi"]);
                        }
                    }

                }
                reader.Close();

                SqlDataReader reader2 = sqlCommand2.ExecuteReader();
                if (reader2.Read())
                {

                    if (Convert.ToInt32(reader2["ogrenciKredi"]) >= toplamkredi)
                    {
                        reader2.Close();

                        string Sqlsorgu3 = "SELECT * FROM tbl_Dersler";
                        SqlCommand sqlCommand3 = new SqlCommand(Sqlsorgu3, conn1);
                        SqlDataReader reader3 = sqlCommand3.ExecuteReader();
                        int[] index = new int[lbSecilenDersler.Items.Count];
                        int index2 = 0;
                        while (reader3.Read())
                        {
                            for (int i = 0; i < lbSecilenDersler.Items.Count; i++)
                            {
                                if (reader3["dersAd"].ToString() == lbSecilenDersler.Items[i].ToString())
                                {
                                    index[i] = Convert.ToInt32(reader3["dersNo"]);
                                }
                            }
                        }
                        reader3.Close();

                        for (int i = 0; i < lbSecilenDersler.Items.Count; i++)
                        {
                            cmd = new SqlCommand("insert tbl_OgrenciDers (ogrenciNo,dersNo) values (@ogrenciNo,@dersNo)", conn1);
                            cmd.Parameters.AddWithValue("@ogrenciNo", Convert.ToInt32(ogrenciNumara));
                            cmd.Parameters.AddWithValue("@dersNo", index[i]);
                            cmd.ExecuteNonQuery();
                        }
                        conn1.Close();
                        MessageBox.Show("Dersleriniz Başarıyla Eklenmiştir.");

                    }
                    else
                    {
                        MessageBox.Show("Krediniz bu dersleri almaya yetmiyor.");
                    }
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
            finally
            {
                conn1.Close();
            }
            lbSecilenDersler.Items.Clear();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
