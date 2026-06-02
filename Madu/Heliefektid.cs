using System;
using System.Collections.Generic;
using System.Text;

namespace Madu
{
    using System;
    using System.Threading.Tasks;

    public static class Heliefektid
    {
        public static void MängiSöömist()
        {
            
            Task.Run(() => Console.Beep(800, 100));
        }

        public static void MängiKaotust()
        {
            Task.Run(() => {
                Console.Beep(400, 150);
                Console.Beep(300, 150);
                Console.Beep(200, 300);
            });
        }
    }
}
