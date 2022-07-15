using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFile = @"C:\Users\Guti\Documents\GitHub\HangMan\words.txt"; //local path
            string lines = File.ReadAllText(textFile);

            lines = Regex.Replace(lines, ",", String.Empty);
            lines = Regex.Replace(lines, "\\n", String.Empty);

            //Console.WriteLine(lines);

            string[] words = lines.Split(' ');//Split() Split(' ')  Actual number of words
            Console.WriteLine(words.Count()); // 915      912               933
                                              //WHY?
        }
    }
}
