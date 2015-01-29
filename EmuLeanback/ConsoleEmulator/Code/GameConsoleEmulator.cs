using EmuLeanback.ConsoleEmulator.Code;
using EmuLeanback.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback.ConsoleEmulator.Code
{
    public class GameConsoleEmulator
    {
        protected ConfigurationHandler _configHandler;
        public object Config;
        public RomLoader RomLoader;
        public KeyboardHandler KBHandler;
        public ConsoleConfig DirectoryConfiguration;
    }
}
