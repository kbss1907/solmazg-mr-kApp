using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolmazGumrukApp
{
    public partial class IslemListesi : Form
    {
        public IslemListesi()
        {
            InitializeComponent();
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;

            this.Load += new System.EventHandler(this.IslemListesi_Load);
        }

        private void Listele()
        {
            string connStr = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = @"
                SELECT 
                    I.IslemID, 
                    M.Unvan AS MusteriUnvan, 
                    I.IslemTarihi, 
                    I.IslemTuru, 
                    I.Aciklama
                FROM 
                    Islemler I
                INNER JOIN 
                    Musteriler M ON I.MusteriID = M.MusteriID";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void IslemListesi_Load(object sender, EventArgs e)
        {
            Listele();
            // Tema uygula
            MessageBox.Show($"Aktif Rol: {Program.AktifRol}");

            UIHelper.ApplyModernDarkTheme(this);


            // Filtre ComboBox işlem türü doldurma
            cmbIslemTuruFiltre.Items.Clear();
            cmbIslemTuruFiltre.Items.Add("");
            cmbIslemTuruFiltre.Items.AddRange(new string[]
            {
        "İthalat", "İhracat", "Transit", "Antrepo", "Serbest Bölge", "Gümrükleme"
            });
            cmbIslemTuruFiltre.SelectedIndex = 0;
            if (Program.AktifRol == "Kullanici")
            {
                btnSil.Enabled = false;
                btnDuzenle.Enabled = false;
            }

        }


        private void btnAra_Click(object sender, EventArgs e)
        {
            string arama = txtArama.Text.Trim();

            string connStr = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = @"
                    SELECT I.IslemID,M.MusteriID, M.Unvan AS Musteri, I.IslemTarihi, I.IslemTuru, I.Aciklama
                    FROM Islemler I
                    INNER JOIN Musteriler M ON I.MusteriID = M.MusteriID
                    WHERE 
                    (CAST(I.IslemID AS NVARCHAR) LIKE @arama OR
                    CAST(M.MusteriID AS NVARCHAR) LIKE @arama OR
                    M.Unvan LIKE @arama OR
                    CONVERT(NVARCHAR, I.IslemTarihi, 104) LIKE @arama OR
                    I.IslemTuru LIKE @arama OR
                    I.Aciklama LIKE @arama)

            ";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.SelectCommand.Parameters.AddWithValue("@arama", "%" + arama + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int islemID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IslemID"].Value);

                DialogResult result = MessageBox.Show("Bu işlemi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string connStr = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        try
                        {
                            conn.Open();
                            string sql = "DELETE FROM Islemler WHERE IslemID = @id";
                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", islemID);
                                cmd.ExecuteNonQuery();
                            }

                            
                            MessageBox.Show("İşlem silindi.");
                            Listele();
                            // Listeyi yenile
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir işlem seçin.");
            }
        }
        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int islemID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IslemID"].Value);

                YeniIslem form = new YeniIslem(islemID);
                form.ShowDialog();

                MessageBox.Show("İşlem Düzenlendi.");
                Listele();

            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek için bir işlem seçin.");
            }
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {

            panelFiltre.Visible = !panelFiltre.Visible;

        }
        private void btnFiltreUygula_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = @"
                SELECT 
                    I.IslemID, 
                    M.Unvan AS MusteriUnvan, 
                    I.IslemTarihi, 
                    I.IslemTuru, 
                    I.Aciklama
                FROM 
                    Islemler I
                INNER JOIN 
                    Musteriler M ON I.MusteriID = M.MusteriID
                WHERE 1=1";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    // Dinamik filtreler:
                    if (dtpBaslangic.Checked && dtpBitis.Checked)
                    {
                        DateTime baslangic = dtpBaslangic.Value.Date;
                        DateTime bitis = dtpBitis.Value.Date.AddDays(1).AddSeconds(-1);

                        sql += " AND I.IslemTarihi BETWEEN @baslangic AND @bitis";
                        cmd.Parameters.AddWithValue("@baslangic", baslangic);
                        cmd.Parameters.AddWithValue("@bitis", bitis);
                    }

                    if (!string.IsNullOrWhiteSpace(cmbIslemTuruFiltre.Text))
                    {
                        sql += " AND I.IslemTuru = @islemTuru";
                        cmd.Parameters.AddWithValue("@islemTuru", cmbIslemTuruFiltre.Text);
                    }

                    if (!string.IsNullOrWhiteSpace(txtAciklamaFiltre.Text))
                    {
                        sql += " AND I.Aciklama COLLATE Latin1_General_CI_AI LIKE @aciklama";
                        cmd.Parameters.AddWithValue("@aciklama", "%" + txtAciklamaFiltre.Text.Trim() + "%");
                    }

                    // Eğer hiçbir filtre yoksa:
                    if (sql == @"
                SELECT 
                    I.IslemID, 
                    M.Unvan AS MusteriUnvan, 
                    I.IslemTarihi, 
                    I.IslemTuru, 
                    I.Aciklama
                FROM 
                    Islemler I
                INNER JOIN 
                    Musteriler M ON I.MusteriID = M.MusteriID
                WHERE 1=1")
                    {
                        Listele();
                        panelFiltre.Visible = false;
                        return;
                    }

                    cmd.CommandText = sql;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    panelFiltre.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
        private void btnFiltreTemizle_Click(object sender, EventArgs e)
        {
            dtpBaslangic.Value = DateTime.Now.AddMonths(-1);
            dtpBitis.Value = DateTime.Now;
            cmbIslemTuruFiltre.SelectedIndex = 0;
            txtAciklamaFiltre.Text = "";

            Listele();
            panelFiltre.Visible = false;
        }

        private void btnFiltreKapat_Click(object sender, EventArgs e)
        {
            panelFiltre.Visible = false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add("Excel'e Aktar", null, (s, ea) => ExportToExcel());
            menu.Items.Add("PDF'e Aktar", null, (s, ea) => ExportToPDF());
            menu.Show(Cursor.Position);
        }
        private void ExportToExcel()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.FileName = "Islemler.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    UIHelper.ExportDataGridViewToExcel(dataGridView1, sfd.FileName);
                    MessageBox.Show("Excel dosyası oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void ExportToPDF()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files|*.pdf";
                sfd.FileName = "Islemler.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    UIHelper.ExportDataGridViewToPDF(dataGridView1, sfd.FileName);
                    MessageBox.Show("PDF dosyası oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


    }


}