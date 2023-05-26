namespace Kopakabana
{
    class WierszTabeli 
    {
        public int Punkty { get; set; }
        public Druzyna Druzyna { get; }

        public WierszTabeli(Druzyna druzyna)
        {
            Punkty = 0;
            Druzyna = druzyna;
        }
        public void DodajPunkt() { Punkty++; }
        public override string ToString()
        {
            return $"{Punkty} {Druzyna}";
        }
    }
}
