
using EmuLeanback.ConsoleEmulator.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback.ConsoleEmulator.Project64
{
    public class Project64 : GameConsoleEmulator
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
