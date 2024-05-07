using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TerraDesign.Forms;
using TerraDesign.Forms.FinalVolOfEartworks;
using TerraDesign.Forms.Lateralreserve;
using TerraDesign.Forms.ScopeOfWorksReclamation;
using TerraDesign.Forms.Waterfacil;

namespace TerraDesign
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Tema());
           
        }
    

    }
}
