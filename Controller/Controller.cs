using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Model;
using ConsoleApp1.View;

namespace ConsoleApp1.Controller
{
    class ParaController
    {
        private ParaModel model;
        private ParaView view;

        public ParaController()
        {
            model = new ParaModel();
            view = new ParaView();
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                int choice = view.ShowMenu();
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        model.ResetFiles();
                        string para = view.Getparafromuser();
                        model.SavePara(para);
                        view.Showmsg("Paragraph added to input.txt successfully");
                        break;
                    case 2:
                        int charsperfile = view.Getcharsperfile();
                        model.SplitIntoFiles(charsperfile);
                        view.Showmsg("Input file is split into multiple files successfully!!");
                        break;
                    case 3:
                        view.ShowAllFiles();
                        break;
                    case 4:
                        string filename = view.Getfilenamefromuser();
                        model.DisplayFileContent(filename);
                        break;
                    case 5:
                        model.Defragmentfiles();
                        break;
                    case 6:
                        running = false;
                        view.Showmsg("Exiting...Bye!");
                        break;
                    default:
                        view.Showmsg("Invalid choice. Please try again.\n");
                        break;
                }
            }
        }
    }
}
