using System;
using System.Windows.Forms;

namespace SolmazGumrukApp
{
    static class Program
    {
        public static string AktifRol = "";
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (Form1 loginForm = new Form1())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new AnaForm());
                }
            }
        }
    }
}
