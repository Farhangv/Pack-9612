using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IODemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var selectedDrive = SelectDrive();
            SelectFolder(selectedDrive);

            Console.ReadKey();
        }

        private static string SelectDrive()
        {
            Console.Clear();
            var drives = DriveInfo.GetDrives();
            var index = 0;
            foreach (var drive in drives)
            {
                if (drive.IsReady)
                    Console.WriteLine($"{index++}.{drive.Name}\t{drive.TotalSize / 1073741824}GB\t{drive.TotalFreeSpace / 1073741824}GB\t{drive.VolumeLabel}\t{drive.DriveFormat}");
            }
            Console.WriteLine("_______________________");
            Console.Write("Enter Index:");
            var selectedIndex = int.Parse(Console.ReadLine());
            return drives[selectedIndex].Name;
        }

        private static void SelectFolder(string path)
        {
            Console.Clear();
            DirectoryInfo di = new DirectoryInfo(path);
            var subDirectories = di.GetDirectories();
            for (int i = 0; i < subDirectories.Length; i++)
            {
                //Console.WriteLine($"{i}.{subDirectories[i].Name}\t{subDirectories[i].FullName}");
                Console.WriteLine($"{i}.{subDirectories[i].Name}");
            }

            var files = di.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"{i + subDirectories.Length}.{files[i].Name}\t[File]");
            }
            Console.WriteLine("_______________________");
            Console.Write("Enter Index:");
            var selectedIndex = int.Parse(Console.ReadLine());
            
            if (selectedIndex < subDirectories.Length)
                SelectFolder(subDirectories[selectedIndex].FullName);
            else if (selectedIndex < subDirectories.Length + files.Length)
            {
                var filePath = files[selectedIndex - subDirectories.Length].FullName;
                if (File.Exists(filePath))
                    Process.Start(filePath);
            }

        }
    }
}
