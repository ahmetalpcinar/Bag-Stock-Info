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

namespace CantaBılgı
{
    public partial class AnaForm : Form
    {
        private string kullaniciRol;

        public AnaForm(string rol)
        {
            InitializeComponent();
            kullaniciRol = rol;
            AyarButonlari();
        }

        private void AyarButonlari()
        {
            if (kullaniciRol != "Müdür" && kullaniciRol != "Müdür Yardımcısı")
            {
                button3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UrunKontrolForm urunKontrolForm = new UrunKontrolForm();
            urunKontrolForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UrunGuncelleForm urunGuncelleForm = new UrunGuncelleForm();
            urunGuncelleForm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (kullaniciRol == "Müdür" || kullaniciRol == "Müdür Yardımcısı")
            {
                this.Hide();
                PersonelKayitForm personelKayitForm = new PersonelKayitForm();
                personelKayitForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Bu bölüme yalnızca müdür veya müdür yardımcıları erişebilir.");
            }
        }
    }
}