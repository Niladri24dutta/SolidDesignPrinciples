using SolidPattern;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SolidPattern.OpenClosedPrinciple;

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

            #region Open-closed principle
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };
            var nf = new NewFilter();
            Console.WriteLine("Green products");
            var result1 = nf.Filter(products, new ColorSpecification(Color.Green));
            foreach (var i in result1)
                Console.WriteLine($" - {i.Name} is green");
            Console.WriteLine("Large products");
            var result2 = nf.Filter(products, new SizeSpecification(Size.Large));
            foreach (var i in result2)
                Console.WriteLine($" - {i.Name} is large");
            Console.WriteLine("Blue and Large products");
            var result3 = nf.Filter(products,
                new AndSpecification<Product>
                    (new ColorSpecification(Color.Blue),
                      new SizeSpecification(Size.Large)
                    )
                  );
            foreach (var i in result3)
                Console.WriteLine($" - {i.Name} is large and blue");
            Console.ReadKey();
            #endregion
            #region liskov principle
            Rectangle rec = new Rectangle(4, 3);
            var d = new Demo();
            Console.WriteLine($"the area of the rectangle {rec} is {d.Area(rec)}");
            Rectangle sq = new Square();
            sq.Width = 5;
            Console.WriteLine($"the area of the square {sq} is {d.Area(sq)}");
            Console.ReadKey();
            #endregion

            #region DI principle
            var parent = new Person("John");
            var child1 = new Person("Matt");
            var child2 = new Person("Test");

            Relationships rel = new Relationships();
            rel.AddParentAndChild(parent, child1);
            rel.AddParentAndChild(parent, child2);
            Research rs = new Research(rel);
            Console.ReadKey();
            #endregion
        }
    }
}
