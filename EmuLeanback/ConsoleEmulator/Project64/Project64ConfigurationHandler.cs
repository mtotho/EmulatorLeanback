using EmuLeanback.ConsoleEmulator.Code;
using EmuLeanback.ConsoleEmulator.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmuLeanback.ConsoleEmulator.Project64
{
    public class Project64ConfigurationHandler : ConfigurationHandler
    {
       
        private Project64Configuration _config;
     
        public Project64ConfigurationHandler(GameConsoleEmulator n64)
        {
            _configFilePath = n64.DirectoryConfiguration.CONFIG_DIRECTORY + "Project64.cfg";
            _emu = n64;
            _config = new Project64Configuration(_configFilePath);

            //default to full screen
            _config.Default.AutoFullScreen = true;
            commit();
        }
        public override object getConfig()
        {
            return _config;
        }

        

      

      

    }
}
