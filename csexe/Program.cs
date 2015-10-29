using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace csexe {
    class Program {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        unsafe delegate void h(int*p);
        [DllImport("cdll.dll")]
        extern static void f([MarshalAs(UnmanagedType.FunctionPtr), In]h h);
        static void Main(string[] args) {
            unsafe{
                f((int*p) => {
                    Console.WriteLine((IntPtr)p);
                    Console.WriteLine(*p);
                });
            }
            Console.WriteLine(456);
            GC.Collect();
            Console.ReadKey(true);
        }
    }
}
