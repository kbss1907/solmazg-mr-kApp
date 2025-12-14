namespace SolmazGumrukApp
{
    partial class IslemListesi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFiltrele = new System.Windows.Forms.Button();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnAra = new System.Windows.Forms.Button();
            this.txtArama = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dtpBaslangic = new System.Windows.Forms.DateTimePicker();
            this.dtpBitis = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelFiltre = new System.Windows.Forms.Panel();
            this.btnFiltreTemizle = new System.Windows.Forms.Button();
            this.btnFiltreKapat = new System.Windows.Forms.Button();
            this.btnFiltreUygula = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAciklamaFiltre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbIslemTuruFiltre = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelFiltre.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnFiltrele);
            this.panel1.Controls.Add(this.btnDuzenle);
            this.panel1.Controls.Add(this.btnSil);
            this.panel1.Controls.Add(this.btnAra);
            this.panel1.Controls.Add(this.txtArama);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1404, 67);
            this.panel1.TabIndex = 0;
            // 
            // btnFiltrele
            // 
            this.btnFiltrele.Location = new System.Drawing.Point(1293, 18);
            this.btnFiltrele.Name = "btnFiltrele";
            this.btnFiltrele.Size = new System.Drawing.Size(99, 33);
            this.btnFiltrele.TabIndex = 6;
            this.btnFiltrele.Text = "Filtrele";
            this.btnFiltrele.UseVisualStyleBackColor = true;
            this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Location = new System.Drawing.Point(656, 17);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(120, 33);
            this.btnDuzenle.TabIndex = 3;
            this.btnDuzenle.Text = "Düzenle";
            this.btnDuzenle.UseVisualStyleBackColor = true;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(498, 17);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(112, 35);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "SİL";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(326, 17);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(119, 34);
            this.btnAra.TabIndex = 1;
            this.btnAra.Text = "ARAMA";
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // txtArama
            // 
            this.txtArama.Location = new System.Drawing.Point(23, 28);
            this.txtArama.Name = "txtArama";
            this.txtArama.Size = new System.Drawing.Size(245, 22);
            this.txtArama.TabIndex = 0;
            this.txtArama.TextChanged += new System.EventHandler(this.txtArama_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1404, 718);
            this.dataGridView1.TabIndex = 1;
            // 
            // dtpBaslangic
            // 
            this.dtpBaslangic.Location = new System.Drawing.Point(588, 21);
            this.dtpBaslangic.Name = "dtpBaslangic";
            this.dtpBaslangic.Size = new System.Drawing.Size(218, 22);
            this.dtpBaslangic.TabIndex = 4;
            // 
            // dtpBitis
            // 
            this.dtpBitis.Location = new System.Drawing.Point(588, 63);
            this.dtpBitis.Name = "dtpBitis";
            this.dtpBitis.Size = new System.Drawing.Size(218, 22);
            this.dtpBitis.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(492, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Başlangıç";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(492, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Bitiş";
            // 
            // panelFiltre
            // 
            this.panelFiltre.Controls.Add(this.btnFiltreTemizle);
            this.panelFiltre.Controls.Add(this.btnFiltreKapat);
            this.panelFiltre.Controls.Add(this.btnFiltreUygula);
            this.panelFiltre.Controls.Add(this.label4);
            this.panelFiltre.Controls.Add(this.txtAciklamaFiltre);
            this.panelFiltre.Controls.Add(this.label3);
            this.panelFiltre.Controls.Add(this.cmbIslemTuruFiltre);
            this.panelFiltre.Controls.Add(this.label1);
            this.panelFiltre.Controls.Add(this.label2);
            this.panelFiltre.Controls.Add(this.dtpBaslangic);
            this.panelFiltre.Controls.Add(this.dtpBitis);
            this.panelFiltre.Location = new System.Drawing.Point(531, 634);
            this.panelFiltre.Name = "panelFiltre";
            this.panelFiltre.Size = new System.Drawing.Size(873, 160);
            this.panelFiltre.TabIndex = 2;
            this.panelFiltre.Visible = false;
            // 
            // btnFiltreTemizle
            // 
            this.btnFiltreTemizle.Location = new System.Drawing.Point(495, 115);
            this.btnFiltreTemizle.Name = "btnFiltreTemizle";
            this.btnFiltreTemizle.Size = new System.Drawing.Size(160, 34);
            this.btnFiltreTemizle.TabIndex = 15;
            this.btnFiltreTemizle.Text = "Filtreleri Temizle";
            this.btnFiltreTemizle.UseVisualStyleBackColor = true;
            this.btnFiltreTemizle.Click += new System.EventHandler(this.btnFiltreTemizle_Click);
            // 
            // btnFiltreKapat
            // 
            this.btnFiltreKapat.Location = new System.Drawing.Point(841, 0);
            this.btnFiltreKapat.Name = "btnFiltreKapat";
            this.btnFiltreKapat.Size = new System.Drawing.Size(32, 24);
            this.btnFiltreKapat.TabIndex = 14;
            this.btnFiltreKapat.Text = "X";
            this.btnFiltreKapat.UseVisualStyleBackColor = true;
            this.btnFiltreKapat.Click += new System.EventHandler(this.btnFiltreKapat_Click);
            // 
            // btnFiltreUygula
            // 
            this.btnFiltreUygula.Location = new System.Drawing.Point(713, 115);
            this.btnFiltreUygula.Name = "btnFiltreUygula";
            this.btnFiltreUygula.Size = new System.Drawing.Size(132, 34);
            this.btnFiltreUygula.TabIndex = 13;
            this.btnFiltreUygula.Text = "Uygula";
            this.btnFiltreUygula.UseVisualStyleBackColor = true;
            this.btnFiltreUygula.Click += new System.EventHandler(this.btnFiltreUygula_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Açıklama:";
            // 
            // txtAciklamaFiltre
            // 
            this.txtAciklamaFiltre.Location = new System.Drawing.Point(41, 55);
            this.txtAciklamaFiltre.Name = "txtAciklamaFiltre";
            this.txtAciklamaFiltre.Size = new System.Drawing.Size(161, 22);
            this.txtAciklamaFiltre.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "İşlem Türü:";
            // 
            // cmbIslemTuruFiltre
            // 
            this.cmbIslemTuruFiltre.FormattingEnabled = true;
            this.cmbIslemTuruFiltre.Location = new System.Drawing.Point(282, 53);
            this.cmbIslemTuruFiltre.Name = "cmbIslemTuruFiltre";
            this.cmbIslemTuruFiltre.Size = new System.Drawing.Size(161, 24);
            this.cmbIslemTuruFiltre.TabIndex = 9;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(940, 18);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(49, 31);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Exp";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // IslemListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 792);
            this.Controls.Add(this.panelFiltre);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "IslemListesi";
            this.Text = "IslemListesi";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelFiltre.ResumeLayout(false);
            this.panelFiltre.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.TextBox txtArama;
        private System.Windows.Forms.Button btnDuzenle;
        private System.Windows.Forms.DateTimePicker dtpBitis;
        private System.Windows.Forms.DateTimePicker dtpBaslangic;
        private System.Windows.Forms.Button btnFiltrele;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelFiltre;
        private System.Windows.Forms.TextBox txtAciklamaFiltre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbIslemTuruFiltre;
        private System.Windows.Forms.Button btnFiltreKapat;
        private System.Windows.Forms.Button btnFiltreUygula;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFiltreTemizle;
        private System.Windows.Forms.Button btnExport;
    }
}