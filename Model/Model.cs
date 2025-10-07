using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public class ParaModel
    {
        private string filepath = "C:\\Users\\thamizselvan.thanika\\OneDrive - psiog.com\\Desktop\\Assignments\\input.txt";
        private string outpath = "C:\\Users\\thamizselvan.thanika\\OneDrive - psiog.com\\Desktop\\Assignments\\output.txt";

        public ParaModel()
        {
            if (!File.Exists(filepath))
            {
                File.Create(filepath).Close();
            }
        }

        public void ResetFiles()
        {
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            if (File.Exists(outpath))
            {
                File.Delete(outpath);
            }

            string[] frag = Directory.GetFiles("C:\\Users\\thamizselvan.thanika\\OneDrive - psiog.com\\Desktop\\Assignments","*.txt");
            foreach (var file in frag)
            {
                File.Delete(file);
            }

            File.Create(filepath).Close();

            Console.WriteLine("All previous file are deleted!");
        }

        public void SavePara(string para)
        {
            File.AppendAllText(filepath, para + Environment.NewLine);
        }

        public string ReadAllContent()
        {
            return File.ReadAllText(filepath);
        }

        public void SplitIntoFiles(int count)
        {
            string allLines = ReadAllContent();

            var matches = Regex.Matches(allLines, @"\S+|\s");

            int totalfiles = (int)Math.Ceiling((double)matches.Count / count);

            int padlength = totalfiles.ToString().Length;

            int fileCount = 1;
            int curcnt = 0;
            string chunk = "";

            foreach(Match match in matches)
            {
                chunk += match.Value;
                curcnt++;

                if (curcnt == count)
                {
                    string filename = $"{fileCount.ToString().PadLeft(padlength, '0')}.txt";
                    string newFilePath = Path.Combine("C:\\Users\\thamizselvan.thanika\\OneDrive - psiog.com\\Desktop\\Assignments", filename);
                    File.WriteAllText(newFilePath, chunk);
                    fileCount++;
                    chunk = "";
                    curcnt = 0;

                }
            }
            if (!string.IsNullOrEmpty(chunk))
            {
                string filename = $"{fileCount.ToString().PadLeft(padlength, '0')}.txt";
                string newFilePath= Path.Combine("C:\\Users\\thamizselvan.thanika\\OneDrive - psiog.com\\Desktop\\Assignments", filename);
                File.WriteAllText(newFilePath,chunk);
            }
        }

        public void DisplayFileContent(string filename)
        {
            string filepath= Path.Combine("C:\\Users\\thamizselvan.thanika\\OneDrive - psiog.com\\Desktop\\Assignments",filename);

            if (File.Exists(filepath))
            {
                string content = File.ReadAllText(filepath);
                Console.WriteLine($"\n--- Contents of {filename} ---");
                Console.WriteLine(content);
                Console.WriteLine("-------------------------------\n");
            }
            else
            {
                Console.WriteLine($"\nFile '{filename}' not found on Desktop.\n");
            }

        }

        private string Normalize(string text)
        {
            return text.Replace("\r\n", "\n");
        }

        public void Defragmentfiles()
        {
            string[] files = Directory.GetFiles("C:\\Users\\thamizselvan.thanika\\OneDrive - psiog.com\\Desktop\\Assignments", "*.txt")
                .Where(f =>
                {
                    string name = Path.GetFileNameWithoutExtension(f);
                    return int.TryParse(name, out _);
                })
                .ToArray();

            if (files.Length == 0)
            {
                Console.WriteLine("No output files found to defragment");
                return;
            }

            Array.Sort(files, (a, b) =>
            {
                int nA = int.Parse(Path.GetFileNameWithoutExtension(a));
                int nB = int.Parse(Path.GetFileNameWithoutExtension(b));
                return nA.CompareTo(nB);
            });

            string finalcont = "";
            foreach(string file in files)
            {
                finalcont += File.ReadAllText(file);
            }
            File.WriteAllText(outpath, finalcont);

            Console.WriteLine("\n--- Defragmented Content ---");
            Console.WriteLine(finalcont);
            Console.WriteLine("-----------------------------\n");

            if (File.Exists(filepath))
            {
                string inputcontent = File.ReadAllText(filepath);
                if (Normalize(inputcontent) == Normalize(finalcont))
                {
                    Console.WriteLine("Defragmentation Successful!");
                }
                else
                {
                    Console.WriteLine("Defragmentation Failed");
                }
            }
            else
            {
                Console.WriteLine("Warning: input.txt not found for comparison.\n");
            }
        }
    }
}
