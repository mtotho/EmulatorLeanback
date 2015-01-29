using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using EmuLeanback.ConsoleEmulator.Helpers;
using EmuLeanback.ConsoleEmulator.Code;
using System.Threading;

namespace EmuLeanback.ConsoleEmulator.Dolphin
{
    public class DolphinRomLoader : RomLoader
    {

        private const uint VK_ESCAPE = 0x1B;

        public DolphinRomLoader(ConsoleConfig FileDirectories)
        {
            _romDirectory = FileDirectories.ROM_DIRECTORY;
            _executable = FileDirectories.EXECUTABLE;
            _processName = "Dolphin";
        }

        public override int SendSave()
        {
            //send f9 which is mapped to save slot 8
            sendKey(KeyboardHandler.KEY_F9, true);
            //sleep for just under a second to allow state to save
            Thread.Sleep(1000);
            return 0;

        }
       
        public override int LoadSave()
        {
            if(_currentProcess!=null)
                SetForegroundWindow(_currentProcess.MainWindowHandle);
            sendKey(KeyboardHandler.KEY_F8);

            return 0;

        }
     
    }
}
