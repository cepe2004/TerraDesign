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
                labelSredina.Visible = false;
                labelH.Visible = false;
                labelH3.Visible = false;
                textBoxH3.Visible = false;
            }
            
            GlobalVars.L1p=Math.Round(GlobalVars.L1p, 2);
            GlobalVars.L2p = Math.Round(GlobalVars.L2p, 2);
            GlobalVars.h1 = Math.Round(GlobalVars.h1, 2);
            GlobalVars.h2 = Math.Round(GlobalVars.h2, 2);
            GlobalVars.h3 = Math.Round(GlobalVars.h3, 2);
            textBoxL1p.Text =Convert.ToString(GlobalVars.L1p);
            textBoxL2p.Text = Convert.ToString(GlobalVars.L2p);
            textBoxH1.Text = Convert.ToString(GlobalVars.h1);
            textBoxH2.Text = Convert.ToString(GlobalVars.h2);
            textBoxH3.Text = Convert.ToString(GlobalVars.h3);
        }

        private void buttonEnter_Click(object sender, EventArgs e)
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
                rng.Text = labelWidthDown.Text + "   " + labelL1p.Text + "1р  " + textBoxL1p.Text + "\n" +
                    labelWidthUp.Text + "   " + labelL2p.Text + "2р  " + textBoxL2p.Text + "\n" +
                    labelDepthInside.Text + "   " + labelH1.Text + "1  " + textBoxH1.Text + "\n" +
                    labelDepthOutside.Text + "   " + labelH2.Text + "2  " + textBoxH2.Text + "\n" +
                    labelSredina.Text + "   " + labelH.Text + "3  " + textBoxH3.Text + "\n";

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

                // Записываем данные в ячейки
                excelWorksheet.Cells[1, 1] = labelWidthDown.Text;
                excelWorksheet.Cells[1, 2] = labelL1p.Text+"1p";
                excelWorksheet.Cells[1, 3] = textBoxL1p.Text;
                excelWorksheet.Cells[2, 1] = labelWidthUp.Text;
                excelWorksheet.Cells[2, 2] = labelL2p.Text+"2p";
                excelWorksheet.Cells[2, 3] = textBoxL2p.Text;
                excelWorksheet.Cells[3, 1] = labelDepthInside.Text;
                excelWorksheet.Cells[3, 2] = labelH1.Text+"1";
                excelWorksheet.Cells[3, 3] = textBoxH1.Text;
                excelWorksheet.Cells[4, 1] = labelDepthOutside.Text;
                excelWorksheet.Cells[4, 2] = labelH2.Text+"2";
                excelWorksheet.Cells[4, 3] = textBoxH2.Text;
                excelWorksheet.Cells[5, 1] = labelSredina.Text;
                excelWorksheet.Cells[5, 2] = labelH.Text+"3";
                excelWorksheet.Cells[5, 3] = textBoxH3.Text;
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
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show("Закройте файл Excel", "Информация");

            }
        }
    }
}
