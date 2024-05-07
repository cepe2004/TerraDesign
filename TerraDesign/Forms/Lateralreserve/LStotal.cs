using Word = Microsoft.Office.Interop.Word;
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

namespace TerraDesign.Forms.Lateralreserve
{
    public partial class LStotal : Form
    {
        public LStotal(bool sr)
        {
            InitializeComponent();
            if (sr==false)
            {
                label10.Visible = false;
                label9.Visible = false;
                label14.Visible = false;
                textBox5.Visible = false;
            }
            
            GlobalVars.L1p=Math.Round(GlobalVars.L1p, 2);
            GlobalVars.L2p = Math.Round(GlobalVars.L2p, 2);
            GlobalVars.h1 = Math.Round(GlobalVars.h1, 2);
            GlobalVars.h2 = Math.Round(GlobalVars.h2, 2);
            GlobalVars.h3 = Math.Round(GlobalVars.h3, 2);
            textBox1.Text =Convert.ToString(GlobalVars.L1p);
            textBox2.Text = Convert.ToString(GlobalVars.L2p);
            textBox3.Text = Convert.ToString(GlobalVars.h1);
            textBox4.Text = Convert.ToString(GlobalVars.h2);
            textBox5.Text = Convert.ToString(GlobalVars.h3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form wFcheck in System.Windows.Forms.Application.OpenForms) wFcheck.Hide();
            Tema tema = new Tema();
            tema.Show();
        }

        private void LStotal_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Создание объекта приложения Word
                Word.Application wordApp = new Word.Application();
                // Создание нового документа
                Document doc = wordApp.Documents.Add();
                // Добавление текста в документ
                Paragraph para = doc.Paragraphs.Add();
                Microsoft.Office.Interop.Word.Range rng = para.Range;
                rng.Text = label1.Text + "   " + label2.Text + "1р  " + textBox1.Text + "\n" +
                    label4.Text + "   " + label3.Text + "2р  " + textBox2.Text + "\n" +
                    label6.Text + "   " + label5.Text + "1  " + textBox3.Text + "\n" +
                    label8.Text + "   " + label7.Text + "2  " + textBox4.Text + "\n" +
                    label10.Text + "   " + label9.Text + "3  " + textBox5.Text + "\n";

                saveFileDialog1.Filter = "doc files (*.doc)|*.doc|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    doc.SaveAs2(saveFileDialog1.FileName, saveFileDialog1.FilterIndex);

                }
                else
                    return;
                saveFileDialog1.Dispose();
                MessageBox.Show("Файл успешно сохранён", "Информация");
                doc.Close();
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

                // Записываем данные в ячейки
                excelWorksheet.Cells[1, 1] = label1.Text;
                excelWorksheet.Cells[1, 2] = label2.Text+"1p";
                excelWorksheet.Cells[1, 3] = textBox1.Text;
                excelWorksheet.Cells[2, 1] = label4.Text;
                excelWorksheet.Cells[2, 2] = label3.Text+"2p";
                excelWorksheet.Cells[2, 3] = textBox2.Text;
                excelWorksheet.Cells[3, 1] = label6.Text;
                excelWorksheet.Cells[3, 2] = label5.Text+"1";
                excelWorksheet.Cells[3, 3] = textBox3.Text;
                excelWorksheet.Cells[4, 1] = label8.Text;
                excelWorksheet.Cells[4, 2] = label7.Text+"2";
                excelWorksheet.Cells[4, 3] = textBox4.Text;
                excelWorksheet.Cells[5, 1] = label10.Text;
                excelWorksheet.Cells[5, 2] = label9.Text+"3";
                excelWorksheet.Cells[5, 3] = textBox5.Text;

                excelWorksheet.Columns.AutoFit();

                saveFileDialog1.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    excelWorkbook.SaveAs(saveFileDialog1.FileName, saveFileDialog1.FilterIndex);

                }
                else
                    return;
                saveFileDialog1.Dispose();
                MessageBox.Show("Файл успешно сохранён", "Информация");
                excelWorkbook.Close();
                excelApp.Quit();
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show("Закройте файл Excel", "Информация");

            }
        }
    }
}
