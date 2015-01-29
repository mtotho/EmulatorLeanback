using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback.ConsoleEmulator.Code
{
    public class ConsoleConfig
    {
     
        public string EXECUTABLE { get; set; }
        public string ROOT_DIRECTORY { get; set; }
        public string ROM_DIRECTORY { get; set; }
        public string USER_DIRECTORY { get; set; }
        public string CONFIG_DIRECTORY { get; set; }
        public ConsoleConfig() { }
    }
}
