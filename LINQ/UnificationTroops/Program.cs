using System;
using System.Collections.Generic;
using System.Linq;

namespace UnificationTroops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Armies armies = new Armies();
            armies.Work();
        }
    }

    class Armies
    {
        private List<Soldier> _firstSquad;
        private List<Soldier> _secondSquad;

        public Armies()
        {
            _firstSquad = new List<Soldier>
            {
                new Soldier("Петров", "Рядовой"),
                new Soldier("Иванов", "Рядовой"),
                new Soldier("Сидоров", "Сержант"),
                new Soldier("Белый", "Сержант"),
                new Soldier("Носков", "Старший сержант")
            };
            _secondSquad = new List<Soldier>
            {
                new Soldier("Соболев", "Рядовой"),
                new Soldier("Кудрявцев", "Рядовой")
            };
        }

        public void Work()
        {
            Console.WriteLine("Отряд 1");
            ShowSoldiersInfo(_firstSquad);
            Console.WriteLine("Отряд 2");
            ShowSoldiersInfo(_secondSquad);

            MoveSelectedSoldiers();

            Console.WriteLine("\nОтряд 1");
            ShowSoldiersInfo(_firstSquad);
            Console.WriteLine("Отряд 2");
            ShowSoldiersInfo(_secondSquad);
        }

        private void MoveSelectedSoldiers()
        {
            var soldiers = _firstSquad.Where(soldier => soldier.Name.Contains("Б"));
            _secondSquad = _secondSquad.Union(soldiers).ToList();
            _firstSquad = _firstSquad.Except(soldiers).ToList();
        }

        private void ShowSoldiersInfo(List<Soldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                soldier.ShowSolider();
            }
        }
    }

    class Soldier
    {
        public Soldier(string name, string rank)
        {
            Name = name;
            Rank = rank;
        }

        public string Name { get; private set; }
        public string Rank { get; private set; }

        public void ShowSolider()
        {
            Console.WriteLine($"Имя: {Name} | Воинское звание: {Rank}.");
        }
    }
}