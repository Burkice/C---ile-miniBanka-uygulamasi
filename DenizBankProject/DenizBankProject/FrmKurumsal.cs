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
    public partial class FrmKurumsal : Form
    {
       
        public FrmKurumsal()
        {
            InitializeComponent();
             
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string KullaniciAdi=txt_kullanici.Text;
            string sifre=txt_sifre.Text;

            if(KullaniciAdi=="admin"&& sifre=="123") 
            {
                MessageBox.Show("Giriş Başarılı");
                FrmYetkili frmYetkili = new FrmYetkili();
                frmYetkili.Show();
                this.Hide();
                
            
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı Lütfen Yönetici ile iletişime Geçin ","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}


//Data Source=BURAK_LAPTOP;Initial Catalog=DenizBank;Integrated Security=True