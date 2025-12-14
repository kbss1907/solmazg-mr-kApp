using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SolmazGumrukApp
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
            UIHelper.ApplyModernDarkTheme(this);

            // BURADA LABELLARI RENKLENDİR:
            label1.ForeColor = ColorTranslator.FromHtml("#25D366");
            label2.ForeColor = ColorTranslator.FromHtml("#25D366");


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void yeniİşlemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YeniIslem yi = new YeniIslem();
            yi.Show();
        }


        private void AnaForm_Load(object sender, EventArgs e)
        {

            UIHelper.ApplyModernDarkTheme(this);

            // MENU STRIP override
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.ForeColor = ColorTranslator.FromHtml("#25D366");
                item.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }

            // LABEL override kesin olarak buraya
            label1.ForeColor = ColorTranslator.FromHtml("#25D366");
            label2.ForeColor = ColorTranslator.FromHtml("#25D366");

            // HATTA DEBUG İÇİN:
            Console.WriteLine($"label1 ForeColor: {label1.ForeColor}");
            Console.WriteLine($"label2 ForeColor: {label2.ForeColor}");
            if (Program.AktifRol == "Kullanici")
            {
                yeniMüşteriToolStripMenuItem.Visible = false;
                yeniİşlemToolStripMenuItem.Visible = false;
            }

        }

        private void müşteriListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusteriListesi ml = new MusteriListesi();
            ml.Show();
        }

        private void yeniMüşteriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YeniMusteri ym = new YeniMusteri();
            ym.Show();
        }

        private void işlemListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IslemListesi il = new IslemListesi();
            il.Show();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void müşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
        

    }
}
