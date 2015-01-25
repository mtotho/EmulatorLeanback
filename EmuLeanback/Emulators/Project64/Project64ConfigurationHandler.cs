using EmuLeanback.Emulators.Code;
using EmuLeanback.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmuLeanback.Emulators.Project64
{
    public class Project64ConfigurationHandler : ConfigurationHandler
    {
       
        private Project64Configuration _config;
     
        public Project64ConfigurationHandler(ConsoleEmulator n64)
        {
            _configFilePath = config.N64.CONFIG_DIRECTORY+ "Project64.cfg";
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
