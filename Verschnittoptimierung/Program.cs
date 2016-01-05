using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verschnittoptimierung
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Verschnittoptimierung1 verschnittoptimierung = new Verschnittoptimierung1();
            Base global = Base.GetInstance();
            global.Verschnittoptimierung = verschnittoptimierung;
            Application.Run(verschnittoptimierung);
        }
    }
}
