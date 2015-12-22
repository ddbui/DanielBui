using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeatureDemo
{
    internal class Person
    {
        string Name { get; set; }    
        int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var person = new List<Person> {new Person("Daniel", 44)};

            // New feature 1: nameof
            // New feature 2: string interpolation without using string.Format
            Console.WriteLine($"The name of my variable is {nameof(person)}");
            Console.Read();
        }
    }
}
