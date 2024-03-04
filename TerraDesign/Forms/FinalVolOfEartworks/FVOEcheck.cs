using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace TerraDesign.Forms.FinalVolOfEartworks
{
    public partial class FVOEcheck : Form
    {
        public FVOEcheck()
        {
            InitializeComponent();
            if (GlobalVars.hc!=0||GlobalVars.Bzp!=0||GlobalVars.hdorod!=0|| GlobalVars.bprc!=0|| GlobalVars.bukrp!=0)
            {
                var result = MessageBox.Show("Вы хотите использовать данные расчёта боковых резервов", "Информация", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    textBox1.Text = Convert.ToString(GlobalVars.hc);
                    textBox2.Text = Convert.ToString(GlobalVars.Bzp);
                    textBox3.Text = Convert.ToString(GlobalVars.hdorod);
                    textBox4.Text = Convert.ToString(GlobalVars.bprc);
                    textBox5.Text = Convert.ToString(GlobalVars.bukrp);

                }
            }
            if (GlobalVars.bk != 0 || GlobalVars.hk != 0 )
            {
                var result = MessageBox.Show("Вы хотите использовать данные расчёта водоотводных сооружений", "Информация", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    textBox7.Text = Convert.ToString(GlobalVars.bk);
                    textBox6.Text = Convert.ToString(GlobalVars.hk);
                }
            }


        }
        int i = 0,p;
        double[] WorkMark, Plot;
        bool[] Mound;

       
        private void VolumeEarth()
        {
            i = 0;
            GlobalVars.v = new double[Plot.Length];
            for (int i = 0; i < WorkMark.Length-1; i++)
            {
                if (WorkMark[i] == 0)
                {
                    GlobalVars.v[i-1] = (Plot[i] / 2) * (GlobalVars.Bzp * (WorkMark[i] + WorkMark[i - 1]) + GlobalVars.m * ((WorkMark[i] * WorkMark[i]) + (WorkMark[i - 1] * WorkMark[i - 1])));
                    
                    GlobalVars.v[i] = (Plot[i+1] / 2) * (GlobalVars.Bzp * (WorkMark[i] + WorkMark[i + 1]) + GlobalVars.m * ((WorkMark[i] * WorkMark[i]) + (WorkMark[i + 1] * WorkMark[i + 1])));
                }
                else
                {
                    GlobalVars.v[i] = (GlobalVars.L / 2) * (GlobalVars.Bzp * (WorkMark[i] + WorkMark[i + 1]) + GlobalVars.m * ((WorkMark[i] * WorkMark[i]) + (WorkMark[i + 1] * WorkMark[i + 1])));
                }
            }

        }
        private void WorkMarkCorrection()
        {
        
            i = 0;
            GlobalVars.N1 = new double[Plot.Length];
            for (int i = 0; i < WorkMark.Length-1; i++)
            {
                if (WorkMark[i] == 0)
                {
                    GlobalVars.N1[i-1] = (GlobalVars.m * ((WorkMark[i-1] - WorkMark[i]) * (WorkMark[i-1] - WorkMark[i])) / 12) * Plot[i];
                    GlobalVars.N1[i] = (GlobalVars.m * ((WorkMark[i] - WorkMark[i + 1]) * (WorkMark[i] - WorkMark[i + 1])) / 12) * Plot[i+1];
                }
                else
                { 
                    GlobalVars.N1[i] = (GlobalVars.m * ((WorkMark[i] - WorkMark[i + 1]) * (WorkMark[i] - WorkMark[i + 1])) / 12) * GlobalVars.L;
                }
            }
        }
        private void RoadwayCorrecion()
        {
            i = 0;
            GlobalVars.N2 = new double[Plot.Length];
            for (int i = 0; i < WorkMark.Length - 1; i++)
            {
                if (Mound[i] == true)
                {
                    if (WorkMark[i] == 0)
                    {
                        GlobalVars.N2[i - 1] = +(GlobalVars.bprc + 2 * GlobalVars.bukrp) * GlobalVars.hdorod * Plot[i];
                        GlobalVars.N2[i] = -(GlobalVars.bprc + 2 * GlobalVars.bukrp) * GlobalVars.hdorod * Plot[i + 1];
                    }
                    else
                    { GlobalVars.N2[i] = -(GlobalVars.bprc + 2 * GlobalVars.bukrp) * GlobalVars.hdorod * GlobalVars.L; }
                }
                else
                {
                    if (Mound[i] == false)
                    {
                        if (WorkMark[i] == 0)
                        {
                            GlobalVars.N2[i - 1] = -(GlobalVars.bprc + 2 * GlobalVars.bukrp) * GlobalVars.hdorod * Plot[i];
                            GlobalVars.N2[i] = +(GlobalVars.bprc + 2 * GlobalVars.bukrp) * GlobalVars.hdorod * Plot[i + 1];
                        }
                        else
                        { GlobalVars.N2[i] = +(GlobalVars.bprc + 2 * GlobalVars.bukrp) * GlobalVars.hdorod * GlobalVars.L; }
                    }
                }
            }
            
            
        }
        private void VegetableSoilCorrecion()
        {
            i = 0;
            GlobalVars.N3 = new double[Plot.Length];
            GlobalVars.N5 = new double[Plot.Length];
            for (int i = 0; i < WorkMark.Length - 1; i++)
            {
                if (Mound[i] == true)
                {
                    if (WorkMark[i] == 0)
                    {
                        GlobalVars.N5[i - 1] = (GlobalVars.Bzp + GlobalVars.n * GlobalVars.hk + 2 * GlobalVars.bk + 2 * GlobalVars.m * GlobalVars.hk + 2 * GlobalVars.m * ((WorkMark[i] + WorkMark[i - 1]) / 2)) * GlobalVars.hc * Plot[i];
                        GlobalVars.N3[i] = (GlobalVars.Bzp + 2 * GlobalVars.m * ((WorkMark[i] + WorkMark[i + 1]) / 2 + GlobalVars.hc)) * GlobalVars.hc * Plot[i + 1];

                          }
                    else
                    {
                        GlobalVars.N3[i] = (GlobalVars.Bzp + 2 * GlobalVars.m * ((WorkMark[i] + WorkMark[i + 1]) / 2 + GlobalVars.hc)) * GlobalVars.hc * GlobalVars.L;
                    }

                }
                else
                {
                    if (Mound[i] == false)
                    {
                        if (WorkMark[i] == 0)
                        {
                            GlobalVars.N3[i - 1] = (GlobalVars.Bzp + 2 * GlobalVars.m * ((WorkMark[i] + WorkMark[i - 1]) / 2 + GlobalVars.hc)) * GlobalVars.hc * Plot[i]; ;
                            GlobalVars.N5[i] = (GlobalVars.Bzp + GlobalVars.n * GlobalVars.hk + 2 * GlobalVars.bk + 2 * GlobalVars.m * GlobalVars.hk + 2 * GlobalVars.m * ((WorkMark[i] + WorkMark[i + 1]) / 2)) * GlobalVars.hc * Plot[i + 1];


                                }
                        else
                        { GlobalVars.N5[i] = (GlobalVars.Bzp + GlobalVars.n * GlobalVars.hk + 2 * GlobalVars.bk + 2 * GlobalVars.m * GlobalVars.hk + 2 * GlobalVars.m * ((WorkMark[i] + WorkMark[i + 1]) / 2)) * GlobalVars.hc * GlobalVars.L; }
                    }
                }
            }
    
        }
        private void CuvetteDepthCorrection()
        {
            i = 0;
            GlobalVars.N4 = new double[Plot.Length];
            for (int i = 0; i < WorkMark.Length - 1; i++)
            {
                if (WorkMark[i] == 0)
                {
                    GlobalVars.N4[i - 1] = 2 * GlobalVars.hk * (GlobalVars.bk + GlobalVars.m * GlobalVars.hk + GlobalVars.n * GlobalVars.hk) * Plot[i];
                    GlobalVars.N4[i] = 2 * GlobalVars.hk * (GlobalVars.bk + GlobalVars.m * GlobalVars.hk + GlobalVars.n * GlobalVars.hk) * Plot[i + 1];
                }
                else
                { GlobalVars.N4[i] = 2 * GlobalVars.hk * (GlobalVars.bk + GlobalVars.m * GlobalVars.hk + GlobalVars.n * GlobalVars.hk) * GlobalVars.L; }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int Useless;
            double useless1;
            bool success = int.TryParse(textBox9.Text, out Useless);
            bool success1 = double.TryParse(textBox10.Text, out useless1);
            if (success && success1)
            {
                try
                {
                    int.TryParse(textBox9.Text, out GlobalVars.N);
                    textBox9.ReadOnly = true;
                    
                    if (WorkMark == null)
                    { WorkMark = new double[GlobalVars.N]; }
                    if (i == (GlobalVars.N - 1))
                    {
                        double.TryParse(textBox10.Text, out WorkMark[i]);
                       
                        throw new IndexOutOfRangeException();
                    }
                    double.TryParse(textBox10.Text, out WorkMark[i]);
                    
                    i++;
                    label38.Text = (i + 1).ToString();
                    textBox10.Text = "";


                }
                catch (System.IndexOutOfRangeException ex)
                {
                    textBox10.Text = "";
                    Plot = new double[WorkMark.Length];
                  
                    for (i = 0; i < WorkMark.Length; i++)
                    {
                        if (WorkMark[i]==0)
                        {
                            textBox8.ReadOnly = false;
                            label14.Text = (i).ToString();
                            break;
                        }
                    }
                        MessageBox.Show("Введены все отметки");
                    textBox10.ReadOnly = true;
                    button1.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Введите числовые значения");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Выберите признак 1-ой рабочей отметки", "Информация");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                   string.IsNullOrWhiteSpace(textBox2.Text) ||
                   string.IsNullOrWhiteSpace(textBox3.Text) ||
                   string.IsNullOrWhiteSpace(textBox4.Text) ||
                   string.IsNullOrWhiteSpace(textBox5.Text) ||
                   string.IsNullOrWhiteSpace(textBox6.Text) ||
                   string.IsNullOrWhiteSpace(textBox7.Text) ||
                   string.IsNullOrWhiteSpace(textBox13.Text) ||
                   string.IsNullOrWhiteSpace(textBox9.Text) ||
                 
                   string.IsNullOrWhiteSpace(textBox12.Text) ||
                   string.IsNullOrWhiteSpace(textBox11.Text))
                {
                    MessageBox.Show("Заполните поля", "Информация");
                }
                else
                {

                    double.TryParse(textBox1.Text, out GlobalVars.hc);
                    double.TryParse(textBox2.Text, out GlobalVars.Bzp);
                    double.TryParse(textBox3.Text, out GlobalVars.hdorod);
                    double.TryParse(textBox4.Text, out GlobalVars.bprc);
                    double.TryParse(textBox5.Text, out GlobalVars.bukrp);
                    double.TryParse(textBox7.Text, out GlobalVars.bk);
                    double.TryParse(textBox6.Text, out GlobalVars.hk);
                    double.TryParse(textBox13.Text, out GlobalVars.L);
                    double.TryParse(textBox12.Text, out GlobalVars.m);
                    double.TryParse(textBox11.Text, out GlobalVars.n);
                    Mound = new bool[WorkMark.Length];
                    try
                    {
                        for (i = 0; i < WorkMark.Length; i++)
                        {
                            if (radioButton1.Checked == true)
                            {
                                if (WorkMark[i] == 0)
                                {
                                    do
                                    {
                                        Mound[i] = false;
                                        i++;
                                    } while (WorkMark[i] != 0 && i < WorkMark.Length - 1);
                                    Mound[i] = true;
                                    continue;
                                }
                                else
                                {
                                    Mound[i] = true;
                                }
                            }
                            else if (radioButton2.Checked == true)
                            {
                                if (WorkMark[i] == 0)
                                {
                                    do
                                    {
                                        Mound[i] = true;
                                        i++;
                                    } while (WorkMark[i] != 0 && i < WorkMark.Length - 1);
                                    Mound[i] = false;
                                    continue;
                                }
                                else
                                {
                                    Mound[i] = false;
                                }

                            }
                        }
                    }
                    catch (System.IndexOutOfRangeException ex)
                    {

                        
                    }
                    
                        
                        
                    
                    i = 0;
                    VolumeEarth();
                    WorkMarkCorrection();
                    RoadwayCorrecion();
                    VegetableSoilCorrecion();
                    CuvetteDepthCorrection();

                    for (int i = 0; i < WorkMark.Length - 1; i++)
                    {
                        if (Mound[i] == true)
                        {
                            GlobalVars.v[i] = GlobalVars.v[i] + GlobalVars.N3[i] + GlobalVars.N2[i] + GlobalVars.N1[i];
                        }
                        else
                        {
                            if (Mound[i] == false)
                            {
                                GlobalVars.v[i] = GlobalVars.v[i] + GlobalVars.N1[i] + GlobalVars.N2[i] - GlobalVars.N5[i] + GlobalVars.N4[i];
                            }
                        }
                    }
                    GlobalVars.mound = new bool[Mound.Length];
                    for (int i = 0; i < Mound.Length; i++)
                    {
                        GlobalVars.mound[i] = Mound[i];
                    }
                    FVOEtotal fVOEtotal = new FVOEtotal();
                    fVOEtotal.Show();
                }
            }
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tema tema=new Tema();
            tema.Show();
            this.Hide();
        }

        private void FVOEcheck_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Plot == null)
            { MessageBox.Show("Введите рабочие метки", "Информация");
                return;
            }
            double.TryParse(textBox13.Text, out GlobalVars.L);
             int.TryParse(label14.Text, out i);
            
            bool success = double.TryParse(textBox8.Text, out Plot[i]);
            if (success==true)
            {
             
                        try
                        {
                            Plot[i + 1] = GlobalVars.L - Plot[i];
                        }
                        catch (System.IndexOutOfRangeException ex)
                        {
                
               
                        }
                        i++;
                        for (; i < WorkMark.Length; i++)
                        {
                            if (WorkMark[i] == 0)
                            {
                                textBox8.ReadOnly = false;
                                label14.Text = (i).ToString();
                                break;
                            }
                        }
                        if (i == WorkMark.Length)
                        {
                            textBox8.ReadOnly = true;
                        }
                        textBox8.Text = "";
            }
            else
            {
                MessageBox.Show("Заполните расстояние в точке перехода на участке", "Информация");
            }
           
        }

        private void FVOEcheck_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            WorkMark = null;
            GlobalVars.N = 0;
            i = 0;
            textBox9.ReadOnly = false;
            textBox10.ReadOnly = false;
            button1.Enabled = true;
            label38.Text = 1.ToString();
        }
    }
}
