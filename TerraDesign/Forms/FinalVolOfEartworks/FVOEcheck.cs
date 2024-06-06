using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            if (GlobalVars.IdUser == 0)
            {
                saveToolStripMenuItem.Visible = false;
                loadToolStripMenuItem.Visible = false;
            }
            else
            {
                saveToolStripMenuItem.Visible = true;
                loadToolStripMenuItem.Visible = true;
            }
            if (GlobalVars.hc!=0||GlobalVars.Bzp!=0||GlobalVars.hdorod!=0|| GlobalVars.bprc!=0|| GlobalVars.bukrp!=0)
            {
                var result = MessageBox.Show("Вы хотите использовать данные расчёта боковых резервов", "Информация", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    textBoxHc.Text = Convert.ToString(GlobalVars.hc);
                    textBoxBzp.Text = Convert.ToString(GlobalVars.Bzp);
                    textBoxHdorod.Text = Convert.ToString(GlobalVars.hdorod);
                    textBoxBprc.Text = Convert.ToString(GlobalVars.bprc);
                    textBoxBukrp.Text = Convert.ToString(GlobalVars.bukrp);

                }
            }
            if (GlobalVars.bk != 0 || GlobalVars.hk != 0 )
            {
                var result = MessageBox.Show("Вы хотите использовать данные расчёта водоотводных сооружений", "Информация", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    textBoxBk.Text = Convert.ToString(GlobalVars.bk);
                    textBoxHk.Text = Convert.ToString(GlobalVars.hk);
                }
            }


        }
        int i = 0;
        double[] WorkMark, Plot;
        bool[] Mound;

       // Нахождение объёма земли
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

        // Исправление рабочих меток

        private void CorrectionWorkMark()
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
        private void CorrecionRoadway()
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
        private void buttonEnterMark_Click(object sender, EventArgs e)
        {
            int Useless;
            double useless1;
            bool success = int.TryParse(textBoxN1.Text, out Useless);
            bool success1 = double.TryParse(textBoxH.Text, out useless1);
            if (success && success1)
            {
                try
                {
                    int.TryParse(textBoxN1.Text, out GlobalVars.N);
                    textBoxN1.ReadOnly = true;
                    
                    if (WorkMark == null)
                    { WorkMark = new double[GlobalVars.N]; }
                    if (i == (GlobalVars.N - 1))
                    {
                        double.TryParse(textBoxH.Text, out WorkMark[i]);
                       
                        throw new IndexOutOfRangeException();
                    }
                    double.TryParse(textBoxH.Text, out WorkMark[i]);
                    
                    i++;
                    labelWorkmark.Text = (i + 1).ToString();
                    textBoxH.Text = "";


                }
                catch (System.IndexOutOfRangeException ex)
                {
                    textBoxH.Text = "";
                    Plot = new double[WorkMark.Length];
                  
                    for (i = 0; i < WorkMark.Length; i++)
                    {
                        if (WorkMark[i]==0)
                        {
                            textBoxDist.ReadOnly = false;
                            labelDist.Text = (i).ToString();
                            break;
                        }
                    }
                        MessageBox.Show("Введены все отметки");
                    textBoxH.ReadOnly = true;
                    buttonEnterMark.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Введите числовые значения");
            }
        }

        private void buttonCount_Click(object sender, EventArgs e)
        
        {
            if (radioButtonEmbankment.Checked == false && radioButtonRecess.Checked == false)
            {
                MessageBox.Show("Выберите признак 1-ой рабочей отметки", "Информация");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(textBoxHc.Text) ||
                   string.IsNullOrWhiteSpace(textBoxBzp.Text) ||
                   string.IsNullOrWhiteSpace(textBoxHdorod.Text) ||
                   string.IsNullOrWhiteSpace(textBoxBprc.Text) ||
                   string.IsNullOrWhiteSpace(textBoxBukrp.Text) ||
                   string.IsNullOrWhiteSpace(textBoxHk.Text) ||
                   string.IsNullOrWhiteSpace(textBoxBk.Text) ||
                   string.IsNullOrWhiteSpace(textBoxL.Text) ||
                   string.IsNullOrWhiteSpace(textBoxN1.Text) ||
                   string.IsNullOrWhiteSpace(textBoxM.Text) ||
                   string.IsNullOrWhiteSpace(textBoxN.Text))
                {
                    MessageBox.Show("Заполните поля", "Информация");
                }
                else
                {

                    double.TryParse(textBoxHc.Text, out GlobalVars.hc);
                    double.TryParse(textBoxBzp.Text, out GlobalVars.Bzp);
                    double.TryParse(textBoxHdorod.Text, out GlobalVars.hdorod);
                    double.TryParse(textBoxBprc.Text, out GlobalVars.bprc);
                    double.TryParse(textBoxBukrp.Text, out GlobalVars.bukrp);
                    double.TryParse(textBoxBk.Text, out GlobalVars.bk);
                    double.TryParse(textBoxHk.Text, out GlobalVars.hk);
                    double.TryParse(textBoxL.Text, out GlobalVars.L);
                    double.TryParse(textBoxM.Text, out GlobalVars.m);
                    double.TryParse(textBoxN.Text, out GlobalVars.n);
                    Mound = new bool[WorkMark.Length];
                    try
                    {
                        for (i = 0; i < WorkMark.Length; i++)
                        {
                            if (radioButtonEmbankment.Checked == true)
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
                            else if (radioButtonRecess.Checked == true)
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
                    CorrectionWorkMark();
                    CorrecionRoadway();
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

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tema tema=new Tema();
            tema.Show();
            this.Hide();
        }

        private void FVOEcheck_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonEnterDistance_Click(object sender, EventArgs e)
        {
            if (Plot == null)
            { MessageBox.Show("Введите рабочие метки", "Информация");
                return;
            }
            double.TryParse(textBoxL.Text, out GlobalVars.L);
             int.TryParse(labelDist.Text, out i);
            
            bool success = double.TryParse(textBoxDist.Text, out Plot[i]);
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
                                textBoxDist.ReadOnly = false;
                                labelDist.Text = (i).ToString();
                                break;
                            }
                        }
                        if (i == WorkMark.Length)
                        {
                            textBoxDist.ReadOnly = true;
                        }
                        textBoxDist.Text = "";
            }
            else
            {
                MessageBox.Show("Заполните расстояние в точке перехода на участке", "Информация");
            }
           
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool success, success1, success2, success3, success4;
            success = double.TryParse(textBoxHc.Text, out GlobalVars.hc);
            success1 = double.TryParse(textBoxBzp.Text, out GlobalVars.Bzp);
            success2 = double.TryParse(textBoxHdorod.Text, out GlobalVars.hdorod);
            success3 = double.TryParse(textBoxBprc.Text, out GlobalVars.bprc);
            success4 = double.TryParse(textBoxBukrp.Text, out GlobalVars.bukrp);
            if (success == false || success1 == false || success2 == false || success3 == false || success4 == false)
            {
                DialogResult = MessageBox.Show(this, "Заполнены не все поля.\nВы уверены что хотите сохранить данные", " Внимание", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    NpgsqlDataAdapter adp = new NpgsqlDataAdapter(" UPDATE public.\"Users\" SET hc = '" + GlobalVars.hc.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, \"Bzp\" = '" + GlobalVars.Bzp.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, hdorod = '" + GlobalVars.hdorod.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, bprc = '" + GlobalVars.bprc.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, bukrp = '" + GlobalVars.bukrp.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision WHERE id = '" + GlobalVars.IdUser + "'; ", GlobalVars.conn);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    MessageBox.Show("Сохранение успешно");
                    DialogResult = DialogResult.None;
                }
            }
            else
            {
                try
                {
                    NpgsqlDataAdapter adp = new NpgsqlDataAdapter(" UPDATE public.\"Users\" SET hc = '" + GlobalVars.hc.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, \"Bzp\" = '" + GlobalVars.Bzp.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, hdorod = '" + GlobalVars.hdorod.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, bprc = '" + GlobalVars.bprc.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, bukrp = '" + GlobalVars.bukrp.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision WHERE id = '" + GlobalVars.IdUser + "'; ", GlobalVars.conn);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    MessageBox.Show("Сохранение успешно");
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(" SELECT hc, \"Bzp\",hdorod,bprc,bukrp FROM \"Users\" WHERE id = '" + GlobalVars.IdUser + "' ", GlobalVars.conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            textBoxHc.Text = dt.Rows[0][0].ToString();
            textBoxBzp.Text = dt.Rows[0][1].ToString();
            textBoxHdorod.Text = dt.Rows[0][2].ToString();
            textBoxBprc.Text = dt.Rows[0][3].ToString();
            textBoxBukrp.Text = dt.Rows[0][4].ToString();
        }

        private void FVOEcheck_Load(object sender, EventArgs e)
        {

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            WorkMark = null;
            GlobalVars.N = 0;
            i = 0;
            textBoxN1.ReadOnly = false;
            textBoxH.ReadOnly = false;
            buttonEnterMark.Enabled = true;
            labelWorkmark.Text = 1.ToString();
        }
    }
}
