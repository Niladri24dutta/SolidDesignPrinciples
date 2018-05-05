using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Demo for single responsibility principle , each class has their own responsibility */

namespace Solidpattern
{
    //Journal class created for add/remove journal entries
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string txt)
        {
            entries.Add($"{++count}: {txt}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }


    }

    // Persistance class created for saving journals
    public class Persistance
    {
        public void SaveFile(Journal j, string fileName, bool overRide = false)
        {
            if (overRide || !File.Exists(fileName))
                File.WriteAllText(fileName, j.ToString());
        }
    }
    class SingleResponsibility
    {
        public static void Main(string[] args)
        {
            #region Single responsibility
            var j = new Journal();
            j.AddEntry("hi");
            j.AddEntry("hello world");
            Console.WriteLine(j);
            //Console.ReadKey();
            var p = new Persistance();
            string fileName = @"C:\LOG\test.txt";
            p.SaveFile(j, fileName, true);
            Process.Start(fileName);
            #endregion

            
        }
    }
}
