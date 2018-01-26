using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

namespace BackgroundFetchDemo
{
    public static class NSLogHelper
    {
        [DllImport(Constants.FoundationLibrary)]
        private static extern void NSLog(IntPtr format, [MarshalAs(UnmanagedType.LPStr)] string s);

        [DllImport(Constants.FoundationLibrary, EntryPoint = "NSLog")]
        private static extern void NSLog_arm64(
            IntPtr format,
            IntPtr p2,
            IntPtr p3,
            IntPtr p4,
            IntPtr p5,
            IntPtr p6,
            IntPtr p7,
            IntPtr p8,
            [MarshalAs(UnmanagedType.LPStr)] string s);

        public static void Write(string message)
        {
            var fmt = NSString.CreateNative("%s");
            if (IntPtr.Size == 8 && Runtime.Arch == Arch.DEVICE)
            {
                NSLog_arm64(
                    fmt,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    message);
            }
            else
            {
                NSLog(fmt, message);
            }
            NSString.ReleaseNative(fmt);
        }
    }
}