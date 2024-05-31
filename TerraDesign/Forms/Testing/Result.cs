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
using TerraDesign.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TerraDesign.Тестирование
{
    public partial class Result : Form
    {
        NpgsqlDataAdapter adp;
        DataTable dt;
        string tema;
        public Result(string tema)
        {
            InitializeComponent();
            this.tema = tema;
        }

        private void Result_Load(object sender, EventArgs e)
        {
            int today = DateTime.Now.Day;
            textBoxDate.Text = DateTime.Now.ToString("dd-MM-yyyy"); ;
            switch (tema)
            {
                case "LS":
                    adp = new NpgsqlDataAdapter("SELECT U.\"FIO\",L.\"dateTime\" , L.\"L2\", L.\"L1\", L.\"h1\", L.\"h2\",L.\"1m\",L.\"1n\",L.\"bprc\"\r\nFROM  \"LateralReserve\" L\r\nJOIN\"Users\" U on id=\"user\"", GlobalVars.conn);
                    dt = new DataTable();
                    adp.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoResizeColumns();
               break;
                case "WF":
                    adp = new NpgsqlDataAdapter("SELECT U.\"FIO\",W.\"dateTime\" , W.\"w\", W.\"x\", W.\"b\", W.\"h\",W.\"m\"\r\nFROM  \"WaterFacilities\" W\r\nJOIN\"Users\" U on id=\"user\"", GlobalVars.conn);
                    dt = new DataTable();
                    adp.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoResizeColumns();
               break;

            }
        }
        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tema tema = new Tema();
            tema.Show();
            this.Hide();
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tema)
                {
                    case "LS":
                        adp = new NpgsqlDataAdapter("SELECT U.\"FIO\",L.\"dateTime\" , L.\"L2\", L.\"L1\", L.\"h1\", L.\"h2\",L.\"1m\",L.\"1n\",L.\"bprc\"\r\nFROM  \"LateralReserve\" L\r\nJOIN\"Users\" U on id=\"user\"WHERE DATE(\"dateTime\") = '" + textBoxDate.Text + "'", GlobalVars.conn);
                        dt = new DataTable();
                        adp.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.AutoResizeColumns();
                        break;
                    case "WF":
                        adp = new NpgsqlDataAdapter("SELECT U.\"FIO\",W.\"dateTime\" , W.\"w\", W.\"x\", W.\"b\", W.\"h\",W.\"m\"\r\nFROM  \"WaterFacilities\" W\r\nJOIN\"Users\" U on id=\"user\" WHERE DATE(\"dateTime\") = '" + textBoxDate.Text + "'", GlobalVars.conn);
                        dt = new DataTable();
                        adp.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.AutoResizeColumns();
                        break;
                }
            }
            catch (Npgsql.PostgresException)
            {

                MessageBox.Show("Введите корректную дату","Ошибка");
            }
            
        }
    

        private void buttonReset_Click(object sender, EventArgs e)
        {
            switch (tema)
            {
                case "LS":
                    adp = new NpgsqlDataAdapter("SELECT U.\"FIO\",L.\"dateTime\" , L.\"L2\", L.\"L1\", L.\"h1\", L.\"h2\",L.\"1m\",L.\"1n\",L.\"bprc\"\r\nFROM  \"LateralReserve\" L\r\nJOIN\"Users\" U on id=\"user\"", GlobalVars.conn);
                    dt = new DataTable();
                    adp.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoResizeColumns();
                    break;
                case "WF":
                    adp = new NpgsqlDataAdapter("SELECT U.\"FIO\",W.\"dateTime\" , W.\"w\", W.\"x\", W.\"b\", W.\"h\",W.\"m\"\r\nFROM  \"WaterFacilities\" W\r\nJOIN\"Users\" U on id=\"user\"", GlobalVars.conn);
                    dt = new DataTable();
                    adp.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoResizeColumns();
                    break;

            }
        }
    }
}
