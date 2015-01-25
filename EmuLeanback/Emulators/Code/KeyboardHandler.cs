using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmuLeanback.Emulators.Code
{
    public class KeyboardHandler
    {
        protected RomLoader _romLoader;
        public const ushort KEY_ESCAPE = 0x1B;
        public const ushort KEY_ENTER = 0x0D;
        public const ushort KEY_SPACE = 0x20;
        public const ushort KEY_F5 = 0x74;
        public const ushort KEY_F7 = 0x76;
        public const ushort KEY_F8 = 0x77;
        public const ushort KEY_F9 = 0x78;
       
        public KeyboardHandler(RomLoader loader)
        {
            _romLoader = loader;
        }

        public virtual void KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) { }
    }
}
