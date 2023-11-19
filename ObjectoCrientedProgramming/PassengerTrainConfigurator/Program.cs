using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PassengerTrainConfigurator
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Depot
    {
        private List<Van> _vans;

        public Depot()
        {
            _vans = new List<Van>();
        }

        public void AddVan(Van van)
        {
            _vans.Add(van);
        }

        public Van GetVan(int number)
        {
            foreach (Van van in _vans)
            {
                if (van.NumberSets == number)
                {
                    //возможно будет проблема ПРОВЕРИТЬ.
                    _vans.Remove(van);
                    return van;
                }
                else
                {
                    Console.WriteLine($"В депо нет вагонов с {number} посадочных мест.");
                    return null;
                }
            }

            return null;
        }

        public int MaxSets()
        {
            int maxValue = 0;

            foreach (Van van in _vans)
            {
                if (maxValue < van.NumberSets)
                    maxValue = van.NumberSets;
            }

            return maxValue;
        }

        public int MinSets(int value)
        {
            int minValue = 0;

            foreach (Van van in _vans)
            {
                if (minValue > van.NumberSets && value != van.NumberSets)
                    minValue = van.NumberSets;
            }

            return minValue;
        }
    }

    class Direction
    {
        public Direction(string firstCity, string secondCity)
        {
            FirstCity = firstCity;
            SecondCity = secondCity;
        }

        public string FirstCity { get; private set; }
        public string SecondCity { get; private set; }

        public string Get()
        {
            return $"{FirstCity} -> {SecondCity}";
        }
    }

    class Van
    {
        public Van(int numberSets, char type, string name)
        {
            NumberSets = numberSets;
            Type = type;
            Name = name;
        }

        public int NumberSets { get; private set; }

        public char Type { get; private set; }

        public string Name { get; private set; }
    }

    class SmallVan : Van
    {
        private static int _numberSets = 30;
        private static char _type = 'A';
        private static string _name = "Маленький";

        public SmallVan() : base(_numberSets, _type, _name) { }
    }

    class MidleVan : Van
    {
        private static int _numberSets = 40;
        private static char _type = 'B';
        private static string _name = "Средний";

        public MidleVan() : base(_numberSets, _type, _name) { }
    }

    class BigVan : Van
    {
        private static int _numberSets = 50;
        private static char _type = 'C';
        private static string _name = "Большой";

        public BigVan() : base(_numberSets, _type, _name) { }
    }

    class Train
    {
        private List<Van> _vans;

        public Train(int numberVan)
        {
            _vans = new List<Van>();
            NumberVan = numberVan;
        }

        public int NumberVan { get; private set; }

        public void Fill(int numberPeople, Depot depot)
        {
            int numberBigestVans;
            int passengersWithoutSeats;
            int sets;

            do
            {
                sets = SearchSuitableVan(numberPeople, depot);
                numberBigestVans = numberPeople / sets;
                passengersWithoutSeats = numberPeople - numberBigestVans * sets;

                for (int i = 0; i < numberBigestVans; i++)
                    _vans.Add(depot.GetVan(sets));
            } while (passengersWithoutSeats > 0);
        }

        private int SearchSuitableVan(int people, Depot depot)
        {
            int sets = 0;

            do
            {
                sets = depot.MinSets(sets);
            } while (people % sets <= 1 || sets == depot.MaxSets());

            return sets;
        }
    }

    class Ticket
    {
        public Ticket(float coast,char type)
        {
            Coast = coast;
            Type = type;
        }

        public float Coast {  get; private set; }

        public char Type { get; private set; }
    }

    class TicketOffice
    {
        private List<Ticket> _tickets;

        public TicketOffice()
        {
            _tickets = new List<Ticket>();
        }

        public float Money {  get; private set; }

        public Ticket SellTicket(Person person, char type)
        {
            Money += person.Money;

            return 
        }

        private Ticket SearchSuitableTicket() 
        {

        }
    }

    class Person
    {
        private Ticket _ticket;

        public Person(float money)
        {
            Money = money;
        }

        public float Money { get; private set; }

        public bool EnoughMoney(float money)
        {
            return Money >= money;
        }

        public void BuyTicket(Ticket ticket)
        {
            _ticket = ticket;
            Money -= ticket.Coast;
        }

        public char GetTypeTicket()
        {
            return _ticket.Type;
        }
    }
}
