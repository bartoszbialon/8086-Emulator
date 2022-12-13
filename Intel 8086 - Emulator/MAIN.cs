using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Markup;

namespace Intel_8086___Emulator
{

    public class MAIN 
    {


        //Registers
        //General (Data)

        public short AX { get; set; }
        public short BX { get; set; }
        public short CX { get; set; }
        public short DX { get; set; }

        

        public void DEFAULT() //Setting register values to zero 
        {
            AX = 0;
            BX = 0;
            CX = 0;
            DX = 0;
        }

        public static void REG_VALUES(short AX, short BX, short CX, short DX) //Printing current register values
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Available registers:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("(1) AX = " + AX);
            Console.WriteLine("(2) BX = " + BX);
            Console.WriteLine("(3) CX = " + CX);
            Console.WriteLine("(4) DX = " + DX + "\n");

            Console.ResetColor();
        }

        public static void SEL_FUNC() //Printing function selection question 
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Insert number of function to choose it: ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("(1) Arithmetic");
            Console.WriteLine("(2) Data Transfer");
            Console.WriteLine("(3) Bit Manipulation");
            Console.WriteLine("(4) Control Transfer");
            Console.WriteLine("(5) Control");
            Console.WriteLine("(6) String \n");

            Console.ResetColor();
        }

        public static void SEL_INSTR(int a)
        {
            switch (a)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Select your desired arithmetic instruction: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(">>(1) ADD");
                    Console.WriteLine(">>(2) SUB");
                    Console.WriteLine(">>(3) INC");
                    Console.WriteLine(">>(4) DEC\n");
                    Console.ResetColor();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Select your desired data transfer instruction: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(">>(1) MOV");
                    Console.ResetColor();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Select your desired bit manipulation instruction: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(">>(1) Nothing implemented yet!");
                    Console.ResetColor();
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Select your desired control transfer instruction: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(">>(1) Nothing implemented yet!");
                    Console.ResetColor();
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Select your desired control instruction: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(">>(1) Nothing implemented yet!");
                    Console.ResetColor();
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Select your desired string instruction: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(">>(1) Nothing implemented yet!");
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Wrong selected number! Please choose instruction number again!");
                    Console.ResetColor();
                    break;
            }
        }
        
        public static void SLEEP()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nProcessing...");
            Thread.Sleep(1500);
            Console.WriteLine("Processing...");
            Thread.Sleep(1500);
            Console.WriteLine("Processing...");
            Thread.Sleep(1500);
            Console.ResetColor();
            Console.Clear();
        }

        public static void Main(string[] args)
        {

            MAIN m = new MAIN();
            m.DEFAULT();
            REG_VALUES(m.AX, m.BX, m.CX, m.DX);
            SEL_FUNC();

            int selected_function, selected_instruction, first_to_operate_with = 0, second_to_operate_with = 0;
            short ADD_num = 0;

            do {
                selected_function = Convert.ToInt32(Console.ReadLine());
            } while (selected_function < 1 || selected_function > 6);

            Console.Clear();

            SEL_INSTR(selected_function);


            selected_instruction = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            if (selected_function == 1)
            {
                if (selected_instruction == 1)
                {

                    do
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Select first register on which You want to operate: ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("(1) AX");
                        Console.WriteLine("(2) BX");
                        Console.WriteLine("(3) CX");
                        Console.WriteLine("(4) DX");
                        Console.WriteLine("(5) number\n");
                        Console.ResetColor();

                        first_to_operate_with = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\n");

                        if (first_to_operate_with < 1 || first_to_operate_with >= 5)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                            Console.ResetColor();
                        }


                    } while (first_to_operate_with < 1 || first_to_operate_with >= 5);

                    if (first_to_operate_with == 1)
                    {
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Select second register on which You want to operate: ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("(2) BX");
                            Console.WriteLine("(3) CX");
                            Console.WriteLine("(4) DX");
                            Console.WriteLine("(5) number\n");
                            Console.ResetColor();

                            second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\n");

                            if (second_to_operate_with < 2 || second_to_operate_with > 5)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                                Console.ResetColor();
                            }

                            if (second_to_operate_with == 5)
                            {
                                do
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Insert number which You want to add to the chosen register:\n ");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    ADD_num = Convert.ToInt16(Console.ReadLine());
                                    Console.ResetColor();

                                } while (ADD_num == 0);
                            }


                        } while (second_to_operate_with < 2 || second_to_operate_with > 5);
                    }

                    else if (first_to_operate_with == 2)
                    {
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Select second register on which You want to operate: ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("(1) AX");
                            Console.WriteLine("(3) CX");
                            Console.WriteLine("(4) DX");
                            Console.WriteLine("(5) number\n");
                            Console.ResetColor();

                            second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\n");

                            if (second_to_operate_with < 1 || second_to_operate_with == 2 || second_to_operate_with > 5)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                                Console.ResetColor();
                            }

                            if (second_to_operate_with == 5)
                            {
                                do
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Insert number which You want to add to the chosen register:\n ");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    ADD_num = Convert.ToInt16(Console.ReadLine());
                                    Console.Clear();
                                    Console.ResetColor();

                                } while (ADD_num == 0);
                            }

                        } while (second_to_operate_with < 1 || second_to_operate_with == 2 || second_to_operate_with > 5);
                    }

                    else if (first_to_operate_with == 3)
                    {
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Select second register on which You want to operate: ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("(1) AX");
                            Console.WriteLine("(2) BX");
                            Console.WriteLine("(4) DX");
                            Console.WriteLine("(5) number\n");
                            Console.ResetColor();

                            second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\n");

                            if (second_to_operate_with < 1 || second_to_operate_with == 3 || second_to_operate_with > 5)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                                Console.ResetColor();
                            }

                            if (second_to_operate_with == 5)
                            {
                                do
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Insert number which You want to add to the chosen register:\n ");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    ADD_num = Convert.ToInt16(Console.ReadLine());
                                    Console.Clear();
                                    Console.ResetColor();

                                } while (ADD_num == 0);
                            }

                        } while (second_to_operate_with < 1 || second_to_operate_with == 3 || second_to_operate_with > 5);

                    }

                    else if (first_to_operate_with == 4)
                    {
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Select second register on which You want to operate: ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("(1) AX");
                            Console.WriteLine("(2) BX");
                            Console.WriteLine("(3) CX");
                            Console.WriteLine("(5) number\n");
                            Console.ResetColor();

                            second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\n");

                            if (second_to_operate_with < 1 || second_to_operate_with == 4 || second_to_operate_with > 5)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                                Console.ResetColor();
                            }

                            if (second_to_operate_with == 5)
                            {
                                do
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Insert number which You want to add to the chosen register:\n ");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    ADD_num = Convert.ToInt16(Console.ReadLine());
                                    Console.Clear();
                                    Console.ResetColor();

                                } while (ADD_num == 0);
                            }

                        } while (second_to_operate_with < 1 || second_to_operate_with == 4 || second_to_operate_with > 5);
                    }
                }

                //else if (selected_instruction == 2)
                //{



                //}

                else if (selected_instruction == 3)
                {

                }
            }

            switch (selected_function)
            {
                case 1:
                    switch(selected_instruction)
                    {
                        case 1:
                            if (ADD_num != 0)
                            {
                                SLEEP();
                                ADD.ADD_REGS(m, first_to_operate_with, ADD_num);
                            }

                            else
                            {
                                ADD.ADD_REGS(m, first_to_operate_with, second_to_operate_with);
                            }
                            break;
                        //case 2:

                        //    break;
                        case 3:

                    }
                    break;
                //case 2:
                //    switch (selected_instruction)
                //    {
                //        case 1:

                //            break;
                //    }
                //    break;
                //case 3:
                //    switch (selected_instruction)
                //    {
                //        case 1:

                //            break;
                //    }
                //    break;
                //case 4:
                //    switch (selected_instruction)
                //    {
                //        case 1:

                //            break;
                //    }
                //    break;
                //case 5:
                //    switch (selected_instruction)
                //    {
                //        case 1:

                //            break;
                //    }
                //    break;
                //case 6:
                //    switch (selected_instruction)
                //    {
                //        case 1:

                //            break;
                //    }
                //    break;
            }


            

             
                
            REG_VALUES(m.AX, m.BX, m.CX, m.DX);

            




            Console.ReadKey();



        }
    }
}
