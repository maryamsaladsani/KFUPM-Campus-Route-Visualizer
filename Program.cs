using SWE316HW1MA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWE316HW1MA
{
    internal static class Program
    {
        // [0]: Summary
        // Entry point of the application.

        [STAThread]
        static void Main()
        {
            // [1]: Build Excel file path (inside project Assets folder)
            string excelPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Assets",
                "TermSchedule251.xlsx"
            );

            // [2]: Load sections before running the form
            try
            {
                var allSections = Sections.LoadSections(excelPath);
                Console.WriteLine($"Loaded {allSections.Count} sections from {excelPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading sections: {ex.Message}");
            }

            // [3]: Launch main form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
