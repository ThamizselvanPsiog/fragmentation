using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.View
{
    public class ParaView
    {

        public int ShowMenu()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Paragraph File Application");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. Add paragraph to input.txt");
            Console.WriteLine("2. Split input.txt into files");
            Console.WriteLine("3. View all created files");
            Console.WriteLine("4. Display content of a file");
            Console.WriteLine("5. Defragmentation and Verification");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
                return choice;

            return 0;
        }
        public string Getparafromuser()
        {
            Console.WriteLine("Enter your Paragraph(No Length Limit!):");
            string paragraph = "";
            string line;
            while ((line = Console.ReadLine())!= "END")
            {
                paragraph += line + Environment.NewLine;
            }
            return paragraph.TrimEnd();
        }
        public int Getcharsperfile()
        {
            int chars = 0;
            do
            {
                Console.Write("Enter number of chars per file (1-10): ");
                int.TryParse(Console.ReadLine(), out chars);
            } while (chars < 1 || chars > 10);

            return chars;
        }

        public void Showmsg(string msg)
        {
            Console.WriteLine(msg);
        }

        public string Getfilenamefromuser()
        {
            Console.Write("Enter the name of the file you want to see:");
            return Console.ReadLine();
        }

        public void ShowAllFiles()
        {
            var allfiles =Directory.GetFiles("C:\\Users\\thamizselvan.thanika\\OneDrive - psiog.com\\Desktop\\Assignments","*.txt");

            if (allfiles.Length == 0)
            {
                Console.WriteLine("No output files found on Desktop");
                return;
            }
            Console.WriteLine("\nAvailable Files:");
            foreach(var file in allfiles)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
            Console.WriteLine();
        }
    }
}
