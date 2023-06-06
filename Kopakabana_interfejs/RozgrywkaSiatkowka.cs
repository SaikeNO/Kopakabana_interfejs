using System;

namespace Kopakabana
{
    [Serializable()]
    class RozgrywkaSiatkowka : Rozgrywka
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

    }
}