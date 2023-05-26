using System.Collections.Generic;

namespace Kopakabana
{
    class Tabela
    {
        private List<WierszTabeli> wiersze = new();
        public Tabela(List<Druzyna> listaDruzyn, Sport sport)
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
        public List<Druzyna> ZnajdzNajlepsze4()
        {
            List<Druzyna> druzyny = new();

            for (int i = 0; i < 4; i++)
            {
                druzyny.Add(wiersze[i].Druzyna);
            }

            return druzyny;
        }
        public List<WierszTabeli> GetTabela()
        {
            return wiersze;
        }
        public string WyswietlTabele()
        {
            return string.Join("\n", wiersze);
        }
    }
}
