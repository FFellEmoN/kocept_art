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

        public Van GetVan(char number)
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
                    Console.WriteLine($"В депо вагонов типа {van.Type} больше нет.");
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
        public Direction(int x, int y)
        {

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
            int minimumAllowedValue = 1;
            int numberBigVans = numberPeople % depot.MaxSets();
            int minimumSets = 0;
            int passengersWithoutSeats = numberPeople - numberBigVans * depot.MaxSets();

            if (numberBigVans >= minimumAllowedValue)
            {
                for (int i = 0; i < numberBigVans; i++)
                {
                    _vans.Add(GetType(depot.MaxSets());
                }
            }
            else
            {
                do
                {
                    minimumSets = depot.MinSets(minimumSets);
                } while (minimumSets % passengersWithoutSeats >= 1);

                _vans.Add(GetType)
            }
        }
    }
}
