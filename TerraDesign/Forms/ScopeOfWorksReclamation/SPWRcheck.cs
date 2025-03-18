using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TerraDesign.Forms.ScopeOfWorksReclamation
{
    public partial class SPWRcheck : Form
    {
        public SPWRcheck()
        {
            InitializeComponent();
            if (GlobalVars.h1 != 0 || GlobalVars.h2 != 0 || GlobalVars.L1p != 0 || GlobalVars.L2p != 0)
            {
                var result = MessageBox.Show("Вы хотите использовать данные расчёта боковых резервов", "Информация", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    textBoxH1p.Text = Convert.ToString(GlobalVars.h1);
                    textBoxH2p.Text = Convert.ToString(GlobalVars.h2);
                    textBoxL1p.Text = Convert.ToString(GlobalVars.L1p);
                    textBoxL2p.Text = Convert.ToString(GlobalVars.L2p);
                }
            }
        }
        int i = 0;
        double[] h1p,h2p,L1p,L2p,Lp,m,n,hpc;

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tema tema = new Tema();
            tema.Show();
            this.Hide();
        }

        private void SPWRcheck_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            h1p = null;
            h2p=null;
            L1p = null;
            L2p = null;
            Lp = null; 
            m = null;
            n = null;
            hpc = null;
            textBoxN.ReadOnly = false;
            textBoxReserve.ReadOnly = false;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            
            if (textBoxReserve.ReadOnly == true)
            {
                MessageBox.Show("Введите номер и данные резерва, а затем нажмите редактировать");
                textBoxReserve.ReadOnly =false;
            }
            else
            {
                try
                {
                    int IndexEdit;
                    int.TryParse(textBoxReserve.Text, out IndexEdit);
                    IndexEdit--;
                    double.TryParse(textBoxH1p.Text, out h1p[IndexEdit]);
                    double.TryParse(textBoxH2p.Text, out h2p[IndexEdit]);
                    double.TryParse(textBoxL1p.Text, out L1p[IndexEdit]);
                    double.TryParse(textBoxL2p.Text, out L2p[IndexEdit]);
                    double.TryParse(textBoxLp.Text, out Lp[IndexEdit]);
                    double.TryParse(textBoxM.Text, out m[IndexEdit]);
                    double.TryParse(textBoxN1.Text, out n[IndexEdit]);
                    double.TryParse(textBoxHpc.Text, out hpc[IndexEdit]);
                    MessageBox.Show("Резерв отредактирован");
                    ReserveArea();
                    VolRemovedSoil();
                    VolRemovedSoilToRestore();
                    SPWRtotal sPWRtotal = new SPWRtotal();
                    sPWRtotal.Show();
                }
                catch (System.IndexOutOfRangeException)
                {
                    MessageBox.Show("Введённого резерва не существует");
                }
            }
        }

        private void ReserveArea()
        { 
            i= 0;
            GlobalVars.Sp= new double[GlobalVars.N];
            for (int i = 0; i < GlobalVars.Sp.Length; i++)
            {
                GlobalVars.Sp[i] = L2p[i] * Lp[i];
            }
            
        }
        private void VolRemovedSoil()
        {
            i = 0;
            GlobalVars.Vrgr = new double[GlobalVars.N];
            for (int i = 0; i < GlobalVars.Vrgr.Length; i++)
            {
                GlobalVars.Vrgr[i] = hpc[i] * GlobalVars.Sp[i];
            }
        }
        private void VolRemovedSoilToRestore()
        {
            i = 0;
            GlobalVars.Vvos = new double[GlobalVars.N];
            for (int i = 0; i < GlobalVars.Vvos.Length; i++)
            {
                GlobalVars.Vvos[i] = (h1p[i] * Math.Sqrt(1 + (m[i] * m[i])) + h2p[i] * Math.Sqrt(1 + (n[i] * n[i])) + L1p[i]) * Lp[i] * hpc[i];
            }
            
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxN.Text) ||
               string.IsNullOrWhiteSpace(textBoxReserve.Text) ||
               string.IsNullOrWhiteSpace(textBoxH1p.Text) ||
               string.IsNullOrWhiteSpace(textBoxH2p.Text) ||
               string.IsNullOrWhiteSpace(textBoxL1p.Text) ||
               string.IsNullOrWhiteSpace(textBoxN1.Text) ||
               string.IsNullOrWhiteSpace(textBoxM.Text) ||
               string.IsNullOrWhiteSpace(textBoxLp.Text) ||
               string.IsNullOrWhiteSpace(textBoxL2p.Text) ||
               string.IsNullOrWhiteSpace(textBoxHpc.Text))
            {
                MessageBox.Show("Заполните поля", "Информация");
            }
            else
            {
                try
                {
                    textBoxN.ReadOnly = true;
                    textBoxReserve.ReadOnly = true;
                    int.TryParse(textBoxN.Text, out GlobalVars.N);

                    if (h1p == null || h2p == null || L1p == null || L2p == null || Lp == null || m == null || n == null || hpc == null)
                    {
                        h1p = new double[GlobalVars.N];
                        h2p = new double[GlobalVars.N];
                        L1p = new double[GlobalVars.N];
                        L2p = new double[GlobalVars.N];
                        Lp = new double[GlobalVars.N];
                        m = new double[GlobalVars.N];
                        n = new double[GlobalVars.N];
                        hpc = new double[GlobalVars.N];
                    }
                    if (GlobalVars.Index == (GlobalVars.N - 1))
                    {
                        double.TryParse(textBoxH1p.Text, out h1p[GlobalVars.Index]);
                        double.TryParse(textBoxH2p.Text, out h2p[GlobalVars.Index]);
                        double.TryParse(textBoxL1p.Text, out L1p[GlobalVars.Index]);
                        double.TryParse(textBoxL2p.Text, out L2p[GlobalVars.Index]);
                        double.TryParse(textBoxLp.Text, out Lp[GlobalVars.Index]);
                        double.TryParse(textBoxM.Text, out m[GlobalVars.Index]);
                        double.TryParse(textBoxN1.Text, out n[GlobalVars.Index]);
                        double.TryParse(textBoxHpc.Text, out hpc[GlobalVars.Index]);
                        textBoxH1p.Text = "";
                        textBoxH2p.Text = "";
                        textBoxL1p.Text = "";
                        textBoxL2p.Text = "";
                        textBoxLp.Text = "";
                        textBoxM.Text = "";
                        textBoxN1.Text = "";
                        textBoxHpc.Text = "";
                        throw new IndexOutOfRangeException();
                    }
                    double.TryParse(textBoxH1p.Text, out h1p[GlobalVars.Index]);
                    double.TryParse(textBoxH2p.Text, out h2p[GlobalVars.Index]);
                    double.TryParse(textBoxL1p.Text, out L1p[GlobalVars.Index]);
                    double.TryParse(textBoxL2p.Text, out L2p[GlobalVars.Index]);
                    double.TryParse(textBoxLp.Text, out Lp[GlobalVars.Index]);
                    double.TryParse(textBoxM.Text, out m[GlobalVars.Index]);
                    double.TryParse(textBoxN1.Text, out n[GlobalVars.Index]);
                    double.TryParse(textBoxHpc.Text, out hpc[GlobalVars.Index]);
                    textBoxH1p.Text = "";
                    textBoxH2p.Text = "";
                    textBoxL1p.Text = "";
                    textBoxL2p.Text = "";
                    textBoxLp.Text = "";
                    textBoxM.Text = "";
                    textBoxN1.Text = "";
                    textBoxHpc.Text = "";
                    GlobalVars.Index++;
                    textBoxReserve.Text = (GlobalVars.Index + 1).ToString();
                }
                catch (System.IndexOutOfRangeException)
                {
                    MessageBox.Show("Введены все резервы");
                    ReserveArea();
                    VolRemovedSoil();
                    VolRemovedSoilToRestore();
                    SPWRtotal sPWRtotal = new SPWRtotal();
                    sPWRtotal.Show();
                }
            }
        }

        private void SPWRcheck_Load(object sender, EventArgs e)
        {

        }
    }
}
