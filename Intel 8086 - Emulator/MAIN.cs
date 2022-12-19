//© Bartosz Białoń, 20-12-2022

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
using System.Linq.Expressions;

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


        //Flags

        public bool CF { get; set; } //Carry Flag
        public bool DF { get; set; } //Direction Flag
        public bool IF { get; set; } //Interrupt Flag

        public void DEFAULT() //Setting register values to zero 
        {
            AX = 0;
            BX = 0;
            CX = 0;
            DX = 0;
            CF = false;
            DF = false;
            IF = false;
        }

        public static void REG_VALUES(MAIN a) //Printing current register values
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Available registers:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("(1) AX = " + a.AX);
            Console.WriteLine("(2) BX = " + a.BX);
            Console.WriteLine("(3) CX = " + a.CX);
            Console.WriteLine("(4) DX = " + a.DX + "\n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Available flags: ");
            Console.ForegroundColor = ConsoleColor.Green;
            
            if (a.CF)
            {
                Console.WriteLine("(1) CF = " + 1);
            }

            else
            {
                Console.WriteLine("(1) CF = " + 0);
            }

            if (a.DF)
            {
                Console.WriteLine("(2) DF = " + 1);
            }

            else
            {
                Console.WriteLine("(2) DF = " + 0);
            }

            if (a.IF)
            {
                Console.WriteLine("(3) IF = " + 1 + "\n");
            }

            else
            {
                Console.WriteLine("(3) IF = " + 0 + "\n");
            }

            Console.ResetColor();
        }

        public static void SEL_FUNC() //Printing function selection question 
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Insert number of function to choose it: ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("(1) Arithmetic");
            Console.WriteLine("(2) Data Transfer");
            Console.WriteLine("(3) Control\n");

            Console.ResetColor();
        }

        public static void SEL_INSTR(int a) //Printing instruction selection question of given function
        {
            switch (a)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Select your desired arithmetic instruction: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(">>(1) ADD");
                    Console.WriteLine(">>(2) ADC");
                    Console.WriteLine(">>(3) SUB");
                    Console.WriteLine(">>(4) INC");
                    Console.WriteLine(">>(5) DEC\n");
                    Console.ResetColor();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Select your desired data transfer instruction: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(">>(1) MOV");
                    Console.WriteLine(">>(2) XCHG\n");
                    Console.ResetColor();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Select your desired bit manipulation instruction: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(">>(1) STC");
                    Console.WriteLine(">>(2) CLC");
                    Console.WriteLine(">>(3) CMC");
                    Console.WriteLine(">>(4) STD");
                    Console.WriteLine(">>(5) CLD");
                    Console.WriteLine(">>(6) STI");
                    Console.WriteLine(">>(7) CLI");
                    Console.WriteLine(">>(8) HLT\n");
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Wrong selected number! Please choose instruction number again!");
                    Console.ResetColor();
                    break;
            }
        }
        
        public static void SLEEP() //Simulating the process of data processing
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

        public static void SLEEP_CONTROL() //Variation of SLEEP function
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Executing...\n");
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Processing...");
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
            bool exit = false;


            MAIN m = new MAIN();
            m.DEFAULT();

            do
            {

                REG_VALUES(m);
                SEL_FUNC();

                int selected_function = 0, selected_instruction = 0, first_to_operate_with = 0, second_to_operate_with = 0;

                short ADD_num = 0;

                do
                {

                    bool exception = false;

                    try
                    {
                        selected_function = Convert.ToInt32(Console.ReadLine());
                    }

                    catch (FormatException)
                    {
                        exception = true;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input format");
                        Console.ResetColor();
                        SEL_FUNC();
                    }

                    catch (OverflowException)
                    {
                        exception = true;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid value - Overflow");
                        Console.ResetColor();
                        SEL_FUNC();
                    }

                    if (exception == false && (selected_function < 1 || selected_function > 3))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                        Console.ResetColor();
                        SEL_FUNC();
                    }

                } while (selected_function < 1 || selected_function > 3);


                switch (selected_function)
                {
                    case 1:
                        Console.Clear();
                        SEL_INSTR(selected_function);
                        break;
                    case 2:
                        Console.Clear();
                        SEL_INSTR(selected_function);
                        break;
                    case 3:
                        Console.Clear();
                        SEL_INSTR(selected_function);
                        break;
                }


                if (selected_function == 1) //Arithmetic handling
                {
                    do
                    {
                        bool exception = false;

                        try
                        {
                            selected_instruction = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                        }

                        catch (FormatException)
                        {
                            exception = true;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input format");
                            Console.ResetColor();
                            SEL_INSTR(selected_function);
                        }

                        catch (OverflowException)
                        {
                            exception = true;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid value - Overflow");
                            Console.ResetColor();
                            SEL_INSTR(selected_function);
                        }


                        if (exception == false && (selected_instruction < 1 || selected_instruction > 5))
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                            Console.ResetColor();
                            SEL_INSTR(selected_function);
                        }

                    } while (selected_instruction < 1 || selected_instruction > 5);

                    if (selected_instruction == 1) //ADD handling
                    {
                        do
                        {
                            bool exception = false;

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Select first register on which you want to operate: ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("(1) AX");
                            Console.WriteLine("(2) BX");
                            Console.WriteLine("(3) CX");
                            Console.WriteLine("(4) DX\n");
                            Console.ResetColor();

                            try
                            {
                                first_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                Console.Write("\n");
                            }

                            catch (FormatException)
                            {
                                exception = true;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid input format");
                                Console.ResetColor();
                            }

                            catch (OverflowException)
                            {
                                exception = true;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid value - Overflow");
                                Console.ResetColor();
                            }

                            if (exception == false && (first_to_operate_with < 1 || first_to_operate_with > 4))
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                                Console.ResetColor();
                            }

                        } while (first_to_operate_with < 1 || first_to_operate_with > 4);

                        switch (first_to_operate_with)
                        {
                            case 1: //First register - AX
                                do
                                {
                                    bool exception = false;

                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Select second register or value with which you want to operate: ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("(2) BX");
                                    Console.WriteLine("(3) CX");
                                    Console.WriteLine("(4) DX");
                                    Console.WriteLine("(5) number\n");
                                    Console.ResetColor();

                                    try
                                    {
                                        second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n");
                                    }

                                    catch (FormatException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input format");
                                        Console.ResetColor();
                                    }

                                    catch (OverflowException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid value - Overflow");
                                        Console.ResetColor();
                                    }

                                    if (exception == false && (second_to_operate_with < 2 || second_to_operate_with > 5))
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
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Insert number which You want to add to the chosen register:\n ");
                                            Console.ForegroundColor = ConsoleColor.Green;

                                            try
                                            {
                                                ADD_num = Convert.ToInt16(Console.ReadLine());
                                                Console.ResetColor();
                                            }

                                            catch (FormatException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid input format");
                                                Console.ResetColor();
                                            }

                                            catch (OverflowException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid value - Overflow");
                                                Console.ResetColor();
                                            }

                                        } while (ADD_num == 0);
                                    }

                                } while (second_to_operate_with < 2 || second_to_operate_with > 5);
                                break;

                            case 2: //First register - BX
                                do
                                {
                                    bool exception = false;

                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Select second register or value with which you want to operate: ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("(1) AX");
                                    Console.WriteLine("(3) CX");
                                    Console.WriteLine("(4) DX");
                                    Console.WriteLine("(5) number\n");
                                    Console.ResetColor();

                                    try
                                    {
                                        second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n");
                                    }

                                    catch (FormatException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input format");
                                        Console.ResetColor();
                                    }

                                    catch (OverflowException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid value - Overflow");
                                        Console.ResetColor();
                                    }

                                    if (exception == false && (second_to_operate_with < 1 || second_to_operate_with == 2 || second_to_operate_with > 5))
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
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Insert number which You want to add to the chosen register:\n ");
                                            Console.ForegroundColor = ConsoleColor.Green;

                                            try
                                            {
                                                ADD_num = Convert.ToInt16(Console.ReadLine());
                                                Console.ResetColor();
                                            }

                                            catch (FormatException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid input format");
                                                Console.ResetColor();
                                            }

                                            catch (OverflowException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid value - Overflow");
                                                Console.ResetColor();
                                            }

                                        } while (ADD_num == 0);
                                    }

                                } while (second_to_operate_with < 1 || second_to_operate_with == 2 || second_to_operate_with > 5);
                                break;

                            case 3: //First register - CX
                                do
                                {
                                    bool exception = false;

                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Select second register or value with which you want to operate: ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("(1) AX");
                                    Console.WriteLine("(2) BX");
                                    Console.WriteLine("(4) DX");
                                    Console.WriteLine("(5) number\n");
                                    Console.ResetColor();

                                    try
                                    {
                                        second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n");
                                    }

                                    catch (FormatException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input format");
                                        Console.ResetColor();
                                    }

                                    catch (OverflowException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid value - Overflow");
                                        Console.ResetColor();
                                    }

                                    if (exception == false && (second_to_operate_with < 1 || second_to_operate_with == 3 || second_to_operate_with > 5))
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
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Insert number which You want to add to the chosen register:\n ");
                                            Console.ForegroundColor = ConsoleColor.Green;

                                            try
                                            {
                                                ADD_num = Convert.ToInt16(Console.ReadLine());
                                                Console.ResetColor();
                                            }

                                            catch (FormatException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid input format");
                                                Console.ResetColor();
                                            }

                                            catch (OverflowException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid value - Overflow");
                                                Console.ResetColor();
                                            }

                                        } while (ADD_num == 0);
                                    }

                                } while (second_to_operate_with < 1 || second_to_operate_with == 3 || second_to_operate_with > 5);
                                break;

                            case 4: //First register - DX
                                do
                                {
                                    bool exception = false;

                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Select second register or value with which you want to operate: ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("(1) AX");
                                    Console.WriteLine("(2) BX");
                                    Console.WriteLine("(3) CX");
                                    Console.WriteLine("(5) number\n");
                                    Console.ResetColor();

                                    try
                                    {
                                        second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n");
                                    }

                                    catch (FormatException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input format");
                                        Console.ResetColor();
                                    }

                                    catch (OverflowException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid value - Overflow");
                                        Console.ResetColor();
                                    }

                                    if (exception == false && (second_to_operate_with < 1 || second_to_operate_with == 4 || second_to_operate_with > 5))
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
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Insert number which You want to add to the chosen register:\n ");
                                            Console.ForegroundColor = ConsoleColor.Green;

                                            try
                                            {
                                                ADD_num = Convert.ToInt16(Console.ReadLine());
                                                Console.ResetColor();
                                            }

                                            catch (FormatException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid input format");
                                                Console.ResetColor();
                                            }

                                            catch (OverflowException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid value - Overflow");
                                                Console.ResetColor();
                                            }

                                        } while (ADD_num == 0);
                                    }

                                } while (second_to_operate_with < 1 || second_to_operate_with == 4 || second_to_operate_with > 5);
                                break;
                        }
                    }

                    else if (selected_instruction == 2) //ADC handling
                    {
                        do
                        {
                            bool exception = false;

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Select first register on which you want to operate: ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("(1) AX");
                            Console.WriteLine("(2) BX");
                            Console.WriteLine("(3) CX");
                            Console.WriteLine("(4) DX\n");
                            Console.ResetColor();

                            try
                            {
                                first_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                Console.Write("\n");
                            }

                            catch (FormatException)
                            {
                                exception = true;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid input format");
                                Console.ResetColor();
                            }

                            catch (OverflowException)
                            {
                                exception = true;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid value - Overflow");
                                Console.ResetColor();
                            }

                            if (exception == false && (first_to_operate_with < 1 || first_to_operate_with > 4))
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                                Console.ResetColor();
                            }

                        } while (first_to_operate_with < 1 || first_to_operate_with > 4);

                        switch (first_to_operate_with)
                        {
                            case 1: //First register - AX
                                do
                                {
                                    bool exception = false;

                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Select second register or value with which you want to operate: ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("(2) BX");
                                    Console.WriteLine("(3) CX");
                                    Console.WriteLine("(4) DX");
                                    Console.WriteLine("(5) number\n");
                                    Console.ResetColor();

                                    try
                                    {
                                        second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n");
                                    }

                                    catch (FormatException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input format");
                                        Console.ResetColor();
                                    }

                                    catch (OverflowException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid value - Overflow");
                                        Console.ResetColor();
                                    }

                                    if (exception == false && (second_to_operate_with < 2 || second_to_operate_with > 5))
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
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Insert number which You want to add to the chosen register:\n ");
                                            Console.ForegroundColor = ConsoleColor.Green;

                                            try
                                            {
                                                ADD_num = Convert.ToInt16(Console.ReadLine());
                                                Console.ResetColor();
                                            }

                                            catch (FormatException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid input format");
                                                Console.ResetColor();
                                            }

                                            catch (OverflowException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid value - Overflow");
                                                Console.ResetColor();
                                            }

                                        } while (ADD_num == 0);
                                    }

                                } while (second_to_operate_with < 2 || second_to_operate_with > 5);
                                break;

                            case 2: //First register - BX
                                do
                                {
                                    bool exception = false;

                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Select second register or value with which you want to operate: ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("(1) AX");
                                    Console.WriteLine("(3) CX");
                                    Console.WriteLine("(4) DX");
                                    Console.WriteLine("(5) number\n");
                                    Console.ResetColor();

                                    try
                                    {
                                        second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n");
                                    }

                                    catch (FormatException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input format");
                                        Console.ResetColor();
                                    }

                                    catch (OverflowException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid value - Overflow");
                                        Console.ResetColor();
                                    }

                                    if (exception == false && (second_to_operate_with < 1 || second_to_operate_with == 2 || second_to_operate_with > 5))
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
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Insert number which You want to add to the chosen register:\n ");
                                            Console.ForegroundColor = ConsoleColor.Green;

                                            try
                                            {
                                                ADD_num = Convert.ToInt16(Console.ReadLine());
                                                Console.ResetColor();
                                            }

                                            catch (FormatException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid input format");
                                                Console.ResetColor();
                                            }

                                            catch (OverflowException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid value - Overflow");
                                                Console.ResetColor();
                                            }

                                        } while (ADD_num == 0);
                                    }

                                } while (second_to_operate_with < 1 || second_to_operate_with == 2 || second_to_operate_with > 5);
                                break;

                            case 3: //First register - CX
                                do
                                {
                                    bool exception = false;

                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Select second register or value with which you want to operate: ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("(1) AX");
                                    Console.WriteLine("(2) BX");
                                    Console.WriteLine("(4) DX");
                                    Console.WriteLine("(5) number\n");
                                    Console.ResetColor();

                                    try
                                    {
                                        second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n");
                                    }

                                    catch (FormatException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input format");
                                        Console.ResetColor();
                                    }

                                    catch (OverflowException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid value - Overflow");
                                        Console.ResetColor();
                                    }

                                    if (exception == false && (second_to_operate_with < 1 || second_to_operate_with == 3 || second_to_operate_with > 5))
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
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Insert number which You want to add to the chosen register:\n ");
                                            Console.ForegroundColor = ConsoleColor.Green;

                                            try
                                            {
                                                ADD_num = Convert.ToInt16(Console.ReadLine());
                                                Console.ResetColor();
                                            }

                                            catch (FormatException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid input format");
                                                Console.ResetColor();
                                            }

                                            catch (OverflowException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid value - Overflow");
                                                Console.ResetColor();
                                            }

                                        } while (ADD_num == 0);
                                    }

                                } while (second_to_operate_with < 1 || second_to_operate_with == 3 || second_to_operate_with > 5);
                                break;

                            case 4: //First register - DX
                                do
                                {
                                    bool exception = false;

                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Select second register or value with which you want to operate: ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("(1) AX");
                                    Console.WriteLine("(2) BX");
                                    Console.WriteLine("(3) CX");
                                    Console.WriteLine("(5) number\n");
                                    Console.ResetColor();

                                    try
                                    {
                                        second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n");
                                    }

                                    catch (FormatException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input format");
                                        Console.ResetColor();
                                    }

                                    catch (OverflowException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid value - Overflow");
                                        Console.ResetColor();
                                    }

                                    if (exception == false && (second_to_operate_with < 1 || second_to_operate_with == 4 || second_to_operate_with > 5))
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
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Insert number which You want to add to the chosen register:\n ");
                                            Console.ForegroundColor = ConsoleColor.Green;

                                            try
                                            {
                                                ADD_num = Convert.ToInt16(Console.ReadLine());
                                                Console.ResetColor();
                                            }

                                            catch (FormatException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid input format");
                                                Console.ResetColor();
                                            }

                                            catch (OverflowException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid value - Overflow");
                                                Console.ResetColor();
                                            }

                                        } while (ADD_num == 0);
                                    }

                                } while (second_to_operate_with < 1 || second_to_operate_with == 4 || second_to_operate_with > 5);
                                break;
                        }
                    }

                    else if (selected_instruction == 3) //SUB handling
                    {
                        do
                        {
                            bool exception = false;

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Select first register on which you want to operate: ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("(1) AX");
                            Console.WriteLine("(2) BX");
                            Console.WriteLine("(3) CX");
                            Console.WriteLine("(4) DX\n");
                            Console.ResetColor();

                            try
                            {
                                first_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                Console.Write("\n");
                            }

                            catch (FormatException)
                            {
                                exception = true;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid input format");
                                Console.ResetColor();
                            }

                            catch (OverflowException)
                            {
                                exception = true;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid value - Overflow");
                                Console.ResetColor();
                            }

                            if (exception == false && (first_to_operate_with < 1 || first_to_operate_with > 4))
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                                Console.ResetColor();
                            }

                        } while (first_to_operate_with < 1 || first_to_operate_with > 4);

                        switch (first_to_operate_with)
                        {
                            case 1: //First register - AX
                                do
                                {
                                    bool exception = false;

                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Select second register or value with which you want to operate: ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("(2) BX");
                                    Console.WriteLine("(3) CX");
                                    Console.WriteLine("(4) DX");
                                    Console.WriteLine("(5) number\n");
                                    Console.ResetColor();

                                    try
                                    {
                                        second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n");
                                    }

                                    catch (FormatException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input format");
                                        Console.ResetColor();
                                    }

                                    catch (OverflowException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid value - Overflow");
                                        Console.ResetColor();
                                    }

                                    if (exception == false && (second_to_operate_with < 2 || second_to_operate_with > 5))
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
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Insert number which You want to add to the chosen register:\n ");
                                            Console.ForegroundColor = ConsoleColor.Green;

                                            try
                                            {
                                                ADD_num = Convert.ToInt16(Console.ReadLine());
                                                Console.ResetColor();
                                            }

                                            catch (FormatException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid input format");
                                                Console.ResetColor();
                                            }

                                            catch (OverflowException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid value - Overflow");
                                                Console.ResetColor();
                                            }

                                        } while (ADD_num == 0);
                                    }

                                } while (second_to_operate_with < 2 || second_to_operate_with > 5);
                                break;

                            case 2: //First register - BX
                                do
                                {
                                    bool exception = false;

                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Select second register or value with which you want to operate: ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("(1) AX");
                                    Console.WriteLine("(3) CX");
                                    Console.WriteLine("(4) DX");
                                    Console.WriteLine("(5) number\n");
                                    Console.ResetColor();

                                    try
                                    {
                                        second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n");
                                    }

                                    catch (FormatException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input format");
                                        Console.ResetColor();
                                    }

                                    catch (OverflowException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid value - Overflow");
                                        Console.ResetColor();
                                    }

                                    if (exception == false && (second_to_operate_with < 1 || second_to_operate_with == 2 || second_to_operate_with > 5))
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
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Insert number which You want to add to the chosen register:\n ");
                                            Console.ForegroundColor = ConsoleColor.Green;

                                            try
                                            {
                                                ADD_num = Convert.ToInt16(Console.ReadLine());
                                                Console.ResetColor();
                                            }

                                            catch (FormatException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid input format");
                                                Console.ResetColor();
                                            }

                                            catch (OverflowException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid value - Overflow");
                                                Console.ResetColor();
                                            }

                                        } while (ADD_num == 0);
                                    }

                                } while (second_to_operate_with < 1 || second_to_operate_with == 2 || second_to_operate_with > 5);
                                break;

                            case 3: //First register - CX
                                do
                                {
                                    bool exception = false;

                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Select second register or value with which you want to operate: ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("(1) AX");
                                    Console.WriteLine("(2) BX");
                                    Console.WriteLine("(4) DX");
                                    Console.WriteLine("(5) number\n");
                                    Console.ResetColor();

                                    try
                                    {
                                        second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n");
                                    }

                                    catch (FormatException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input format");
                                        Console.ResetColor();
                                    }

                                    catch (OverflowException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid value - Overflow");
                                        Console.ResetColor();
                                    }

                                    if (exception == false && (second_to_operate_with < 1 || second_to_operate_with == 3 || second_to_operate_with > 5))
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
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Insert number which You want to add to the chosen register:\n ");
                                            Console.ForegroundColor = ConsoleColor.Green;

                                            try
                                            {
                                                ADD_num = Convert.ToInt16(Console.ReadLine());
                                                Console.ResetColor();
                                            }

                                            catch (FormatException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid input format");
                                                Console.ResetColor();
                                            }

                                            catch (OverflowException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid value - Overflow");
                                                Console.ResetColor();
                                            }

                                        } while (ADD_num == 0);
                                    }

                                } while (second_to_operate_with < 1 || second_to_operate_with == 3 || second_to_operate_with > 5);
                                break;

                            case 4: //First register - DX
                                do
                                {
                                    bool exception = false;

                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Select second register or value with which you want to operate: ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("(1) AX");
                                    Console.WriteLine("(2) BX");
                                    Console.WriteLine("(3) CX");
                                    Console.WriteLine("(5) number\n");
                                    Console.ResetColor();

                                    try
                                    {
                                        second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n");
                                    }

                                    catch (FormatException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input format");
                                        Console.ResetColor();
                                    }

                                    catch (OverflowException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid value - Overflow");
                                        Console.ResetColor();
                                    }

                                    if (exception == false && (second_to_operate_with < 1 || second_to_operate_with == 4 || second_to_operate_with > 5))
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
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Insert number which You want to add to the chosen register:\n ");
                                            Console.ForegroundColor = ConsoleColor.Green;

                                            try
                                            {
                                                ADD_num = Convert.ToInt16(Console.ReadLine());
                                                Console.ResetColor();
                                            }

                                            catch (FormatException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid input format");
                                                Console.ResetColor();
                                            }

                                            catch (OverflowException)
                                            {
                                                exception = true;
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Invalid value - Overflow");
                                                Console.ResetColor();
                                            }

                                        } while (ADD_num == 0);
                                    }

                                } while (second_to_operate_with < 1 || second_to_operate_with == 4 || second_to_operate_with > 5);
                                break;
                        }
                    }

                    else if (selected_instruction == 4) //INC handling
                    {
                        do
                        {
                            bool exception = false;

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Select register on which you want to operate: ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("(1) AX");
                            Console.WriteLine("(2) BX");
                            Console.WriteLine("(3) CX");
                            Console.WriteLine("(4) DX\n");
                            Console.ResetColor();

                            try
                            {
                                first_to_operate_with = Convert.ToInt32(Console.ReadLine());
                            }

                            catch (FormatException)
                            {
                                exception = true;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid input format");
                                Console.ResetColor();
                            }

                            catch (OverflowException)
                            {
                                exception = true;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid value - Overflow");
                                Console.ResetColor();
                            }

                            if (exception == false && (first_to_operate_with < 1 || first_to_operate_with > 4))
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                                Console.ResetColor();
                            }

                        } while (first_to_operate_with < 1 || first_to_operate_with > 4);
                    }

                    else if (selected_instruction == 5) //DEC handling
                    {
                        do
                        {
                            bool exception = false;

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Select register on which you want to operate: ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("(1) AX");
                            Console.WriteLine("(2) BX");
                            Console.WriteLine("(3) CX");
                            Console.WriteLine("(4) DX\n");
                            Console.ResetColor();

                            try
                            {
                                first_to_operate_with = Convert.ToInt32(Console.ReadLine());
                            }

                            catch (FormatException)
                            {
                                exception = true;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid input format");
                                Console.ResetColor();
                            }

                            catch (OverflowException)
                            {
                                exception = true;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid value - Overflow");
                                Console.ResetColor();
                            }

                            if (exception == false && (first_to_operate_with < 1 || first_to_operate_with > 4))
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                                Console.ResetColor();
                            }

                        } while (first_to_operate_with < 1 || first_to_operate_with > 4);
                    }
                }

                else if (selected_function == 2) //Data Transfer handling
                {
                    do
                    {
                        bool exception = false;

                        try
                        {
                            selected_instruction = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                        }

                        catch (FormatException)
                        {
                            exception = true;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input format");
                            Console.ResetColor();
                            SEL_INSTR(selected_function);
                        }

                        catch (OverflowException)
                        {
                            exception = true;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid value - Overflow");
                            Console.ResetColor();
                            SEL_INSTR(selected_function);
                        }


                        if (exception == false && (selected_instruction < 1 || selected_instruction > 2))
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                            Console.ResetColor();
                            SEL_INSTR(selected_function);
                        }

                    } while (selected_instruction < 1 || selected_instruction > 2);

                    if (selected_instruction == 1) //MOV handling
                    {
                        do
                        {
                            bool exception = false;

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Select first register on which you want to operate: ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("(1) AX");
                            Console.WriteLine("(2) BX");
                            Console.WriteLine("(3) CX");
                            Console.WriteLine("(4) DX\n");
                            Console.ResetColor();

                            try
                            {
                                first_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                Console.Write("\n");
                            }

                            catch (FormatException)
                            {
                                exception = true;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid input format");
                                Console.ResetColor();
                            }

                            catch (OverflowException)
                            {
                                exception = true;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid value - Overflow");
                                Console.ResetColor();
                            }

                            if (exception == false && (first_to_operate_with < 1 || first_to_operate_with > 4))
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                                Console.ResetColor();
                            }

                        } while (first_to_operate_with < 1 || first_to_operate_with > 4);

                        switch (first_to_operate_with)
                        {
                            case 1: //First register - AX
                                do
                                {
                                    bool exception = false;

                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Select second register with which you want to operate: ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("(2) BX");
                                    Console.WriteLine("(3) CX");
                                    Console.WriteLine("(4) DX\n");
                                    Console.ResetColor();

                                    try
                                    {
                                        second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n");
                                    }

                                    catch (FormatException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input format");
                                        Console.ResetColor();
                                    }

                                    catch (OverflowException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid value - Overflow");
                                        Console.ResetColor();
                                    }

                                    if (exception == false && (second_to_operate_with < 2 || second_to_operate_with > 4))
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                                        Console.ResetColor();
                                    }

                                } while (second_to_operate_with < 2 || second_to_operate_with > 4);
                                break;

                            case 2: //First register - BX
                                do
                                {
                                    bool exception = false;

                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Select second register with which you want to operate: ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("(1) AX");
                                    Console.WriteLine("(3) CX");
                                    Console.WriteLine("(4) DX\n");
                                    Console.ResetColor();

                                    try
                                    {
                                        second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n");
                                    }

                                    catch (FormatException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input format");
                                        Console.ResetColor();
                                    }

                                    catch (OverflowException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid value - Overflow");
                                        Console.ResetColor();
                                    }

                                    if (exception == false && (second_to_operate_with < 1 || second_to_operate_with == 2 || second_to_operate_with > 4))
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                                        Console.ResetColor();
                                    }

                                } while (second_to_operate_with < 1 || second_to_operate_with == 2 || second_to_operate_with > 4);
                                break;

                            case 3: //First register - CX
                                do
                                {
                                    bool exception = false;

                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Select second register with which you want to operate: ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("(1) AX");
                                    Console.WriteLine("(2) BX");
                                    Console.WriteLine("(4) DX\n");
                                    Console.ResetColor();

                                    try
                                    {
                                        second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n");
                                    }

                                    catch (FormatException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input format");
                                        Console.ResetColor();
                                    }

                                    catch (OverflowException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid value - Overflow");
                                        Console.ResetColor();
                                    }

                                    if (exception == false && (second_to_operate_with < 1 || second_to_operate_with == 3 || second_to_operate_with > 4))
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                                        Console.ResetColor();
                                    }

                                } while (second_to_operate_with < 1 || second_to_operate_with == 3 || second_to_operate_with > 4);
                                break;

                            case 4: //First register - DX
                                do
                                {
                                    bool exception = false;

                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Select second register with which you want to operate: ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("(1) AX");
                                    Console.WriteLine("(2) BX");
                                    Console.WriteLine("(3) CX\n");
                                    Console.ResetColor();

                                    try
                                    {
                                        second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n");
                                    }

                                    catch (FormatException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input format");
                                        Console.ResetColor();
                                    }

                                    catch (OverflowException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid value - Overflow");
                                        Console.ResetColor();
                                    }

                                    if (exception == false && (second_to_operate_with < 1 || second_to_operate_with > 3))
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                                        Console.ResetColor();
                                    }

                                } while (second_to_operate_with < 1 || second_to_operate_with > 3);
                                break;
                        }
                    }

                    if (selected_instruction == 2) //XCHG handling
                    {
                        do
                        {
                            bool exception = false;

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Select first register on which you want to operate: ");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("(1) AX");
                            Console.WriteLine("(2) BX");
                            Console.WriteLine("(3) CX");
                            Console.WriteLine("(4) DX\n");
                            Console.ResetColor();

                            try
                            {
                                first_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                Console.Write("\n");
                            }

                            catch (FormatException)
                            {
                                exception = true;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid input format");
                                Console.ResetColor();
                            }

                            catch (OverflowException)
                            {
                                exception = true;
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid value - Overflow");
                                Console.ResetColor();
                            }

                            if (exception == false && (first_to_operate_with < 1 || first_to_operate_with > 4))
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                                Console.ResetColor();
                            }

                        } while (first_to_operate_with < 1 || first_to_operate_with > 4);

                        switch (first_to_operate_with)
                        {
                            case 1: //First register - AX
                                do
                                {
                                    bool exception = false;

                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Select second register with which you want to operate: ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("(2) BX");
                                    Console.WriteLine("(3) CX");
                                    Console.WriteLine("(4) DX\n");
                                    Console.ResetColor();

                                    try
                                    {
                                        second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n");
                                    }

                                    catch (FormatException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input format");
                                        Console.ResetColor();
                                    }

                                    catch (OverflowException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid value - Overflow");
                                        Console.ResetColor();
                                    }

                                    if (exception == false && (second_to_operate_with < 2 || second_to_operate_with > 4))
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                                        Console.ResetColor();
                                    }

                                } while (second_to_operate_with < 2 || second_to_operate_with > 4);
                                break;

                            case 2: //First register - BX
                                do
                                {
                                    bool exception = false;

                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Select second register with which you want to operate: ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("(1) AX");
                                    Console.WriteLine("(3) CX");
                                    Console.WriteLine("(4) DX\n");
                                    Console.ResetColor();

                                    try
                                    {
                                        second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n");
                                    }

                                    catch (FormatException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input format");
                                        Console.ResetColor();
                                    }

                                    catch (OverflowException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid value - Overflow");
                                        Console.ResetColor();
                                    }

                                    if (exception == false && (second_to_operate_with < 1 || second_to_operate_with == 2 || second_to_operate_with > 4))
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                                        Console.ResetColor();
                                    }

                                } while (second_to_operate_with < 1 || second_to_operate_with == 2 || second_to_operate_with > 4);
                                break;

                            case 3: //First register - CX
                                do
                                {
                                    bool exception = false;

                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Select second register with which you want to operate: ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("(1) AX");
                                    Console.WriteLine("(2) BX");
                                    Console.WriteLine("(4) DX\n");
                                    Console.ResetColor();

                                    try
                                    {
                                        second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n");
                                    }

                                    catch (FormatException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input format");
                                        Console.ResetColor();
                                    }

                                    catch (OverflowException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid value - Overflow");
                                        Console.ResetColor();
                                    }

                                    if (exception == false && (second_to_operate_with < 1 || second_to_operate_with == 3 || second_to_operate_with > 4))
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                                        Console.ResetColor();
                                    }

                                } while (second_to_operate_with < 1 || second_to_operate_with == 3 || second_to_operate_with > 4);
                                break;

                            case 4: //First register - DX
                                do
                                {
                                    bool exception = false;

                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("Select second register with which you want to operate: ");
                                    Console.ResetColor();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("(1) AX");
                                    Console.WriteLine("(2) BX");
                                    Console.WriteLine("(3) CX\n");
                                    Console.ResetColor();

                                    try
                                    {
                                        second_to_operate_with = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("\n");
                                    }

                                    catch (FormatException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid input format");
                                        Console.ResetColor();
                                    }

                                    catch (OverflowException)
                                    {
                                        exception = true;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid value - Overflow");
                                        Console.ResetColor();
                                    }

                                    if (exception == false && (second_to_operate_with < 1 || second_to_operate_with > 3))
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                                        Console.ResetColor();
                                    }

                                } while (second_to_operate_with < 1 || second_to_operate_with > 3);
                                break;
                        }
                    }
                }

                else if (selected_function == 3) //Control handling
                {
                    do
                    {
                        bool exception = false;

                        try
                        {
                            selected_instruction = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                        }

                        catch (FormatException)
                        {
                            exception = true;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input format");
                            Console.ResetColor();
                            SEL_INSTR(selected_function);
                        }

                        catch (OverflowException)
                        {
                            exception = true;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid value - Overflow");
                            Console.ResetColor();
                            SEL_INSTR(selected_function);
                        }


                        if (exception == false && (selected_instruction < 1 || selected_instruction > 8))
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("You have inserted wrong number! Please type it again correctly...");
                            Console.ResetColor();
                            SEL_INSTR(selected_function);
                        }

                    } while (selected_instruction < 1 || selected_instruction > 8);

                }



                switch (selected_function) //Used to perform certain tasks for example: ADD, MOV... 
                {
                    case 1: //Arithmetics
                        switch (selected_instruction)
                        {
                            case 1: //ADD
                                if (ADD_num != 0)
                                {
                                    SLEEP();
                                    ADD.ADD_REGS(m, first_to_operate_with, ADD_num);
                                }

                                else
                                {
                                    SLEEP();
                                    ADD.ADD_REGS(m, first_to_operate_with, second_to_operate_with);
                                }
                                break;
                            case 2: //ADC
                                if (ADD_num != 0)
                                {
                                    SLEEP();
                                    ADC.ADC_REGS(m, first_to_operate_with, ADD_num);
                                }

                                else
                                {
                                    SLEEP();
                                    ADC.ADC_REGS(m, first_to_operate_with, second_to_operate_with);
                                }
                                break;
                            case 3: //SUB
                                if (ADD_num != 0)
                                {
                                    SLEEP();
                                    SUB.SUB_REGS(m, first_to_operate_with, ADD_num);
                                }

                                else
                                {
                                    SLEEP();
                                    SUB.SUB_REGS(m, first_to_operate_with, second_to_operate_with);
                                }
                                break;
                            case 4: //INC
                                SLEEP();
                                INC.INC_REG(m, first_to_operate_with);
                                break;
                            case 5: //DEC
                                SLEEP();
                                DEC.DEC_REG(m, first_to_operate_with);
                                break;
                        }
                        break;
                    case 2: //Data Transfer
                        switch (selected_instruction)
                        {
                            case 1: //MOV
                                SLEEP();
                                MOV.MOV_REGS(m, first_to_operate_with, second_to_operate_with);
                                break;
                            case 2: //XCHG
                                SLEEP();
                                XCHG.XCHG_REGS(m, first_to_operate_with, second_to_operate_with);
                                break;
                        }
                        break;
                    case 3: //Control
                        switch (selected_instruction)
                        {
                            case 1: //STC
                                SLEEP_CONTROL();
                                STC.STC_FLAGS(m);
                                break;
                            case 2: //CLC
                                SLEEP_CONTROL();
                                CLC.CLC_FLAGS(m);
                                break;
                            case 3: //CMC
                                SLEEP_CONTROL();
                                CMC.CMC_FLAGS(m);
                                break;
                            case 4: //STD
                                SLEEP_CONTROL();
                                STD.STD_FLAGS(m);
                                break;
                            case 5: //CLD
                                SLEEP_CONTROL();
                                CLD.CLD_FLAGS(m);
                                break;
                            case 6: //STI
                                SLEEP_CONTROL();
                                STI.STI_FLAGS(m);
                                break;
                            case 7: //CLI
                                SLEEP_CONTROL();
                                CLI.CLI_FLAGS(m);
                                break;
                            case 8: //HLT
                                SLEEP_CONTROL();
                                HLT.HLT_EXIT();
                                break;
                        }
                        break;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Press ESCAPE to stop or do anything else to continue\n");

                if(Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    exit = true;
                    Console.Write("\n");
                    Console.ResetColor();
                }

                else
                {
                    Console.Clear();
                }

            } while (exit == false);

        }
    }
}
