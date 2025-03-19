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
                    textBox3.Text = Convert.ToString(GlobalVars.h1);
                    textBox4.Text = Convert.ToString(GlobalVars.h2);
                    textBox5.Text = Convert.ToString(GlobalVars.L1p);
                    textBox9.Text = Convert.ToString(GlobalVars.L2p);
           

                }
            }
        }
        int i = 0;
        double[] h1p,h2p,L1p,L2p,Lp,m,n,hpc;

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tema tema = new Tema();
            tema.Show();
            this.Hide();
        }

        private void SPWRcheck_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            h1p = null;
            h2p=null;
            L1p = null;
            L2p = null;
            Lp = null; 
            m = null;
            n = null;
            hpc = null;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (textBox2.ReadOnly == true)
            {
                MessageBox.Show("Введите номер и данные резерва, а затем нажмите редактировать");
                textBox2.ReadOnly =false;
                button1.Enabled= false;
            }
            else
            {
                try
                {
                    int IndexEdit;
                    int.TryParse(textBox2.Text, out IndexEdit);
                    IndexEdit--;
                    double.TryParse(textBox3.Text, out h1p[IndexEdit]);
                    double.TryParse(textBox4.Text, out h2p[IndexEdit]);
                    double.TryParse(textBox5.Text, out L1p[IndexEdit]);
                    double.TryParse(textBox9.Text, out L2p[IndexEdit]);
                    double.TryParse(textBox8.Text, out Lp[IndexEdit]);
                    double.TryParse(textBox7.Text, out m[IndexEdit]);
                    double.TryParse(textBox6.Text, out n[IndexEdit]);
                    double.TryParse(textBox10.Text, out hpc[IndexEdit]);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
               string.IsNullOrWhiteSpace(textBox2.Text) ||
               string.IsNullOrWhiteSpace(textBox3.Text) ||
               string.IsNullOrWhiteSpace(textBox4.Text) ||
               string.IsNullOrWhiteSpace(textBox5.Text) ||
               string.IsNullOrWhiteSpace(textBox6.Text) ||
               string.IsNullOrWhiteSpace(textBox7.Text) ||
               string.IsNullOrWhiteSpace(textBox8.Text) ||
               string.IsNullOrWhiteSpace(textBox9.Text) ||
               string.IsNullOrWhiteSpace(textBox10.Text))
            {
                MessageBox.Show("Заполните поля", "Информация");
            }
            else
            {
                try
                {
                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    int.TryParse(textBox1.Text, out GlobalVars.N);

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
                        double.TryParse(textBox3.Text, out h1p[GlobalVars.Index]);
                        double.TryParse(textBox4.Text, out h2p[GlobalVars.Index]);
                        double.TryParse(textBox5.Text, out L1p[GlobalVars.Index]);
                        double.TryParse(textBox9.Text, out L2p[GlobalVars.Index]);
                        double.TryParse(textBox8.Text, out Lp[GlobalVars.Index]);
                        double.TryParse(textBox7.Text, out m[GlobalVars.Index]);
                        double.TryParse(textBox6.Text, out n[GlobalVars.Index]);
                        double.TryParse(textBox10.Text, out hpc[GlobalVars.Index]);
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox9.Text = "";
                        textBox8.Text = "";
                        textBox7.Text = "";
                        textBox6.Text = "";
                        textBox10.Text = "";
                        throw new IndexOutOfRangeException();
                    }
                    double.TryParse(textBox3.Text, out h1p[GlobalVars.Index]);
                    double.TryParse(textBox4.Text, out h2p[GlobalVars.Index]);
                    double.TryParse(textBox5.Text, out L1p[GlobalVars.Index]);
                    double.TryParse(textBox9.Text, out L2p[GlobalVars.Index]);
                    double.TryParse(textBox8.Text, out Lp[GlobalVars.Index]);
                    double.TryParse(textBox7.Text, out m[GlobalVars.Index]);
                    double.TryParse(textBox6.Text, out n[GlobalVars.Index]);
                    double.TryParse(textBox10.Text, out hpc[GlobalVars.Index]);
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox9.Text = "";
                    textBox8.Text = "";
                    textBox7.Text = "";
                    textBox6.Text = "";
                    textBox10.Text = "";
                    
                    GlobalVars.Index++;
                    textBox2.Text = (GlobalVars.Index + 1).ToString();


                }
                catch (System.IndexOutOfRangeException ex)
                {
                    MessageBox.Show("Введены все резервы");
                    ReserveArea();
                    VolRemovedSoil();
                    VolRemovedSoilToRestore();
                    button2.Enabled= true;
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
