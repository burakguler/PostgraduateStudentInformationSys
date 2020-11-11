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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        public SqlConnection conn1 = new SqlConnection(@"Data Source=ErkanK;Initial Catalog=DTS;Integrated Security=True;");
        DataTable tablo = new DataTable();

        private void Form7_Load(object sender, EventArgs e)
        {
            SqlDataAdapter komut = new SqlDataAdapter("Select * from tbl_Dersler", conn1);
            komut.Fill(tablo);
            CrystalReport5 rapor = new CrystalReport5();
            rapor.SetDataSource(tablo);
            crystalReportViewer1.ReportSource = rapor;
        }
    }
}
