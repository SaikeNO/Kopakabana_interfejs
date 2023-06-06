using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Kopakabana
{
	[Serializable()]
	public class ListaDruzyn
	{
		private List<Druzyna> druzyny = new();

		public void DodajDruzyne(Druzyna druzyna)
		{
			if(!druzyny.Contains(druzyna)) 
			{
				druzyny.Add(druzyna);
			}
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

		public int RozmiarListy()
		{
			return druzyny.Count;
		}
		public void Clear()
		{
			druzyny.Clear();
		}
	}
}
