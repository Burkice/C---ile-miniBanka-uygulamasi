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
    public partial class Bakiye : Form
    {
        public Bakiye()
        {
            InitializeComponent();
        }

        private void Bakiye_Load(object sender, EventArgs e)
        {
            lbl_bakiye.Text= FrmBireyselGiris.mBakiye.ToString() + " TL ";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FrmMusteri frmMusteri = new FrmMusteri();
            frmMusteri.Show();
            this.Hide();

        }
    }
}
