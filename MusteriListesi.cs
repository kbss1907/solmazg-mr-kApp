using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SolmazGumrukApp
{
    public partial class MusteriListesi : Form
    {
        private DataTable dtMusteriler;

        public MusteriListesi()
        {
            InitializeComponent();
        }

        private void MusteriListesi_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                MessageBox.Show($"Aktif Rol: {Program.AktifRol}");

                try
                {
                    conn.Open();
                    string sql = "SELECT MusteriID, Unvan, VergiNo, Adres, Telefon, Email FROM Musteriler";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    dtMusteriler = new DataTable();  // DataTable global değişken olmalı!
                    da.Fill(dtMusteriler);
                    dataGridView1.DataSource = dtMusteriler;


                    UIHelper.ApplyModernDarkTheme(this);


                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
                if (Program.AktifRol == "Kullanici")
                {
                    btnSil.Enabled = false;
                    btnDuzenle.Enabled = false;
                }
            }
        }
    

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int musteriId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["MusteriID"].Value);

                DialogResult result = MessageBox.Show("Seçili müşteriyi silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string connStr = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Musteriler WHERE MusteriID=@id", conn);
                        cmd.Parameters.AddWithValue("@id", musteriId);
                        cmd.ExecuteNonQuery();
                    }

                    // Tabloyu yeniden yükle
                    MusteriListesi_Load(null, null);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir müşteri seçin.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (dtMusteriler != null)
            {
                string filter = txtArama.Text.Trim().Replace("'", "''");

                if (string.IsNullOrWhiteSpace(filter))
                {
                    // Arama boşsa tüm listeyi geri getir
                    dtMusteriler.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    // Filtre uygula
                    dtMusteriler.DefaultView.RowFilter =
                        $"Unvan LIKE '%{filter}%' OR VergiNo LIKE '%{filter}%' OR Adres LIKE '%{filter}%' OR Telefon LIKE '%{filter}%' OR Email LIKE '%{filter}%'";
                }
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells["MusteriID"].Value != DBNull.Value)
            {
                int musteriId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MusteriID"].Value);

                YeniMusteri frm = new YeniMusteri(musteriId);
                frm.ShowDialog();

                // Güncel veriyi tekrar yükle
                MusteriListesi_Load(null, null);
            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek istediğiniz bir müşteri seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                sfd.FileName = "Musteriler.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    UIHelper.ExportDataGridViewToExcel(dataGridView1, sfd.FileName);
                    MessageBox.Show("Excel dosyası oluşturuldu!");
                }
            }
        }
        private void ExportToPDF()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files|*.pdf";
                sfd.FileName = "Musteriler.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    UIHelper.ExportDataGridViewToPDF(dataGridView1, sfd.FileName);
                    MessageBox.Show("PDF dosyası oluşturuldu!");
                }
            }
        }

    }
}
