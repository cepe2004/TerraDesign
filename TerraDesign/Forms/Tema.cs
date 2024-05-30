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

        private void боковыеРезервыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalVars.RoleUser == 2)
            {
                Testing testing = new Testing("LS");
                testing.Show();
                this.Hide();
            }
            else
            {
                Result result= new Result();
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
            }
            else
            {
                enterToolStripMenuItem.Text = "Выход";
            }
        }
    }
}
