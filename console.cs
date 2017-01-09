using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransfer
{
    class Program
    {
        private static string destSource;
        public static bool running;


        static void Main(string[] args)
        {


            int num = 0;
            running = true;

            {

                Console.WriteLine("These files are new or modified:");
                ModifiedFiles newFiles = new ModifiedFiles();
                num = 0;
                destSource = @"C:\Folder B";
                foreach (var file in newFiles.modified())
                {
                    Console.WriteLine("\"" + file + "\"");
                    num++;


                    File.Copy(file.FullName, Path.Combine(destSource, file.Name), true);
                    num++;


                    Console.WriteLine("{0} file(s) transfered.", num);

                }



            }

        }


    }
    class ModifiedFiles
    {
        public string sourceDir;
        public IEnumerable<FileInfo> modified()
        {
            sourceDir = @"C:\Folder A";
            var directory = new DirectoryInfo(sourceDir);
            DateTime from_date = DateTime.Now.AddDays(-1);
            DateTime to_date = DateTime.Now;
            var files = directory.GetFiles()
              .Where(file => file.LastWriteTime >= from_date && file.LastWriteTime <= to_date);
            return files.ToList();
        }
    }
}
