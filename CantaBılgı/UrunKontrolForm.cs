using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CantaBılgı
{
    public partial class UrunKontrolForm : Form
    {
        public UrunKontrolForm()
        {
            InitializeComponent();
        }

        private void UrunKontrolForm_Load(object sender, EventArgs e)
        {
            this.urunlerTableAdapter.Fill(this.cantaStokYonetimiDataSet.Urunler);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnaForm anaForm = new AnaForm("rol");
            anaForm.ShowDialog();
            this.Close();
        }
    }
}
