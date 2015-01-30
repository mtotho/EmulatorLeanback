
using GameConsoleEmulator.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsoleEmulator.Emulators.Project64
{
    public class Project64 : GameConsole
    {



        public Project64(ConsoleConfig DirectoryConfig)
        {
            DirectoryConfiguration = DirectoryConfig;
            RomLoader = new Project64RomLoader(DirectoryConfiguration);

            _configHandler = new Project64ConfigurationHandler(this);
            Config = _configHandler.getConfig();
        }
    }
}
