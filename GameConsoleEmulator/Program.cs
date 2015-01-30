using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameConsoleEmulator.Emulators.Dolphin;
using GameConsoleEmulator.Code;


namespace GameConsoleEmulator
{
    public class Program
    {
        static void Main(string[] args)
        {

            Dolphin dolphin = new Dolphin(new ConsoleConfig()
            {
                EXECUTABLE = @"C:\Emulators\Dolphin-x64\Dolphin.exe",
                ROOT_DIRECTORY = @"C:\Emulators\Dolphin-x64\",
                ROM_DIRECTORY = @"C:\roms\gc\",
                USER_DIRECTORY = @"C:\Users\Michael\Documents\Dolphin Emulator\"
            });



            dolphin.RomLoader.LoadRom(dolphin.RomLoader.GetRoms()[0]);
        }

        void MainWindow_KeyDown(object sender, System.Windows.Forms.KeyEventHandler e)
        {

        }
    }
}
