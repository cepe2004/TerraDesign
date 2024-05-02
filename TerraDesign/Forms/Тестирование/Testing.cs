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
using TerraDesign.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TerraDesign
{
    public partial class Testing : Form
    {
        string[] question = {"Выберите ширину резерва по верху",                //L2p
                             "Выберите ширину резерва по низу",                 //L1p
                             "Выберите глубину резерва у внутреннего откоса",  //h1
                             "Выберите глубину резерва у внешнего откоса",     //h2
                             "Выберите крутизну внутреннего откоса",  //1:m
                             "Выберите крутизну внешнего откоса",  //1:n
                             "Выберите ширину проезжей части", //Впр.ч
        };

        int i = 0;
        bool[] questionMark = new bool[10];
        string tema;
        public Testing(string tema)
        {
            InitializeComponent();

            
            this.tema = tema;
            switch (tema)
            {
                case "LS":
                    lbQuestion.Text = question[0];
                    pictureQuest1.Image = Resources.Боковой_резерв1;
                    pictureQuest2.Image = Resources.Боковой_резерв2;
                    pictureQuest3.Image = Resources.Боковой_резерв3;
                    for (int i = 0; i < question.Length; i++)
                    {
                        lbQuestion.Text = question[i];
                    }
                  
                    break;
                           



                    //        break;
                    //    case 1: n = 1; break;
                    //    case 1.5: n = 0.61; break;
                    //    default:
                    //        MessageBox.Show("Программой не предусмотрен вариант решения для введенного вами значения коэффициента");
                    //        return;
                    //}
            }
        }

        private void btAnswer_Click(object sender, EventArgs e)
        {
            switch (tema)
            {
                
                case "LS":
                    try
                    {
                        switch (i)
                        {
                            case 0:
                                {
                                    if (rbAnswer8.Checked)
                                    {
                                        questionMark[i] = true;
                                        MessageBox.Show("Вы ответили верно", "Информация");
                                    }
                                    else
                                    {
                                        questionMark[i] = false;
                                        MessageBox.Show("Вы ответили неверно", "Информация");
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    if (rbAnswer7.Checked)
                                    {
                                        questionMark[i] = true;
                                        MessageBox.Show("Вы ответили верно", "Информация");
                                    }
                                    else
                                    {
                                        questionMark[i] = false;
                                        MessageBox.Show("Вы ответили неверно", "Информация");
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    if (rbAnswer3.Checked)
                                    {
                                        questionMark[i] = true;
                                        MessageBox.Show("Вы ответили верно", "Информация");
                                    }
                                    else
                                    {
                                        questionMark[i] = false;
                                        MessageBox.Show("Вы ответили неверно", "Информация");
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    if (rbAnswer4.Checked)
                                    {
                                        questionMark[i] = true;
                                        MessageBox.Show("Вы ответили верно", "Информация");
                                    }
                                    else
                                    {
                                        questionMark[i] = false;
                                        MessageBox.Show("Вы ответили неверно", "Информация");
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    if (rbAnswer6.Checked)
                                    {
                                        questionMark[i] = true;
                                        MessageBox.Show("Вы ответили верно", "Информация");
                                    }
                                    else
                                    {
                                        questionMark[i] = false;
                                        MessageBox.Show("Вы ответили неверно", "Информация");
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    if (rbAnswer5.Checked)
                                    {
                                        questionMark[i] = true;
                                        MessageBox.Show("Вы ответили верно", "Информация");
                                    }
                                    else
                                    {
                                        questionMark[i] = false;
                                        MessageBox.Show("Вы ответили неверно", "Информация");
                                    }
                                    break;
                                }
                            case 6:
                                {
                                    if (rbAnswer2.Checked)
                                    {
                                        questionMark[i] = true;
                                        MessageBox.Show("Вы ответили верно", "Информация");
                                    }
                                    else
                                    {
                                        questionMark[i] = false;
                                        MessageBox.Show("Вы ответили неверно", "Информация");
                                    }
                                    break;
                                }

                        }
                        i++;
                        lbQuestion.Text = question[i];

                    }
                    catch (System.IndexOutOfRangeException)
                    {
                        NpgsqlConnection conn = new NpgsqlConnection("Host = localhost;port = 5432; database = TerraDesign; user id = postgres; password=12345");
                        NpgsqlDataAdapter adp = new NpgsqlDataAdapter("INSERT INTO public.LateralReserve ("Выберите ширину резерва по верху", "Выберите ширину резерва по низу", "Выберите глубину резерва у внутре", "Выберите крутизну внутреннего отк", "Выберите крутизну внешнего откоса", "Выберите ширину проезжей части") VALUES(question::boolean, true::boolean, true::boolean, true::boolean, false::boolean, true::boolean) returning "id_LateralReserve" Пароль = '" + tbpassword.Text + "';", conn);
                        //                        INSERT INTO public."LateralReserve" (
                        //"Выберите ширину резерва по верху", "Выберите ширину резерва по низу", "Выберите глубину резерва у внутре", "Выберите крутизну внутреннего отк", "Выберите крутизну внешнего откоса", "Выберите ширину проезжей части") VALUES(
                        //true::boolean, true::boolean, true::boolean, true::boolean, false::boolean, true::boolean)
                        // returning "id_LateralReserve";
                        throw;
                    }
                    


                    break;




                    //        break;
                    //    case 1: n = 1; break;
                    //    case 1.5: n = 0.61; break;
                    //    default:
                    //        MessageBox.Show("Программой не предусмотрен вариант решения для введенного вами значения коэффициента");
                    //        return;
                    //}
            }
        }

        private void pictureQuest2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Form form = new Form();

                PictureBox pictureBox = new PictureBox();
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.Image = pictureQuest2.Image;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                form.Controls.Add(pictureBox);

                form.ShowDialog();
            }
        }

        private void pictureQuest1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Form form = new Form();

                PictureBox pictureBox = new PictureBox();
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.Image = pictureQuest1.Image;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                form.Controls.Add(pictureBox);

                form.ShowDialog();
            }
        }

        

        private void pictureQuest3_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Form form = new Form();

                PictureBox pictureBox = new PictureBox();
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.Image = pictureQuest3.Image;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                form.Controls.Add(pictureBox);

                form.ShowDialog();
            }
        }

        private void Testing_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
    }
}

