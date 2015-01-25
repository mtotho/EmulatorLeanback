using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback.Handlers
{
    public class Project64RomLoader : RomLoader
    {
       
  

        public Project64RomLoader()
        {
            _romDirectory = config.N64.ROM_DIRECTORY;
            _executable = config.N64.EXECUTABLE;
            _processName = "Project64";
        }

     
   
    }

}
