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
            string path = @"C:\Работа\";
            string text = System.IO.File.ReadAllText(path + "net.txt");

            List<Dictionary> dictionaries = Service.GetDictionary(text);            
            List<string> sentences = Service.TextToSentences(text);
            
            Service.SaveToFile(dictionaries, path + "net_dictionary.txt");
            Service.SaveToFile(sentences, path + "net_sentences.txt" );

            Service.SaveToJson(dictionaries, path + "net_dictionaries.json");
            Service.SaveToJson(sentences, path + "net_sentences.json");
            
            List<Dictionary> dictionariesFromJson = Service.LoadJson<Dictionary>(path + "net_dictionaries.json");
            List<string> sentencesFromJson = Service.LoadJson<string>(path + "net_sentences.json");

            List<string> list = Service.GetSentences(sentences, "might");
        }
    }
}

