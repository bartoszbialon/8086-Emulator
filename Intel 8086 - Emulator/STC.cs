using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel_8086___Emulator
{
    public class STC
    {
        public static void STC_FLAGS(MAIN a) //Method which clears Carry Flag's value
        {
            a.CF = true;
        }
    }
}
