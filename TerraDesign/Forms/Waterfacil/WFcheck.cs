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
        double Q, i, n, m, B, H, w, X, R, W, v;
        
        private void clearArea()
        {
            if (rbTrape.Checked)
            {
                w = (B + m / 2 * H) * H;
            }
            else if (rbTriangle.Checked)
            {
                w = m * (H * H);
            }

            
        }
        private void wettedPerimeter()
        { 
        if (rbTrape.Checked)
        {
                X = B + H * (Math.Sqrt(1 + m * m) + Math.Sqrt(1 + m * m));
        }
        else if (rbTriangle.Checked)
        {
                X=2*H*Math.Sqrt(1 + m * m);
        }
        }

            private void button2_Click(object sender, EventArgs e)
        {
            
            bool success = double.TryParse(tbQ.Text, out Q);
            bool success1 = double.TryParse(tbI.Text, out i);
            bool success2 = double.TryParse(cbn.Text, out n);
            bool success3 = double.TryParse(tbm.Text, out m);
            bool success4 = double.TryParse(cbB.Text, out B);
            bool success5 = double.TryParse(cbH.Text, out H);

            if (success==false || success1 == false || success2 == false || success3 == false || success4 == false || success5 == false)
            {
                MessageBox.Show("Введите числовые значения ", "Информация");
            }
            else
            {
                clearArea();
                wettedPerimeter();
                R = w / X;
                R = Math.Round(R, 2);
                if (n == 0.017)
                {
                    switch (R)
                    {
                        case 0.10: W = 12.0; break;
                        case 0.12: W = 13.6; break;
                        case 0.14: W = 15.1; break;
                        case 0.16: W = 16.6; break;
                        case 0.18: W = 17.9; break;
                        case 0.20: W = 20.6; break;
                        case 0.22: W = 21.8; break;
                        case 0.24: W = 22.0; break;
                        case 0.26: W = 23.2; break;
                        case 0.28: W = 24.0; break;
                        case 0.30: W = 25.2; break;
                        case 0.32: W = 26.0; break;
                        case 0.34: W = 27.9; break;
                        case 0.36: W = 29.0; break;
                        case 0.38: W = 30.1; break;
                        case 0.40: W = 31.2; break;
                        case 0.45: W = 33.8; break;
                        case 0.50: W = 36.4; break;
                        case 0.55: W = 39.0; break;
                        case 0.60: W = 41.4; break;
                        case 0.65: W = 43.6; break;
                        case 0.70: W = 45.8; break;
                        case 0.75: W = 48.1; break;
                        case 0.80: W = 50.4; break;
                        case 0.85: W = 52.6; break;
                        case 0.90: W = 54.8; break;
                        case 0.95: W = 56.8; break;
                        case 1.00: W = 58.8; break;
                        default: break;
                    }
                }
                if (n == 0.020)
                {
                    switch (R)
                    {
                        case 0.10: W = 9.75; break;
                        case 0.12: W = 11.1; break;
                        case 0.14: W = 12.4; break;
                        case 0.16: W = 13.6; break;
                        case 0.18: W = 14.8; break;
                        case 0.20: W = 16.0; break;
                        case 0.22: W = 17.1; break;
                        case 0.24: W = 18.1; break;
                        case 0.26: W = 19.2; break;
                        case 0.28: W = 20.3; break;
                        case 0.30: W = 21.4; break;
                        case 0.32: W = 22.2; break;
                        case 0.34: W = 23.2; break;
                        case 0.36: W = 24.2; break;
                        case 0.38: W = 25.2; break;
                        case 0.40: W = 26.2; break;
                        case 0.45: W = 28.4; break;
                        case 0.50: W = 30.6; break;
                        case 0.55: W = 32.6; break;
                        case 0.60: W = 34.8; break;
                        case 0.65: W = 36.8; break;
                        case 0.70: W = 38.7; break;
                        case 0.75: W = 40.6; break;
                        case 0.80: W = 42.7; break;
                        case 0.85: W = 44.5; break;
                        case 0.90: W = 46.5; break;
                        case 0.95: W = 48.1; break;
                        case 1.00: W = 50.0; break;
                        default: break;
                    }
                }
                if (n == 0.025)
                {
                    switch (R)
                    {
                        case 0.10: W = 7.10; break;
                        case 0.12: W = 8.14; break;
                        case 0.14: W = 9.15; break;
                        case 0.16: W = 10.1; break;
                        case 0.18: W = 11.0; break;
                        case 0.20: W = 12.0; break;
                        case 0.22: W = 12.9; break;
                        case 0.24: W = 13.7; break;
                        case 0.26: W = 14.5; break;
                        case 0.28: W = 15.4; break;
                        case 0.30: W = 16.2; break;
                        case 0.32: W = 17.0; break;
                        case 0.34: W = 17.8; break;
                        case 0.36: W = 18.6; break;
                        case 0.38: W = 19.3; break;
                        case 0.40: W = 20.2; break;
                        case 0.45: W = 21.9; break;
                        case 0.50: W = 23.8; break;
                        case 0.55: W = 25.6; break;
                        case 0.60: W = 27.3; break;
                        case 0.65: W = 29.0; break;
                        case 0.70: W = 30.6; break;
                        case 0.75: W = 32.2; break;
                        case 0.80: W = 33.9; break;
                        case 0.85: W = 35.4; break;
                        case 0.90: W = 37.0; break;
                        case 0.95: W = 38.5; break;
                        case 1.00: W = 40.0; break;
                        default: break;
                    }
                }
                if (n == 0.030)
                {
                    switch (R)
                    {
                        case 0.10: W = 5.54; break;
                        case 0.12: W = 6.36; break;
                        case 0.14: W = 7.19; break;
                        case 0.16: W = 7.98; break;
                        case 0.18: W = 8.76; break;
                        case 0.20: W = 9.54; break;
                        case 0.22: W = 10.2; break;
                        case 0.24: W = 10.9; break;
                        case 0.26: W = 11.7; break;
                        case 0.28: W = 12.3; break;
                        case 0.30: W = 13.1; break;
                        case 0.32: W = 13.7; break;
                        case 0.34: W = 14.4; break;
                        case 0.36: W = 15.0; break;
                        case 0.38: W = 15.7; break;
                        case 0.40: W = 16.3; break;
                        case 0.45: W = 17.9; break;
                        case 0.50: W = 19.4; break;
                        case 0.55: W = 20.8; break;
                        case 0.60: W = 22.4; break;
                        case 0.65: W = 23.8; break;
                        case 0.70: W = 25.1; break;
                        case 0.75: W = 26.6; break;
                        case 0.80: W = 28.8; break;
                        case 0.85: W = 29.4; break;
                        case 0.90: W = 30.8; break;
                        case 0.95: W = 32.1; break;
                        case 1.00: W = 33.3; break;
                        default: break;
                    }
                }
                v=W*Math.Sqrt(i);
                GlobalVars.Q = w * v;
                Q = Q + (Q * 5 / 100);
                if (GlobalVars.Q>Q)
                {
                    MessageBox.Show("Расчётное число меньше выбранного");
                }
                if (GlobalVars.Q < Q)
                {
                    MessageBox.Show("Расчётное число больше выбранного");
                }
                GlobalVars.bk = B;
                GlobalVars.hk= H+0.2;
                
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
