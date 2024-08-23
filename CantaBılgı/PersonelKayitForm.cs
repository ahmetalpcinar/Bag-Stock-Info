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
    public partial class PersonelKayitForm : Form
    {
        public PersonelKayitForm()
        {
            InitializeComponent();
        }

        private void PersonelGuncelleForm_Load(object sender, EventArgs e)
        {
            this.personelTableAdapter.Fill(this.cantaStokYonetimiDataSet.Personel);
        }

        private void PersonelKayitForm_Load(object sender, EventArgs e)
        {
            this.personelTableAdapter.Fill(this.cantaStokYonetimiDataSet.Personel);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnaForm anaForm = new AnaForm("rol");
            anaForm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string adSoyad = textBox1.Text;
            string sifre = textBox2.Text;
            string rol = textBox3.Text;

            DataRow newRow = cantaStokYonetimiDataSet.Personel.NewRow();
            newRow["AdSoyad"] = adSoyad;
            newRow["Sifre"] = sifre;
            newRow["Rol"] = rol;
            cantaStokYonetimiDataSet.Personel.Rows.Add(newRow);

            personelTableAdapter.Update(cantaStokYonetimiDataSet.Personel);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(row.Index);
                }

                personelTableAdapter.Update(cantaStokYonetimiDataSet.Personel);
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz satırı seçin.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            personelTableAdapter.Update(cantaStokYonetimiDataSet.Personel);
        }
    }
}