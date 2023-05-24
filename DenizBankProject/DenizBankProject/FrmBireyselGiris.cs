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
    public partial class FrmBireyselGiris : Form
    {
        SqlCommand cmd;
        SqlDataReader reader;
        SqlConnection conn;
        public FrmBireyselGiris()
        {
            InitializeComponent();
        }
        public static int mId = 0;
        public static float mBakiye = 0.0f;
        public static string adSoyad = "";
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi=txt_username.Text;
            string sifre= txt_sifre.Text;

            conn= new SqlConnection("Data Source=BURAK_LAPTOP;Initial Catalog=DenizBank;Integrated Security=True");
            cmd = new SqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "select*from Musteriler where tcNo='"+txt_username.Text+"' AND sifre='"+txt_sifre.Text+"'";
            reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                FrmMusteri frmMusteri = new FrmMusteri();
                frmMusteri.Show();
                this.Hide();
                mBakiye = float.Parse(reader["bakiye"].ToString());//Burada bakiye miktariını da okumasını istedik.
                adSoyad = reader["adSoyad"].ToString();
                mId = int.Parse(reader["ID"].ToString());
                
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifremiUnuttum sifremiUnuttum=new SifremiUnuttum();
            sifremiUnuttum.Show(); 
            this.Hide();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            DenizBank_Kayit denizBank_Kayit = new DenizBank_Kayit();
            denizBank_Kayit.Show();
            this.Hide();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
