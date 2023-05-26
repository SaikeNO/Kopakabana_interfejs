

using System.Security.Cryptography.X509Certificates;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
/*
namespace Kopakabana
{
    class Program
    {
        public static void Main(string[] args)
        {
            Stream stream;
            BinaryFormatter formatter;
            Kantorek kantorek;
            if (File.Exists("Sedziowie.bin"))
            {
                stream = File.Open("Sedziowie.bin", FileMode.Open);
                formatter = new BinaryFormatter();
                kantorek = (Kantorek)formatter.Deserialize(stream);
                stream.Close();
            }
            else
            {
                kantorek = new Kantorek();
            }
            int choice = 1;
            Opcje();
            while (Convert.ToBoolean(choice))
            {
                Console.WriteLine("Podaj opcje:");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            int choice1 = 1;
                            while (Convert.ToBoolean(choice1))
                            {
                                Console.WriteLine("1.Dodaj Sedziego");
                                Console.WriteLine("2.Usun Sedziego");
                                Console.WriteLine("3.Wyswietl Sedziow");
                                Console.WriteLine("0.Cofnij");
                                Console.WriteLine("Podaj opcje:");
                                choice1 = Convert.ToInt32(Console.ReadLine());
                                switch (choice1)
                                {
                                    case 0:
                                        {
                                            Opcje();
                                            break;
                                        }
                                    case 1:
                                        {
                                            Console.WriteLine("Podaj imie:");
                                            string imie = Convert.ToString(Console.ReadLine());
                                            Console.WriteLine("Podaj nazwisko:");
                                            string nazwisko = Convert.ToString(Console.ReadLine());
                                            int choice3 = 1;
                                            while (Convert.ToBoolean(choice3))
                                            {
                                                Console.WriteLine("Wybierz sport");
                                                Console.WriteLine("1.Siatkowka");
                                                Console.WriteLine("2.Dwa ognie");
                                                Console.WriteLine("3.Przeciaganie liny");
                                                Console.WriteLine("Podaj wybor:");
                                                choice3 = Convert.ToInt32(Console.ReadLine());

                                                switch (choice3)
                                                {
                                                    case 1:
                                                        {
                                                            var sport = new Siatkowka();
                                                            var sedzia = new Sedzia(imie, nazwisko, sport);
                                                            kantorek.DodajSedziego(sedzia);
                                                            Console.WriteLine("Dodano sedziego:");
                                                            Console.WriteLine(sedzia.ToString());
                                                            stream = File.Open("Sedziowie.bin", FileMode.Create);
                                                            formatter = new BinaryFormatter();
                                                            formatter.Serialize(stream, kantorek);
                                                            stream.Close();
                                                            choice3 = 0;
                                                            break;
                                                        }
                                                    case 2:
                                                        {
                                                            var sport = new DwaOgnie();
                                                            var sedzia = new Sedzia(imie, nazwisko, sport);
                                                            Console.WriteLine(sedzia.ToString());
                                                            choice3 = 0;
                                                            break;
                                                        }
                                                    case 3:
                                                        {
                                                            var sport = new PrzeciaganieLiny();
                                                            var sedzia = new Sedzia(imie, nazwisko, sport);
                                                            Console.WriteLine(sedzia.ToString());
                                                            choice3 = 0;
                                                            break;
                                                        }
                                                    default:
                                                        {
                                                            Console.WriteLine("Popraw opcje");
                                                            break;
                                                        }
                                                }
                                            }
                                            break;
                                        }
                                    case 2:
                                        {
                                            // usuwanie
                                            break;
                                        }
                                    case 3:
                                        {
                                            foreach (Sedzia sedzia in kantorek.GetSedziowie())
                                            {
                                                Console.WriteLine(sedzia);
                                            }

                                            break;
                                        }
                                    default: { Console.WriteLine("Brak opcji"); break; }
                                }

                            }
                            break;
                        }
                    case 2:
                        {
                            int choice2 = 1;
                            while (Convert.ToBoolean(choice2))
                            {
                                Console.WriteLine("1.Dodaj Druzyne");
                                Console.WriteLine("2.Usun Druzyne");
                                Console.WriteLine("3.Przegladaj Druzyny");
                                Console.WriteLine("0.Cofnij");
                                Console.WriteLine("Podaj opcje:");
                                choice2 = Convert.ToInt32(Console.ReadLine());
                                switch (choice2)
                                {
                                    case 0:
                                        {
                                            Opcje();
                                            break;
                                        }
                                    case 1:
                                        {
                                            // dodawanie
                                            break;
                                        }
                                    case 2:
                                        {
                                            // usuwanie
                                            break;
                                        }
                                    case 3:
                                        {
                                            //wyswietlanie
                                            break;
                                        }
                                    default: { Console.WriteLine("Brak opcji"); break; }
                                }

                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Brak opcji");
                            Opcje(); break;
                        }
                }
            }
            void Opcje()
            {
                Console.WriteLine("Projek Kopakabana");
                Console.WriteLine("Opcje: ");
                Console.WriteLine("1.Zarzadzaj Sedziami");
                Console.WriteLine("2.Zarzadzaj Druzynami");
                Console.WriteLine("0.Zakoncz program");
            }
        }



    }


}

*/