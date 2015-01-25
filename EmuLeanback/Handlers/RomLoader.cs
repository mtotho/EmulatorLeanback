using EmuLeanback.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmuLeanback.Handlers
{
    public abstract class RomLoader
    {
        protected string _romDirectory;
        protected string _executable;
        protected string _processName = string.Empty;

        [DllImport("user32.dll")]
        protected static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        protected static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        protected static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("User32.dll")]
        protected static extern int SetForegroundWindow(IntPtr point);
        [DllImport("user32.dll")]
        protected static extern UInt32 SendInput(UInt32 nInputs, [MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] Input[] pInputs, Int32 cbSize);

        public RomLoader()
        {

        }

        public List<string> GetRoms()
        {
            List<string> roms = new List<string>();

            var files = Directory.GetFiles(_romDirectory);
            for (int i = 0; i < files.Length; i++)
            {
                roms.Add(files[i].Split('\\').Last());
            }

            return roms;
        }

        //This works for dolphin and n64
        public virtual int LoadRom(string romFileName)
        {
            KillAll();
            string path = _romDirectory + romFileName;

            ProcessStartInfo start = new ProcessStartInfo();

            start.Arguments = string.Format("\"{0}\"", path);
            start.FileName = _executable;

            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = false;

            Process p = Process.Start(start);
            

            return 0;
        }

        public bool IsRunning()
        {
            Process[] proc = Process.GetProcessesByName(_processName);

            return (proc.Length > 0);
        }

        //send key to current window, dont switch foreground
        public int sendKey(ushort key)
        {
            return sendKey(key, false);
        }

        //send key to specific process, bool whether or not you want to switch to that window
        public int sendKey(ushort key, Process p, bool setForeground)
        {

            const uint WM_KEYDOWN = 0x100;
            const uint WM_SYSCOMMAND = 0x018;
            const uint SC_CLOSE = 0x053;
            IntPtr result3 = new IntPtr();
            
            //Process p = Process.GetProcessesByName(_processName).First();
             if (p != null)
             {
                 IntPtr ptrOBS= p.MainWindowHandle;
                 if (ptrOBS.ToInt64() != 0)
                 {
                     if(setForeground)
                        SetForegroundWindow(ptrOBS);
                 }

                 result3 = SendMessage(ptrOBS, WM_KEYDOWN, ((IntPtr)key), (IntPtr)0);

             }
               
            
            return result3.ToInt32();

        }

        //send key to rom process, switch to foreground
        public int sendKey(ushort key, bool switchForeGroundToProcess)
        {
              Process p = Process.GetProcessesByName(_processName).First();
              return sendKey(key, p, switchForeGroundToProcess);
        }

        //stop all project 64 processes. Will block until all finished
        public int KillAll()
        {
            if (_processName == string.Empty)
                throw new Exception("Process name not set");

            Process[] proc = Process.GetProcessesByName(_processName);

            for (int i = 0; i < proc.Length; i++)
            {
                proc[i].Kill();
                proc[i].WaitForExit();
            }

            return 1;
        }
    }
}
