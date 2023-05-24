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
    public partial class Havale : Form
    {
        public Havale()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=BURAK_LAPTOP;Initial Catalog=DenizBank;Integrated Security=True");

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            float sayi= float.Parse(txt_havale.Text);
            if (sayi > FrmBireyselGiris.mBakiye)
            {
                MessageBox.Show("Yetersiz Bakiye","Havake İşlemi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("update Musteriler set bakiye=bakiye - @p1 where ID= @p2 ", conn);
                cmd.Parameters.AddWithValue("@p1", sayi);
                cmd.Parameters.AddWithValue("@p2", FrmBireyselGiris.mId);

                SqlCommand cmd2 = new SqlCommand("update Musteriler set bakiye= bakiye + @p3 where ID= @p4 ", conn);
                cmd2.Parameters.AddWithValue("@p3", txt_havale.Text);
                cmd2.Parameters.AddWithValue("@p4", txt_hesapNo.Text);

                if (sayi < 10)
                {
                    MessageBox.Show("Lütfen 10 tl üzerşi giriniz");
                }
                else
                {
                    conn.Open();
                    int sonuc1 = cmd2.ExecuteNonQuery();
                    conn.Close();
                    if (sonuc1 == 1)
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Havale İşlemi Gerçekleştiriildi");
                        FrmBireyselGiris.mBakiye -= sayi;




                    }
                    else
                    {

                        MessageBox.Show("Alıcı Hesap No Hatalı");

                    }


                }
                
            }
            txt_havale.Text = null;
            txt_hesapNo.Text = null;



        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FrmMusteri frmMusteri = new FrmMusteri();
            frmMusteri.Show();
            this.Hide();
        }
    }
}
