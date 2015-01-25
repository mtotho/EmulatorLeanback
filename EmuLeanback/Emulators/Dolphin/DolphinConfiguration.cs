using EmuLeanback.Emulators.Code;
using EmuLeanback.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback.Emulators.Dolphin
{
    public class DolphinConfiguration : IGameConsoleConfiguration
    {
        private Dictionary<string,string> _configDictionary;
        private string _configFilePath;

        public DisplayConfiguration Display;
        public HotkeyConfiguration Hotkeys;




        public DolphinConfiguration(string configPath)
        {
            _configFilePath = configPath;
            _configDictionary=loadDictionary();
            Hotkeys = new HotkeyConfiguration(_configDictionary);

            Display = new DisplayConfiguration(_configDictionary);

        }

        public void SetConfigDictionary(Dictionary<string,string> dict)
        {
            _configDictionary = dict;

           // applyConfigFromDictionary();
        }

      
        public override string ToString()
        {
            string configStr = string.Empty;
            for (int i = 0; i < _configDictionary.Count; i++)
            {
                var key = _configDictionary.ElementAt(i).Key;
                var value = _configDictionary.ElementAt(i).Value;

                if (value == "Label")
                {
                    configStr += key + "\r\n";
                }
                else
                {
                    configStr += string.Format("{0} = {1}\r\n", key, value);
                }
            }

            return configStr;
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

                if (configLine.Split('=').Length > 1)
                {
                    var key = configLine.Split('=')[0].Trim();
                    var value = configLine.Split('=')[1].Trim();
                    if (! configDictionary.ContainsKey(key))
                        configDictionary.Add(key,value);
                }
                else if (configLine != string.Empty)
                {
                    configDictionary.Add(configLine, "Label");
                }

            }
            return configDictionary;
        }

    }


    public class DisplayConfiguration{
        private Dictionary<string, string> _configDictionary;
        public DisplayConfiguration(Dictionary<string, string> configDictionary) { _configDictionary = configDictionary; }
        public bool Fullscreen
        {
            get
            {
                return _configDictionary["Fullscreen"] == "True" ? true : false;
            }
            set
            {
                _configDictionary["Fullscreen"] = value.ToString();
            }
        }
    }

    public class HotkeyConfiguration
    {
        private Dictionary<string, string> _configDictionary;
        public HotkeyConfiguration(Dictionary<string, string> configDictionary) { _configDictionary = configDictionary; }
        public enum KEYS{
            F9 = 348
        }
        public int SaveStateSlot8
        {
            get
            {
                return Int32.Parse(_configDictionary["SaveStateSlot8"]);
            }
            set
            {
                _configDictionary["SaveStateSlot8"] = value.ToString();
            }
        }
        public int SaveStateSlot8Modifier 
        {
            get{ return Int32.Parse(_configDictionary["SaveStateSlot8Modifier "]); }
            set{ _configDictionary["SaveStateSlot8Modifier "] =  value.ToString();}
        }

    }
}
