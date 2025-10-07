using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Model;
using ConsoleApp1.View;
using ConsoleApp1.Controller;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ParaController controller = new ParaController();

            controller.Run();
        }
    }
}
