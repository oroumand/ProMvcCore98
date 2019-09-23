using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Session21.TestBefore
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Windows";
            //ShwoDirectory(path);
            ShowByLinq(path);
            Console.Read();
        }

        private static void ShowByLinq(string path)
        {
            var files = Directory.GetFiles(path);
            foreach (var item in files.OrderByDescending(c=>c.Length))
            {

                Console.WriteLine(item);
            }
        }

        private static void ShwoDirectory(string path)
        {
            var files = Directory.GetFiles(path);
            List<string> s = new List<string>();
            Array.Sort(files, new stringDesending());
            //foreach (var item in files)
            //{

            //    Console.WriteLine(item);
            //}

            var enumerator = files.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
    }
    public class stringDesending : IComparer
    {
        public int Compare(object x, object y)
        {
            return 1;
        }
    }
}
