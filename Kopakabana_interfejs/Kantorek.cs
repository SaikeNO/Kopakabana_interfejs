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
            listaSedziow.RemoveAt(index);
            
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
        /*
        public static Sedzia WybierzSedziego(Kantorek kantorek)
        {
            
            int sedziaIndex = 0;
            while (sedziaIndex > kantorek.GetSedziowie().Count || sedziaIndex <= 0)
            {
                Console.Write("Wybierz Sedziego glownego > ");
                sedziaIndex = Convert.ToInt32(Console.ReadLine());
            }
            return kantorek.GetSedziowie()[sedziaIndex];
            
         }

        public static Sedzia[] WybierzSedziowPomocniczych(Kantorek kantorek, Sedzia sedziaGlowny)
            {
                Sedzia[] sedziowie = new Sedzia[2];

                int sedziaPom1Index = 0;
                while (sedziaPom1Index > kantorek.GetSedziowie().Count || sedziaPom1Index <= 0 || kantorek.GetSedziowie()[sedziaPom1Index - 1].Equals(sedziaGlowny))
                {
                    Console.Write("Wybierz pierwszego Sedziego pomocniczego > ");
                    sedziaPom1Index = Convert.ToInt32(Console.ReadLine());

                    if (kantorek.GetSedziowie()[sedziaPom1Index - 1].Equals(sedziaGlowny))
                        Console.WriteLine("Sedzia pomocniczy nie moze byc jednoczesnie Sedzia glownym");
                }

                int sedziaPom2Index = 0;
                while (sedziaPom2Index > kantorek.GetSedziowie().Count || sedziaPom2Index <= 0 || kantorek.GetSedziowie()[sedziaPom2Index - 1].Equals(sedziaGlowny) || sedziaPom1Index == sedziaPom2Index)
                {
                    Console.Write("Wybierz drugiego Sedziego pomocniczego > ");
                    sedziaPom2Index = Convert.ToInt32(Console.ReadLine());

                    if (kantorek.GetSedziowie()[sedziaPom2Index - 1].Equals(sedziaGlowny))
                        Console.WriteLine("Sedzia pomocniczy nie moze byc jednoczesnie Sedzia glownym");
                    else if (sedziaPom2Index == sedziaPom1Index)
                        Console.WriteLine("Pierwszy Sedzia pomocniczy nie moze byc jednoczesnie drugim Sedzia pomocniczym");
                }

                return sedziowie;
            }
        }
        */
    }
}