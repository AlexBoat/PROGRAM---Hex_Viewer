using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hex_Viewer_
{
    public partial class Form1 : Form
    {
        int contor_pt_endline = 0, contor_pt_index = 1;
        string rezultat16 = "", line, contor_pt_index16 = "00000001";
        int intreg_aux = 0;
        int index_aux = 0;
        string rezultat_index = "";
        string file = "date.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "00000001";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            contor_pt_endline = 0;
            contor_pt_index = 0;
            rezultat16 = "";
            contor_pt_index16 = "00000001";
            intreg_aux = 0;
            index_aux = 0;
            rezultat_index = "";
            richTextBox1.Width = 63;
            richTextBox2.Width = 337;
            richTextBox2.Left = 76;
            richTextBox3.Width = 209;
            richTextBox3.Left = 417;
            file = textBox1.Text;
            try
            {

                using (StreamReader sr = new StreamReader(file)) //Hex_viewer\Hex_viewer\bin\Debug\date.txt
                {
                    while (sr.Peek() >= 0)
                    {
                        line = sr.ReadLine();
                        richTextBox3.Text += line;
                        for (int i = 0; i < line.Length; i++)
                        {
                            rezultat_index = "";
                            contor_pt_index16 = "";
                            index_aux = 0;
                            intreg_aux = 0;
                            intreg_aux = Convert.ToInt32(line[i]);
                            if (intreg_aux <= 9)
                            {
                                rezultat16 = "0" + Convert.ToString(intreg_aux);
                            }
                            else
                            {
                                while (intreg_aux != 0)
                                {
                                    switch (intreg_aux % 16)
                                    {
                                        case 10: rezultat16 = "A" + rezultat16; break;
                                        case 11: rezultat16 = "B" + rezultat16; break;
                                        case 12: rezultat16 = "C" + rezultat16; break;
                                        case 13: rezultat16 = "D" + rezultat16; break;
                                        case 14: rezultat16 = "E" + rezultat16; break;
                                        case 15: rezultat16 = "F" + rezultat16; break;
                                        default: rezultat16 = Convert.ToString(intreg_aux % 16) + rezultat16; break;
                                    }
                                    intreg_aux /= 16;
                                }
                            }
                            richTextBox2.Text += rezultat16 + " ";
                            contor_pt_endline++;
                            if (contor_pt_endline == 16)
                            {
                                contor_pt_endline = 0;
                                contor_pt_index++;
                                if (contor_pt_index <= 9)
                                {
                                    contor_pt_index16 = "0000000" + Convert.ToString(contor_pt_index);
                                    richTextBox1.Text += contor_pt_index16;
                                }
                                else
                                {
                                    contor_pt_index16 = "";
                                    index_aux = contor_pt_index;
                                    while (index_aux != 0)
                                    {
                                        switch (index_aux % 16)
                                        {
                                            case 10: rezultat_index = "A" + rezultat_index; break;
                                            case 11: rezultat_index = "B" + rezultat_index; break;
                                            case 12: rezultat_index = "C" + rezultat_index; break;
                                            case 13: rezultat_index = "D" + rezultat_index; break;
                                            case 14: rezultat_index = "E" + rezultat_index; break;
                                            case 15: rezultat_index = "F" + rezultat_index; break;
                                            default: rezultat_index = Convert.ToString(index_aux % 16) + rezultat_index; break;
                                        }
                                        index_aux /= 16;
                                    }
                                    if(rezultat_index=="15")
                                    {
                                        richTextBox1.Width = 79;
                                        richTextBox2.Left = 92;
                                        richTextBox2.Width = 354;
                                        richTextBox3.Left = 447;
                                        richTextBox3.Width = 174;
                                    }
                                    if(rezultat_index=="16")
                                    {
                                        richTextBox1.Width = 80;
                                        richTextBox2.Left = 93;
                                        richTextBox2.Width = 355;
                                        richTextBox3.Left = 448;
                                        richTextBox3.Width = 175;
                                    }
                                    for (int j = 1; j <= 8 - rezultat_index.Length; j++)
                                    {
                                        contor_pt_index16 += "0";
                                    }
                                    contor_pt_index16 += rezultat_index;
                                    richTextBox1.Text += contor_pt_index16;
                                }
                            }
                            rezultat16 = "";
                        }
                    }
                }
            }
            catch(Exception E)
            {
                MessageBox.Show("Invalid input!");
            }
        }
    }
}
