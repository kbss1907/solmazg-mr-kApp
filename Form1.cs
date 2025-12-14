using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace SolmazGumrukApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Bağlantı başarılı!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bağlantı hatası: " + ex.Message);
                }
            }
            UIHelper.ApplyModernDarkTheme(this);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString))
            {
                conn.Open();
                string sql = "SELECT Rol FROM Kullanicilar WHERE KullaniciAdi=@kadi AND Sifre=@sifre AND Durum=1";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@kadi", kullaniciAdi);
                cmd.Parameters.AddWithValue("@sifre", sifre);

                object result = cmd.ExecuteScalar();

                if (result!= null)
                {
                    Program.AktifRol = result.ToString();
                    MessageBox.Show("Giriş başarılı.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hatalı kullanıcı adı veya şifre.");
                }
            }
        }

    }
}
