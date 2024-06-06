using Word= Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;

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
            foreach (Form wFcheck in System.Windows.Forms.Application.OpenForms) wFcheck.Hide();
            Tema tema = new Tema();
            tema.Show();
        }

        private void FVOEtotal_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
              
                // Создание объекта приложения Word
                Word.Application wordApp = new Word.Application();
                // Создание нового документа
                Word.Document doc = wordApp.Documents.Add();

                // Добавляем данные из DataGridView в документ Word
                Word.Table table = doc.Tables.Add(doc.Range(), dataGridView1.RowCount+1, dataGridView1.ColumnCount);
                // Добавляем заголовки столбцов
                for (int col = 0; col < dataGridView1.ColumnCount; col++)
                {
                    table.Cell(1, col + 1).Range.Text = dataGridView1.Columns[col].HeaderText;
                    table.Cell(1, col + 1).Borders.Enable = 1;// 1 - для включения границ ячейки
                }
                // Добавляем данные
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        table.Cell(i + 2, j + 1).Range.Text = dataGridView1.Rows[i].Cells[j].Value != null ? dataGridView1.Rows[i].Cells[j].Value.ToString() : "";
                        table.Cell(i + 2, j + 1).Borders.Enable = 1;// 1 - для включения границ ячейки
                    }
                }

                Word.Paragraph para = doc.Paragraphs.Add();
                Word.Range rng = para.Range;
                rng.Text = label1.Text + "   " + textBox1.Text + "\n" +
                   label2.Text + "   " + textBox2.Text + "\n" +
                   label3.Text + "   " + textBox3.Text + "\n" +
                   label5.Text + "   " + textBox4.Text + "\n";

                saveFileDialog1.Filter = "doc files (*.doc)|*.doc|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    doc.SaveAs2(saveFileDialog1.FileName, saveFileDialog1.FilterIndex);

                }
                else
                {
                    doc.Close(false);
                    wordApp.Quit();
                    return;
                }
                saveFileDialog1.Dispose();
                MessageBox.Show("Файл успешно сохранён", "Информация");
                doc.Close(false);
                wordApp.Quit();
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show("Закройте файл Word", "Информация");

            }

        }

        private void ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = excelWorkbook.Sheets[1];
                // Получение активного листа
                Worksheet sheet = excelWorkbook.ActiveSheet;
                for (int col = 0; col < dataGridView1.Columns.Count; col++)
                {
                    sheet.Cells[1, col + 1] = dataGridView1.Columns[col].HeaderText;
                }

                // Копирование данных из DataGridView в Excel
                int row = 2; // Начинаем со второй строки (после заголовков)
                foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
                {
                    int column = 1;
                    foreach (DataGridViewCell dataGridViewCell in dataGridViewRow.Cells)
                    {
                        sheet.Cells[row, column] = dataGridViewCell.Value;
                        column++;
                    }
                    row++;
                }
                excelWorksheet.Cells[row+2, 1] = label1.Text;
                excelWorksheet.Cells[row + 2, 2] = textBox1.Text;
                excelWorksheet.Cells[row + 3, 1] = label2.Text;
                excelWorksheet.Cells[row + 3, 2] = textBox2.Text;
                excelWorksheet.Cells[row + 4, 1] = label3.Text;
                excelWorksheet.Cells[row + 4, 2] = textBox3.Text;
                excelWorksheet.Cells[row + 5, 1] = label5.Text;
                excelWorksheet.Cells[row + 5, 2] = textBox4.Text;
                excelWorksheet.Columns.AutoFit();
                //Сохранение
                saveFileDialog1.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    excelWorkbook.SaveAs(saveFileDialog1.FileName, saveFileDialog1.FilterIndex);

                }
                else
                {
                    excelWorkbook.Close(false);
                    GlobalVars.CloseExcelApp(excelApp);
                    return;
                }
                saveFileDialog1.Dispose();
                MessageBox.Show("Файл успешно сохранён", "Информация");
                excelWorkbook.Close(false);
                GlobalVars.CloseExcelApp(excelApp);
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show("Закройте файл Excel", "Информация");

            }
        }
    }
}
