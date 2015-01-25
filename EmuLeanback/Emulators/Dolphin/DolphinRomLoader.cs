using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using EmuLeanback.Helpers;
using EmuLeanback.Emulators.Code;
using System.Threading;

namespace EmuLeanback.Emulators.Dolphin
{
    public class DolphinRomLoader : RomLoader
    {

        private const uint VK_ESCAPE = 0x1B;

        public DolphinRomLoader()
        {
            _romDirectory = config.GAMECUBE.ROM_DIRECTORY;
            _executable = config.GAMECUBE.EXECUTABLE;
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
