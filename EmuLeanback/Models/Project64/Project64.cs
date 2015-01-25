using EmuLeanback.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback.Models.Project64
{
    public class Project64 
    {

        private Project64ConfigurationHandler _configHandler;
        public Project64Configuration Config;
        public Project64RomLoader RomLoader;

        public Project64()
        {
            RomLoader = new Project64RomLoader();

            _configHandler = new Project64ConfigurationHandler(this);
            Config = _configHandler.getConfig();
        }
    }
}
