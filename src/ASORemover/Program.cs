using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ASORemover
{
    class ASORemoverProgram
    {
        const string FLASH_8 = "Flash 8";
        const string FLASH_MX_2004 = "Flash MX 2004";
        const string FLASH_MX = "Flash MX";
        
        private Arguments arguments;

        

        static string userHOMEDRIVE = System.Environment.GetEnvironmentVariable("HOMEDRIVE").Replace("\\", "\\\\");
        static string userHOMEPATH = System.Environment.GetEnvironmentVariable("HOMEPATH").Replace("\\", "\\\\");

        static string asoFilesDirectory = userHOMEDRIVE + userHOMEPATH + @"\Local Settings\Application Data\Macromedia\" + FLASH_8 + @"\en\Configuration\Classes\aso";

        
                        
        static void Main(string[] args)
        {
            int length = args.Length;
            bool invalidCommand = true;
            switch (length)
            {
                case 0:
                    
                    break;
                case 1:
                    if (args[0].IndexOf("-a") == 0)
                    {
                        DeleteAllASOFiles();
                        return;
                    }
                    break;
                case 2:
                    if (args[0].IndexOf("-p") == 0)
                    {
                        
                        Console.WriteLine("This feature is not yet implemented");
                        return;
                    }
                    break;
            }
            if (invalidCommand)
            {
                WriteUsage();
            }
            
        }

        static void DeleteAllASOFiles()
        {
            DirectoryInfo di = new DirectoryInfo(asoFilesDirectory);
            if (di.Exists)
            {
                di.Delete(true);
                Console.WriteLine(asoFilesDirectory + " deleted.");
            }
        }

        static void WriteUsage()
        {
            string usages = "Invalid Command Line: Option must be specified\n\n";
            usages += "Usage: -a | (-p <package1> <package2> .. <packageN>)\n\n";
            //usages += "Help: -v is by default 8 i.e Flash 8 IDE, you can use 6 or 7 for Flash MX or Flash MX 2004 respectively\n\n";
            usages += "Examples:-\n\n1) To remove all ASO files:\n\n\t\tASORemover -a\n\n";
            usages += "2) To remove all ASO files for specific packages package:\n\n\t\tASORemover -p com.abdulqabiz.ui.controls com.abdulqabiz.utils\n";

            Console.Write(usages);
        }
    }
}
