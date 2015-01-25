using EmuLeanback.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback.Models.Dolphin
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
                _romLoader.KillAll();
                //string urlContents = await _currentLoader.sendKey(KEY_ESCAPE, true);


            }

        }
    }
}
