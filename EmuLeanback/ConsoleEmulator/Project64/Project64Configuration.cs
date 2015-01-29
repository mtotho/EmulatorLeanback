using EmuLeanback.ConsoleEmulator.Code;
using EmuLeanback.ConsoleEmulator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback.ConsoleEmulator.Project64
{
    public class Project64Configuration : EmulatorConfiguration
    {
      
        private string _configFilePath;
       // private Dictionary<string, string> _configDictionary;

        private Dictionary<string, Dictionary<string, string>> _configDictionary;

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

        }

        //Load Key/value string dictionary of all the settings available
        private Dictionary<string, Dictionary<string, string>> loadDictionary()
        {
            Dictionary<string, Dictionary<string, string>> configDictionary = new Dictionary<string, Dictionary<string, string>>();
            string readText = FileIO.FileToString(_configFilePath);

            string[] configLineSeparator = new string[] { "\r\n" };

            var configLines = readText.Split(configLineSeparator, StringSplitOptions.None);
            var currentGroup = string.Empty;

            for (int i = 0; i < configLines.Length; i++)
            {
                var configLine = configLines[i];

                //Config line empty, move on
                if (configLine == string.Empty)
                {
                    continue;
                }

                //has equal sign, add key, value pair to current group
                if (configLine.Split('=').Length > 1)
                {
                    var key = configLine.Split('=')[0].Trim();
                    var value = configLine.Split('=')[1].Trim();
              
                    if (configDictionary.ContainsKey(currentGroup))
                    {
                        configDictionary[currentGroup].Add(key, value);
                    }
                }

                //Config line not empty, but no equal - group header - create new config group
                else if (configLine != string.Empty)
                {
                    currentGroup = configLine;
                    configDictionary.Add(currentGroup, new Dictionary<string, string>());
                }

            }
            return configDictionary;
        }

        public override string ToString()
        {
            string configStr = string.Empty;
          
            for (int i = 0; i < _configDictionary.Count; i++)
            {
                var configGroup = _configDictionary.ElementAt(i).Value;
                var configGroupKey = _configDictionary.ElementAt(i).Key;

                if (i > 0) //add an additional new line if we are starting a new config group (but not the first)
                {
                    configStr += "\r\n";
                }

                //add config group title
                configStr += configGroupKey + "\r\n"; 

                //add config group key,values 
                for (int k = 0; k < configGroup.Count; k++)
                {
                    var key = configGroup.ElementAt(k).Key;
                    var value = configGroup.ElementAt(k).Value;

                    configStr += string.Format("{0}={1}\r\n", key, value);
                }
            }
            return configStr;
        }//end: toString
    }//end config class

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
        private Dictionary<string, Dictionary<string, string>>_configDictionary;
     
        public DefaultConfiguration(Dictionary<string, Dictionary<string, string>> configDictionary){ _configDictionary = configDictionary; }
        public bool AutoFullScreen
        {
            get 
            { //return false if key is not present.. otherwise returnt he value
                if(!_configDictionary["[default]"].ContainsKey("Auto Full Screen"))
                    return false;
                return (_configDictionary["[default]"]["Auto Full Screen"]) == "1" ? true : false; 
            }
            set
            {   //Add setting key and set value if it doesnt exist
                if (_configDictionary.ContainsKey("[default]")) 
                {
                    if (!_configDictionary["[default]"].ContainsKey("Auto Full Screen"))
                        _configDictionary["[default]"].Add("Auto Full Screen", value ? "1" : "0");
                    else
                        _configDictionary["[default]"]["Auto Full Screen"] = value ? "1" : "0"; 
                }
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
