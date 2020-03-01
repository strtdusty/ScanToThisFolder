using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanToThisFolder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() < 1)
            {
                RegistryKey shell = Registry.ClassesRoot.CreateSubKey(@"Directory\shell\scantothisfolder", true);
                shell.SetValue("", "Scan to this folder");
                shell = Registry.ClassesRoot.CreateSubKey(@"Directory\shell\scantothisfolder\command", true);
                shell.SetValue("", string.Format("{0} \"%L\"", System.Reflection.Assembly.GetEntryAssembly().Location));
            }
            else
            {
                PFUScanner p = new PFUScanner();
                RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\PFU\ScanToOffice\History\Folder", true);
                reg.SetValue("Folder0", args[0]);
                p.scan();
            }
        }
    }
}
