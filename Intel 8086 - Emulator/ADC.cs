using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel_8086___Emulator
{
    public class ADC
    {
        public static void ADC_REGS(MAIN a, int first, int second) //Method which adds value from one register to another
        {
            a.CF = true; //Carry Flag set to 1

            switch (first)
            {
                case 1:
                    switch (second)
                    {
                        case 2:
                            a.AX += a.BX;
                            break;
                        case 3:
                            a.AX += a.CX;
                            break;
                        case 4:
                            a.AX += a.DX;
                            break;
                    }
                    break;
                case 2:
                    switch (second)
                    {
                        case 1:
                            a.BX += a.AX;
                            break;
                        case 3:
                            a.BX += a.CX;
                            break;
                        case 4:
                            a.BX += a.DX;
                            break;
                    }
                    break;
                case 3:
                    switch (second)
                    {
                        case 1:
                            a.CX += a.AX;
                            break;
                        case 2:
                            a.CX += a.BX;
                            break;
                        case 4:
                            a.CX += a.DX;
                            break;
                    }
                    break;
                case 4:
                    switch (second)
                    {
                        case 1:
                            a.DX += a.AX;
                            break;
                        case 2:
                            a.DX += a.BX;
                            break;
                        case 3:
                            a.DX += a.CX;
                            break;
                    }
                    break;
            }
        }

        public static void ADC_REGS(MAIN a, int first, short num) //Method which adds given value to the specified register
        {
            a.CF = true; //Carry Flag set to 1

            switch (first)
            {
                case 1:
                    a.AX += num;
                    break;
                case 2:
                    a.BX += num;
                    break;
                case 3:
                    a.CX += num;
                    break;
                case 4:
                    a.DX += num;
                    break;
            }
        }
    }
}
