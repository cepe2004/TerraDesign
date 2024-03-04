using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TerraDesign.Forms.Lateralreserve
{
    public partial class LStotal : Form
    {
        public LStotal(bool sr)
        {
            InitializeComponent();
            if (sr==false)
            {
                label10.Visible = false;
                label9.Visible = false;
                label14.Visible = false;
                textBox5.Visible = false;
            }
            
            GlobalVars.L1p=Math.Round(GlobalVars.L1p, 2);
            GlobalVars.L2p = Math.Round(GlobalVars.L2p, 2);
            GlobalVars.h1 = Math.Round(GlobalVars.h1, 2);
            GlobalVars.h2 = Math.Round(GlobalVars.h2, 2);
            GlobalVars.h3 = Math.Round(GlobalVars.h3, 2);
            textBox1.Text =Convert.ToString(GlobalVars.L1p);
            textBox2.Text = Convert.ToString(GlobalVars.L2p);
            textBox3.Text = Convert.ToString(GlobalVars.h1);
            textBox4.Text = Convert.ToString(GlobalVars.h2);
            textBox5.Text = Convert.ToString(GlobalVars.h3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form wFcheck in Application.OpenForms) wFcheck.Hide();
            Tema tema = new Tema();
            tema.Show();
        }

        private void LStotal_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
