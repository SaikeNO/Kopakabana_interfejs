using System;
using System.Collections.Generic;

namespace Kopakabana
{
    [Serializable()]
    public class Zawodnik : Osoba, IEquatable<Zawodnik?>
    {
		public int NumerKoszulki { get; set; }

		public Zawodnik(string name, string surname, int numerKoszulki) : base(name, surname)
		{
			NumerKoszulki = numerKoszulki;
		}
        public override bool Equals(Object? obj)
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

        public bool Equals(Zawodnik? other)
        {
            return other is not null &&
                   Name == other.Name &&
                   Surname == other.Surname &&
                   NumerKoszulki == other.NumerKoszulki;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Surname, NumerKoszulki);
        }

        public static bool operator ==(Zawodnik? left, Zawodnik? right)
        {
            return EqualityComparer<Zawodnik>.Default.Equals(left, right);
        }

        public static bool operator !=(Zawodnik? left, Zawodnik? right)
        {
            return !(left == right);
        }
    }
}
