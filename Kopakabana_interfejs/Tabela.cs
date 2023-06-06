using System;
using System.Collections.Generic;

namespace Kopakabana
{
    [Serializable()]
    class Tabela
    {
        private readonly List<WierszTabeli> wiersze = new();
        public Tabela(List<Druzyna> listaDruzyn)
        {
            foreach (Druzyna druzyna in listaDruzyn)
            {
                wiersze.Add(new WierszTabeli(druzyna));
            }
        }
        public void DodajPunkt(Druzyna? druzyna)
        {
            if (druzyna == null) return;

            foreach (WierszTabeli wiersz in wiersze)
            {
                if (druzyna == wiersz.Druzyna) wiersz.DodajPunkt();
            }
        }
        public void Sortuj()
        {
            wiersze.Sort((a, b) => b.Punkty.CompareTo(a.Punkty));
        }
        public ListaDruzyn ZnajdzNajlepsze4()
        {
            ListaDruzyn listaDruzyn = new();

            for (int i = 0; i < 4; i++)
            {
                listaDruzyn.DodajDruzyne(wiersze[i].Druzyna);
            }

            return listaDruzyn;
        }
        public List<WierszTabeli> GetWiersze()
        {
            return wiersze;
        }
        public override string ToString()
        {
            return string.Join("\n", wiersze);
        }
    }
}
