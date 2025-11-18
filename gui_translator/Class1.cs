using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace gui_translator
{
    internal class Translator
    {
        private Dictionary<string, string> lang_1_to_lang_2;
        private Dictionary<string, string> lang_2_to_lang_1;
        private string lang_1_name;
        private string lang_2_name;
        
        public Translator()
        {
            lang_1_to_lang_2 = new Dictionary<string, string>();
            lang_2_to_lang_1 = new Dictionary<string, string>();
            lang_1_name = "";
            lang_2_name = "";
        }
        private static string formatMultiples(string original, string append)
        {
            
            if (original[0]=='(')
            {
                original = original.Substring(1, original.Length-2);
            }
            if (original.Split('/').Contains(append))
            {
                return original;
            }
            
            return $"({original}/{append})";
        }

        public string GetLang1Name()
        {
            return lang_1_name;
        }
        public string GetLang2Name()
        {
            return lang_2_name;
        }
        

        public void AddWord(string lang_1_word, string lang_2_word)
        {
            lang_1_word = lang_1_word.ToLower();
            lang_2_word = lang_2_word.ToLower();
            if (lang_1_to_lang_2.ContainsKey(lang_1_word))
            {
                lang_1_to_lang_2[lang_1_word] = formatMultiples(lang_1_to_lang_2[lang_1_word],lang_2_word);
            }
            else { lang_1_to_lang_2.Add(lang_1_word,lang_2_word); }

            if (lang_2_to_lang_1.ContainsKey(lang_2_word))
            {
                lang_2_to_lang_1[lang_2_word] = formatMultiples(lang_2_to_lang_1[lang_2_word], lang_1_word);
            }
            else { lang_2_to_lang_1.Add(lang_2_word, lang_1_word); }
        }

        public string Translate1To2(string lang_1_string)
        {
            //regex shamelessly stolen from https://stackoverflow.com/a/6143686
            string regex;
            lang_1_string = lang_1_string.ToLower();
            //thank you https://stackoverflow.com/a/20087299 for the array sorting thing
            string[] keys = lang_1_to_lang_2.Keys.ToArray();
            Array.Sort(keys, (x, y) => x.Length.CompareTo(y.Length));
            Array.Reverse(keys);
            foreach (string s in keys)
            {
                regex = $"\\b{s}\\b";
                lang_1_string = Regex.Replace(lang_1_string, regex, lang_1_to_lang_2[s]);
            }
            return lang_1_string;
        }
        public string Translate2To1(string lang_2_string)
        {
            //regex shamelessly stolen from https://stackoverflow.com/a/6143686
            string regex;
            lang_2_string = lang_2_string.ToLower();
            //thank you https://stackoverflow.com/a/20087299 for the array sorting thing
            string[] keys = lang_2_to_lang_1.Keys.ToArray();
            Array.Sort(keys, (x, y) => x.Length.CompareTo(y.Length));
            Array.Reverse(keys);
            foreach (string s in keys)
            {
                regex = $"\\b{s}\\b";
                lang_2_string = Regex.Replace(lang_2_string, regex, lang_2_to_lang_1[s]);
            }
            return lang_2_string;
        }

        public static Translator ImportFromSS14FTL(string path)
        {
            //accent-.+-words-{n}(-\d+)? = //<-- that detects all the words to be replaced
            //accent-.+-words-replace-{n}(-\d+)? //<-- detects all words to replace them with
            Translator outt = new Translator();
            outt.lang_1_name = "english";
            
            string fullfile;
            using(StreamReader reader = new StreamReader(path))
            {
                fullfile = reader.ReadToEnd();
            }

            outt.lang_2_name = Regex.Match(fullfile, "(?<=accent-).*(?=-words-\\d+(-\\d+)? = .*)").ToString();
            bool keepgoin = true;
            List<string> testwords = new List<string>();
            List<string> testreplacements = new List<string>();
            MatchCollection tester = Regex.Matches(fullfile, $"accent-.+-words-{2}(-\\d+)? = .*");
            for (int i = 0; keepgoin ; i++)
            {
                MatchCollection words = Regex.Matches(fullfile, $"accent-.+-words-{i+1}(-\\d+)? = .*");
                MatchCollection replacements = Regex.Matches(fullfile, $"accent-.+-words-replace-{i+1}(-\\d+)? = .*");
                if (words.Count == 0)
                {
                    keepgoin = false;
                }
                else
                {
                    testwords = new List<string>();
                    testreplacements = new List<string>();
                    foreach (Match match in words)
                    {
                        string str = Regex.Replace(match.ToString(), $"accent-.+-words-{i+1}(-\\d+)? = ", "");
                        testwords.Add(str);
                    }
                    foreach (Match match in replacements)
                    {
                        testreplacements.Add(Regex.Replace(match.ToString(), $"accent-.+-words-replace-{i+1}(-\\d+)? = ", ""));
                    }
                    foreach(string word in testwords)
                    {
                        foreach (string replacement in testreplacements)
                        {
                            outt.AddWord(word, replacement);
                        }
                    }

                }
            }
            return outt;
        }

        public static Translator ImportFromCSV(string path)
        {
            Translator out_translator = new Translator();
            using(TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                string[] fields = parser.ReadFields();
                out_translator.lang_1_name = fields[0];
                out_translator.lang_2_name = fields[1];
                Dictionary<string, string> l1tol2 = new Dictionary<string, string>();
                Dictionary<string,string> l2tol1 = new Dictionary<string, string>();
                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();

                    out_translator.AddWord(fields[0], fields[1]);
                    
                }
            }

            return out_translator;
        }
    }
}
