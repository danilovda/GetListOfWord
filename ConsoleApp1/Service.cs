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

        public static List<string> TextToSentencesOld(string text)
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

        public static List<string> TextToSentences(string text) 
        {
            string tmp = text.Replace("\r\n", " ").Replace("•", " ");
            string[] sentences = Regex.Split(tmp, @"(?<=[\.!•\?])\s+");

            return sentences.ToList();
        }

        public static List<string> GetSentences(List<string> list, string text) =>
            list.Where(p => p.Contains(text)).ToList();

        public static void SaveToFile<T>(List<T> list, string path)
        {
            using (StreamWriter file =
            new StreamWriter(path))
            {
                foreach (var item in list)
                {
                    file.WriteLine(item.ToString());
                }
            }
        }

        public static void SaveToJson<T>(List<T> list, string path)
        {
            string json = JsonConvert.SerializeObject(list.ToArray());
            File.WriteAllText(path, json);
        }

        public static List<T> LoadJson<T>(string text)
        {
            List<T> items = null;
            using (StreamReader r = new StreamReader(text))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<T>>(json);
            }
            return items;
        }

    }
}
