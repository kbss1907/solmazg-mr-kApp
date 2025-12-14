using System.Drawing;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;
using iTextSharp.text.pdf;


public static class UIHelper
{
    private static readonly Color BackgroundColor = ColorTranslator.FromHtml("#2C2F33");
    private static readonly Color PanelColor = ColorTranslator.FromHtml("#23272A");
    private static readonly Color ForegroundColor = Color.WhiteSmoke;
    public static readonly Color AccentColor = ColorTranslator.FromHtml("#25D366");

    public static void ApplyModernDarkTheme(Form form)
    {
        form.BackColor = BackgroundColor;
        form.ForeColor = ForegroundColor;
        form.FormBorderStyle = FormBorderStyle.FixedSingle;
        form.MaximizeBox = false;
        form.MinimizeBox = true;

        StyleMenuStrip(form);

        ApplyThemeToControls(form.Controls);
    }

    private static void ApplyThemeToControls(Control.ControlCollection controls)
    {
        foreach (Control ctrl in controls)
        {
            switch (ctrl)
            {
                case Label lbl:
                    lbl.ForeColor = AccentColor;
                    break;
                case TextBox txt:
                    txt.BackColor = PanelColor;
                    txt.ForeColor = ForegroundColor;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    break;
                case Panel pnl:
                    pnl.BackColor = PanelColor;
                    ApplyThemeToControls(pnl.Controls);
                    break;
                case Button btn:
                    StyleModernButton(btn);
                    break;
                case DataGridView dgv:
                    StyleModernDataGridView(dgv);
                    break;
                default:
                    ApplyThemeToControls(ctrl.Controls);
                    break;
            }
        }
    }

    public static void StyleModernButton(Button btn)
    {
        btn.BackColor = PanelColor;
        btn.ForeColor = AccentColor;
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 1;
        btn.FlatAppearance.BorderColor = AccentColor;
        btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        btn.Cursor = Cursors.Hand;
        btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(44, 47, 51);
        btn.MouseLeave += (s, e) => btn.BackColor = PanelColor;

    }

    public static void StyleModernDataGridView(DataGridView dgv)
    {
        dgv.BackgroundColor = BackgroundColor;
        dgv.DefaultCellStyle.BackColor = BackgroundColor;
        dgv.DefaultCellStyle.ForeColor = ForegroundColor;
        dgv.AlternatingRowsDefaultCellStyle.BackColor = PanelColor;
        dgv.AlternatingRowsDefaultCellStyle.ForeColor = ForegroundColor;
        dgv.ColumnHeadersDefaultCellStyle.BackColor = PanelColor;
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = AccentColor;
        dgv.EnableHeadersVisualStyles = false;
        dgv.RowHeadersVisible = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.ReadOnly = true;
    }
    public static void StyleMenuStrip(Form form)
    {
        foreach (Control ctrl in form.Controls)
        {
            if (ctrl is MenuStrip menu)
            {
                menu.BackColor = PanelColor;
                foreach (ToolStripMenuItem item in menu.Items)
                {
                    item.ForeColor = AccentColor;
                    item.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }

            }
        }
    }
    public static void ExportDataGridViewToExcel(DataGridView dgv, string filePath)
    {
        using (var wb = new ClosedXML.Excel.XLWorkbook())
        {
            var ws = wb.Worksheets.Add("Musteriler");

            // Header
            for (int col = 0; col < dgv.Columns.Count; col++)
            {
                ws.Cell(1, col + 1).Value = dgv.Columns[col].HeaderText;
            }

            // Rows
            for (int row = 0; row < dgv.Rows.Count; row++)
            {
                for (int col = 0; col < dgv.Columns.Count; col++)
                {
                    ws.Cell(row + 2, col + 1).Value = dgv.Rows[row].Cells[col].Value?.ToString();
                }
            }

            wb.SaveAs(filePath);
        }
    }
    public static void ExportDataGridViewToPDF(DataGridView dgv, string filePath)
    {
        var doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);
        PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
        doc.Open();

        var table = new PdfPTable(dgv.Columns.Count);

        var font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);

        foreach (DataGridViewColumn column in dgv.Columns)
        {
            table.AddCell(new iTextSharp.text.Phrase(column.HeaderText, font));
        }

        foreach (DataGridViewRow row in dgv.Rows)
        {
            if (!row.IsNewRow)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    table.AddCell(new iTextSharp.text.Phrase(cell.Value?.ToString() ?? "", font));
                }
            }
        }

        doc.Add(table);
        doc.Close();
    }



}