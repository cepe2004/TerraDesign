using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TerraDesign.Forms.ScopeOfWorksReclamation
{
    public partial class SPWRtotal : Form
    {
        
        public SPWRtotal()
        {
            InitializeComponent();
            int i;
            dataGridView1.RowCount = GlobalVars.Vvos.Length;

            for (i = 0; i < GlobalVars.Vvos.Length; i++)
            {

                GlobalVars.Sp[i] = Math.Round(GlobalVars.Sp[i], 2);
                GlobalVars.Vrgr[i] = Math.Round(GlobalVars.Vrgr[i], 2);
                GlobalVars.Vvos[i] = Math.Round(GlobalVars.Vvos[i], 2);
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                dataGridView1.Rows[i].Cells[1].Value = GlobalVars.Sp[i];
                dataGridView1.Rows[i].Cells[2].Value = GlobalVars.Vrgr[i];
                dataGridView1.Rows[i].Cells[3].Value = GlobalVars.Vvos[i];

            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form wFcheck in Application.OpenForms) wFcheck.Hide();
            Tema tema = new Tema();
            tema.Show();
        }

        private void SPWRtotal_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }
    }
}
