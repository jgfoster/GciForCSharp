// https://stackoverflow.com/questions/6300093/why-cant-i-return-a-char-string-from-c-to-c-sharp-in-a-release-build

using System;
using System.Runtime.InteropServices;

namespace GCI {
    class ConstCharPtrMarshaler : ICustomMarshaler
    {
        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            return Marshal.PtrToStringAnsi(pNativeData);
        }

        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            return IntPtr.Zero;
        }

        public void CleanUpNativeData(IntPtr pNativeData)
        {
        }

        public void CleanUpManagedData(object ManagedObj)
        {
        }

        public int GetNativeDataSize()
        {
            return IntPtr.Size;
        }

        static readonly ConstCharPtrMarshaler instance = new ConstCharPtrMarshaler();

        public static ICustomMarshaler GetInstance(string cookie)
        {
            return instance;
        }
    }
}
