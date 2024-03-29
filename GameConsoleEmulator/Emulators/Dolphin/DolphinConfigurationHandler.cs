﻿using GameConsoleEmulator.Code;
using GameConsoleEmulator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsoleEmulator.Emulators.Dolphin
{
    public class DolphinConfigurationHandler : ConfigurationHandler
    {
        private DolphinConfiguration _config;

        public DolphinConfigurationHandler(GameConsole emu)
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
