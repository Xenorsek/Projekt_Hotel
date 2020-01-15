using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp50
{
    class Program
    {
        
         public class Hotel
        {
            public Osoba Kierownik;
            public List<Room> pokoje;
            public List<Pracownik> Personel;
            public List<Gosc> Goscie;

        }
        public abstract class Room : Hotel
        {
            public abstract double Koszt();
            public abstract string GetOpis();
            //public abstract int NumerPokoju();
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
            //public override int NumerPokoju()
            //{
            //    return 1;
            //}
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
        }
        public class Osoba : Hotel
        {
            public string Imie;
            public string Nazwisko;
        }
        public class Gosc : Osoba
        {
            public bool KartaCzłonkowska = false; // true wtedy znizka
            public int IloscOdwiedzin = 0;
            public double Rachunek = 0;
            public int Posilki = 0; // 1 sniadanie 2 obiad 4 kolacja
            public void ZostanCzlonkiem()
            {
                Console.WriteLine("Czy akceptujesz zasady RODO ? Y/N");
                char RODO = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("Czy akceptujesz zasady regulaminu ? Y/N");
                char Regulamin = Convert.ToChar(Console.ReadLine());
                if ((RODO == 'Y' || RODO == 'y') && (Regulamin == 'Y' || Regulamin == 'y'))
                {
                    this.KartaCzłonkowska = true;
                    Console.WriteLine("Zostałeś członkiem klubu");
                }
            }
            public void PrzypiszDoPokoju(Pokoj pokoj)
            {
                
            }
        }
        public class Pracownik : Osoba
        {
            public double Wyplata;
            public bool Zmiana; // false dzien, true noc
            public int Ilosc_Godzin; // w ciagu tygodnia
            public double Staż; // zaleznie od dlugosci czasu wieksza wyplata
        }
        public class Boj : Pracownik
        {


        }
        class Restauracja : Hotel
        {

        }
        static void Main(string[] args)
        {
        }
    }
}
