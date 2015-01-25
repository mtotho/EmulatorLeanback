using EmuLeanback.Handlers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
    
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback.Models.Dolphin
{
    public class Dolphin 
    {

        private DolphinConfigurationHandler _configHandler;
        public DolphinConfiguration Config;
        public DolphinRomLoader RomLoader;
        public DolphinKeyboardHandler KBHandler;
      

        public Dolphin()
        {
            RomLoader = new DolphinRomLoader();

            _configHandler = new DolphinConfigurationHandler(this);
            Config = _configHandler.getConfig();
            KBHandler = new DolphinKeyboardHandler(this);

        }

      
     
    }
}
