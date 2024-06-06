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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace TerraDesign.Forms.Waterfacil
{
    public partial class WFtotal : Form
    {
        public WFtotal()
        {
            InitializeComponent();
            GlobalVars.bk = Math.Round(GlobalVars.bk, 2);
            GlobalVars.hk = Math.Round(GlobalVars.hk, 2);
            GlobalVars.bk = Math.Round(GlobalVars.bk, 2);
            GlobalVars.hk = Math.Round(GlobalVars.hk, 2);
           
            textBoxB.Text = Convert.ToString(GlobalVars.bk);
            textBoxHk.Text = Convert.ToString(GlobalVars.hk);
           
        }
        
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            foreach (Form wFcheck in System.Windows.Forms.Application.OpenForms) wFcheck.Hide();
            Tema tema = new Tema();
            tema.Show();
           
            
        }

        private void WFtotal_FormClosed(object sender, FormClosedEventArgs e)
        {
        
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Создание объекта приложения Word
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                // Создание нового документа
                Document doc = wordApp.Documents.Add();
                // Добавление текста в документ
                Paragraph para = doc.Paragraphs.Add();
                Microsoft.Office.Interop.Word.Range rng = para.Range;
                rng.Text = labelWidth.Text+"   "+labelB.Text+"  "+textBoxB.Text+"\n"+
                    labelDepth.Text + "   " + labelH.Text + "  " + textBoxHk.Text + "\n";

                saveFileDialog1.Filter = "doc files (*.doc)|*.doc|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                  
                    doc.SaveAs2(saveFileDialog1.FileName,saveFileDialog1.FilterIndex);
                    
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
                Microsoft.Office.Interop.Excel.Application excelApp= new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();
                Microsoft.Office.Interop.Excel.Worksheet excelWorksheet = excelWorkbook.Sheets[1];

                // Записываем данные в ячейки
                excelWorksheet.Cells[1, 1] = labelWidth.Text;
                excelWorksheet.Cells[1, 2] = labelB.Text;
                excelWorksheet.Cells[1, 3] = textBoxB.Text;
                excelWorksheet.Cells[2, 1] = labelDepth.Text;
                excelWorksheet.Cells[2, 2] = labelH.Text;
                excelWorksheet.Cells[2, 3] = textBoxHk.Text;
                excelWorksheet.Columns.AutoFit();

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

                ;

               

            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show("Закройте файл Excel", "Информация");

            }
          
        }
    }
}
