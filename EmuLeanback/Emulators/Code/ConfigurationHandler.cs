using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback.Emulators.Code
{
    public abstract class ConfigurationHandler
    {

        private object _config;
        protected static string _configFilePath;
        protected ConsoleEmulator _emu;

        public int commit()
        {
            _emu.RomLoader.KillAll();

            System.IO.File.WriteAllText(_configFilePath, getConfig().ToString());
            return 0;
        }

        public virtual object getConfig()
        {
            return _config;
        }
       
    }
}
