using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DenizBankProject
{
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=BURAK_LAPTOP;Initial Catalog=DenizBank;Integrated Security=True");

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txt_tc.Text == " " || txt_tel.Text == " " || txt_yeniSifre.Text==" ")
            {
                MessageBox.Show("Lütfen Gerekli Alanları Doldurunuz");

            }
            else if (txt_yeniSifre.Text.Length < 5)
            {
                MessageBox.Show("En az 5 karakter uzunluğunda şifre belirleyiniz");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("update Musteriler set sifre =@p1 where tcNo=@p2 and telefon= @p3 ", conn);
                cmd.Parameters.AddWithValue("@p1", txt_yeniSifre.Text);
                cmd.Parameters.AddWithValue("@p2", txt_tc.Text);
                cmd.Parameters.AddWithValue("@p3", txt_tel.Text);

                conn.Open();

                int sonuc = cmd.ExecuteNonQuery();
                if (sonuc == 1)
                {
                    MessageBox.Show("Yeni Şifre Oluşturma  İşlemi Başarıyla Gerçekleştirildi");
                    
                }
                else
                {

                    MessageBox.Show("Şifre Değiştirme Başarısız");

                }
                conn.Close();
                txt_tel.Text = " "; 
                txt_tc.Text = " ";
                txt_yeniSifre.Text = " ";

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FrmBireyselGiris frmBireyselGiris = new FrmBireyselGiris();
            frmBireyselGiris.Show();
            this.Hide();
        }
    }
}
