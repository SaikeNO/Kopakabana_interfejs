using System;
using System.Collections.Generic;

namespace Kopakabana
{
	[Serializable()]
	class Kwalifikacje
	{
		public Tabela Tabela { get; set; }
		private Sport Sport { get; set; }
		private readonly List<Rozgrywka> listaRozgrywek = new();

		public Kwalifikacje(Sport sport, ListaDruzyn listaDruzyn)
		{
			Sport = sport;
			Tabela = new Tabela(listaDruzyn.GetListaDruzyn());

			for (int i = 0; i < listaDruzyn.GetListaDruzyn().Count; i++)
			{
				for (int j = i + 1; j < listaDruzyn.GetListaDruzyn().Count; j++)
				{
					if (Sport is Siatkowka)
					{
						listaRozgrywek.Add(new RozgrywkaSiatkowka(listaDruzyn.GetListaDruzyn()[i], listaDruzyn.GetListaDruzyn()[j]));
					}
					else
					{
						listaRozgrywek.Add(new Rozgrywka(listaDruzyn.GetListaDruzyn()[i], listaDruzyn.GetListaDruzyn()[j]));
					}
				}
			}
		}

		public List<Rozgrywka> GetListaRozgrywek()
		{
			return listaRozgrywek;
		}

		public List<WierszTabeli> GetTabela()
		{
			return Tabela.GetWiersze();
		}

		public ListaDruzyn ZnajdzNajlepsze4()
		{
			return Tabela.ZnajdzNajlepsze4();
		}
		public bool CzyRozegrane()
		{
			foreach(Rozgrywka rozgrywka in listaRozgrywek)
			{
				if (rozgrywka.WygranaDruzyna is null) return false;
			}

			return true;
		}
    }
}
