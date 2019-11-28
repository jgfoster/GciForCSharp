using System;
using System.Text;
using System.Runtime.InteropServices;

namespace GCI {
    public class LibGciTs_3_5_0 : LibGci
    {
        [DllImport("libgcits-3.5.0-64.dylib", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)] 
        static extern uint GciTsVersion(StringBuilder buffer, int size);
        public override string version()
        {
            StringBuilder buffer = new StringBuilder(64);
            uint size = GciTsVersion(buffer, 64);
            return buffer.ToString();
        }
    }
}
