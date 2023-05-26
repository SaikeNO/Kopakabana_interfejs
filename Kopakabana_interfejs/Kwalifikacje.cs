using System.Collections.Generic;

namespace Kopakabana
{
	class Kwalifikacje
	{
		private Tabela Tabela { get; set; }
		private Sport Sport { get; set; }
		private List<Rozgrywka> listaRozgrywek = new();
		private Kantorek kantorekSportu;
        public Kwalifikacje(Sport sport, List<Druzyna> listaDruzyn, Kantorek kantorek)
		{
			Sedzia sedzia;
			Sport = sport;
            Tabela = new Tabela(listaDruzyn, sport);
            kantorekSportu = kantorek.GetKantorekSportu(Sport);

			/*
			for (int i = 0; i < listaDruzyn.Count; i++)
			{
				for (int j = i + 1; j < listaDruzyn.Count; j++)
				{
					Console.WriteLine(Rozgrywka.WyswietlDruzyny(listaDruzyn[i], listaDruzyn[j]));
					Console.WriteLine(kantorekSportu);

					sedzia = Kantorek.WybierzSedziego(kantorekSportu);

					if (Sport is Siatkowka)
					{
						Sedzia[] sedziowiePomocniczy = Kantorek.WybierzSedziowPomocniczych(kantorekSportu, sedzia);
						listaRozgrywek.Add(new RozgrywkaSiatkowka(listaDruzyn[i], listaDruzyn[j], sedzia, sedziowiePomocniczy[0], sedziowiePomocniczy[1]));
					}
					else
					{
						listaRozgrywek.Add(new Rozgrywka(listaDruzyn[i], listaDruzyn[j], sedzia));
					}
				}
			}
			*/
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
