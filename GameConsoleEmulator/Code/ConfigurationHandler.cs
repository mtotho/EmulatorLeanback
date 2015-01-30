using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsoleEmulator.Code
{
    public abstract class ConfigurationHandler
    {

        protected object _config;
        protected string _configFilePath;
        protected GameConsole _emu;

        //Kill all rom processes. Save config to file
        public int commit()
        {
            _emu.RomLoader.KillAll();

            System.IO.File.WriteAllText(_configFilePath, getConfig().ToString());
            return 0;
        }

        public virtual object getConfig()
        {
            return new NotImplementedException();
        }
       
    }
}
