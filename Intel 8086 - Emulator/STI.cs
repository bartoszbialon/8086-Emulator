using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel_8086___Emulator
{
    public class STI
    {
        public static void STI_FLAGS(MAIN a) //Method which enables Interrupt Flag
        {
            a.IF = true;
        }
    }
}
