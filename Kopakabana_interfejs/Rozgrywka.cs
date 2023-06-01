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
        public void Rozegraj()
        {
            /*
            Console.WriteLine($"Rozgrywka");
            Console.WriteLine($"1. {druzyna1}");
            Console.WriteLine($"2. {druzyna2}");

            while (true)
            { 
                Console.Write("Wybierz wygrana druzyne > ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if(choice == 1)
                {
                    WygranaDruzyna = druzyna1;
                    break;
                } 
                else if(choice == 2)
                {
                    WygranaDruzyna = druzyna2;
                    break;
                } 
                else
                {
                    Console.WriteLine("Wybrano bledna druzyne");
                }
            } */

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