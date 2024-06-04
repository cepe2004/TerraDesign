using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked==false&&radioButton2.Checked==false||
                radioButton3.Checked == false && radioButton4.Checked == false ||
                radioButton5.Checked == false && radioButton6.Checked == false)
            {
                MessageBox.Show("Выберите тип поперечного профиля дорожной одежды, \nсхему располжения резерва относительно насыпи, \nтип поперечного уклона дна резерва", "Информация");
            }
            else
            {

            
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
               string.IsNullOrWhiteSpace(textBox2.Text) ||
               string.IsNullOrWhiteSpace(textBox3.Text) ||
               string.IsNullOrWhiteSpace(textBox4.Text) ||
               string.IsNullOrWhiteSpace(textBox5.Text)) 
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
                        double.TryParse(textBox1.Text, out GlobalVars.hc);
                        double.TryParse(textBox2.Text, out GlobalVars.Bzp);
                        double.TryParse(textBox3.Text, out GlobalVars.hp);
                        double.TryParse(textBox4.Text, out GlobalVars.m);
                        double.TryParse(textBox5.Text, out GlobalVars.n);
                        double.TryParse(textBox6.Text, out GlobalVars.hdorod);
                        double.TryParse(textBox7.Text, out GlobalVars.bprc);
                        double.TryParse(textBox8.Text, out GlobalVars.bukrp);


                        if (radioButton1.Checked == true)
                        {
                            GlobalVars.AvgMarkFirstKm();
                            AvgEmbankmentsTrough();

                        }
                        if (radioButton2.Checked == true)
                        {
                            GlobalVars.AvgMarkFirstKm();
                            AvgEmbankmentsCrescent();
                        }
                        if (radioButton3.Checked == true)
                        {
                            WidthBottomTwo();
                        }
                        if (radioButton4.Checked == true)
                        {
                            WidthBottomOne();
                        }
                        if (radioButton5.Checked == true)
                        {
                            DepthReserveOne();
                            sredina = false;
                        }
                        if (radioButton6.Checked == true)
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

        private void button1_Click(object sender, EventArgs e)
        {
        double h;
        bool success = int.TryParse(textBox9.Text, out GlobalVars.N);
        bool success1 = double.TryParse(textBox10.Text, out h);

            if (success&&success1)
            {
                textBox9.ReadOnly = true;
                i++;
                if (i<GlobalVars.N)
                {
                GlobalVars.H += h;
                label24.Text = (i + 1).ToString();
                textBox10.Text = "";
                }
             else
             {
                GlobalVars.H += h;
                    textBox10.Text = "";
                    MessageBox.Show("Введены все рабочие отметки");
                textBox10.ReadOnly = true;
                button1.Enabled = false;
             }
            }
            else
            { MessageBox.Show("Введите числовые значения"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            i = 0;
            GlobalVars.N = 0;
            GlobalVars.H = 0;
            label24.Text = "1";
            textBox9.ReadOnly = false;
            textBox10.ReadOnly = false;
            button1.Enabled = true;
            textBox9.Text = "";
            textBox10.Text = "";
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
            try
            {
                double.TryParse(textBox1.Text, out GlobalVars.hc);
                double.TryParse(textBox2.Text, out GlobalVars.Bzp);
                double.TryParse(textBox3.Text, out GlobalVars.hp);
                double.TryParse(textBox4.Text, out GlobalVars.m);
                double.TryParse(textBox5.Text, out GlobalVars.n);
                double.TryParse(textBox6.Text, out GlobalVars.hdorod);
                double.TryParse(textBox7.Text, out GlobalVars.bprc);
                double.TryParse(textBox8.Text, out GlobalVars.bukrp);
                NpgsqlDataAdapter adp = new NpgsqlDataAdapter(" UPDATE public.\"Users\" SET hc = '"+GlobalVars.hc+"'::double precision, \"Bzp\" = '"+GlobalVars.Bzp+"'::double precision, hp = '"+GlobalVars.hp+"'::double precision, m = '"+GlobalVars.m+"'::double precision, n = '"+GlobalVars.n+"'::double precision, hdorod = '"+GlobalVars.hdorod+"'::double precision, bprc = '"+GlobalVars.bprc+"'::double precision, bukrp = '"+GlobalVars.bukrp+"'::double precision WHERE id = '"+GlobalVars.IdUser+"'; ", GlobalVars.conn);
                DataTable dt = new DataTable();
                adp.Fill(dt);
            }
            catch (Exception)
            {
               
                throw;
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(" SELECT hc, \"Bzp\",hp,m,n,hdorod,bprc,bukrp FROM \"Users\" WHERE id = '"+GlobalVars.IdUser+"' ", GlobalVars.conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            textBox1.Text = dt.Rows[0][0].ToString();
            textBox2.Text = dt.Rows[0][1].ToString();
            textBox3.Text = dt.Rows[0][2].ToString();
            textBox4.Text = dt.Rows[0][3].ToString();
            textBox5.Text = dt.Rows[0][4].ToString();
            textBox6.Text = dt.Rows[0][5].ToString();
            textBox7.Text = dt.Rows[0][6].ToString();
            textBox8.Text = dt.Rows[0][7].ToString();

        }
    }
}
