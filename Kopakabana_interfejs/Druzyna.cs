using System;
using System.Collections.Generic;

namespace Kopakabana
{
	class Druzyna
	{
		private List<Zawodnik> zawodnicy = new();
		private string Nazwa { get; set; }

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
        public override string ToString()
        {
            return Nazwa;
        }
    }
}
