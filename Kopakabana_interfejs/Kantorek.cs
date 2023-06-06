using System;
using System.Collections.Generic;

namespace Kopakabana
{
    [Serializable()]
    class Kantorek
    {
        private List<Sedzia> listaSedziow = new();

        public Kantorek() { }
        public Kantorek(List<Sedzia> lista)
        {
            listaSedziow.AddRange(lista);
        }
        public void UsunSedziego(int index)
        {
            try
            {
                listaSedziow.RemoveAt(index);
            }
            catch (ArgumentOutOfRangeException)
            { }
            
        }

        public void DodajSedziego(Sedzia sedzia)
        {
            listaSedziow.Add(sedzia);
        }

        public List<Sedzia> GetSedziowie()
        {
            return listaSedziow;
        }
        public Kantorek GetKantorekSportu(Sport sport)
        {
            return new Kantorek(listaSedziow.FindAll(s => s.Sport == sport));
        }
        public override string ToString()
        {
            string returnValue = string.Empty;
            for (int i = 1; i <= listaSedziow.Count; i++)
            {
                returnValue += $"{i}. {listaSedziow[i]}\n";
            }

            return returnValue;
        }
    }
}