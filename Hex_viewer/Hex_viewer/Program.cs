using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hex_viewer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int contor_pt_endline = 0, contor_pt_index=1;
            string rezultat16 = "", line, contor_pt_index16="00000000";
            int intreg_aux = 0;
            int index_aux = contor_pt_index;
            string rezultat_index = "";
            using (StreamReader sr = new StreamReader("date.txt")) //Hex_viewer\Hex_viewer\bin\Debug\date.txt
            {
                while (sr.Peek()>=0)
                {
                    Console.Write(rezultat_index + ": ");
                    rezultat_index = "";
                    contor_pt_index16 = "";
                    line = sr.ReadLine();
                    for(int i = 0; i < line.Length; i++)
                    {
                        intreg_aux = Convert.ToInt32(line[i]);
                        if(intreg_aux<=9)
                        {
                            rezultat16="0"+Convert.ToString(intreg_aux);
                        }
                        else
                        {
                            while(intreg_aux != 0)
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
                        Console.Write(rezultat16 + " ");
                        contor_pt_endline++;
                        if(contor_pt_endline==16)
                        {
                            contor_pt_endline = 0;
                            contor_pt_index++;
                            if(contor_pt_index<=9)
                            {
                                contor_pt_index16 = "0000000" + Convert.ToString(contor_pt_index);
                            }
                            else
                            {
                                index_aux=contor_pt_index;
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
                                for(int j=1; j<=8-rezultat_index.Length; j++)
                                {
                                    contor_pt_index16 += "0";
                                }
                                contor_pt_index16 += rezultat_index;
                            }
                            //Console.Write(line);
                            Console.WriteLine();
                        }
                        rezultat16 = "";
                        
                    }
                }
            }
            Console.Read();
        }
    }
}
