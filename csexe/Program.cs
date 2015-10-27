using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace csexe {
    class Program {
        delegate void h();
        [DllImport("cdll.dll")]
        extern static void f(h h);
        static void Main(string[] args) {
            {
                f(() => { Console.WriteLine(123); });
            }
            Console.WriteLine(456);
            GC.Collect();
            Console.ReadKey(true);
        }
    }
}
