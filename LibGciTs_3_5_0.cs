using System;
using System.Text;
using System.Runtime.InteropServices;

namespace GCI {
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct GciErrSType
    {
        public long category;       // error dictionary
        public long context;        // GsProcess instance
        public long exceptionObj;   // AbstractException instance
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public long[] args;           // arguments
        public int  number;         // argument count
        public char fatal;          // nonzero if error is fatal
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1025)]
        public char[] message;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1025)]
        public char[] reason;
    }

    public class LibGciTs_3_5_0 : LibGci
    {
        [DllImport("libgcits-3.5.0-64.dylib", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)] 

        static extern long GciTsLogin(
            string stoneNRS, 
            string hostUserId, 
            string hostPassword,
            bool   hostPwIsEncrypted, 
            string gemNRS, 
            string gsUserId, 
            string gsPassword, 
            uint   loginFlags, 
            int    haltOnErrNum, 
            ref GciErrSType err);

        public override long login()
        {
            GciErrSType errSType = new GciErrSType();
            long session = GciTsLogin(
                "!tcp@localhost#server!gs64stone",
                null,   // hostUserId
                null,   // hostPassword
                false,  // hostPwIsEncrypted
                "!tcp@localhost#netldi:gs64ldi#task!gemnetobject",
                "DataCurator",
                "swordfish",
                0,      // loginFlags
                0,      // haltOnErrNum
                ref errSType);
            return session;
        }

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
