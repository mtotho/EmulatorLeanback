using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback
{
    public static class config
    {

        public static class GAMECUBE
        {
            public static string EXECUTABLE = @"C:\Emulators\Dolphin-x64\Dolphin.exe";
            public static string ROOT_DIRECTORY = @"C:\Emulators\Dolphin-x64\";
            public static string ROM_DIRECTORY = @"C:\roms\gc\";
            public static string USER_DIRECTORY = @"C:\Users\Michael\Documents\Dolphin Emulator\";
        }

        public static class N64
        {
            public static string EXECUTABLE = @"C:\Emulators\Project64_2.1\Project64.exe";
            public static string ROOT_DIRECTORY = @"C:\Emulators\Project64_2.1\";
            public static string ROM_DIRECTORY = @"C:\roms\n64\";
        }
    }
}
