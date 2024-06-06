using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TerraDesign.Forms
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLogin.Text) || string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                MessageBox.Show("Заполните поля", "Информация");
                return;
            }
            else
            {
                try
                {
                   
                    NpgsqlDataAdapter adp = new NpgsqlDataAdapter("select id,\"FIO\",\"id_role\" from \"Users\" where login = '" + tbLogin.Text + "'and password = '" + tbPassword.Text + "'", GlobalVars.conn);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    int.TryParse(dt.Rows[0][0].ToString(), out GlobalVars.IdUser);
                    GlobalVars.FIOUser = dt.Rows[0][1].ToString();
                    int.TryParse(dt.Rows[0][2].ToString(), out GlobalVars.RoleUser);
                    Tema tema = new Tema();
                    tema.Show();
                    this.Hide();
                }
                catch (NpgsqlException)
                {
                    MessageBox.Show("Проверьте подключение к интернету");
                }
                catch (System.IndexOutOfRangeException)
                {
                    MessageBox.Show("Неверный логин или пароль");
                }


            }
        }

        private  void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tema tema = new Tema();
            tema.Show();
            this.Hide();
        }

        private void checkBoxHidePassword_CheckedChanged(object sender, EventArgs e)
        {
            tbPassword.PasswordChar = tbPassword.PasswordChar == '*' ? '\0' : '*';
        }

        private void Authorization_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
