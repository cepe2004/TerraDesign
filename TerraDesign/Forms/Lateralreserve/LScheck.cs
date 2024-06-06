using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TerraDesign.Forms;
using TerraDesign.Forms.Lateralreserve;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TerraDesign
{
    public partial class LScheck : Form
    {
        public LScheck()
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
        }
        int i = 0;
        bool sredina = true;
        private void AvgEmbankmentsTrough()
        {
            GlobalVars.Fcp = GlobalVars.Bzp * GlobalVars.Hcp + GlobalVars.m * (GlobalVars.Hcp * GlobalVars.Hcp) - (GlobalVars.bprc + (2 * GlobalVars.bukrp)) * GlobalVars.hdorod;
           
        }
        private void AvgEmbankmentsCrescent()
        {
            GlobalVars.Fcp = GlobalVars.Bzp * GlobalVars.Hcp + GlobalVars.m * (GlobalVars.Hcp * GlobalVars.Hcp);
        }
        private void WidthBottomTwo()
        {
            GlobalVars.L1p = (GlobalVars.Fcp / (2 * GlobalVars.hp)) - (GlobalVars.hp / 2) * (GlobalVars.m + GlobalVars.n);
        }
        private void WidthBottomOne()
        {
            GlobalVars.L1p = (GlobalVars.Fcp / GlobalVars.hp) - (GlobalVars.hp / 2) * (GlobalVars.m + GlobalVars.n);
        }
        private void DepthReserveOne()
        {
            GlobalVars.h1 = GlobalVars.hp - 0.01 * GlobalVars.L1p;
            GlobalVars.h2 = GlobalVars.hp + 0.01 * GlobalVars.L1p;
        }
        private void DepthReserveTwo()
        {
            GlobalVars.h1=GlobalVars.h2 = GlobalVars.hp - 0.005 * GlobalVars.L1p;
            GlobalVars.h3 = GlobalVars.hp + 0.005 * GlobalVars.L1p;
        }
        private void WidthReserveUp()
        {
            GlobalVars.L2p = GlobalVars.L1p + GlobalVars.m * GlobalVars.h1 + GlobalVars.n * GlobalVars.h2;
        }

        private void buttonCount_Click(object sender, EventArgs e)
        {
            if (radioButtonSelfish.Checked==false&&radioButtonCrescent.Checked==false||
                radioButtonDoublesided.Checked == false && radioButtonOnesided.Checked == false ||
                radioButtonSingleslope.Checked == false && radioButtonDoubleslope.Checked == false)
            {
                MessageBox.Show("Выберите тип поперечного профиля дорожной одежды, \nсхему располжения резерва относительно насыпи, \nтип поперечного уклона дна резерва", "Информация");
            }
            else
            {
            if (string.IsNullOrWhiteSpace(textBoxHc.Text) ||
               string.IsNullOrWhiteSpace(textBoxBzp.Text) ||
               string.IsNullOrWhiteSpace(textBoxHp.Text) ||
               string.IsNullOrWhiteSpace(textBoxM.Text) ||
               string.IsNullOrWhiteSpace(textBoxN.Text)) 
            {
                MessageBox.Show("Заполните поля", "Информация");
            }
            else {

                    if (GlobalVars.H == 0 || i <= (GlobalVars.N-1))
                    {
                        MessageBox.Show("Введите отметки");
                    }
                    else
                    {
                        double.TryParse(textBoxHc.Text, out GlobalVars.hc);
                        double.TryParse(textBoxBzp.Text, out GlobalVars.Bzp);
                        double.TryParse(textBoxHp.Text, out GlobalVars.hp);
                        double.TryParse(textBoxM.Text, out GlobalVars.m);
                        double.TryParse(textBoxN.Text, out GlobalVars.n);
                        double.TryParse(textBoxHdorod.Text, out GlobalVars.hdorod);
                        double.TryParse(textBoxBprc.Text, out GlobalVars.bprc);
                        double.TryParse(textBoxBukrp.Text, out GlobalVars.bukrp);


                        if (radioButtonSelfish.Checked == true)
                        {
                            GlobalVars.AvgMarkFirstKm();
                            AvgEmbankmentsTrough();

                        }
                        if (radioButtonCrescent.Checked == true)
                        {
                            GlobalVars.AvgMarkFirstKm();
                            AvgEmbankmentsCrescent();
                        }
                        if (radioButtonDoublesided.Checked == true)
                        {
                            WidthBottomTwo();
                        }
                        if (radioButtonOnesided.Checked == true)
                        {
                            WidthBottomOne();
                        }
                        if (radioButtonSingleslope.Checked == true)
                        {
                            DepthReserveOne();
                            sredina = false;
                        }
                        if (radioButtonDoubleslope.Checked == true)
                        {
                            DepthReserveTwo();
                            sredina = true;
                        }
                        WidthReserveUp();
                        LStotal lStotal = new LStotal(sredina);
                        lStotal.Show();
                    }
                }
            }
        }

        private void buttonEnterWorkmark_Click(object sender, EventArgs e)
        {
            double h;
            bool success = int.TryParse(textBoxN1.Text, out GlobalVars.N);
            bool success1 = double.TryParse(textBoxH1.Text, out h);

            if (success&&success1)
            {
                textBoxN1.ReadOnly = true;
                i++;
                if (i<GlobalVars.N)
                {
                GlobalVars.H += h;
                labelWorkmark.Text = (i + 1).ToString();
                textBoxH1.Text = "";
                }
             else
             {
                GlobalVars.H += h;
                    textBoxH1.Text = "";
                    MessageBox.Show("Введены все рабочие отметки");
                textBoxH1.ReadOnly = true;
                buttonEnterWorkmark.Enabled = false;
             }
            }
            else
            { MessageBox.Show("Введите числовые значения"); }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            i = 0;
            GlobalVars.N = 0;
            GlobalVars.H = 0;
            labelWorkmark.Text = "1";
            textBoxN1.ReadOnly = false;
            textBoxH1.ReadOnly = false;
            buttonEnterWorkmark.Enabled = true;
            textBoxN1.Text = "";
            textBoxH1.Text = "";
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tema tema=new Tema();
            tema.Show();
            this.Hide();
        }

        private void LScheck_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            bool success,success1,success2,success3,success4,success5,success6,success7;
            success=double.TryParse(textBoxHc.Text, out GlobalVars.hc);
            success1=double.TryParse(textBoxBzp.Text, out GlobalVars.Bzp);
            success2=double.TryParse(textBoxHp.Text, out GlobalVars.hp);
            success3=double.TryParse(textBoxM.Text, out GlobalVars.m);
            success4=double.TryParse(textBoxN.Text, out GlobalVars.n);
            success5=double.TryParse(textBoxHdorod.Text, out GlobalVars.hdorod);
            success6=double.TryParse(textBoxBprc.Text, out GlobalVars.bprc);
            success7=double.TryParse(textBoxBukrp.Text, out GlobalVars.bukrp);
            
            if (success == false || success1 == false || success2 == false || success3 == false || success4 == false || success5 == false || success6 == false || success7 == false)
            {
                DialogResult= MessageBox.Show(this, "Заполнены не все поля.\nВы уверены что хотите сохранить данные", " Внимание", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    NpgsqlDataAdapter adp = new NpgsqlDataAdapter(" UPDATE public.\"Users\" SET hc = '" + GlobalVars.hc.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, \"Bzp\" = '" + GlobalVars.Bzp.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, hp = '" + GlobalVars.hp.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, m = '" + GlobalVars.m.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, n = '" + GlobalVars.n.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, hdorod = '" + GlobalVars.hdorod.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, bprc = '" + GlobalVars.bprc.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, bukrp = '" + GlobalVars.bukrp.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision WHERE id = '" + GlobalVars.IdUser + "'; ", GlobalVars.conn);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    MessageBox.Show("Сохранение успешно");
                    DialogResult=DialogResult.None;
                }
            }
            else
            {
                try
                {
                    NpgsqlDataAdapter adp = new NpgsqlDataAdapter(" UPDATE public.\"Users\" SET hc = '" + GlobalVars.hc.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, \"Bzp\" = '" + GlobalVars.Bzp.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, hp = '" + GlobalVars.hp.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, m = '" + GlobalVars.m.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, n = '" + GlobalVars.n.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, hdorod = '" + GlobalVars.hdorod.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, bprc = '" + GlobalVars.bprc.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision, bukrp = '" + GlobalVars.bukrp.ToString(CultureInfo.InvariantCulture).Replace(",", ".") + "'::double precision WHERE id = '" + GlobalVars.IdUser + "'; ", GlobalVars.conn);
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
            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(" SELECT hc, \"Bzp\",hp,m,n,hdorod,bprc,bukrp FROM \"Users\" WHERE id = '"+GlobalVars.IdUser+"' ", GlobalVars.conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            textBoxHc.Text = dt.Rows[0][0].ToString();
            textBoxBzp.Text = dt.Rows[0][1].ToString();
            textBoxHp.Text = dt.Rows[0][2].ToString();
            textBoxM.Text = dt.Rows[0][3].ToString();
            textBoxN.Text = dt.Rows[0][4].ToString();
            textBoxHdorod.Text = dt.Rows[0][5].ToString();
            textBoxBprc.Text = dt.Rows[0][6].ToString();
            textBoxBukrp.Text = dt.Rows[0][7].ToString();

        }
    }
}
