using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TerraDesign.Forms.FinalVolOfEartworks;
using TerraDesign.Forms.ScopeOfWorksReclamation;
using TerraDesign.Forms.Waterfacil;

namespace TerraDesign.Forms
{
    public partial class Tema : Form
    {
        public Tema()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LScheck lScheck=new LScheck();
            lScheck.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WFcheck wFcheck= new WFcheck();
            wFcheck.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FVOEcheck fVOEcheck=new FVOEcheck();
            fVOEcheck.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SPWRcheck sPWRcheck=new SPWRcheck();
            sPWRcheck.Show();
            this.Hide();
        }

        private void Tema_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("              Программа расчётов водоотводных сооружений\n                                и объёмов земляных работ\n  \n              Разработчик - Гребельный Сергей Андреевич,\n                                     студент 901 группы\n              КГБПОУ \"Благовещенский строительный техникум\n                              р.п. Степное Озеро, 2023 год ", "Информация");
        }
    }
}
