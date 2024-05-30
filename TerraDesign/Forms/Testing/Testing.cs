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
using TerraDesign.Тестирование;
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
                        GlobalVars.IdUser = 1;
                        NpgsqlConnection conn = new NpgsqlConnection("Host = localhost;port = 5432; database = TerraDesign; user id = postgres; password=12345");
                        NpgsqlDataAdapter adp = new NpgsqlDataAdapter("INSERT INTO public.\"LateralReserve\" (\"user\", \"L2\", \"L1\", h1, h2, \"1m\", \"1n\", bprc,\"dateTime\") VALUES('" + GlobalVars.IdUser +"'::bigint, '" + questionMark[0] + "'::boolean, '" + questionMark[1] + "'::boolean, '" + questionMark[2] + "'::boolean, '" + questionMark[3] +"'::boolean, '" + questionMark[4] +"'::boolean, '" + questionMark[5] + "'::boolean, '" + questionMark[6] +"'::boolean,'"+DateTime.Now+"'::timestamp without time zone) returning \"id_LateralReserve\" ", conn);
                        DataTable dt1 = new DataTable();
                        adp.Fill(dt1);
                        MessageBox.Show("Ответы получены");
                        Tema tema = new Tema();
                        tema.Show();
                        this.Hide();
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

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tema tema = new Tema();
            tema.Show();
            this.Hide();
        }
    }
}

