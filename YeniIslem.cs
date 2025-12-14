using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace SolmazGumrukApp
{
    
    public partial class YeniIslem : Form
    {
        private int? islemId = null;
        public YeniIslem()
        {
            InitializeComponent();
        }
        public YeniIslem(int id) : this()
        {
            islemId = id;
        }

        private void YeniIslem_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // 1️⃣ İşlem Türü seçeneklerini doldur
                    cmbIslemTuru.Items.AddRange(new string[] {
                "İthalat",
                "İhracat",
                "Transit",
                "Antrepo",
                "Serbest Bölge",
                "Gümrükleme"
            });
                    cmbIslemTuru.SelectedIndex = 0;

                    // 2️⃣ Müşteri listesini doldur
                    string sqlMusteri = "SELECT MusteriID, Unvan FROM Musteriler";
                    SqlDataAdapter da = new SqlDataAdapter(sqlMusteri, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbMusteri.DataSource = dt;
                    cmbMusteri.DisplayMember = "Unvan";
                    cmbMusteri.ValueMember = "MusteriID";

                    cmbMusteri.SelectedIndex = -1;

                    // 3️⃣ Düzenleme modunda mı?
                    if (islemId.HasValue)
                    {
                        string sqlIslem = "SELECT MusteriID, IslemTarihi, IslemTuru, Aciklama FROM Islemler WHERE IslemID = @id";
                        using (SqlCommand cmd = new SqlCommand(sqlIslem, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", islemId.Value);
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    cmbMusteri.SelectedValue = dr["MusteriID"];
                                    dtpTarih.Value = Convert.ToDateTime(dr["IslemTarihi"]);
                                    cmbIslemTuru.Text = dr["IslemTuru"].ToString();
                                    txtAciklama.Text = dr["Aciklama"].ToString();
                                }
                            }
                        }

                        this.Text = "İşlem Düzenle";
                        btnKaydet.Text = "Güncelle";
                    }
                    else
                    {
                        this.Text = "Yeni İşlem";
                        btnKaydet.Text = "Kaydet";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
                UIHelper.ApplyModernDarkTheme(this);


            }
        }


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Validasyon:
            if (cmbMusteri.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(cmbIslemTuru.Text) ||
                string.IsNullOrWhiteSpace(txtAciklama.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!chkOnay.Checked)
            {
                MessageBox.Show("Kaydetmeden önce onayı işaretleyin.", "Onay Gerekli", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int musteriID = Convert.ToInt32(cmbMusteri.SelectedValue);
            DateTime islemTarihi = dtpTarih.Value;
            string islemTuru = cmbIslemTuru.SelectedItem.ToString();
            string aciklama = txtAciklama.Text;

            string connStr = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                if (islemId.HasValue)
                {
                    // 🔧 UPDATE işlemi
                    string sql = "UPDATE Islemler SET MusteriID=@MusteriID, IslemTarihi=@IslemTarihi, IslemTuru=@IslemTuru, Aciklama=@Aciklama WHERE IslemID=@IslemID";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MusteriID", musteriID);
                        cmd.Parameters.AddWithValue("@IslemTarihi", islemTarihi);
                        cmd.Parameters.AddWithValue("@IslemTuru", islemTuru);
                        cmd.Parameters.AddWithValue("@Aciklama", aciklama);
                        cmd.Parameters.AddWithValue("@IslemID", islemId.Value);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("İşlem güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    // INSERT işlemi (yeni işlem kaydı)
                    string sql = "INSERT INTO Islemler (MusteriID, IslemTarihi, IslemTuru, Aciklama) VALUES (@MusteriID, @IslemTarihi, @IslemTuru, @Aciklama)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MusteriID", musteriID);
                        cmd.Parameters.AddWithValue("@IslemTarihi", islemTarihi);
                        cmd.Parameters.AddWithValue("@IslemTuru", islemTuru);
                        cmd.Parameters.AddWithValue("@Aciklama", aciklama);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Yeni işlem kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void chkOnay_CheckedChanged(object sender, EventArgs e)
        {
            btnKaydet.Enabled = chkOnay.Checked;
        }

        private void dtpTarih_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtAciklama_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

