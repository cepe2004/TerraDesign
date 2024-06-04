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
        double Q, i, n, m, B=0.4, H=0.3, w, X, R, W, v;

        
        private void clearArea()
        {
            if (rbTrape.Checked)
            {
                w=(B+m*H)*H;
                //w = (B + ((m+m) / 2) * H) * H;
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
                X=B+(2*(H*Math.Sqrt(1+(m*m))));
                //X = B + H * (Math.Sqrt(1 + m * m) + Math.Sqrt(1 + m * m));
        }
        else if (rbTriangle.Checked)
        {
                X=2*H*Math.Sqrt(1 + m * m);
        }
        }
        private double speedCharacteristics(double r)
        {
           
            if (n == 0.017)
            {
                switch (r)
                {

                    case 0.10: return 12.0; 
                    case 0.12: return 13.6; 
                    case 0.14: return 15.1;
                    case 0.16: return 16.6;
                    case 0.18: return 17.9;
                    case 0.20: return 20.6;
                    case 0.22: return 21.8;
                    case 0.24: return 22.0;
                    case 0.26: return 23.2;
                    case 0.28: return 24.0;
                    case 0.30: return 25.2;
                    case 0.32: return 26.0;
                    case 0.34: return 27.9;
                    case 0.36: return 29.0;
                    case 0.38: return 30.1;
                    case 0.40: return 31.2;
                    case 0.45: return 33.8;
                    case 0.50: return 36.4;
                    case 0.55: return 39.0;
                    case 0.60: return 41.4;
                    case 0.65: return 43.6;
                    case 0.70: return 45.8;
                    case 0.75: return 48.1;
                    case 0.80: return 50.4;
                    case 0.85: return 52.6;
                    case 0.90: return 54.8;
                    case 0.95: return 56.8;
                    case 1.00: return 58.8;
                    default: return 0 ;
                }
            }
            if (n == 0.020)
            {
                switch (r)
                {
                    case 0.10: return 9.75;
                    case 0.12: return 11.1;
                    case 0.14: return 12.4;
                    case 0.16: return 13.6;
                    case 0.18: return 14.8;
                    case 0.20: return 16.0;
                    case 0.22: return 17.1;
                    case 0.24: return 18.1;
                    case 0.26: return 19.2;
                    case 0.28: return 20.3;
                    case 0.30: return 21.4;
                    case 0.32: return 22.2;
                    case 0.34: return 23.2;
                    case 0.36: return 24.2;
                    case 0.38: return 25.2;
                    case 0.40: return 26.2;
                    case 0.45: return 28.4;
                    case 0.50: return 30.6;
                    case 0.55: return 32.6;
                    case 0.60: return 34.8;
                    case 0.65: return 36.8;
                    case 0.70: return 38.7;
                    case 0.75: return 40.6;
                    case 0.80: return 42.7;
                    case 0.85: return 44.5;
                    case 0.90: return 46.5;
                    case 0.95: return 48.1;
                    case 1.00: return 50.0;
                    default:return 0 ;
                }
            }
            if (n == 0.025)
            {
                switch (r)
                {
                    case 0.10: return 7.10;
                    case 0.12: return 8.14;
                    case 0.14: return 9.15;
                    case 0.16: return 10.1;
                    case 0.18: return 11.0;
                    case 0.20: return 12.0;
                    case 0.22: return 12.9;
                    case 0.24: return 13.7;
                    case 0.26: return 14.5;
                    case 0.28: return 15.4;
                    case 0.30: return 16.2;
                    case 0.32: return 17.0;
                    case 0.34: return 17.8;
                    case 0.36: return 18.6;
                    case 0.38: return 19.3;
                    case 0.40: return 20.2;
                    case 0.45: return 21.9;
                    case 0.50: return 23.8;
                    case 0.55: return 25.6;
                    case 0.60: return 27.3;
                    case 0.65: return 29.0;
                    case 0.70: return 30.6;
                    case 0.75: return 32.2;
                    case 0.80: return 33.9;
                    case 0.85: return 35.4;
                    case 0.90: return 37.0;
                    case 0.95: return 38.5;
                    case 1.00: return 40.0;
                    default: return 0 ;
                }
            }
            if (n == 0.030)
            {
                switch (r)
                {
                    case 0.10: return 5.54;
                    case 0.12: return 6.36;
                    case 0.14: return 7.19;
                    case 0.16: return 7.98;
                    case 0.18: return 8.76;
                    case 0.20: return 9.54;
                    case 0.22: return 10.2;
                    case 0.24: return 10.9;
                    case 0.26: return 11.7;
                    case 0.28: return 12.3;
                    case 0.30: return 13.1;
                    case 0.32: return 13.7;
                    case 0.34: return 14.4;
                    case 0.36: return 15.0;
                    case 0.38: return 15.7;
                    case 0.40: return 16.3;
                    case 0.45: return 17.9;
                    case 0.50: return 19.4;
                    case 0.55: return 20.8;
                    case 0.60: return 22.4;
                    case 0.65: return 23.8;
                    case 0.70: return 25.1;
                    case 0.75: return 26.6;
                    case 0.80: return 28.8;
                    case 0.85: return 29.4;
                    case 0.90: return 30.8; 
                    case 0.95: return 32.1; 
                    case 1.00: return 33.3; 
                    default: return 0;
                }
            }
            return 0;
        }

            private void button2_Click(object sender, EventArgs e)
        {
            
            bool success = double.TryParse(tbQ.Text, out Q);
            bool success1 = double.TryParse(tbI.Text, out i);
            bool success2 = double.TryParse(cbn.Text, out n);
            bool success3 = double.TryParse(tbm.Text, out m);

            if (success==false || success1 == false || success2 == false || success3 == false )
            {
                MessageBox.Show("Введите числовые значения ", "Информация");
            }
            else
            {
                start:
                clearArea();
                wettedPerimeter();
                R = w / X;
                R = Math.Round(R, 2);
               W=speedCharacteristics(R);
              
           
                decimal Rm = new decimal(R);
             

                if (Rm % 0.02m != 0 && R<40)
                {
                    double R1, R2,W1,W2;
                    R1 = R - 0.01;
                    R1 = Math.Round(R1, 2);
                    R2 = R + 0.01;
                    R2 = Math.Round(R2, 2);
                    W1 = speedCharacteristics(R1);
                    W2 = speedCharacteristics(R2);
                    W=((W2- W1)*(R-R1))/(R2-R1);
                    W = Math.Round(W, 2);
                    W = W + W1;
                    W = Math.Round(W, 2);
                }
                if (R > 40&&Rm % 0.05m != 0)
                {
                    double R1, R2, W1, W2;
                    R1 = R;
                    R1 = Math.Round(R1, 2);
                    R2 = R;
                    R2 = Math.Round(R2, 2);
                    decimal R1m = new decimal(R1);
                    decimal R2m = new decimal(R2);
                    while (R1m % 0.05m != 0 )
                    {
                        R1 = R1 - 0.01;
                        R1 = Math.Round(R1, 2);
                        R1m = new decimal(R1);
                    }
                    while (R2m % 0.05m != 0)
                    {
                        R2 = R2 + 0.01;
                        R2 = Math.Round(R2, 2);
                        R2m = new decimal(R2);
                    }
                    W1 = speedCharacteristics(R1);
                    W2 = speedCharacteristics(R2);
                    W = ((W2 - W1) * (R - R1)) / (R2 - R1);
                    W = Math.Round(W, 2);
                    W = W + W1;
                    W = Math.Round(W, 2);
                }
                v=W*Math.Sqrt(i);
                GlobalVars.Q = w * v;
                double Q1,Q2;
                Q1 = Q + (Q * 5 / 100);
                Q2= Q - (Q * 5 / 100);
                if (GlobalVars.Q > Q1)
                {
                   if (B>0.4)
                    {
                        B = B - 0.01;
                        goto start;
                        
                    }
                    else
                    {
                         if (H>0.3)
                        {
                            H = H - 0.01;
                            goto start;
                        }   
                       
                    
                    }
                }
                else if (GlobalVars.Q < Q2)
                {
                    if (H < 0.8)
                    {
                        H = H + 0.01;
                        goto start;

                    }
                    else
                    {
                        if (B < 0.6)
                        {
                            B = B + 0.01;
                            goto start;
                        }


                    }
                    goto start;


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
