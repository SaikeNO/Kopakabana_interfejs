using System;
using System.Collections.Generic;

namespace Kopakabana
{
    [Serializable()]
    public class Druzyna
	{
		private List<Zawodnik> zawodnicy = new();
		public string Nazwa { get; set; }

		public Druzyna(string nazwa)
		{
            Nazwa = nazwa;
		}

		public Druzyna(string nazwa, List<Zawodnik> lista)
		{
            Nazwa = nazwa;
			zawodnicy.AddRange(lista);
		}

		public void DodajZawodnika(Zawodnik zawodnik)
		{
            zawodnicy.Add(zawodnik);
		}
        public Zawodnik UsunZawodnika(Zawodnik zawodnik)
        {
            zawodnicy.Remove(zawodnik);
            return zawodnik;
        }
        public string WyswietlZawodnikow()
        {
            return string.Join("\n", zawodnicy);
        }
        public List<Zawodnik> GetZawodnicy()
        {
            return zawodnicy;
        }
        public void SetZawodnicy(List<Zawodnik> lista)
        {
            zawodnicy = lista;
        }
        public override bool Equals(Object? obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType())) return false;

            Druzyna druzyna = (Druzyna)obj;

            return string.Equals(druzyna.Nazwa, Nazwa);
        }
        public override string ToString()
        {
            return Nazwa;
        }

        public override int GetHashCode()
        {
            return Nazwa.GetHashCode();
        }
    }
}
