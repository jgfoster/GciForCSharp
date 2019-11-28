using System;

namespace GCI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            LibGciTs_3_5_0 lib = new LibGciTs_3_5_0();
            Console.WriteLine(lib.version());
        }
    }
}
