using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            Path path = new Path(@"C:\Работа\", "net");

            string text = File.ReadAllText(path.FullPath);

            List<Dictionary> dictionaries = Service.GetDictionary(text);            
            List<string> sentences = Service.TextToSentences(text);
            
            Service.SaveToFile(dictionaries, path.DictionariesTxt);
            Service.SaveToFile(sentences, path.SentencesTxt);

            Service.SaveToJson(dictionaries, path.DictionariesJson);
            Service.SaveToJson(sentences, path.SentencesJson);
            
            List<Dictionary> dictionariesFromJson = Service.LoadJson<Dictionary>(path.DictionariesJson);
            List<string> sentencesFromJson = Service.LoadJson<string>(path.SentencesJson);

            List<string> list = Service.GetSentences(sentences, "might");
        }
    }
}

