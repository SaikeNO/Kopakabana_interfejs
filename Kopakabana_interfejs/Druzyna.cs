using System;
using System.Collections.Generic;

namespace Kopakabana
{
    [Serializable()]
    class Druzyna
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
        public override string ToString()
        {
            return Nazwa;
        }
    }
}
