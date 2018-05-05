using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPattern
{
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
        public Person(string n)
        {
            Name = n;
        }
    }

    //create interface for DI
    public interface IRelationshipBrowser<T>
    {
        IEnumerable<T> FindAllChildrenOf(string name);
    }

    public class Relationships : IRelationshipBrowser<Person> // low-level
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>(); //create new tuple

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }


        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return relations
              .Where(x => x.Item1.Name == name
                          && x.Item2 == Relationship.Parent).Select(r => r.Item3);
        }
    }

    public class Research
    {
        public Research()
        {

        }
        /* as per DI principle only interface should be passed instead of concrete class such that it it loosely coupled
         * with the underlying mechanism */
        public Research(IRelationshipBrowser<Person> re)
        {
            foreach (var p in re.FindAllChildrenOf("John"))
            {
                Console.WriteLine($"John has a child named {p.Name}");
            }
        }
    }
}
