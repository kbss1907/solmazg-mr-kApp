using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SolmazGumrukApp
{
    public partial class YeniMusteri : Form
    {
        public YeniMusteri()
        {
            InitializeComponent();
        }
        private int? musteriId = null;
        public YeniMusteri(int id) : this()
        {
            musteriId = id;
        }
        private void YeniMusteri_Load(object sender, EventArgs e)
        {
            

           
            {

                UIHelper.ApplyModernDarkTheme(this);








            }
            if (musteriId.HasValue)
            {
                string connStr = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "SELECT Unvan, VergiNo, Adres, Telefon, Email FROM Musteriler WHERE MusteriID = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", musteriId.Value);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                txtUnvan.Text = dr["Unvan"].ToString();
                                txtVergiNo.Text = dr["VergiNo"].ToString();
                                txtAdres.Text = dr["Adres"].ToString();
                                txtTelefon.Text = dr["Telefon"].ToString();
                                txtEmail.Text = dr["Email"].ToString();
                            }
                        }
                    }
                }

                this.Text = "Müşteri Düzenle";
                btnKaydet.Text = "Güncelle";
            }
            else
            {
                this.Text = "Yeni Müşteri";
                btnKaydet.Text = "Kaydet";
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Validasyon:
            if (string.IsNullOrWhiteSpace(txtUnvan.Text) ||
                string.IsNullOrWhiteSpace(txtVergiNo.Text) ||
                string.IsNullOrWhiteSpace(txtAdres.Text) ||
                string.IsNullOrWhiteSpace(txtTelefon.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!chkOnay.Checked)
            {
                MessageBox.Show("Kaydetmeden önce onayı işaretleyin.", "Onay Gerekli", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                if (musteriId.HasValue)
                {
                    // UPDATE işlemi
                    string sql = "UPDATE Musteriler SET Unvan=@unvan, VergiNo=@vergiNo, Adres=@adres, Telefon=@telefon, Email=@email WHERE MusteriID=@id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@unvan", txtUnvan.Text);
                        cmd.Parameters.AddWithValue("@vergiNo", txtVergiNo.Text);
                        cmd.Parameters.AddWithValue("@adres", txtAdres.Text);
                        cmd.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@id", musteriId.Value);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Müşteri bilgisi güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    // INSERT işlemi (senin mevcut INSERT kodun)
                    string sql = "INSERT INTO Musteriler (Unvan, VergiNo, Adres, Telefon, Email) VALUES (@unvan, @vergiNo, @adres, @telefon, @email)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@unvan", txtUnvan.Text);
                        cmd.Parameters.AddWithValue("@vergiNo", txtVergiNo.Text);
                        cmd.Parameters.AddWithValue("@adres", txtAdres.Text);
                        cmd.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Müşteri kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }




        private void txtUnvan_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void chkOnay_CheckedChanged(object sender, EventArgs e)
        {
            btnKaydet.Enabled = chkOnay.Checked;
        }
    }
}
