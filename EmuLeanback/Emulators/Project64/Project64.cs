
using EmuLeanback.Emulators.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback.Emulators.Project64
{
    public class Project64 : ConsoleEmulator
    {

    

        public Project64()
        {
            RomLoader = new Project64RomLoader();

            _configHandler = new Project64ConfigurationHandler(this);
            Config = _configHandler.getConfig();
        }
    }
}
