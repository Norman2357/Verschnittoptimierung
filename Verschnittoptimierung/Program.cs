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
            Verschnittoptimierung verschnittoptimierung = new Verschnittoptimierung();
            Base global = Base.GetInstance();
            global.Verschnittoptimierung = verschnittoptimierung;
            Application.Run(verschnittoptimierung);
        }
    }
}
