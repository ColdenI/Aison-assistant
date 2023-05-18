using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace Aison___assistant
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            System.Threading.Thread.Sleep(500);
            Process pr = RI();
            if (pr != null)
                Application.Run(new ProgramAlreadyOpenForm(pr));
            else
            {
                try
                {
                    Application.Run(new MainForm());
                }catch (Exception ex) 
                {
                    Application.Run(new ErrorStartForm(ex));
                }
            }
                
        }

        private static void timer_aison_activ_Tick(object sender, EventArgs e)
        {

        }

        public static Process RI()
        {
            Process current = Process.GetCurrentProcess();
            Process[] pr = Process.GetProcessesByName(current.ProcessName);
            foreach (Process i in pr)
            {
                if (i.Id != current.Id)
                {
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        return i;
                    }
                }
            }
            return null;
        }
    }
}
