using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using EmuLeanback.Helpers;

namespace EmuLeanback.Handlers
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

     
    }
}
