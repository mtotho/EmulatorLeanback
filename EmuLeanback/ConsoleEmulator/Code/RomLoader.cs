using EmuLeanback.ConsoleEmulator.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmuLeanback.ConsoleEmulator.Code
{
    public abstract class RomLoader
    {
        protected string _romDirectory;
        protected string _executable;
        protected string _processName = string.Empty;
        protected Process _currentProcess;

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
            _currentProcess = p;
            LoadSave(3000);
            return 0;
        }

        public bool IsRunning()
        {
            Process[] proc = Process.GetProcessesByName(_processName);

            return (proc.Length > 0);
        }

        public virtual int SendSave()
        {
            return 0;
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

           
             if (p != null)
             {  
                 
                 //try sending key to main window handle
                 IntPtr ptrOBS= p.MainWindowHandle;
                 if (setForeground)
                     SetForegroundWindow(ptrOBS);
                 result3 = SendMessage(ptrOBS, WM_KEYDOWN, ((IntPtr)key), (IntPtr)0);

                
                 if (result3.ToInt32() == 0)
                 {

                     if (setForeground)
                         SetForegroundWindow(ptrOBS);

                     ptrOBS = p.Handle;
                     result3 = SendMessage(ptrOBS, WM_KEYDOWN, ((IntPtr)key), (IntPtr)0);
                 }

                 if (result3.ToInt32() == 0)
                 {
                     if (setForeground)
                         SetForegroundWindow(ptrOBS);

                     ptrOBS = new IntPtr(p.Id);
                     result3 = SendMessage(ptrOBS, WM_KEYDOWN, ((IntPtr)key), (IntPtr)0);
                 }

              

              
             }
               
            
            return result3.ToInt32();

        }
        public virtual int LoadSave() { return 0; }
        public int LoadSave(int mstimeout)
        {
            Thread.Sleep(mstimeout);
            return LoadSave();
        }
        //send key to rom process, switch to foreground
        public int sendKey(ushort key, bool switchForeGroundToProcess)
        {
              Process p = Process.GetProcessesByName(_processName).FirstOrDefault();
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
