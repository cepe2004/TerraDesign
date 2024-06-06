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
using TerraDesign.Тестирование;

namespace TerraDesign.Forms
{
    public partial class Tema : Form
    {
        public Tema()
        {
            InitializeComponent();
        }

        private void buttonLS_Click(object sender, EventArgs e)
        {
            LScheck lScheck=new LScheck();
            lScheck.Show();
            this.Hide();
        }

        private void buttonWF_Click(object sender, EventArgs e)
        {
            WFcheck wFcheck= new WFcheck();
            wFcheck.Show();
            this.Hide();
        }

        private void buttonFVOE_Click(object sender, EventArgs e)
        {
            FVOEcheck fVOEcheck=new FVOEcheck();
            fVOEcheck.Show();
            this.Hide();
        }

        private void buttonSPWR_Click(object sender, EventArgs e)
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

        private void enterStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (GlobalVars.IdUser == 0)
            {
                Authorization authorization = new Authorization();
                authorization.Show();
                this.Hide();
            }
            else
            {
                
                GlobalVars.IdUser = 0;
                this.OnLoad(e);
            }
           
        }

        private void lSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalVars.RoleUser == 2)
            {
                Testing testing = new Testing("LS");
                testing.Show();
                this.Hide();
            }
            else
            {
                Result result= new Result("LS");
                result.Show();
                this.Hide();
            }
          
        }

        private void Tema_Load(object sender, EventArgs e)
        {
            if (GlobalVars.IdUser==0)
            {
                enterToolStripMenuItem.Text = "Вход";
                testingToolStripMenuItem.Visible = false;
                managementToolStripMenuItem.Visible = false;
            }
            else if (GlobalVars.RoleUser==3)
            {
                testingToolStripMenuItem.Visible = false;
                enterToolStripMenuItem.Text = "Выход";
            }
            else
            {
                enterToolStripMenuItem.Text = "Выход";
                managementToolStripMenuItem.Visible = false;
            }
        }

        private void wFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalVars.RoleUser == 2)
            {
                Testing testing = new Testing("WF");
                testing.Show();
                this.Hide();
            }
            else
            {
                Result result = new Result("WF");
                result.Show();
                this.Hide();
            }
        }

        private void managementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SysAdmin sysAdmin= new SysAdmin();
            sysAdmin.Show();
            this.Hide();
        }
    }
}
