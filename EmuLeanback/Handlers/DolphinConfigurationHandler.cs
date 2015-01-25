using EmuLeanback.Helpers;
using EmuLeanback.Models.Dolphin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback.Handlers
{
    public class DolphinConfigurationHandler
    {

        private DolphinConfiguration _dolphinConfig;
        private static string _configFilePath = config.GAMECUBE.USER_DIRECTORY + "Config\\Dolphin.ini";
        private Dolphin _dolphin;

        public DolphinConfigurationHandler(Dolphin dolphin)
        {
            _dolphin = dolphin;
            _dolphinConfig = new DolphinConfiguration(_configFilePath);

            //default to full screen
            _dolphinConfig.Display.Fullscreen=true;
            commit();
        }
        public int commit()
        {
            _dolphin.RomLoader.KillAll();

            System.IO.File.WriteAllText(_configFilePath, _dolphinConfig.ToString());
            return 0;
        }

        public DolphinConfiguration getConfig()
        {
            return _dolphinConfig;
        }
       
    }
}
