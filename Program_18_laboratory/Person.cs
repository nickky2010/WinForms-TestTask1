using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_18_laboratory
{
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Foto { get; set; }
        public Person(string name, string surname, int age, string foto)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Foto = foto;
        }
        public Person(Person person)
        {
            Name = person.Name;
            Surname = person.Surname;
            Age = person.Age;
            Foto = person.Foto;

        }
        public override string ToString()
        {
            return Name;
        }
    }
}
