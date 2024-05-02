using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace TerraDesign.Forms.Waterfacil
{
    public partial class WFcheck : Form
    {
        public WFcheck()
        {
            InitializeComponent();
        }
        double n;
        private void ConsumSingleRough()
        {
            GlobalVars.Ksch = (GlobalVars.Q * GlobalVars.n)/ (Math.Sqrt(GlobalVars.i));
            //GlobalVars.Ksch= GlobalVars.Ksch-0.01;
            GlobalVars.Ksch = Math.Round(GlobalVars.Ksch, 1); 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            bool success = double.TryParse(textBox1.Text, out GlobalVars.Q);
            bool success1 = double.TryParse(textBox2.Text, out GlobalVars.i);
            bool success2 = double.TryParse(textBox3.Text, out GlobalVars.n);
            bool success3 = double.TryParse(textBox4.Text, out GlobalVars.m);
            if (success==false || success1 == false || success2 == false || success3 == false)
                     
           
            {
                MessageBox.Show("Введите числовые значения ", "Информация");
            }
            else
            {
                double.TryParse(textBox1.Text, out GlobalVars.Q);
                double.TryParse(textBox2.Text, out GlobalVars.i);
                double.TryParse(textBox3.Text, out GlobalVars.n);
                double.TryParse(textBox4.Text, out GlobalVars.m);
                ConsumSingleRough();
                switch (GlobalVars.m)
                {
                    case 0: n = 2; break;
                    case 1: n = 1; break;
                    case 1.5: n = 0.61; break;
                    default:
                        MessageBox.Show("Программой не предусмотрен вариант решения для введенного вами значения коэффициента");
                        return;

                }
                if (n == 0.61)
                {
                    switch (GlobalVars.Ksch)
                    {
                        case 0.1: GlobalVars.hk = 0.35; break;
                        case 0.15: GlobalVars.hk = 0.42; break;
                        case 0.2: GlobalVars.hk = 0.47; break;
                        case 0.25: GlobalVars.hk = 0.52; break;
                        case 0.3: GlobalVars.hk = 0.55; break;
                        case 0.35: GlobalVars.hk = 0.58; break;
                        case 0.4: GlobalVars.hk = 0.6; break;
                        case 0.45: GlobalVars.hk = 0.63; break;
                        case 0.5: GlobalVars.hk = 0.67; break;
                        case 0.6: GlobalVars.hk = 0.73; break;
                        case 0.7: GlobalVars.hk = 0.77; break;
                        case 0.8: GlobalVars.hk = 0.8; break;
                        case 0.9: GlobalVars.hk = 0.85; break;
                        case 1: GlobalVars.hk = 0.88; break;
                        default: break;
                    }
                }
                if (n == 1)
                {
                    switch (GlobalVars.Ksch)
                    {
                        case 0.1: GlobalVars.hk = 0.2; break;
                        case 0.15: GlobalVars.hk = 0.38; break;
                        case 0.2: GlobalVars.hk = 0.42; break;
                        case 0.25: GlobalVars.hk = 0.47; break;
                        case 0.3: GlobalVars.hk = 0.5; break;
                        case 0.35: GlobalVars.hk = 0.53; break;
                        case 0.4: GlobalVars.hk = 0.55; break;
                        case 0.45: GlobalVars.hk = 0.57; break;
                        case 0.5: GlobalVars.hk = 0.6; break;
                        case 0.6: GlobalVars.hk = 0.65; break;
                        case 0.7: GlobalVars.hk = 0.68; break;
                        case 0.8: GlobalVars.hk = 0.72; break;
                        case 0.9: GlobalVars.hk = 0.75; break;
                        case 1: GlobalVars.hk = 0.8; break;
                        default: break;
                    }
                }
                if (n == 2)
                {
                    switch (GlobalVars.Ksch)
                    {
                        case 0.1: GlobalVars.hk = 0; break;
                        case 0.15: GlobalVars.hk = 0.33; break;
                        case 0.2: GlobalVars.hk = 0.38; break;
                        case 0.25: GlobalVars.hk = 0.42; break;
                        case 0.3: GlobalVars.hk = 0.45; break;
                        case 0.35: GlobalVars.hk = 0.47; break;
                        case 0.4: GlobalVars.hk = 0.49; break;
                        case 0.45: GlobalVars.hk = 0.51; break;
                        case 0.5: GlobalVars.hk = 0.53; break;
                        case 0.6: GlobalVars.hk = 0.58; break;
                        case 0.7: GlobalVars.hk = 0.6; break;
                        case 0.8: GlobalVars.hk = 0.63; break;
                        case 0.9: GlobalVars.hk = 0.68; break;
                        case 1: GlobalVars.hk = 0.7; break;
                        default: break;
                    }
                }
                GlobalVars.bk = n * GlobalVars.hk;
                if (GlobalVars.bk == 0)
                {
                    GlobalVars.bk = 0.30;
                }
                if (GlobalVars.hk == 0)
                {
                    GlobalVars.hk = 0.30;
                }
                WFtotal wFtotal = new WFtotal();
                wFtotal.Show();
            }

        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tema tema = new Tema();
            tema.Show();
            this.Hide();
        }

        private void WFcheck_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
