namespace Kopakabana
{
    public class Rozgrywka
    {
        private Druzyna druzyna1, druzyna2;
        public Druzyna? WygranaDruzyna { get; set; }
        public Sedzia? Sedzia { get; set; }
        
        public Rozgrywka(Druzyna druzyna1, Druzyna druzyna2)
        {
            this.druzyna1 = druzyna1;
            this.druzyna2 = druzyna2;
        }
        public Rozgrywka(Druzyna druzyna1, Druzyna druzyna2, Sedzia sedzia)
        {
            this.druzyna1 = druzyna1;
            this.druzyna2 = druzyna2;
            Sedzia = sedzia;
        }
        public override string ToString()
        {
            if(Sedzia == null)
            {
                return $"{druzyna1} vs {druzyna2}";
            } 
            else
            {
                return $"{druzyna1} vs {druzyna2}\nSedzia: {Sedzia}";
            }
        }
        public static string WyswietlDruzyny(Druzyna druzyna1, Druzyna druzyna2)
        {
            return $"{druzyna1} vs {druzyna2}";
        }
    }
}