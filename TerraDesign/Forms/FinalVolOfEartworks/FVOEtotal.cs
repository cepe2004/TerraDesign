using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TerraDesign.Forms.FinalVolOfEartworks
{
    public partial class FVOEtotal : Form
    {
        public FVOEtotal()
        {
            InitializeComponent();
            int i;
            double TotalCutMound=0, TotalMound=0,TotalCutExcavation = 0,TotalExcavation = 0;
            GlobalVars.L1p = Math.Round(GlobalVars.L1p, 2);
            GlobalVars.L2p = Math.Round(GlobalVars.L2p, 2);
            GlobalVars.h1 = Math.Round(GlobalVars.h1, 2);
            GlobalVars.h2 = Math.Round(GlobalVars.h2, 2);
            GlobalVars.h3 = Math.Round(GlobalVars.h3, 2);
            dataGridView1.RowCount = GlobalVars.v.Length-1;

            for (i = 0; i < GlobalVars.v.Length-1; i++)
            {
                if (GlobalVars.mound[i]==true)
                {
                    dataGridView1.Rows[i].Cells[1].Value = "Насыпь";
                    GlobalVars.N3[i] = Math.Round(GlobalVars.N3[i], 2);
                    dataGridView1.Rows[i].Cells[4].Value = GlobalVars.N3[i];
                    TotalCutMound += GlobalVars.N3[i];
                    TotalMound += GlobalVars.v[i];
                }
                else if (GlobalVars.mound[i] == false)
                {
                    dataGridView1.Rows[i].Cells[1].Value = "Выемка";
                    GlobalVars.N5[i] = Math.Round(GlobalVars.N5[i], 2);
                    dataGridView1.Rows[i].Cells[3].Value = GlobalVars.N5[i];
                    TotalCutExcavation += GlobalVars.N5[i];
                    TotalExcavation += GlobalVars.v[i];
                }
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                GlobalVars.v[i] = Math.Round(GlobalVars.v[i], 2);
                dataGridView1.Rows[i].Cells[2].Value = GlobalVars.v[i];
               
               
            }
            TotalMound=Math.Round(TotalMound, 2);
            TotalExcavation=Math.Round(TotalExcavation, 2);
            TotalCutExcavation = Math.Round(TotalCutExcavation, 2);
            TotalCutMound = Math.Round(TotalCutMound, 2);
            textBox1.Text = Convert.ToString(TotalMound);
            textBox2.Text = Convert.ToString(TotalExcavation);
            textBox3.Text = Convert.ToString(TotalCutExcavation);
            textBox4.Text = Convert.ToString(TotalCutMound);
            GlobalVars.v = null;
            GlobalVars.N1 = null;
            GlobalVars.N2 = null;
            GlobalVars.N3 = null;
            GlobalVars.N4 = null;
            GlobalVars.N5 = null;
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form wFcheck in Application.OpenForms) wFcheck.Hide();
            Tema tema = new Tema();
            tema.Show();
        }

        private void FVOEtotal_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
