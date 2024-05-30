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

namespace TerraDesign.Тестирование
{
    public partial class Result : Form
    {
        public Result()
        {
            InitializeComponent();
        }

        private void Result_Load(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;port=5432;database=TerraDesign;Username=postgres;password = 12345");
            NpgsqlDataAdapter adp = new NpgsqlDataAdapter("SELECT U.\"FIO\",L.\"dateTime\" , L.\"L2\", L.\"L1\", L.\"h1\", L.\"h2\",L.\"1m\",L.\"1n\",L.\"bprc\"\r\nFROM  \"LateralReserve\" L\r\nJOIN\"Users\" U on id=\"user\"", conn);
            DataTable dt = new DataTable();

            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns();
            dataGridView1.Columns[0].Width = 25;
            //   dataGridView1.Columns.AddRange( question)
        }
    }
}
