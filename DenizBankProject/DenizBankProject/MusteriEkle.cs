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

namespace DenizBankProject
{
    public partial class MusteriEkle : Form
    {
        SqlCommand cmd;
        SqlDataReader reader;
        SqlConnection conn;

        public MusteriEkle()
        {
            InitializeComponent();
        }


        private void sımplebutton1_Click(object sender, EventArgs e)
        {
        
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=BURAK_LAPTOP;Initial Catalog=DenizBank;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Musteriler(tcNo,adSoyad,adres,telefon,sifre,bakiye) values ('" + txt_tc.Text + "','" + txt_adSoyad.Text + "','" + txt_adres.Text + "','"+txt_tel.Text+"','" + textBox1.Text + "','" + txt_bakiye.Text + "')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Müşteri Kaydı Başarıyla Yapıldı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FrmYetkili frmYetkili = new FrmYetkili();
            frmYetkili.Show();
            this.Hide();
        }
    }
}
