using System;

namespace Kopakabana
{
    [Serializable()]
    public class Sedzia : Osoba
    {
		public Sport Sport { get; set; }

        public Sedzia(string name, string surname, Sport sport) : base(name, surname)
        {
            Sport = sport;
        }
        public override string ToString()
        {
            return $"{Name} {Surname}, Sport {Sport}";
        }
    }
}
