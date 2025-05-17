using System;
using System;
using System.Windows.Forms;
using PersonnelDepartmentApp;

namespace PersonnelDepartmentApp
{
    static class Program
    {
        
        /// Главная точка входа для приложения.
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
