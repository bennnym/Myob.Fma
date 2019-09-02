
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Myob.Fma.Mopping
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Order("4of Fo1r pe6ople g3ood th5e the2"));
            

        }
        
        public static string Order(string words)
        {
           if (string.IsNullOrWhiteSpace(words)) return string.Empty;

           var wordList = words.Split(" ").ToList();

           var orderedList = new List<string>();

           for (int i = 1; i <= wordList.Count; i++)
           {
               var numerIAmLookingFor = i.ToString();

               var foundWord = wordList.Find(w => w.Contains(numerIAmLookingFor));
               
               orderedList.Add(foundWord);
           }

           return string.Join(" ", orderedList);

        }

  
        

    }
}