using EmuLeanback.Helpers;
using EmuLeanback.Models.Project64;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmuLeanback.Handlers
{
    public class Project64ConfigurationHandler 
    {
       
        private Project64Configuration _pj64Config;
        private static string _configFilePath = config.N64.ROOT_DIRECTORY + "Config\\Project64.cfg";
        private Project64 _n64;

        public Project64ConfigurationHandler(Project64 n64)
        {
            _n64 = n64;
            _pj64Config = getConfigFromFile();

            //default to full screen
            _pj64Config.Default.AutoFullScreen = "1";
            commit();
        }
        public Project64Configuration getConfig()
        {
            return _pj64Config;
        }

        public int setDirect3D8Configuration(Direct3D8Configuration config)
        {
            _pj64Config.Direct3D8 = config;

            
            return 0;
        }

        public int commit()
        {
            _n64.RomLoader.KillAll();
         
            System.IO.File.WriteAllText(_configFilePath, _pj64Config.ToString());
            return 0;
        }


        private static Project64Configuration getConfigFromFile()
        {
            Project64Configuration pj64cfg = new Project64Configuration();

            string readText = FileIO.FileToString(_configFilePath);
            //string pat = @"(\[.*\])(?:(?!(\n\n))(\n(.)*))*";
          


            string[] stringSeparators = new string[] {"\r\n\r\n"};
            var configGroups= readText.Split(stringSeparators, StringSplitOptions.None);

            string[] configLineSeparator = new string[] {"\r\n"};

            //TODO: REFACTOR
            //what i should do here is loop through all the lines, store dictionary key, value pairs. Then later I can search the dictionary for matches to 
            //settings used in the model. should be more robust

            //plugin group
            var pluginGroup = configGroups[0];
            var pluginLines = pluginGroup.Split(configLineSeparator, StringSplitOptions.None);

            pj64cfg.Plugins.AudioDll = pluginLines[1].Split('=')[1];
            pj64cfg.Plugins.ControllerDll = pluginLines[2].Split('=')[1];
            pj64cfg.Plugins.GraphicsDll = pluginLines[3].Split('=')[1];
            pj64cfg.Plugins.RspDll = pluginLines[4].Split('=')[1];

            //default group
            var defaultGroup = configGroups[1];
            var defaultLines = defaultGroup.Split(configLineSeparator, StringSplitOptions.None);

            pj64cfg.Default.AutoFullScreen = defaultLines[1].Split('=')[1];
            pj64cfg.Default.CurrentLanguage = defaultLines[2].Split('=')[1];


            //rom browser
            var rbGroup = configGroups[2];
            var rbLines = rbGroup.Split(configLineSeparator, StringSplitOptions.None);

            pj64cfg.RomBrowser.Left = rbLines[1].Split('=')[1];
            pj64cfg.RomBrowser.Maximized = rbLines[2].Split('=')[1];
            pj64cfg.RomBrowser.SortAscending0 = rbLines[3].Split('=')[1];
            pj64cfg.RomBrowser.SortAscending1 = rbLines[4].Split('=')[1];
            pj64cfg.RomBrowser.SortAscending2 = rbLines[5].Split('=')[1];
            pj64cfg.RomBrowser.SortAscending3 = rbLines[6].Split('=')[1];
            pj64cfg.RomBrowser.SortField0 = rbLines[7].Split('=')[1];
            pj64cfg.RomBrowser.SortField1 = rbLines[8].Split('=')[1];
            pj64cfg.RomBrowser.SortField2 = rbLines[9].Split('=')[1];
            pj64cfg.RomBrowser.SortField3 = rbLines[10].Split('=')[1];
            pj64cfg.RomBrowser.Top = rbLines[11].Split('=')[1];

            //Main Window
            var mainwindowGroup = configGroups[3];
            var mainwindowLines = mainwindowGroup.Split(configLineSeparator, StringSplitOptions.None);

            pj64cfg.MainWindow.Left = mainwindowLines[1].Split('=')[1];
            pj64cfg.MainWindow.Top = mainwindowLines[2].Split('=')[1];

            //controller groups
            for (int i = 4; i < 8; i++)
            {
                var controllerGroup = configGroups[i];
                var controllerLines = controllerGroup.Split(configLineSeparator, StringSplitOptions.None);

                DirectInputControllerConfiguration controllerConfig = new DirectInputControllerConfiguration()
                {
                    A=controllerLines[1].Split('=')[1],
                    AnalogDown=controllerLines[2].Split('=')[1],
                    AnalogLeft=controllerLines[3].Split('=')[1],
                    AnalogRight=controllerLines[4].Split('=')[1],
                    AnalogUp=controllerLines[5].Split('=')[1],
                    B=controllerLines[6].Split('=')[1],
                    C_Down=controllerLines[7].Split('=')[1],
                    C_Left=controllerLines[8].Split('=')[1],
                    C_Right=controllerLines[9].Split('=')[1],
                    C_Up=controllerLines[10].Split('=')[1],
                    Deadzone=controllerLines[11].Split('=')[1],
                    DigitalDown=controllerLines[12].Split('=')[1],
                    DigitalLeft=controllerLines[13].Split('=')[1],
                    DigitalRight=controllerLines[14].Split('=')[1],
                    DigitalUp=controllerLines[15].Split('=')[1],
                    GUID=controllerLines[16].Split('=')[1],
                    L=controllerLines[17].Split('=')[1],
                    Present=controllerLines[18].Split('=')[1],
                    R=controllerLines[19].Split('=')[1],
                    Range = controllerLines[20].Split('=')[1],
                    Start = controllerLines[21].Split('=')[1],
                    Type=controllerLines[22].Split('=')[1],
                    Z = controllerLines[23].Split('=')[1]

                };

                pj64cfg.Controllers.Add(controllerConfig);
            }

            //recent files;
            var recentFilesGroup = configGroups[8];
            var recentFileLines = recentFilesGroup.Split(configLineSeparator, StringSplitOptions.None);
            for (int j = 1; j < recentFileLines.Count(); j++)
            {
                pj64cfg.RecentFiles.Add(recentFileLines[j].Split('=')[1]);
            }


            //Direct3d8
            var direct3dgroup = configGroups[9];
            var direct3dLines = direct3dgroup.Split(configLineSeparator, StringSplitOptions.None);


            pj64cfg.Direct3D8.Anisotropic = direct3dLines[1].Split('=')[1];
            pj64cfg.Direct3D8.DumpTextures = direct3dLines[2].Split('=')[1];
            pj64cfg.Direct3D8.EmulateBuffer = direct3dLines[3].Split('=')[1];
            pj64cfg.Direct3D8.ForceBlend = direct3dLines[4].Split('=')[1];
            pj64cfg.Direct3D8.ForceCombiner = direct3dLines[5].Split('=')[1];
            pj64cfg.Direct3D8.FullscreenHeight = direct3dLines[6].Split('=')[1];
            pj64cfg.Direct3D8.FullscreenWidth = direct3dLines[7].Split('=')[1];
            pj64cfg.Direct3D8.Multisample = direct3dLines[8].Split('=')[1];
            pj64cfg.Direct3D8.SoftwareEmu = direct3dLines[9].Split('=')[1];
            pj64cfg.Direct3D8.Vsync = direct3dLines[10].Split('=')[1];
            pj64cfg.Direct3D8.WindowType = direct3dLines[11].Split('=')[1];
            
            return pj64cfg; 

        }

    }
}
