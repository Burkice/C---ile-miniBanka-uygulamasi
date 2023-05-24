using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DenizBankProject
{
    public partial class FrmMusteri : Form
    {
        public FrmMusteri()
        {
            InitializeComponent();
        }

        private void FrmMusteri_Load(object sender, EventArgs e)
        {
            
            //lbl_adsoyad.Text = FrmBireyselGiris.adSoyad;
            //lbl_hesapNo.Text = FrmBireyselGiris.mId.ToString();
        }

        private void btn_cikis_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void btn_güncelle_Click(object sender, EventArgs e)
        {
            Bakiye bakiye = new Bakiye();
            bakiye.Show();
            this.Hide();


        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            Havale havale = new Havale();
            havale.Show();
            this.Hide();
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            SifreDegistirme sifreDegistirme = new SifreDegistirme();
            sifreDegistirme.Show();
            this.Hide();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FrmBireyselGiris frmBireyselGiris = new FrmBireyselGiris();
            frmBireyselGiris.Show();
            this.Hide();
        }
    }
}
