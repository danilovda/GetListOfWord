using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Работа\net.txt");
            string tmp = Regex.Replace(text, "[^a-zA-Z ]+", "").Replace("  ", "");
            string text2 = tmp.Replace(" ", "\n");

            

            System.IO.File.WriteAllText(@"C:\Работа\net2.txt", text2);

        }
    }
}
