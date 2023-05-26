using System;

namespace Kopakabana
{
    [Serializable()]
    class Zawodnik : Osoba
	{
		public int NumerKoszulki { get; set; }

		public Zawodnik(string name, string surname, int numerKoszulki) : base(name, surname)
		{
			NumerKoszulki = numerKoszulki;
		}
        public override string ToString()
        {
            return $"{Name} {Surname} nr {NumerKoszulki}";
        }
    }
}
