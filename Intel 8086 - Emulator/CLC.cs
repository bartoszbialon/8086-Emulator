using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel_8086___Emulator
{
    public class CLC
    {
        public static void CLC_FLAGS(MAIN a) //Method which clears Carry Flag so sets its value to 0 
        {
            a.CF = false;
        }
    }
}
