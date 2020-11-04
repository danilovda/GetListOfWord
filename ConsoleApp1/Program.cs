using Newtonsoft.Json;
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

            List<Dictionary> dictionaries = Service.GetDictionary(text);
            List<string> sentences = Service.TextToSentences(text);
            List<string> sentences2 = Service.TextToSentencesV2(text);

            List<string> list = Service.GetSentences(sentences2, "might");
            Service.SaveToFile(dictionaries);
            Service.SaveToJSON(dictionaries);

            List<Dictionary> dictionariesFromJson = Service.LoadJson(@"C:\Работа\net.json");
        }
    }
}

