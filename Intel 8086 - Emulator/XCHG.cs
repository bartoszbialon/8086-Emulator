using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel_8086___Emulator
{
    public class XCHG
    {
        public static void XCHG_REGS(MAIN a, int first, int second) //Method which exchange values of two registers
        {
            short temp = 0;

            switch (first)
            {
                case 1:
                    temp = a.AX;
                    switch (second)
                    {
                        case 2:
                            a.AX = a.BX;
                            a.BX = temp;
                            break;
                        case 3:
                            a.AX = a.CX;
                            a.CX = temp;
                            break;
                        case 4:
                            a.AX = a.DX;
                            a.DX = temp;
                            break;
                    }
                    break;
                case 2:
                    temp = a.BX;
                    switch (second)
                    {
                        case 1:
                            a.BX = a.AX;
                            a.AX = temp;
                            break;
                        case 3:
                            a.BX = a.CX;
                            a.CX = temp;
                            break;
                        case 4:
                            a.BX = a.DX;
                            a.DX = temp;
                            break;
                    }
                    break;
                case 3:
                    temp = a.CX;
                    switch (second)
                    {
                        case 1:
                            a.CX = a.AX;
                            a.AX = temp;
                            break;
                        case 2:
                            a.CX = a.BX;
                            a.BX = temp;
                            break;
                        case 4:
                            a.CX = a.DX;
                            a.DX = temp;
                            break;
                    }
                    break;
                case 4:
                    temp = a.DX;
                    switch (second)
                    {
                        case 1:
                            a.DX = a.AX;
                            a.AX = temp;
                            break;
                        case 2:
                            a.DX = a.BX;
                            a.BX = temp;
                            break;
                        case 3:
                            a.DX = a.CX;
                            a.CX = temp;
                            break;
                    }
                    break;
            }
        }
    }
}
