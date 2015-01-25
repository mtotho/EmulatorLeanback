using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback.Models.Project64
{
    public class Project64Configuration : EmulatorConfiguration
    {
      
        public PluginConfiguration Plugins;
        public DefaultConfiguration Default;
        public RomBrowserConfiguration RomBrowser;
        public MainWindowConfiguration MainWindow;
        public List<DirectInputControllerConfiguration> Controllers;
        public List<string> RecentFiles;
        public Direct3D8Configuration Direct3D8;

        public Project64Configuration()
        {
            Plugins = new PluginConfiguration();
            Default = new DefaultConfiguration();
            RomBrowser = new RomBrowserConfiguration();
            MainWindow = new MainWindowConfiguration();
            Controllers = new List<DirectInputControllerConfiguration>();
            RecentFiles = new List<string>();
            Direct3D8 = new Direct3D8Configuration();

        }

        public override string ToString()
        {
            string output = "";
            
            //plugins
            output = string.Format(
                "[Plugin]\r\nAudio Dll Ver={0}\r\nController Dll Ver={1}\r\nGraphics Dll Ver={2}\r\nRSP Dll Ver={3}\r\n\r\n",
                Plugins.AudioDll,Plugins.ControllerDll,Plugins.GraphicsDll,Plugins.RspDll);

            //default
            output += "[default]\r\n";
            output += string.Format("Auto Full Screen={0}\r\n", Default.AutoFullScreen);
            output += string.Format("Current Language={0}\r\n\r\n", Default.CurrentLanguage);

            //Rom browser
            output += "[Rom Browser]\r\n";
            output += string.Format("Left={0}\r\n", RomBrowser.Left);
            output += string.Format("Maximized={0}\r\n", RomBrowser.Maximized);
            output += string.Format("Sort Ascending 0={0}\r\n", RomBrowser.SortAscending0);
            output += string.Format("Sort Ascending 1={0}\r\n", RomBrowser.SortAscending1);
            output += string.Format("Sort Ascending 2={0}\r\n", RomBrowser.SortAscending2);
            output += string.Format("Sort Ascending 3={0}\r\n", RomBrowser.SortAscending3);
            output += string.Format("Sort Field 0={0}\r\n", RomBrowser.SortField0);
            output += string.Format("Sort Field 1={0}\r\n", RomBrowser.SortField1);
            output += string.Format("Sort Field 2={0}\r\n", RomBrowser.SortField2);
            output += string.Format("Sort Field 3={0}\r\n", RomBrowser.SortField3);
            output += string.Format("Top={0}\r\n\r\n", RomBrowser.Top);

            //main window
            output += "[Main Window]\r\n";
            output += string.Format("Left={0}\r\n", MainWindow.Left);
            output += string.Format("Top={0}\r\n\r\n", MainWindow.Top);

            //controllers
            for (int i = 0; i < Controllers.Count; i++)
            {
                var controller = Controllers[i];

                output += string.Format("[DirectInput-Controller {0}]\r\n", i);
                output += string.Format("A={0}\r\n", controller.A);
                output += string.Format("Analog Down={0}\r\n", controller.AnalogDown);
                output += string.Format("Analog Left={0}\r\n", controller.AnalogLeft);
                output += string.Format("Analog Right={0}\r\n", controller.AnalogRight);
                output += string.Format("Analog Up={0}\r\n", controller.AnalogUp);
                output += string.Format("B={0}\r\n", controller.B);
                output += string.Format("C-Down={0}\r\n", controller.C_Down);
                output += string.Format("C-Left={0}\r\n", controller.C_Left);
                output += string.Format("C-Right={0}\r\n", controller.C_Right);
                output += string.Format("C-Up={0}\r\n", controller.C_Up);
                output += string.Format("Dead Zone={0}\r\n", controller.Deadzone);
                output += string.Format("Digital Down={0}\r\n", controller.DigitalDown);
                output += string.Format("Digital Left={0}\r\n", controller.DigitalLeft);
                output += string.Format("Digital Right={0}\r\n", controller.DigitalRight);
                output += string.Format("Digital Up={0}\r\n", controller.DigitalUp);
                output += string.Format("GUID={0}\r\n", controller.GUID);
                output += string.Format("L={0}\r\n", controller.L);
                output += string.Format("Present={0}\r\n", controller.Present);
                output += string.Format("R={0}\r\n", controller.R);
                output += string.Format("Range={0}\r\n", controller.Range);
                output += string.Format("Start={0}\r\n", controller.Start);
                output += string.Format("Type={0}\r\n", controller.Type);
                output += string.Format("Z={0}\r\n\r\n", controller.Z);
             
            }

            //recents
            output += "[Recent File]\r\n";
            for (int j = 0; j < RecentFiles.Count(); j++)
            {
                var recentFile = RecentFiles[j];
                output += string.Format("Recent Rom {0}={1}\r\n",j, recentFile);

                if ((j + 1) == RecentFiles.Count())
                {
                    output += "\r\n";
                }

            }

            //direct3d8
            output += "[Direct3D8]\r\n";
            output += string.Format("Anisotropic={0}\r\n", Direct3D8.Anisotropic); ;
            output += string.Format("DumpTextures={0}\r\n", Direct3D8.DumpTextures);
            output += string.Format("EmulateBuffer={0}\r\n", Direct3D8.EmulateBuffer);
            output += string.Format("ForceBlend={0}\r\n", Direct3D8.ForceBlend);
            output += string.Format("ForceCombiner={0}\r\n", Direct3D8.ForceCombiner);
            output += string.Format("FullscreenHeight={0}\r\n", Direct3D8.FullscreenHeight);
            output += string.Format("FullscreenWidth={0}\r\n", Direct3D8.FullscreenWidth);
            output += string.Format("Multisample={0}\r\n", Direct3D8.Multisample);
            output += string.Format("SoftwareEmu={0}\r\n", Direct3D8.SoftwareEmu);
            output += string.Format("Vsync={0}\r\n", Direct3D8.Vsync);
            output += string.Format("WindowType={0}\r\n", Direct3D8.WindowType);

            return output;
        }
      
    }

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
        public string AutoFullScreen;
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
