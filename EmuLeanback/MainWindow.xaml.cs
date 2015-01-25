
using EmuLeanback.Emulators.Code;
using EmuLeanback.Emulators.Dolphin;
using EmuLeanback.Emulators.Project64;
using EmuLeanback.Helpers;
using Gma.UserActivityMonitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmuLeanback
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private RomLoader _currentLoader;
        private KeyboardHandler _kbHandler;
        private List<ConsoleEmulator> Emus;
        public MainWindow()
        {
            Emus = new List<ConsoleEmulator>();

            InitializeComponent();
            Project64 n64 = new Project64();
            Dolphin dolphin = new Dolphin();
            Emus.Add(n64);
            Emus.Add(dolphin);

           // List<string> n64roms =  n64.RomLoader.GetRoms();
            //List<string> dolphinRoms = dolphin.RomLoader.GetRoms();
          //  n64.RomLoader.LoadRom(n64roms[1]);

           
            var emu = Emus[0];
            emu.RomLoader.LoadRom(emu.RomLoader.GetRoms()[0]);
            //dolphin.RomLoader.LoadRom(dolphinRoms[0]);
            //currentLoader = dolphin.RomLoader;


//            HookManager.KeyDown += dolphin.KBHandler.KeyDown;
         
        }

     
        void MainWindow_KeyDown(object sender, System.Windows.Forms.KeyEventHandler e)
        {
           
        }
    }
}
