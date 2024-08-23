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
    public partial class UrunGuncelleForm : Form
    {
        public UrunGuncelleForm()
        {
            InitializeComponent();
        }

        private void UrunGuncelleForm_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            string urunAdi = textBox1.Text;
            int stok = int.Parse(textBox2.Text);
            int fiyat = int.Parse(textBox3.Text);
            string birim = textBox4.Text;

            DataRow newRow = cantaStokYonetimiDataSet.Urunler.NewRow();
            newRow["UrunAdi"] = urunAdi;
            newRow["Stok"] = stok;
            newRow["Fiyat"] = fiyat;
            newRow["ParaBirimi"] = birim;
            cantaStokYonetimiDataSet.Urunler.Rows.Add(newRow);

            urunlerTableAdapter.Update(cantaStokYonetimiDataSet.Urunler);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(row.Index);
                }

                urunlerTableAdapter.Update(cantaStokYonetimiDataSet.Urunler);
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz satırı seçin.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            urunlerTableAdapter.Update(cantaStokYonetimiDataSet.Urunler);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text))
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        row.Cells["UrunAdi"].Value = textBox1.Text;
                        row.Cells["Stok"].Value = int.Parse(textBox2.Text);
                        row.Cells["Fiyat"].Value = int.Parse(textBox3.Text);
                        row.Cells["ParaBirimi"].Value = textBox4.Text;
                    }
                    urunlerTableAdapter.Update(cantaStokYonetimiDataSet.Urunler);
                }
                else
                {
                    MessageBox.Show("Lütfen güncellemek istediğiniz satırı seçin.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm bilgileri doldurun.");
            }
        }
    }
}