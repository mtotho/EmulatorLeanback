

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
using GameConsoleEmulator.Code;
using GameConsoleEmulator.Emulators.Dolphin;
using GameConsoleEmulator.Emulators.Project64;

namespace EmuLeanback
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private RomLoader _currentLoader;
        private KeyboardHandler _kbHandler;
        private List<GameConsole> Emus;
        public MainWindow()
        {
            Emus = new List<GameConsole>();

            InitializeComponent();
            Project64 n64 = new Project64(new ConsoleConfig(){
                        EXECUTABLE = @"C:\Emulators\Project64_2.1\Project64.exe",
                        ROOT_DIRECTORY =  @"C:\Emulators\Project64_2.1\",
                        ROM_DIRECTORY = @"C:\roms\n64\",
                        CONFIG_DIRECTORY =@"C:\Emulators\Project64_2.1\Config\"
                    });

            Dolphin dolphin = new Dolphin(new ConsoleConfig(){
                        EXECUTABLE = @"C:\Emulators\Dolphin-x64\Dolphin.exe",
                        ROOT_DIRECTORY = @"C:\Emulators\Dolphin-x64\",
                        ROM_DIRECTORY = @"C:\roms\gc\",
                        USER_DIRECTORY = @"C:\Users\Michael\Documents\Dolphin Emulator\"
                    });
            Emus.Add(n64);
            Emus.Add(dolphin);

           // List<string> n64roms =  n64.RomLoader.GetRoms();
            //List<string> dolphinRoms = dolphin.RomLoader.GetRoms();
          //  n64.RomLoader.LoadRom(n64roms[1]);

           
            var emu = Emus[1];
            emu.RomLoader.LoadRom(emu.RomLoader.GetRoms()[0]);
            //dolphin.RomLoader.LoadRom(dolphinRoms[0]);
            //currentLoader = dolphin.RomLoader;

             
         
        }

     
        void MainWindow_KeyDown(object sender, System.Windows.Forms.KeyEventHandler e)
        {
           
        }
    }
}
