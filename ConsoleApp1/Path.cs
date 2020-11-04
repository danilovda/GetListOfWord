using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Path
    {
        public Path(string path, string fileName)
        {
            this.path = path;
            this.fileName = fileName;
        }

        readonly string path;
        readonly string fileName;
        readonly string txt = ".txt";
        readonly string json = ".json";

        readonly string dictionaries = "dictionaries";
        readonly string sentences = "sentences";

        public string FullPath { get => path + fileName + txt; } 
        public string SentencesTxt { get => path + fileName + "_" + sentences + txt; } 
        public string DictionariesTxt { get => path + fileName + "_" + dictionaries + txt; }
        public string SentencesJson { get => path + fileName + "_" + sentences + json; }
        public string DictionariesJson { get => path + fileName + "_" + dictionaries + json; }
    }
}
