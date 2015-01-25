using EmuLeanback.Emulators.Code;
using EmuLeanback.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback.Emulators.Dolphin
{
    public class DolphinConfigurationHandler : ConfigurationHandler
    {
        private DolphinConfiguration _config;

        public DolphinConfigurationHandler(ConsoleEmulator emu)
        {
            _configFilePath = config.GAMECUBE.USER_DIRECTORY + "Config\\Dolphin.ini";
            _emu = emu;
            _config = new DolphinConfiguration(_configFilePath);

            //default to full screen
            _config.Display.Fullscreen = true;

            _config.Hotkeys.SaveStateSlot8 = (int)HotkeyConfiguration.KEYS.F9;
            _config.Hotkeys.SaveStateSlot8Modifier = 0;

            commit();
        }

        public override object getConfig()
        {
            return _config;
        }
     
    }
}
