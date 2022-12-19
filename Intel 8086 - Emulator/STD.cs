using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel_8086___Emulator
{
    public class STD
    {
        public static void STD_FLAGS(MAIN a) //Method which sets value of Direction Flag to 1
        {
            a.DF = true;
        }
    }
}
