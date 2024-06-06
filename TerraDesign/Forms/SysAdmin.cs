
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TerraDesign.Forms
{
    public partial class SysAdmin : Form
    {
        NpgsqlDataAdapter adp;
        DataTable dt;
        public SysAdmin()
        {
            InitializeComponent();
            NpgsqlDataAdapter adp = new NpgsqlDataAdapter("SELECT * FROM \"Users\"", GlobalVars.conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            comboBoxTable.SelectedIndex = 0;
        }

        private void comboBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxTable.SelectedIndex)
            {
                case 0:
                    adp = new NpgsqlDataAdapter("SELECT * FROM \"Users\"", GlobalVars.conn);
                    dt = new DataTable();
                    adp.Fill(dt);
                    dataGridView1.DataSource = dt;
                    labelFIO.Visible = true;
                    labelLogin.Visible = true;
                    labelPassword.Visible = true;
                    labelRole.Visible = true;
                    textBoxFio.Visible = true;
                    textBoxLogin.Visible = true;
                    textBoxPassword.Visible = true;
                    comboBoxRole.Visible = true;
                    buttonAdd.Visible = true;
                    buttonEdit.Visible = true;
                    break;
                case 1:
                    adp = new NpgsqlDataAdapter("SELECT \"id_LateralReserve\",\"Users\".\"FIO\",\"L2\",\"L1\",h1,h2,\"1m\",\"1n\",\"LateralReserve\".bprc,\"LateralReserve\".\"dateTime\"\r\nFROM public.\"LateralReserve\"\r\nJOIN\"Users\" ON id=\"user\"", GlobalVars.conn);
                    dt = new DataTable();
                    adp.Fill(dt);
                    dataGridView1.DataSource = dt;
                    labelFIO.Visible = false;
                    labelLogin.Visible = false;
                    labelPassword.Visible = false;
                    labelRole.Visible = false;
                    textBoxFio.Visible = false;
                    textBoxLogin.Visible = false;
                    textBoxPassword.Visible = false;
                    comboBoxRole.Visible = false;
                    buttonAdd.Visible = false;
                    buttonEdit.Visible = false;
                    break;
                case 2:
                    adp = new NpgsqlDataAdapter("SELECT \"Id_WaterFacilities\",\"Users\".\"FIO\",\"w\",\"x\",b,h,\"WaterFacilities\".\"m\",\"WaterFacilities\".\"dateTime\"\r\nFROM public.\"WaterFacilities\"\r\nJOIN\"Users\" ON id=\"user\"", GlobalVars.conn);
                    dt = new DataTable();
                    adp.Fill(dt);
                    dataGridView1.DataSource = dt;
                    labelFIO.Visible = false;
                    labelLogin.Visible = false;
                    labelPassword.Visible = false;
                    labelRole.Visible = false;
                    textBoxFio.Visible = false;
                    textBoxLogin.Visible = false;
                    textBoxPassword.Visible = false;
                    comboBoxRole.Visible = false;
                    buttonAdd.Visible = false;
                    buttonEdit.Visible = false;
                    break;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
            string str = "INSERT INTO public.\"Users\" (\"FIO\", id_role, login, password) VALUES('" + textBoxFio.Text + "'::text, '" + comboBoxRole.SelectedIndex + 1 + "'::bigint, '" + textBoxLogin.Text + "'::character varying, '" + textBoxPassword.Text + "'::character varying) returning id; ";
            NpgsqlDataAdapter adp1 = new NpgsqlDataAdapter(str, GlobalVars.conn);
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);
            comboBoxTable_SelectedIndexChanged(sender, e);
            }
            catch (Npgsql.PostgresException)
            {
                MessageBox.Show("Заполните поля");
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFio.Text) ||
                string.IsNullOrWhiteSpace(textBoxLogin.Text) ||
                string.IsNullOrWhiteSpace(textBoxPassword.Text) ||
                string.IsNullOrWhiteSpace(comboBoxRole.Text))
            {
                MessageBox.Show("Заполните поля", "Информация");
            }
            else
            {
                DialogResult = MessageBox.Show(this, "Подтвердите редактирование", " Внимание", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    string idUser = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    NpgsqlDataAdapter adp1 = new NpgsqlDataAdapter("UPDATE public.\"Users\" SET password = '" + textBoxPassword.Text + "'::character varying, login = '" + textBoxLogin.Text + "'::character varying, \"FIO\" = '" + textBoxFio.Text + "'::text WHERE id = '" + idUser + "'; ", GlobalVars.conn);
                    DataTable dt2 = new DataTable();
                    adp1.Fill(dt2);
                    comboBoxTable_SelectedIndexChanged(sender, e);
                }
                DialogResult = DialogResult.None;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show(this, "Подтвердите удаление", " Внимание", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {
                switch (comboBoxTable.SelectedIndex)
                {
                    case 0:
                        string idUser = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        NpgsqlDataAdapter adp1 = new NpgsqlDataAdapter("DELETE FROM public.\"Users\"  WHERE id IN  ('" + idUser + "'); ", GlobalVars.conn);
                        DataTable dt1 = new DataTable();
                        adp1.Fill(dt1);
                        comboBoxTable_SelectedIndexChanged(sender, e);
                        break;
                    case 1:
                        string idReserve = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        NpgsqlDataAdapter adp2 = new NpgsqlDataAdapter("DELETE FROM public.\"LateralReserve\"  WHERE \"id_LateralReserve\" IN  ('" + idReserve + "'); ", GlobalVars.conn);
                        DataTable dt2 = new DataTable();
                        adp2.Fill(dt2);
                        comboBoxTable_SelectedIndexChanged(sender, e);
                        break;
                    case 2:
                        string idFacilities = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        NpgsqlDataAdapter adp3 = new NpgsqlDataAdapter("DELETE FROM public.\"WaterFacilities\"  WHERE \"Id_WaterFacilities\" IN  ('" + idFacilities + "'); ", GlobalVars.conn);
                        DataTable dt3 = new DataTable();
                        adp3.Fill(dt3);
                        comboBoxTable_SelectedIndexChanged(sender, e);
                        break;


                }
            }
            DialogResult = DialogResult.None;
            }
            catch (Npgsql.PostgresException)
            {
                MessageBox.Show("Не выбрано поле");
            }
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tema tema = new Tema();
            tema.Show();
            this.Hide();
        }

        private void SysAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
