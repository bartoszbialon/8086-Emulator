using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel_8086___Emulator
{
    public class CLI
    {
        public static void CLI_FLAGS(MAIN a) //Method which disables Interrupt Flag
        {
            a.IF = false;
        }
    }
}
