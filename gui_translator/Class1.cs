using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

        public void AddWord(string lang_1_word, string lang_2_word)
        {
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
