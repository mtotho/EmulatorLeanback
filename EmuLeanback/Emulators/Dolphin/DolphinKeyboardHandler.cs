
using EmuLeanback.Emulators.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmuLeanback.Emulators.Dolphin
{
    public class DolphinKeyboardHandler : KeyboardHandler
    {
        private Dolphin _dolphin;

        public DolphinKeyboardHandler(Dolphin dolphin)
            : base((RomLoader)dolphin.RomLoader)
        {
            _dolphin = dolphin;    
        }

        public override void KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if ((int)e.KeyCode == 65) //a
            {
            
                _romLoader.SendSave();
              

                //kill all roms
                _romLoader.KillAll();
             
            }

            if ((int)e.KeyCode == 66) //a
            {
                //send f9 which is mapped to save slot 8
                _romLoader.LoadRom(_romLoader.GetRoms()[1]);

            }

        }
    }
}
