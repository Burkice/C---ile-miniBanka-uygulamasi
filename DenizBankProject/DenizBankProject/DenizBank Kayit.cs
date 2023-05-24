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
    public partial class DenizBank_Kayit : Form
    {
        SqlCommand cmd;
        SqlDataReader reader;
        SqlConnection conn;

        public DenizBank_Kayit()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hesap Oluşturmak İçin Bir Miktar Para Yatırmanız Gerekmektedir","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=BURAK_LAPTOP;Initial Catalog=DenizBank;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Musteriler(tcNo,adSoyad,adres,telefon,sifre,bakiye) values ('" + txt_tc.Text + "','" + txt_adSoyad.Text + "','" + txt_adres.Text + "','" + txt_tel.Text + "','" + textBox1.Text + "','" + txt_bakiye.Text + "')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("DenizBank'a Hoşgeldiniz Kaydınız Başarıyla Yapıldı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            FrmBireyselGiris frmBireyselGiris = new FrmBireyselGiris();
            frmBireyselGiris.Show();
            this.Hide();
        }
    }
}
