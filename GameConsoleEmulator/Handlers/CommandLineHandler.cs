using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLeanback.Handlers
{
    public class CommandLineHandler
    {
        private string cwd;
        
        public CommandLineHandler(string base_dir)
        {
            cwd = base_dir;
        }


        public int ExecuteCommand(string command, string arguments)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = false;
            startInfo.FileName = command;
            startInfo.Arguments = string.Format("\"{0}\"",arguments);

            process.StartInfo = startInfo;
            process.Start();
            return 0;
        }

    }
}
