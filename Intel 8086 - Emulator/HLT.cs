using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Intel_8086___Emulator
{
    public class HLT
    {
        public static void HLT_EXIT() //Method which stops program execution
        {
            System.Environment.Exit(0);
        }
    }
}
