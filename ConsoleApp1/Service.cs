using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Service
    {
        public static List<Dictionary> GetDictionary(string text)
        {
            string tmp = Regex.Replace(text, "[^a-zA-Z ]+", "").Replace("  ", "").ToLower();
            return tmp
                .Split(' ')
                .GroupBy(p => p)
                .Select(g => new Dictionary { Name = g.Key, Count = g.Count() })
                .OrderByDescending(t => t.Count).ToList();
        }

        public static List<string> TextToSentences(string text)
        {
            string tmp = text
                .Replace("\r\n", ".");
            //    .Replace("\n", "")
            //    .Replace("• ", "");

            return tmp
                .Split('.')
                .Where(p => p != "")
                .ToList();
        }

        public static List<string> TextToSentencesV2(string text) 
        {
            string tmp = text.Replace("\r\n", " ").Replace("•", " ");
            string[] sentences = Regex.Split(tmp, @"(?<=[\.!•\?])\s+");

            return sentences.ToList();
        }

        public static List<string> GetSentences(List<string> list, string text) =>
            list.Where(p => p.Contains(text)).ToList();

        public static void SaveToFile(List<Dictionary> dictionaries)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Работа\net_line.txt"))
            {
                foreach (var item in dictionaries)
                {
                    file.WriteLine($"{item.Name} {item.Count}");
                }
            }
        }

        public static void SaveToJSON(List<Dictionary> dictionaries)
        {
            string json = JsonConvert.SerializeObject(dictionaries.ToArray());
            System.IO.File.WriteAllText(@"C:\Работа\net_json.txt", json);
        }
    }
}
