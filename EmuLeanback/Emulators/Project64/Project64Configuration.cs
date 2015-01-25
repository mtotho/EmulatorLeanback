using EmuLeanback.Emulators.Code;
using EmuLeanback.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback.Emulators.Project64
{
    public class Project64Configuration : EmulatorConfiguration
    {
      
        private string _configFilePath;
        private Dictionary<string, string> _configDictionary;

        public PluginConfiguration Plugins;
        public DefaultConfiguration Default;
        public RomBrowserConfiguration RomBrowser;
        public MainWindowConfiguration MainWindow;
        public List<DirectInputControllerConfiguration> Controllers;
        public List<string> RecentFiles;
        public Direct3D8Configuration Direct3D8;



        public Project64Configuration(string configPath)
        {
          
            _configFilePath = configPath;
            _configDictionary = loadDictionary();
            Plugins = new PluginConfiguration();
            Default = new DefaultConfiguration(_configDictionary);
            RomBrowser = new RomBrowserConfiguration();
            MainWindow = new MainWindowConfiguration();
            Controllers = new List<DirectInputControllerConfiguration>();
            RecentFiles = new List<string>();
            Direct3D8 = new Direct3D8Configuration();

            //loadDictionary2();
            
        }

        private Dictionary<string, string> loadDictionary()
        {
            var configDictionary = new Dictionary<string, string>();
            string readText = FileIO.FileToString(_configFilePath);

            string[] configLineSeparator = new string[] { "\r\n" };

            var configLines = readText.Split(configLineSeparator, StringSplitOptions.None);
            for (int i = 0; i < configLines.Length; i++)
            {
                var configLine = configLines[i];

                if (configLine == string.Empty)
                {
                    continue;
                }

                if (configLine.Split('=').Length > 1)
                {
                    var key = configLine.Split('=')[0].Trim();
                    var value = configLine.Split('=')[1].Trim();
                    int k = 0;

                    if (configDictionary.ContainsKey(key))
                    {
                        k = 2;
                        while (configDictionary.ContainsKey(key +"-"+ k))
                            k++;

                    }
                   
                    configDictionary.Add(k==0?key: key +"-"+k, value);
                        
                }
                else if (configLine != string.Empty)
                {
                    configDictionary.Add(configLine, "Label");
                }

            }
            return configDictionary;
        }

        /*
        private void loadDictionary2()
        {
            //Project64Configuration pj64cfg = new Project64Configuration();

            string readText = FileIO.FileToString(_configFilePath);
            //string pat = @"(\[.*\])(?:(?!(\n\n))(\n(.)*))*";



            string[] stringSeparators = new string[] { "\r\n\r\n" };
            var configGroups = readText.Split(stringSeparators, StringSplitOptions.None);

            string[] configLineSeparator = new string[] { "\r\n" };

            //TODO: REFACTOR
            //what i should do here is loop through all the lines, store dictionary key, value pairs. Then later I can search the dictionary for matches to 
            //settings used in the model. should be more robust

            //plugin group
            var pluginGroup = configGroups[0];
            var pluginLines = pluginGroup.Split(configLineSeparator, StringSplitOptions.None);

            Plugins.AudioDll = pluginLines[1].Split('=')[1];
            Plugins.ControllerDll = pluginLines[2].Split('=')[1];
            Plugins.GraphicsDll = pluginLines[3].Split('=')[1];
            Plugins.RspDll = pluginLines[4].Split('=')[1];

            //default group
            var defaultGroup = configGroups[1];
            var defaultLines = defaultGroup.Split(configLineSeparator, StringSplitOptions.None);

            Default.AutoFullScreen = defaultLines[1].Split('=')[1];
            Default.CurrentLanguage = defaultLines[2].Split('=')[1];


            //rom browser
            var rbGroup = configGroups[2];
            var rbLines = rbGroup.Split(configLineSeparator, StringSplitOptions.None);

            RomBrowser.Left = rbLines[1].Split('=')[1];
            RomBrowser.Maximized = rbLines[2].Split('=')[1];
            RomBrowser.SortAscending0 = rbLines[3].Split('=')[1];
            RomBrowser.SortAscending1 = rbLines[4].Split('=')[1];
            RomBrowser.SortAscending2 = rbLines[5].Split('=')[1];
            RomBrowser.SortAscending3 = rbLines[6].Split('=')[1];
            RomBrowser.SortField0 = rbLines[7].Split('=')[1];
            RomBrowser.SortField1 = rbLines[8].Split('=')[1];
            RomBrowser.SortField2 = rbLines[9].Split('=')[1];
            RomBrowser.SortField3 = rbLines[10].Split('=')[1];
            RomBrowser.Top = rbLines[11].Split('=')[1];

            //Main Window
            var mainwindowGroup = configGroups[3];
            var mainwindowLines = mainwindowGroup.Split(configLineSeparator, StringSplitOptions.None);

            MainWindow.Left = mainwindowLines[1].Split('=')[1];
            MainWindow.Top = mainwindowLines[2].Split('=')[1];

            //controller groups
            for (int i = 4; i < 8; i++)
            {
                var controllerGroup = configGroups[i];
                var controllerLines = controllerGroup.Split(configLineSeparator, StringSplitOptions.None);

                DirectInputControllerConfiguration controllerConfig = new DirectInputControllerConfiguration()
                {
                    A = controllerLines[1].Split('=')[1],
                    AnalogDown = controllerLines[2].Split('=')[1],
                    AnalogLeft = controllerLines[3].Split('=')[1],
                    AnalogRight = controllerLines[4].Split('=')[1],
                    AnalogUp = controllerLines[5].Split('=')[1],
                    B = controllerLines[6].Split('=')[1],
                    C_Down = controllerLines[7].Split('=')[1],
                    C_Left = controllerLines[8].Split('=')[1],
                    C_Right = controllerLines[9].Split('=')[1],
                    C_Up = controllerLines[10].Split('=')[1],
                    Deadzone = controllerLines[11].Split('=')[1],
                    DigitalDown = controllerLines[12].Split('=')[1],
                    DigitalLeft = controllerLines[13].Split('=')[1],
                    DigitalRight = controllerLines[14].Split('=')[1],
                    DigitalUp = controllerLines[15].Split('=')[1],
                    GUID = controllerLines[16].Split('=')[1],
                    L = controllerLines[17].Split('=')[1],
                    Present = controllerLines[18].Split('=')[1],
                    R = controllerLines[19].Split('=')[1],
                    Range = controllerLines[20].Split('=')[1],
                    Start = controllerLines[21].Split('=')[1],
                    Type = controllerLines[22].Split('=')[1],
                    Z = controllerLines[23].Split('=')[1]

                };

                Controllers.Add(controllerConfig);
            }

            //recent files;
            var recentFilesGroup = configGroups[8];
            var recentFileLines = recentFilesGroup.Split(configLineSeparator, StringSplitOptions.None);
            for (int j = 1; j < recentFileLines.Count(); j++)
            {
                RecentFiles.Add(recentFileLines[j].Split('=')[1]);
            }


            //Direct3d8
            var direct3dgroup = configGroups[9];
            var direct3dLines = direct3dgroup.Split(configLineSeparator, StringSplitOptions.None);


            Direct3D8.Anisotropic = direct3dLines[1].Split('=')[1];
            Direct3D8.DumpTextures = direct3dLines[2].Split('=')[1];
            Direct3D8.EmulateBuffer = direct3dLines[3].Split('=')[1];
            Direct3D8.ForceBlend = direct3dLines[4].Split('=')[1];
            Direct3D8.ForceCombiner = direct3dLines[5].Split('=')[1];
            Direct3D8.FullscreenHeight = direct3dLines[6].Split('=')[1];
            Direct3D8.FullscreenWidth = direct3dLines[7].Split('=')[1];
            Direct3D8.Multisample = direct3dLines[8].Split('=')[1];
            Direct3D8.SoftwareEmu = direct3dLines[9].Split('=')[1];
            Direct3D8.Vsync = direct3dLines[10].Split('=')[1];
            Direct3D8.WindowType = direct3dLines[11].Split('=')[1];

            

        }*/
        public override string ToString()
        {
            string configStr = string.Empty;
            for (int i = 0; i < _configDictionary.Count; i++)
            {
                var key = _configDictionary.ElementAt(i).Key;
                var value = _configDictionary.ElementAt(i).Value;

                if (value == "Label")
                {
                    if (i > 0)
                    {
                        configStr += "\r\n";
                    }

                    configStr += key + "\r\n";
                }
                else
                {
                    configStr += string.Format("{0}={1}\r\n", key, value);
                }
            }

            return configStr;
        }
        /*
        public override string ToString()
        {
            string output = "";
            
            //plugins
            output = string.Format(
                "[Plugin]\r\nAudio Dll Ver={0}\r\nController Dll Ver={1}\r\nGraphics Dll Ver={2}\r\nRSP Dll Ver={3}\r\n\r\n",
                Plugins.AudioDll,Plugins.ControllerDll,Plugins.GraphicsDll,Plugins.RspDll);

            //default
            output += "[default]\r\n";
            output += string.Format("Auto Full Screen={0}\r\n", Default.AutoFullScreen);
            output += string.Format("Current Language={0}\r\n\r\n", Default.CurrentLanguage);

            //Rom browser
            output += "[Rom Browser]\r\n";
            output += string.Format("Left={0}\r\n", RomBrowser.Left);
            output += string.Format("Maximized={0}\r\n", RomBrowser.Maximized);
            output += string.Format("Sort Ascending 0={0}\r\n", RomBrowser.SortAscending0);
            output += string.Format("Sort Ascending 1={0}\r\n", RomBrowser.SortAscending1);
            output += string.Format("Sort Ascending 2={0}\r\n", RomBrowser.SortAscending2);
            output += string.Format("Sort Ascending 3={0}\r\n", RomBrowser.SortAscending3);
            output += string.Format("Sort Field 0={0}\r\n", RomBrowser.SortField0);
            output += string.Format("Sort Field 1={0}\r\n", RomBrowser.SortField1);
            output += string.Format("Sort Field 2={0}\r\n", RomBrowser.SortField2);
            output += string.Format("Sort Field 3={0}\r\n", RomBrowser.SortField3);
            output += string.Format("Top={0}\r\n\r\n", RomBrowser.Top);

            //main window
            output += "[Main Window]\r\n";
            output += string.Format("Left={0}\r\n", MainWindow.Left);
            output += string.Format("Top={0}\r\n\r\n", MainWindow.Top);

            //controllers
            for (int i = 0; i < Controllers.Count; i++)
            {
                var controller = Controllers[i];

                output += string.Format("[DirectInput-Controller {0}]\r\n", i);
                output += string.Format("A={0}\r\n", controller.A);
                output += string.Format("Analog Down={0}\r\n", controller.AnalogDown);
                output += string.Format("Analog Left={0}\r\n", controller.AnalogLeft);
                output += string.Format("Analog Right={0}\r\n", controller.AnalogRight);
                output += string.Format("Analog Up={0}\r\n", controller.AnalogUp);
                output += string.Format("B={0}\r\n", controller.B);
                output += string.Format("C-Down={0}\r\n", controller.C_Down);
                output += string.Format("C-Left={0}\r\n", controller.C_Left);
                output += string.Format("C-Right={0}\r\n", controller.C_Right);
                output += string.Format("C-Up={0}\r\n", controller.C_Up);
                output += string.Format("Dead Zone={0}\r\n", controller.Deadzone);
                output += string.Format("Digital Down={0}\r\n", controller.DigitalDown);
                output += string.Format("Digital Left={0}\r\n", controller.DigitalLeft);
                output += string.Format("Digital Right={0}\r\n", controller.DigitalRight);
                output += string.Format("Digital Up={0}\r\n", controller.DigitalUp);
                output += string.Format("GUID={0}\r\n", controller.GUID);
                output += string.Format("L={0}\r\n", controller.L);
                output += string.Format("Present={0}\r\n", controller.Present);
                output += string.Format("R={0}\r\n", controller.R);
                output += string.Format("Range={0}\r\n", controller.Range);
                output += string.Format("Start={0}\r\n", controller.Start);
                output += string.Format("Type={0}\r\n", controller.Type);
                output += string.Format("Z={0}\r\n\r\n", controller.Z);
             
            }

            //recents
            output += "[Recent File]\r\n";
            for (int j = 0; j < RecentFiles.Count(); j++)
            {
                var recentFile = RecentFiles[j];
                output += string.Format("Recent Rom {0}={1}\r\n",j, recentFile);

                if ((j + 1) == RecentFiles.Count())
                {
                    output += "\r\n";
                }

            }

            //direct3d8
            output += "[Direct3D8]\r\n";
            output += string.Format("Anisotropic={0}\r\n", Direct3D8.Anisotropic); ;
            output += string.Format("DumpTextures={0}\r\n", Direct3D8.DumpTextures);
            output += string.Format("EmulateBuffer={0}\r\n", Direct3D8.EmulateBuffer);
            output += string.Format("ForceBlend={0}\r\n", Direct3D8.ForceBlend);
            output += string.Format("ForceCombiner={0}\r\n", Direct3D8.ForceCombiner);
            output += string.Format("FullscreenHeight={0}\r\n", Direct3D8.FullscreenHeight);
            output += string.Format("FullscreenWidth={0}\r\n", Direct3D8.FullscreenWidth);
            output += string.Format("Multisample={0}\r\n", Direct3D8.Multisample);
            output += string.Format("SoftwareEmu={0}\r\n", Direct3D8.SoftwareEmu);
            output += string.Format("Vsync={0}\r\n", Direct3D8.Vsync);
            output += string.Format("WindowType={0}\r\n", Direct3D8.WindowType);

            return output;
        }
     */ 
    }

    public class Direct3D8Configuration
    {
        public string Anisotropic { get; set; }
        public string DumpTextures { get; set; }
        public string EmulateBuffer { get; set; }
        public string ForceBlend { get; set; }
        public string ForceCombiner { get; set; }
        public string FullscreenHeight { get; set; }
        public string FullscreenWidth { get; set; }
        public string Multisample { get; set; }
        public string SoftwareEmu { get; set; }
        public string Vsync { get; set; }
        public string WindowType { get; set; }
    }
    public class PluginConfiguration
    {
        public string AudioDll;
        public string ControllerDll;
        public string GraphicsDll;
        public string RspDll;
    }
    public class DefaultConfiguration
    {
        private Dictionary<string, string> _configDictionary;
        public DefaultConfiguration(Dictionary<string, string> configDictionary) { _configDictionary = configDictionary; }
        public bool AutoFullScreen
        {
            get { return (_configDictionary["Auto Full Screen"]) == "1" ? true : false; }
            set { 
                _configDictionary["Auto Full Screen"] =value?"1":"0"; 
            }
        }
        public string CurrentLanguage;
    }

    public class RomBrowserConfiguration
    {
        public string Left;
        public string Maximized;
        public string SortAscending0;
        public string SortAscending1;
        public string SortAscending2;
        public string SortAscending3;
        public string SortField0;
        public string SortField1;
        public string SortField2;
        public string SortField3;
        public string Top;

    }

    public class MainWindowConfiguration
    {
        public string Left;
        public string Top;
    }

    public class DirectInputControllerConfiguration
    {
        public string A;
        public string AnalogDown;
        public string AnalogLeft;
        public string AnalogRight;
        public string AnalogUp;
        public string B;
        public string C_Down;
        public string C_Left;
        public string C_Right;
        public string C_Up;
        public string Deadzone;
        public string DigitalDown;
        public string DigitalLeft;
        public string DigitalRight;
        public string DigitalUp;
        public string GUID;
        public string L;
        public string Present;
        public string R;
        public string Range;
        public string Start;
        public string Type;
        public string Z;

    }
  
  
}
