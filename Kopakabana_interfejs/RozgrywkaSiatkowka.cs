using System;

namespace Kopakabana
{
    [Serializable()]
    public class RozgrywkaSiatkowka : Rozgrywka
    {
        public Sedzia? sedzia1 { get; set; }
        public Sedzia? sedzia2 { get; set; }
        public RozgrywkaSiatkowka(Druzyna druzyna1, Druzyna druzyna2) : base(druzyna1, druzyna2) { }

        public RozgrywkaSiatkowka(Druzyna druzyna1, Druzyna druzyna2, Sedzia sedzia, Sedzia sedzia1, Sedzia sedzia2) :
            base(druzyna1, druzyna2, sedzia)
        {
            this.sedzia1 = sedzia1;
            this.sedzia2 = sedzia2;
        }
        public override string ToString()
        {
            if (Sedzia == null || sedzia1 == null || sedzia2 == null )
            {
                return $"{druzyna1} vs {druzyna2}";
            }
            else 
            {
                return $"{druzyna1} vs {druzyna2}\nSedzia glowny: {Sedzia.Name} {Sedzia.Surname}" +
                    $"\nSedzia pomocniczy (1): {sedzia1.Name} {sedzia2.Surname}\nSedzia pomocniczy (2) {sedzia2.Name} {sedzia2.Surname}";
            }
        }

    }
}