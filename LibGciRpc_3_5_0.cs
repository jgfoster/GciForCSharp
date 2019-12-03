using System;
using System.Runtime.InteropServices;

namespace GCI {
    public class LibGciRpc_3_5_0 : LibGci
    {
        [DllImport("libgcirpc-3.5.0-64.dylib", CallingConvention = CallingConvention.Cdecl)] 
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ConstCharPtrMarshaler))]
        static extern string GciVersion();
        public override string version()
        {
            return GciVersion();
        }
        public override long login()
        {
            return 0;
        }
    }
}
