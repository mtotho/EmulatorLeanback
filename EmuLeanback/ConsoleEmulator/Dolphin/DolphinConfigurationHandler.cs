using EmuLeanback.ConsoleEmulator.Code;
using EmuLeanback.ConsoleEmulator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback.ConsoleEmulator.Dolphin
{
    public class DolphinConfigurationHandler : ConfigurationHandler
    {
        private DolphinConfiguration _config;

        public DolphinConfigurationHandler(GameConsoleEmulator emu)
        {
            _configFilePath = emu.DirectoryConfiguration.USER_DIRECTORY+ "Config\\Dolphin.ini";
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
