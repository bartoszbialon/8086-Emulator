using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel_8086___Emulator
{
    public class CMC
    {
        public static void CMC_FLAGS(MAIN a) //Method which inverts value of Carry Flag
        {
            if (a.CF == true)
            {
                a.CF = false;
            }

            else
            {
                a.CF = true;
            }
        }
    }
}
