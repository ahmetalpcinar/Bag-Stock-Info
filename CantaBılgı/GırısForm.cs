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
using System.Configuration;

namespace CantaBılgı
{
    public partial class GırısForm : Form
    {
        public GırısForm()
        {
            InitializeComponent();
            CheckAndCreateAdminUser();
        }

        private void CheckAndCreateAdminUser()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CantaStokYonetimiConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM Personel WHERE AdSoyad = 'admin'";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                int count = (int)checkCmd.ExecuteScalar();

                if (count == 0)
                {
                    string insertQuery = "INSERT INTO Personel (AdSoyad, Sifre, Rol) VALUES ('admin', '1234', 'Müdür')";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.ExecuteNonQuery();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string isim = textBox1.Text;
            string sifre = textBox2.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["CantaStokYonetimiConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Personel WHERE AdSoyad = @AdSoyad AND Sifre = @Sifre";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AdSoyad", isim);
                cmd.Parameters.AddWithValue("@Sifre", sifre);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string rol = reader["Rol"].ToString();
                    AnaForm anaForm = new AnaForm(rol);
                    anaForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Geçersiz kullanıcı adı veya şifre.");
                }
            }
        }
    }
}