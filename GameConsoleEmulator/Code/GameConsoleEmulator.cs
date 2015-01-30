using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsoleEmulator.Code
{
    public class GameConsole
    {
        protected ConfigurationHandler _configHandler;
        public object Config;
        public RomLoader RomLoader;
        public KeyboardHandler KBHandler;
        public ConsoleConfig DirectoryConfiguration;
    }
}
