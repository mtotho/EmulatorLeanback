using EmuLeanback.Emulators.Code;
using EmuLeanback.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback.Emulators.Code
{
    public class ConsoleEmulator
    {
        protected ConfigurationHandler _configHandler;
        public object Config;
        public RomLoader RomLoader;
        public KeyboardHandler KBHandler;

    }
}
