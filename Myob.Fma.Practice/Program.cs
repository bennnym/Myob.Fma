using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Myob.Fma.Practice.ExtensionMethods;

namespace Myob.Fma.Practice
{
    class Program
    {
        static void Main(string[] args)
        {

            var date = "1 March";

            var reveresed = string.Join(" ",date.Split(" ").Reverse());

            Console.WriteLine(reveresed);
//            try
//            {
//                var word = "11 March";
//                var splitword = word.Split(" ");
//
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("you broke it");
//                throw;
//            }
//            finally
//            {
//                Console.WriteLine("still executed");
//            }


//            var dateTime = DateTime.Now;
//            Console.WriteLine(dateTime.Kind);
//            
//            Console.WriteLine(dateTime);
//
//            var utcNow = DateTime.UtcNow;
//            Console.WriteLine(utcNow.Kind);
//            Console.WriteLine(utcNow);
//            
//            var unsepcifiedTime = new DateTime(2019,11,11,11,11,11);
//            Console.WriteLine(unsepcifiedTime);
//            Console.WriteLine(unsepcifiedTime.Kind);
//
//            
//            Console.WriteLine(dateTime.ToUniversalTime());
//            Console.WriteLine(unsepcifiedTime.ToUniversalTime());
//
//            Console.WriteLine(dateTime.ToString(format:"f"));
        }
    }
}