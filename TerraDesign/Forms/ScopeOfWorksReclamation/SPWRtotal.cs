using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Office.Interop.Excel;

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

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            foreach (Form wFcheck in System.Windows.Forms.Application.OpenForms) wFcheck.Hide();
            Tema tema = new Tema();
            tema.Show();
        }

        private void SPWRtotal_FormClosed(object sender, FormClosedEventArgs e)
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
                Word.Table table = doc.Tables.Add(doc.Range(), dataGridView1.RowCount + 1, dataGridView1.ColumnCount);
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
