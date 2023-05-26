using System.Collections.Generic;

namespace Kopakabana
{
	class Kwalifikacje
	{
		private Tabela Tabela { get; set; }
		private Sport Sport { get; set; }
		private List<Rozgrywka> listaRozgrywek = new();

        public Kwalifikacje(Sport sport, List<Druzyna> listaDruzyn, Kantorek kantorek)
		{
			Sport = sport;
            Tabela = new Tabela(listaDruzyn, sport);
			
			for (int i = 0; i < listaDruzyn.Count; i++)
			{
				for (int j = i + 1; j < listaDruzyn.Count; j++)
				{
					if (Sport is Siatkowka)
					{
						listaRozgrywek.Add(new RozgrywkaSiatkowka(listaDruzyn[i], listaDruzyn[j]));
					}
					else
					{
						listaRozgrywek.Add(new Rozgrywka(listaDruzyn[i], listaDruzyn[j]));
					}
				}
			}
		}
		public void Rozegraj()
		{
			foreach(Rozgrywka rozgrywka in listaRozgrywek)
			{
				rozgrywka.Rozegraj();
				Tabela.DodajPunkt(rozgrywka.WygranaDruzyna);
			}
		}
		public List<Druzyna> ZnajdzNajlepsze4()
		{
			return Tabela.ZnajdzNajlepsze4();
		}
    }
}
