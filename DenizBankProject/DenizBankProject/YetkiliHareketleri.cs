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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DenizBankProject
{
    public partial class YetkiliHareketleri : Form
    {
        public YetkiliHareketleri()
        {
            InitializeComponent();
        }
       SqlConnection conn = new SqlConnection("Data Source=BURAK_LAPTOP;Initial Catalog=DenizBank;Integrated Security=True");
        private void verilerigoster()
        {
           listView1.Items.Clear();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select*from Musteriler", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = rdr["ID"].ToString();
                item.SubItems.Add(rdr["tcNo"].ToString());
                item.SubItems.Add(rdr["adSoyad"].ToString());
                item.SubItems.Add(rdr["adres"].ToString());
                item.SubItems.Add(rdr["telefon"].ToString());
                item.SubItems.Add(rdr["sifre"].ToString());
                item.SubItems.Add(rdr["bakiye"].ToString());
                item.SubItems.Add(rdr["durum"].ToString());
                listView1.Items.Add(item);
                
               

            }

            conn.Close();



        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        int id = 0;

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            txt_tc.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txt_adSoyad.Text = listView1.SelectedItems[0].SubItems[2].Text;
            txt_adres.Text = listView1.SelectedItems[0].SubItems[3].Text;
            txt_tel.Text = listView1.SelectedItems[0].SubItems[4].Text;
            txt_sifre.Text = listView1.SelectedItems[0].SubItems[5].Text;
            txt_bakiye.Text = listView1.SelectedItems[0].SubItems[6].Text;
            txt_durum.Text = listView1.SelectedItems[0].SubItems[7].Text;


        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Musteriler where ID=("+id+")", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            verilerigoster();
        }
        

        private void btn_temizle_Click(object sender, EventArgs e)
        {    
            txt_tc.Clear();
            txt_adSoyad.Clear();
            txt_adres.Clear();
            txt_tel.Clear();
            txt_bakiye.Clear();
            txt_sifre.Clear();
            txt_durum.Clear();            
        }
        
        private void btn_ara_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select*from Musteriler where adSoyad like '%"+txt_ara.Text+"%'",conn);//Sorgu yapıldı
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = rdr["ID"].ToString();
                item.SubItems.Add(rdr["tcno"].ToString());
                item.SubItems.Add(rdr["adSoyad"].ToString());
                item.SubItems.Add(rdr["adres"].ToString());
                item.SubItems.Add(rdr["telefon"].ToString());
                item.SubItems.Add(rdr["sifre"].ToString());
                item.SubItems.Add(rdr["bakiye"].ToString());
                item.SubItems.Add(rdr["durum"].ToString());
                listView1.Items.Add(item);



                
            }
            conn.Close();
        }
        

        private void btn_güncelle_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update  Musteriler set tcNo='"+ txt_tc.Text + "',adSoyad='" + txt_adSoyad.Text + "',adres='" + txt_adres.Text + "',telefon='" + txt_tel.Text + "',sifre='" + txt_sifre.Text + "',bakiye='" + txt_bakiye.Text + "',durum='" + txt_durum.Text +"' where ID = "+id+"" ,conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            verilerigoster();
        }
        
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FrmYetkili frmYetkili = new FrmYetkili();
            frmYetkili.Show();
            this.Hide();
            
        }
        
    }
}
