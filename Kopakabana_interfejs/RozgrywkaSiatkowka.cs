namespace Kopakabana
{
    class RozgrywkaSiatkowka : Rozgrywka
    {
        private Sedzia sedzia1, sedzia2;

        public RozgrywkaSiatkowka(Druzyna druzyna1, Druzyna druzyna2, Sedzia sedzia, Sedzia sedzia1, Sedzia sedzia2) :
            base(druzyna1, druzyna2, sedzia)
        {
            this.sedzia1 = sedzia1;
            this.sedzia2 = sedzia2;
        }

    }
}