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
    public partial class SifreDegistirme : Form
    {
        public SifreDegistirme()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=BURAK_LAPTOP;Initial Catalog=DenizBank;Integrated Security=True");


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txt_eskiSifre.Text == " " || txt_yeniSifre.Text==" " )
            {
                MessageBox.Show("Lütfen Gerekli Alanları Doldurunuz");

            }
            else if(txt_yeniSifre.Text.Length < 5) 
            {
                MessageBox.Show("En az 5 karakter uzunluğunda şifre belirleyiniz");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("update Musteriler set sifre =@p1 where sifre=@p2 ", conn);
                cmd.Parameters.AddWithValue("@p1", txt_yeniSifre.Text);
                cmd.Parameters.AddWithValue("@p2", txt_eskiSifre.Text);

                conn.Open();

                int sonuc=cmd.ExecuteNonQuery();
                if(sonuc==1)
                {
                    MessageBox.Show("Şifre Değiştirme İşlemi Başarıyla Oluşturuldu");
                }
                else {

                    MessageBox.Show("Şifre Değiştirme Başarısız");
                
                }
                conn.Close();
                txt_eskiSifre.Text = " ";
                txt_yeniSifre.Text= " ";


            }
            


            

        }

        private void txt_yeniSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_eskiSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FrmMusteri frmMusteri = new FrmMusteri();
            frmMusteri.Show();
            this.Hide();
        }
    }
}
