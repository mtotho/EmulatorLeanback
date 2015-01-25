using EmuLeanback.Emulators.Code;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmuLeanback.Emulators.Project64
{
    public class Project64RomLoader : RomLoader
    {
       
  

        public Project64RomLoader()
        {
            _romDirectory = config.N64.ROM_DIRECTORY;
            _executable = config.N64.EXECUTABLE;
            _processName = "Project64";
        }


        public override int SendSave()
        {
            //send f9 which is mapped to save slot 8
            sendKey(KeyboardHandler.KEY_F5, true);
            //sleep for just under a second to allow state to save
            Thread.Sleep(1000);
            return 0;

        }

        public override int LoadSave()
        {
            if (_currentProcess != null)
            {
                if (_currentProcess.MainWindowHandle.ToInt32() > 0)
                {
                    //SetForegroundWindow(_currentProcess.MainWindowHandle);
                }
                else
                {
                   // SetForegroundWindow(_currentProcess.Handle);
                }
            }
                
            sendKey(KeyboardHandler.KEY_F7, true);

            return 0;

        }
     
    }

}
