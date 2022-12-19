using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel_8086___Emulator
{
    public class CLD
    {
        public static void CLD_FLAGS(MAIN a) //Method which clears Direction Flag, so its value is set to 0
        {
            a.DF = false;
        }
    }
}
