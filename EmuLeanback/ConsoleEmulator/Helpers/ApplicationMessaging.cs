using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback.ConsoleEmulator.Helpers
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseInput
    {
        public int dx;
        public int dy;
        public int mouseData;
        public int dwFlags;
        public int time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KeyboardInput
    {
        public short wVk;      //Virtual KeyCode (not needed here)
        public short wScan;    //Directx Keycode 
        public int dwFlags;    //This tells you what is use (Keyup, Keydown..)
        public int time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HardwareInput
    {
        public int uMsg;
        public short wParamL;
        public short wParamH;
    }

    [StructLayout(LayoutKind.Explicit)]
   public struct Input
    {
        [FieldOffset(0)]
        public int type;
        [FieldOffset(4)]
        public MouseInput mi;
        [FieldOffset(4)]
        public KeyboardInput ki;
        [FieldOffset(4)]
        public HardwareInput hi;
    }

    [Flags]
    public enum KeyFlag
    {
        KeyDown = 0x0000,
        ExtendedKey = 0x0001,
        KeyUp = 0x0002,
        UniCode = 0x0004,
        ScanCode = 0x0008
    }
}
