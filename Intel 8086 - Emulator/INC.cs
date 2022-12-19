using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel_8086___Emulator
{
    public class INC
    {
        public static void INC_REG(MAIN a, int first) //Method which increments value of given register
        {
            switch (first)
            {
                case 1:
                    a.AX += 1;
                    break;
                case 2:
                    a.BX += 1;
                    break;
                case 3:
                    a.CX += 1;
                    break;
                case 4:
                    a.DX += 1;
                    break;
            }
        }
    }
}
