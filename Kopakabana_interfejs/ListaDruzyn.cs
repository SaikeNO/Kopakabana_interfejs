using System;
using System.Collections.Generic;

namespace Kopakabana
{
	[Serializable()]
	class ListaDruzyn
	{
		private List<Druzyna> druzyny = new();

		public void DodajDruzyne(Druzyna druzyna)
		{
			druzyny.Add(druzyna);
		}

		public Druzyna UsunDruzyne(Druzyna druzyna)
		{
			druzyny.Remove(druzyna);
			return druzyna;
		}

		public List<Druzyna> GetListaDruzyn()
		{
			return druzyny;
		}
	}
}
