﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Program
    {

        public class Hotel
        {
            //public Osoba Kierownik = new Osoba("Admin","Admin");
            public List<Room> pokoje = new List<Room>();
            public List<Pracownik> Personel = new List<Pracownik>();
            public List<Gosc> Goscie = new List<Gosc>();
            public void DodajGoscia(Gosc g)
            {
                Goscie.Add(g);
            }
            public void DodajPracownika(Pracownik p)
            {
                Personel.Add(p);
            }
        }
        public abstract class Room : Hotel
        {
            public abstract double Koszt();
            public abstract string GetOpis();
            public abstract int NumerPokoju();
        }
        public class Pokoj : Room
        {
            public override double Koszt()
            {
                return 500.99;
            }
            public override string GetOpis()
            {
                return "Pokój";
            }
            public override int NumerPokoju()
            {
                return 1;
            }
        }
        //Dekorator pokoj
        public abstract class PokojDekorator : Room
        {
            protected Room room;
            public PokojDekorator(Room _room)
            {
                room = _room;
            }
            public override string GetOpis()
            {
                return room.GetOpis();
            }
            public override double Koszt()
            {
                return room.Koszt();
            }
            public override int NumerPokoju()
            {
                return room.NumerPokoju();
            }
        }
        //dodac dla lozka dla dziecka, lozko krolewskie, wanna, mini bar, jacuzzi, czy dla zwierzat, taras, ilu osobowy
        class Lozeczko : PokojDekorator
        {
            public Lozeczko(Room _room) : base(_room)
            {

            }
            public override double Koszt()
            {
                return 100 + room.Koszt();
            }
            public override string GetOpis()
            {
                return room.GetOpis() + ", z łóżkiem dla dziecka";
            }
            public override int NumerPokoju()
            {

                return room.NumerPokoju() + 10;

            }
        }
        class Łoże : PokojDekorator
        {
            public Łoże(Room _room) : base(_room)
            {

            }
            public override double Koszt()
            {
                return 150 + room.Koszt();
            }
            public override string GetOpis()
            {
                return room.GetOpis() + ", z łóżkiem królewskim";
            }
            public override int NumerPokoju()
            {
                return room.NumerPokoju() + 5;


            }
        }
        class Minibar : PokojDekorator
        {
            public Minibar(Room _room) : base(_room)
            {

            }
            public override double Koszt()
            {
                return 50 + room.Koszt();
            }
            public override string GetOpis()
            {
                return room.GetOpis() + ", z minibarem";
            }
            public override int NumerPokoju()
            {
                return room.NumerPokoju() + 1;
            }
        }
        class Wanna : PokojDekorator
        {
            public Wanna(Room _room) : base(_room)
            {

            }
            public override double Koszt()
            {
                return 30 + room.Koszt();
            }
            public override string GetOpis()
            {
                return room.GetOpis() + ", z dużą wanną";
            }
            public override int NumerPokoju()
            {
                return room.NumerPokoju() + 2;
            }

        }
        class Dostosuj : PokojDekorator
        {
            public Dostosuj(Room _room) : base(_room)
            {

            }
            public override double Koszt()
            {
                return room.Koszt();
            }
            public override string GetOpis()
            {
                return room.GetOpis();
            }
            public override int NumerPokoju()
            {
                return room.NumerPokoju() + 1;
            }
        }
        class Zwierzeta : PokojDekorator
        {
            public Zwierzeta(Room _room) : base(_room)
            {

            }
            public override double Koszt()
            {
                return 100 + room.Koszt();
            }
            public override string GetOpis()
            {
                return room.GetOpis() + ", przeznaczony dla zwierząt";
            }
            public override int NumerPokoju()
            {
                return room.NumerPokoju() + 1;
            }
        }
        class Osobowy : PokojDekorator
        {
            public int IloscOsob = 0;
            public Osobowy(Room _room, int osoby) : base(_room)
            {
                this.IloscOsob = osoby;
            }
            public override double Koszt()
            {
                if (IloscOsob == 1)
                    return 0 + room.Koszt();
                else if (IloscOsob == 2)
                    return 100 + room.Koszt();
                else if (IloscOsob == 3)
                    return 150 + room.Koszt();
                else
                    return 250 + room.Koszt();
            }
            public override string GetOpis()
            {
                if (IloscOsob == 1)
                    return room.GetOpis() + ", Jednoosobowy";
                else if (IloscOsob == 2)
                    return room.GetOpis() + ", Dwuosobowy";
                else if (IloscOsob == 3)
                    return room.GetOpis() + ", Trzyosobowy";
                else
                    return room.GetOpis() + ", Czteroosobowy";
            }
            public override int NumerPokoju()
            {
                if (IloscOsob == 1)
                    return room.NumerPokoju() + 0;
                else if (IloscOsob == 2)
                    return room.NumerPokoju() + 10;
                else if (IloscOsob == 3)
                    return room.NumerPokoju() + 20;
                else
                    return room.NumerPokoju() + 30;
            }

        }
        public class Osoba : Hotel
        {
            public string Imie;
            public string Nazwisko;
        }
        public class Gosc : Osoba //Trzeba jakoś powiązać gościa z pokojem bo jak zrobić rachunek? Chyba że damy rachunek w hotelu i wszystko sciągnie przez dziedziczenie
        {
            public bool KartaCzłonkowska = false; // true wtedy znizka
            public int IloscOdwiedzin = 0;
            public double Rachunek = 0;
            public int Posilki = 0; // 1 sniadanie 2 obiad 4 kolacja
            public Room Aktualny_pokoj;
            public int Id;
            public Gosc(bool czykarta, string imie, string nazwisko)
            {
                this.KartaCzłonkowska = czykarta;
                this.IloscOdwiedzin = this.IloscOdwiedzin + 1;
                this.Imie = imie;
                this.Nazwisko = nazwisko;
                this.Id = 1;
            }
            public void PrzypiszDoPokoju(Room pokoj)
            {
                pokoj = PokojDostepny(pokoj);
                Aktualny_pokoj = pokoj;
                pokoje.Add(pokoj);
                if (KartaCzłonkowska == true)
                    Rachunek = Rachunek + pokoj.Koszt() * 0.80;
                else
                    Rachunek = Rachunek + pokoj.Koszt();
                Console.WriteLine("Numer pokoju: " + pokoj.NumerPokoju() + " Koszt: " + Rachunek);
            }
            public Room PokojDostepny(Room pokoj)
            {
                int numerek = pokoj.NumerPokoju();
                if (pokoje == null)
                {

                }
                else
                {
                    foreach (Room p in pokoje)
                    {
                        if (numerek == p.NumerPokoju())
                        {
                            pokoj = new Dostosuj(pokoj);
                        }
                    }
                }
                return pokoj;
            }
        }
        public class Pracownik : Osoba
        {
            public double Wyplata = 14; // na godzine startowa potem * ilość godzin #Tygodniówka
            public bool Zmiana; // false dzien, true noc
            public int Ilosc_Godzin; // w ciagu tygodnia
            public double Staż = 0; // zaleznie od dlugosci czasu wieksza wyplata
            public string obowiązki;
        }
        public class Boj : Pracownik
        {
            public Boj(string Imię, bool zmianaa, double staż, string nazwisko)
            {
                this.Zmiana = zmianaa;
                this.Ilosc_Godzin = 56;
                this.Staż = staż;
                this.Wyplata += this.Wyplata * this.Ilosc_Godzin + 100 * (Staż / 6);
                this.obowiązki = "Zamawianie taksówki, udzielanie informacji o okolicy, dostarczanie zamawiane do pokoju posiłki czy odnoszenie garderoby do pralni";
                this.Imie = Imię;
                this.Nazwisko = nazwisko;
            }
            public void Info()
            {
                string zminy;
                if (this.Zmiana == false)
                {
                    zminy = "Dzienna";
                }
                else
                {
                    zminy = "Nocna";
                }
                string info = "Imię: " + this.Imie + "\nNazwisko: " + Nazwisko + "\nStaż: " + this.Staż + "\nZmiana: " + zminy + "\nWypłata: " + this.Wyplata +
                    "\nIlość Godzin w tygodniu: " + this.Ilosc_Godzin + "\nZakres Obowiązków: " + this.obowiązki;
                Console.WriteLine(info);
            }

        }
        public class Sprzątaczka : Pracownik
        {
            public Sprzątaczka(string Imię, bool zmianaa, double staż, string nazwisko)
            {
                this.Zmiana = zmianaa;
                this.Ilosc_Godzin = 48;
                this.Staż = staż;
                this.Wyplata += this.Wyplata * this.Ilosc_Godzin + 70 * (Staż / 6);
                this.obowiązki = "Dbanie o porządek na obszarze całego hotelu";
                this.Imie = Imię;
                this.Nazwisko = nazwisko;
            }
            public void Info()
            {
                string zminy;
                if (this.Zmiana == false)
                {
                    zminy = "Dzienna";
                }
                else
                {
                    zminy = "Nocna";
                }
                string info = "Imię: " + this.Imie + "\nNazwisko: " + Nazwisko + "\nStaż: " + this.Staż + "\nZmiana: " + zminy + "\nWypłata: " + this.Wyplata +
                    "\nIlość Godzin w tygodniu: " + this.Ilosc_Godzin + "\nZakres Obowiązków: " + this.obowiązki;
                Console.WriteLine(info);
            }
        }
        public class Recepcjonista : Pracownik
        {
            public Recepcjonista(string Imię, bool zmianaa, double staż, string nazwisko)
            {
                this.Zmiana = zmianaa;
                this.Ilosc_Godzin = 84;
                this.Staż = staż;
                this.Wyplata += this.Wyplata * Ilosc_Godzin + 150 * (Staż / 6);
                this.obowiązki = "Rozporządzanie pokojami hotelowymi i dbanie o przyjemny pobyt klientów";
                this.Imie = Imię;
                this.Nazwisko = nazwisko;
            }
            public void Info()
            {
                string zminy;
                if (this.Zmiana == false)
                {
                    zminy = "Dzienna";
                }
                else
                {
                    zminy = "Nocna";
                }
                string info = "Imię: " + this.Imie + "\nNazwisko: " + Nazwisko + "\nStaż: " + this.Staż + "\nZmiana: " + zminy + "\nWypłata: " + this.Wyplata +
                    "\nIlość Godzin w tygodniu: " + this.Ilosc_Godzin + "\nZakres Obowiązków: " + this.obowiązki;
                Console.WriteLine(info);
            }
        }
        public class Restauracja : Hotel
        {

        }

        static void Main(string[] args)
        {
            Hotel hotel = new Hotel();
            Boj jeden = new Boj("Andrzej", false, 12, "Dudeł");
            hotel.Personel.Add(jeden);
            Sprzątaczka dwa = new Sprzątaczka("Wiesia", false, 2, "Mozambik");
            hotel.Personel.Add(dwa);
            Recepcjonista trzy = new Recepcjonista("Mystosław", true, 18, "Bajkiewicz");
            hotel.Personel.Add(trzy);
            //trzy.Info(); //Informacje o pracowniku
            Room room = new Pokoj();
            room = new Zwierzeta(room);
            room = new Osobowy(room, 3);
            Room room2 = new Pokoj();
            room2 = new Zwierzeta(room2);
            room2 = new Osobowy(room2, 3);
            //Gosc Pan_Kierownik = new Gosc(true, "Marcin", "Kozlowski");
            //osoba.PrzypiszDoPokoju(room);
            //osoba.PrzypiszDoPokoju(room2);
            //Console.WriteLine(osoba.Rachunek);
            Symulacja();
            Console.WriteLine("Życzymy Miłego Dnia :)");
            Console.ReadKey();
            void Symulacja()
            {
                Console.WriteLine("      Witamy w naszym upośledzonym hotelu!\n\n\n");
                bool exit = false;
                bool admin = false;
                do
                {
                    Console.WriteLine("Zaloguj jako admin - 1");
                    Console.WriteLine("Zaloguj jako gość - 2");
                    string wynik = Console.ReadLine();
                    if (wynik == "1")
                    {
                        Console.WriteLine("Podaj Login: ");
                        string login = Console.ReadLine();
                        Console.WriteLine("Podaj hasło: ");
                        string hasło = Console.ReadLine();
                        if (login == hasło)
                        {
                            if (login == "admin")
                            {
                                admin = true;
                                exit = true;
                            }
                        }
                    }
                    if (wynik == "2")
                    {
                        exit = true;
                    }
                } while (exit != true);
                exit = false;
                do
                {
                    Console.WriteLine("Co Chcesz Zrobić? \n");
                    Console.WriteLine("Zatrudnij Pracownika - zatrudnij");
                    Console.WriteLine("Weź Pokój - pokoj");
                    Console.WriteLine("Poproś o rachunek - rachunek");

                    if (admin == true)
                    {
                        Console.WriteLine("Wypisz liste gości - goscie");
                        Console.WriteLine("Wypisz liste pracowników - pracownicy");
                    }
                    Console.WriteLine("Wyjście  - exit");
                    string wynik = Console.ReadLine();
                    if (wynik == "exit")
                    {
                        exit = true;
                    }
                    if (wynik == "zatrudnij")
                    {
                        string zat;
                        do
                        {
                            Console.WriteLine("\n\n\n\n Zatrudnij boja - boj \n Zatrudnij sprzątaczkę - sprzataczka \n Zatrudnij Recepcjoniste - recepcjonista \n Wróć - back");
                            zat = Console.ReadLine();
                            if (zat == "boj")
                            {
                                string imie, nazwisko, zmiana;
                                bool zmian = false;
                                Console.WriteLine("\n Podaj Imię Pracownika: ");
                                imie = Console.ReadLine();
                                Console.WriteLine("\n Podaj Nazwisko Pracownika: ");
                                nazwisko = Console.ReadLine();
                                Console.WriteLine("\n Zmiana dzienna - d czy nocna - n ?");
                                zmiana = Console.ReadLine();
                                if (zmiana == "d")
                                    zmian = false;
                                if (zmiana == "n")
                                    zmian = true;
                                var a = new Boj(imie, zmian, 0, nazwisko);
                                hotel.DodajPracownika(a);
                                Console.WriteLine("\n Zatrudniono pracownika \n");

                            }
                            if (zat == "sprzataczka")
                            {
                                string imie, nazwisko, zmiana;
                                bool zmian = false;
                                Console.WriteLine("\n Podaj Imię Pracownika: ");
                                imie = Console.ReadLine();
                                Console.WriteLine("\n Podaj Nazwisko Pracownika: ");
                                nazwisko = Console.ReadLine();
                                Console.WriteLine("\n Zmiana dzienna - d czy nocna - n ?");
                                zmiana = Console.ReadLine();
                                if (zmiana == "d")
                                    zmian = false;
                                if (zmiana == "n")
                                    zmian = true;
                                var a = new Sprzątaczka(imie, zmian, 0, nazwisko);
                                hotel.DodajPracownika(a);
                                Console.WriteLine("\n Zatrudniono pracownika \n");
                            }
                            if (zat == "recepcjonista")
                            {
                                string imie, nazwisko, zmiana;
                                bool zmian = false;
                                Console.WriteLine("\n Podaj Imię Pracownika: ");
                                imie = Console.ReadLine();
                                Console.WriteLine("\n Podaj Nazwisko Pracownika: ");
                                nazwisko = Console.ReadLine();
                                Console.WriteLine("\n Zmiana dzienna - d czy nocna - n ?");
                                zmiana = Console.ReadLine();
                                if (zmiana == "d")
                                    zmian = false;
                                if (zmiana == "n")
                                    zmian = true;
                                var a = new Recepcjonista(imie, zmian, 0, nazwisko);
                                hotel.DodajPracownika(a);
                                Console.WriteLine("\n Zatrudniono pracownika \n");
                            }
                        } while (zat != "back");
                    }
                    if (wynik == "pokoj")
                    {
                        string imie, nazwisko, kart;
                        bool karta = false;
                        Console.WriteLine("\n\n\n Poproszę podać Imię: ");
                        imie = Console.ReadLine();
                        Console.WriteLine("\n Nazwisko: ");
                        nazwisko = Console.ReadLine();
                        Console.WriteLine("\n Czy Posiada pan kartę członkowską? - y/n");
                        kart = Console.ReadLine();
                        if (kart == "y")
                        {
                            karta = true;
                        }
                        if (kart == "n")
                        {
                            string t;
                            Console.WriteLine("\n Czy chciał by pan/pani wyrobić kartę członkowską? Upoważnia ona do zniżki - y/n");
                            t = Console.ReadLine();
                            if (t == "y")
                            {
                                Console.WriteLine("\n Czy akceptujesz zasady RODO ? Y/N");
                                char RODO = Convert.ToChar(Console.ReadLine());
                                Console.WriteLine("\n Czy akceptujesz zasady regulaminu ? Y/N");
                                char Regulamin = Convert.ToChar(Console.ReadLine());
                                if ((RODO == 'Y' || RODO == 'y') && (Regulamin == 'Y' || Regulamin == 'y'))
                                {
                                    karta = true;
                                    Console.WriteLine("\n Zostałeś członkiem klubu");
                                }
                            }
                        }
                        Gosc osoba1 = new Gosc(karta, imie, nazwisko);
                        hotel.DodajGoscia(osoba1);
                        osoba1.Id = hotel.Goscie.Count;
                        Console.WriteLine("Twoje id To : " + osoba1.Id + " Zapamietaj! ");
                        bool Wykonuj = true;
                        char Czytaj_znak;
                        int pomoc = 0;
                        Console.WriteLine(" Dostosuj swoj pokoj : ");
                        Room room1 = new Pokoj();
                        while (Wykonuj)
                        {

                            Console.WriteLine("Czy chcesz mieć w tym pokoju : Łużeczko dla dzieci ('l'), Łoże Królewskie('ł'), Minibar'(m'), Wanna('w'), Zwierzeta('z'). Koniec('0') ");
                            Czytaj_znak = Convert.ToChar(Console.ReadLine());
                            if (Czytaj_znak == 'l')
                            {
                                room1 = new Lozeczko(room1);
                                Console.WriteLine(room1.GetOpis());
                                pomoc++;
                            }
                            else if (Czytaj_znak == 'ł')
                            {
                                room1 = new Łoże(room1);
                                Console.WriteLine(room1.GetOpis());
                                pomoc++;
                            }
                            else if (Czytaj_znak == 'm')
                            {
                                room1 = new Minibar(room1);
                                Console.WriteLine(room1.GetOpis());
                                pomoc++;
                            }
                            else if (Czytaj_znak == 'w')
                            {
                                room1 = new Wanna(room1);
                                Console.WriteLine(room1.GetOpis());
                                pomoc++;
                            }
                            else if (Czytaj_znak == 'z')
                            {
                                room1 = new Zwierzeta(room1);
                                Console.WriteLine(room1.GetOpis());
                                pomoc++;
                            }
                            else if (Czytaj_znak == '0')
                            {
                                Wykonuj = false;
                            }
                            else
                            {
                                Console.WriteLine("Podałeś zły znak. Spróbuj ponownie");
                            }
                            if (pomoc == 5)
                            {
                                Wykonuj = false;
                            }
                        }
                        Console.WriteLine("Ilu osobowy ma być pokój ? ( od 1 do 4 ) ");
                        int iloscpokojow = 0;
                        iloscpokojow = int.Parse(Console.ReadLine());
                        room1 = new Osobowy(room1, iloscpokojow);
                        osoba1.PrzypiszDoPokoju(room1);
                        Console.WriteLine(" " + room1.GetOpis() + " Numer pokoju to : " + room1.NumerPokoju());

                    }
                    if (wynik == "rachunek")
                    {
                        Gosc osoba = new Gosc(true, "a", "b");
                        Console.WriteLine("Podaj swoje id by opłacić rachunek");
                        int numerek = int.Parse(Console.ReadLine());
                        for (int i = 0; i < hotel.Goscie.Count; i++)
                        {
                            if (numerek == hotel.Goscie[i].Id)
                            {
                                osoba = hotel.Goscie[i];
                            }

                        }
                        Console.WriteLine(" " + osoba.Rachunek);
                        Console.WriteLine("Płatność Kartą czy gotówką? - karta/gotowka");
                        string a = Console.ReadLine();
                        if (a == "gotowka")
                        {
                            Console.WriteLine("\n\nDziękujemy za skorzystanie z naszego hotelu");
                        }
                        if (a == "karta")
                        {
                            Console.WriteLine("Czy drukować fakturę? - y/n");
                            var fak = Console.ReadLine();
                            if (fak == "y")
                            {
                                Console.WriteLine("\n Proszę o to faktura, Dziękujemy za skorzystanie z naszego hotelu");
                            }
                            if (fak == "n")
                            {
                                Console.WriteLine("Dziękujemy za skorzystanie z naszego hotelu");
                            }
                        }
                    }
                    if (wynik == "goscie")
                    {
                        var goscie = hotel.Goscie;
                        for (int i = 0; i < goscie.Count; i++)
                        {
                            Console.WriteLine("Id: " + goscie[i].Id + " Imie: " + goscie[i].Imie + " Nazwisko: " + goscie[i].Nazwisko + " Karta Członkowska: " + goscie[i].KartaCzłonkowska + " Ilosc Odwiedzin: " + goscie[i].IloscOdwiedzin);
                        }
                    }
                    if (wynik == "pracownicy")
                    {
                        var prac = hotel.Personel;
                        for (int i = 0; i < prac.Count; i++)
                        {
                            Console.WriteLine("Id: " + i + " Imie: " + prac[i].Imie + " Nazwisko: " + prac[i].Nazwisko + " Ilosc Godzin: " + prac[i].Ilosc_Godzin + " Obowiązki:  " + prac[i].obowiązki);
                        }
                        Console.WriteLine("\n\n Czy chcesz zwonić pracownika? - y/n");
                        string zw = Console.ReadLine();
                        if (zw == "y")
                        {
                            Console.WriteLine("Podaj id pracownika: ");
                            string a = Console.ReadLine();
                            int b = Convert.ToInt32(a);
                            for (int i = 0; i < prac.Count; i++)
                            {
                                if (i == b)
                                {
                                    hotel.Personel.Remove(prac[i]);
                                }
                            }
                        }
                    }
                } while (exit != true);

            }
        }
    }
}