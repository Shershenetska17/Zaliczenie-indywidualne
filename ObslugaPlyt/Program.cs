using Date;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ObslugaPlyt
{
    internal class Program
    {
        static List <Plyta> plyty = new List<Plyta>();

        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("\n----- MENU GŁÓWNE -----");
                Console.WriteLine("1. Wciśnij '1', jeżeli chcesz dodać nową płytę");
                Console.WriteLine("2. Wciśnij '2', jeżeli chcesz wyświetlić wszystkie płyty");
                Console.WriteLine("3. Wciśnij '3', jeżeli chcesz wyświetlić szczegóły płyty");
                Console.WriteLine("4. Wciśnij '4', jeżeli chcesz wyświetlic wykonawców na płycie");
                Console.WriteLine("5. Wciśnij '5', jeżeli chcesz wyświetlić szczegóły utworu");
                Console.WriteLine("6. Wciśnij '6', jeżeli chcesz zapisać bazę danych");
                Console.WriteLine("7. Wciśnij '7', jeżeli chcesz wyjść z programu");
                Console.Write("Wybierz opcję:");

                string opcja = Console.ReadLine();

                switch (opcja)
                {
                    case "1":
                        DodajNowaPlyte();
                        break;

                    case "2":
                        WyswietlWszystkiePlyty();
                        break;

                    case "3":
                        WyswietlSzczegolyPlyty();
                        break;

                    case "4":
                        WyswietlWykonawcowNaPlycie();
                        break;

                    case "5":
                        WyswietlSzczegolyUtworu();
                        break;

                    case "6":
                        ZapiszBazeDanych();
                        break;

                    case "7":
                        ZapiszBazeDanych();
                        Environment.Exit(0);
                        break;
                }
            }  
        }

        static void DodajNowaPlyte()
        {
            while (true)
            {
                try
                {
                    Plyta nowaPlyta = new Plyta();

                    Console.Write("\nPodaj tytuł płyty: ");
                    nowaPlyta.Tytul = Console.ReadLine();

                    Console.Write("Podaj typ płyty (CD/DVD): ");
                    nowaPlyta.Typ = Console.ReadLine();
                    if (nowaPlyta.Typ != "CD" && nowaPlyta.Typ != "cd" && nowaPlyta.Typ != "DVD" && nowaPlyta.Typ != "dvd")
                    {
                        throw new Exception("Nie poprawny typ dysku");
                    }

                    Console.Write("Podaj numer płyty: ");
                    nowaPlyta.NumerPlyty = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Podaj spis utworów (oddzielając utwory przecinkami): ");
                    string utworyInput = Console.ReadLine();
                    string[] utworySplit = utworyInput.Split(',');

                    int numerUtworu = 1;

                    foreach (string utwor in utworySplit)
                    {
                        Console.Write($"Podaj czas trwania utworu '{utwor}' (w minutach):");
                        int czasMinuty = Convert.ToInt32(Console.ReadLine());


                        Console.Write($"Podaj czas trwania utworu '{utwor}' (w sekundach):");
                        int czasSekundy = Convert.ToInt32(Console.ReadLine());
                        int spr = czasSekundy / 60;
                        int zos = czasSekundy % 60;
                        if (czasSekundy > 60)
                        {
                            czasMinuty += spr;
                            czasSekundy = zos;
                        }
                        Console.Write($"Podaj kompozytora dla utworu '{utwor}': ");
                        string kompozytor = Console.ReadLine();
                        Console.Write("Podaj wykonawcę dla utworu '{utwor}': ");
                        string wykonawca = Console.ReadLine();

                        nowaPlyta.Utwory.Add(new Utwor { Tytul = utwor, Kompozytor = kompozytor, Wykonawca = wykonawca, NumerUtworu = numerUtworu++, CzasTrwaniaMinuty = czasMinuty, CzasTrwaniaSekundy = czasSekundy }); ;
                        nowaPlyta.Wykonawcy.Add(wykonawca);
                        Console.WriteLine("Utwor został dodany pomyślnie!");

                    }
                    plyty.Add(nowaPlyta);

                }
                catch(Exception ex)
                {
                    Console.Write(ex.Message);
                }
                break;
                
            }
            Console.WriteLine("Płyta została dodana pomyślnie!");
        } 

        

        static void WyswietlWszystkiePlyty()
        {
            Console.WriteLine("\n----- WSZYSTKIE PŁYTY -----");
            if (plyty.Count == 0)
            {
                Console.WriteLine("Brak płyt w bazie danych.");
                return;
            }

            Console.WriteLine("Lista płyt:");
            foreach (Plyta plyta in plyty)
            {
                Console.WriteLine($"{plyta.Tytul} (nr {plyta.NumerPlyty})");

            }


        }
        static void WyswietlSzczegolyPlyty()
        {
            Console.WriteLine("\nPodaj numer płyty, dla której chcesz wyświetlić szczegóły:");
            int numerPlyty = Convert.ToInt32(Console.ReadLine());

            Plyta znalezionaPlyta = null;
            foreach (Plyta plyta in plyty)
            {
                if (plyta.NumerPlyty == numerPlyty)
                {
                    znalezionaPlyta = plyta;
                    break;
                }
            }

            if (znalezionaPlyta == null)
            {
                Console.WriteLine("Nie znaleziono płyty o podanym numerze.");
                return;
            }

            Console.WriteLine($"----- SZCZEGÓŁY PŁYTY {znalezionaPlyta.Tytul} -----");
            Console.WriteLine($"Tytuł: {znalezionaPlyta.Tytul}");
            Console.WriteLine($"Typ: {znalezionaPlyta.Typ}");

            Console.WriteLine("Lista utworów:");
            foreach (Utwor utwor in znalezionaPlyta.Utwory)
            {
                Console.WriteLine($"{utwor.NumerUtworu}. {utwor.Tytul}");
            }

        }

        static void WyswietlWykonawcowNaPlycie()
        {
            Console.Write("\nPodaj numer płyty, dla której chcesz wyświetlić wykonawców:");
            int numerPlyty = Convert.ToInt32(Console.ReadLine());

            Plyta znalezionaPlyta = null;
            foreach (Plyta plyta in plyty)
            {
                if (plyta.NumerPlyty == numerPlyty)
                {
                    znalezionaPlyta = plyta;
                    break;
                }
            }

            if (znalezionaPlyta == null)
            {
                Console.WriteLine("Nie znaleziono płyty o podanym numerze.");
                return;
            }

            Console.WriteLine($"----- WYKONAWCY PŁYTY {znalezionaPlyta.Tytul} -----");
            Console.WriteLine("Lista wykonawców:");
            foreach ( string wykonawca in znalezionaPlyta.Wykonawcy)
            {
                Console.WriteLine($"- {wykonawca}");
            }
        }

        static void WyswietlSzczegolyUtworu()
        {
            Console.Write("\nPodaj numer płyty, dla której chcesz wyświetlić szczegóły:");
            int numerPlyty = Convert.ToInt32(Console.ReadLine());

            Plyta znalezionaPlyta = null;
            foreach (Plyta plyta in plyty)
            {
                if (plyta.NumerPlyty == numerPlyty)
                {
                    znalezionaPlyta = plyta;
                    break;
                }
            }

            if (znalezionaPlyta == null)
            {
                Console.WriteLine("Nie znaleziono płyty o podanym numerze.");
                return;
            }

            Console.Write("Podaj numer utworu, którego szczegóły chcesz wyświetlić: ");
            int numerUtworu = Convert.ToInt32(Console.ReadLine());

            Utwor znalezionyUtwor = null;
            foreach (Utwor utwor in znalezionaPlyta.Utwory)
            {
                if (utwor.NumerUtworu == numerUtworu)
                {
                    znalezionyUtwor = utwor;
                    break;
                }
            }

            if (znalezionyUtwor== null)
            {
                Console.WriteLine("Nie znaleziono utworu o podanym numerze.");
                return;
            }
            Console.WriteLine($"----- SZCZEGÓŁY UTWORU {znalezionyUtwor.Tytul} NA PŁYCIE {znalezionaPlyta.Tytul} -----");
            Console.WriteLine($"Tytuł: {znalezionyUtwor.Tytul}");
            Console.WriteLine($"Czas trwania: {znalezionyUtwor.CzasTrwaniaMinuty} min {znalezionyUtwor.CzasTrwaniaSekundy} sek ");
            Console.WriteLine("Wykonawcy:");
            foreach (var wykonawca in znalezionyUtwor.Wykonawcy)
            {
                Console.WriteLine($"- {wykonawca}");
            }
            Console.WriteLine($"Kompozytor: {znalezionyUtwor.Kompozytor}");

        }

        static void ZapiszBazeDanych()
        {
            Console.Write("Czy na pewno chcesz zapisać zmiany w bazie danych do pliku? (T/N): ");
            string odpowiedz = Console.ReadLine().ToUpper();

            if (odpowiedz == "T")
            {
                using (StreamWriter sw = new StreamWriter("baza.txt"))
                {
                    foreach (var plyta in plyty)
                    {
                        sw.Write("\n");
                        sw.Write("Tytuł plyty: " + plyta.Tytul);
                        sw.Write("\nTyp: " + plyta.Typ);
                        sw.WriteLine("\n");
                        
                        foreach (var utwor in plyta.Utwory)
                        {
                            sw.Write("\n" + utwor.Tytul + " " + utwor.CzasTrwaniaMinuty + " min " + utwor.CzasTrwaniaSekundy + " sek");
                            foreach(var wykonawca in utwor.Wykonawcy)
                            {
                                sw.Write($"{wykonawca}");
                            }
                            sw.Write("\nKompozytor: " + utwor.Kompozytor);
                            sw.Write("\nID: " + utwor.NumerUtworu);
                            sw.Write("\n");
                        }
                    }
                }

                Console.WriteLine("Zmiany zostały zapisane do pliku baza.txt.");
            }
            else
            {
                Console.WriteLine("Zapisanie zmian zostało anulowane.");
            }
        }

      

    }
}
