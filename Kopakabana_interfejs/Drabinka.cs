using System.Collections.Generic;

namespace Kopakabana
{
    class Drabinka
    {
        private Kantorek kantorekSportu;
        private Druzyna d1, d2, d3, d4;
        private Sport Sport { get; set; }
        public Druzyna? wygranaDruzyna { get; set; }
        public Drabinka(Sport sport, List<Druzyna> lista, Kantorek kantorek)
        {
            d1 = lista[0];
            d2 = lista[1];
            d3 = lista[2];
            d4 = lista[3];
            Sport = sport;
            kantorekSportu = kantorek.GetKantorekSportu(Sport);
        }

        public void Rozegraj()
        {
            /*
            Rozgrywka polfinal1, polfinal2, final;
            Console.WriteLine(Rozgrywka.WyswietlDruzyny(d1, d2));
            Console.WriteLine(kantorekSportu);

            Sedzia sedzia;

            if (Sport is Siatkowka)
            {
                sedzia = Kantorek.WybierzSedziego(kantorekSportu);
                Sedzia[] sedziowiePomocniczy = Kantorek.WybierzSedziowPomocniczych(kantorekSportu, sedzia);
                polfinal1 = new RozgrywkaSiatkowka(d1, d2, sedzia, sedziowiePomocniczy[0], sedziowiePomocniczy[1]);

                sedzia = Kantorek.WybierzSedziego(kantorekSportu);
                sedziowiePomocniczy = Kantorek.WybierzSedziowPomocniczych(kantorekSportu, sedzia);
                polfinal2 = new RozgrywkaSiatkowka(d3, d4, sedzia, sedziowiePomocniczy[0], sedziowiePomocniczy[1]);
            }
            else
            {
                sedzia = Kantorek.WybierzSedziego(kantorekSportu);
                polfinal1 = new Rozgrywka(d1, d2, sedzia);

                sedzia = Kantorek.WybierzSedziego(kantorekSportu);
                polfinal2 = new Rozgrywka(d3, d4, sedzia);
            }

            polfinal1.Rozegraj();
            polfinal2.Rozegraj();

            if(Sport is Siatkowka)
            {
                sedzia = Kantorek.WybierzSedziego(kantorekSportu);
                Sedzia[] sedziowiePomocniczy = Kantorek.WybierzSedziowPomocniczych(kantorekSportu, sedzia);
                final = new RozgrywkaSiatkowka(polfinal1.WygranaDruzyna, polfinal2.WygranaDruzyna, sedzia, sedziowiePomocniczy[0], sedziowiePomocniczy[1]);
            }
            else
            {
                sedzia = Kantorek.WybierzSedziego(kantorekSportu);
                final = new Rozgrywka(polfinal1.WygranaDruzyna, polfinal2.WygranaDruzyna, sedzia);
            }

            final.Rozegraj();
            */
        }
    }
}