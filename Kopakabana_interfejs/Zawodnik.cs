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
        public override bool Equals(Object obj)
        {
            if (obj is not Zawodnik) return false;

            Zawodnik zawodnik = (Zawodnik)obj;
            if (zawodnik.Name == Name && zawodnik.Surname == Surname && zawodnik.NumerKoszulki == NumerKoszulki) return true;
            else return false;
        }
        public override string ToString()
        {
            return $"{Name} {Surname} nr {NumerKoszulki}";
        }
    }
}
