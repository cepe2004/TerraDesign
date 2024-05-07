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

namespace TerraDesign.Forms.Waterfacil
{
    public partial class WFtotal : Form
    {
        public WFtotal()
        {
            InitializeComponent();
            GlobalVars.bk = Math.Round(GlobalVars.bk, 2);
            GlobalVars.hk = Math.Round(GlobalVars.hk, 2);
            GlobalVars.bk = Math.Round(GlobalVars.bk, 2);
            GlobalVars.hk = Math.Round(GlobalVars.hk, 2);
           
            textBox1.Text = Convert.ToString(GlobalVars.bk);
            textBox2.Text = Convert.ToString(GlobalVars.hk);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form wFcheck in Application.OpenForms) wFcheck.Hide();
            Tema tema = new Tema();
            tema.Show();
           
            
        }

        private void WFtotal_FormClosed(object sender, FormClosedEventArgs e)
        {
        
        }
    }
}
