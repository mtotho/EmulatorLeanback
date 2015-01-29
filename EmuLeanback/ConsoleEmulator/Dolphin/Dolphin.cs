
using EmuLeanback.ConsoleEmulator.Code;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback.ConsoleEmulator.Dolphin
{
    public class Dolphin : GameConsoleEmulator
    {
      
      //  private DolphinConfigurationHandler _configHandler;
       /// public DolphinConfiguration Config;
      //  public DolphinRomLoader RomLoader;
        //public DolphinKeyboardHandler KBHandler;
      

        public Dolphin(ConsoleConfig DirectoryConfig)
        {
            DirectoryConfiguration = DirectoryConfig;
            RomLoader = new DolphinRomLoader(DirectoryConfig);

            _configHandler = new DolphinConfigurationHandler(this);
            Config = _configHandler.getConfig();
            KBHandler = new DolphinKeyboardHandler(this);

        }

      
     
    }
}
