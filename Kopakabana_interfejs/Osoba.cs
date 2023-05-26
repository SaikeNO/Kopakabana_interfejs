using System;

namespace Kopakabana
{
    [Serializable()]
    class Osoba
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Osoba(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
