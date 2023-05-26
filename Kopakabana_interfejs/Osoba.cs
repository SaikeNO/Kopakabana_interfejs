using System;

namespace Kopakabana
{
    [Serializable()]
    class Osoba
    {
        protected string Name { get; }
        protected string Surname { get; }

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
