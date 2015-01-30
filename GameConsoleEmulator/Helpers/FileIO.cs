using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsoleEmulator.Helpers
{
    public static class FileIO
    {
        public static string FileToString(string filepath)
        {
            StringBuilder filestr = new StringBuilder();
            try
            {
                using (var fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                {
                    String line = sr.ReadToEnd();
                    filestr.AppendLine(line);
                    // Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);

                return string.Empty;
            }

            return filestr.ToString();
        }

    }
}
