using System;
using System.Collections.Generic;

namespace DeckCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ShowHandCardsMenu = "1";
            const string PutCardMenu = "2";
            const string DiscardsCardsHand = "3";
            const string ExitMenu = "4";

            bool isWork = true;

            string disaredAction;

            int numberOnTable = 0;

            var deck = new Deck();
            var player = new Player(++numberOnTable, "Maks");

            do
            {
                Console.WriteLine($"{ShowHandCardsMenu} - показать карты на руках.");
                Console.WriteLine($"{PutCardMenu} - взять карту.");
                Console.WriteLine($"{DiscardsCardsHand} - cбросить карты с руки.");
                Console.WriteLine($"{ExitMenu} - выйти из приложения.");

                Console.WriteLine("Выбирите желаемое действие");
                disaredAction = Console.ReadLine();

                switch (disaredAction)
                {
                    case ShowHandCardsMenu:
                        player.ShowCardsHand();
                        break;

                    case PutCardMenu:
                        player.PutCardInHand(deck.GetCard());
                        break;

                    case DiscardsCardsHand:
                        player.DiscardAllCards();
                        break;

                    case ExitMenu:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Действие не существует.");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                Console.ReadKey();
                Console.Clear();
            } while (isWork);
        }
    }

    class Player
    {
        private List<Cards> _cardsOnHand;

        public Player(int numberOnTable, string name)
        {
            _cardsOnHand = new List<Cards>();
            Name = name;
            MaxCards = 4;
        }

        public int MaxCards { get; private set; }

        public string Name { get; private set; }

        public void PutCardInHand(Cards card)
        {
            if (_cardsOnHand.Count < MaxCards && card != null)
            {
                _cardsOnHand.Add(card);
            }
            else
            {
                Console.WriteLine("На руках максимальное число карт.");
            }
        }

        public void PickUpCardInDeck(Cards card)
        {
            _cardsOnHand.Remove(card);
        }

        public void ShowCardsHand()
        {
            if (_cardsOnHand.Count <= 0)
            {
                Console.WriteLine("Список пуст!");
            }

            foreach (Cards card in _cardsOnHand)
            {
                Console.WriteLine($"Значение: {card.Value}\nЦвет: {card.Collor}\nМасть: {card.Suit}\n");
            }
        }

        public void DiscardAllCards()
        {
            _cardsOnHand.Clear();
        }
    }

    class Cards
    {
        private int _minValue = 2;
        private int _maxValue = 15;
        private int _minValueCollor = 0;
        private int _maxValueCollor = 2;
        private int _minValueSuit = 0;
        private int _maxValueSuit = 4;

        private static Random _random = new Random();
        public Cards()
        {
            Value = _random.Next(_minValue, _maxValue);
            Collor = SetCollor(_random.Next(_minValueCollor, _maxValueCollor));
            Suit = SetSuit();
        }

        public int Value { get; private set; }

        public string Collor { get; private set; }
        public string Suit { get; private set; }

        private string SetCollor(int value)
        {
            string[] collor = { "черный", "красный"};
            Random random = new Random();

            return collor[random.Next(0, collor.Length)];
        }

        private string SetSuit()
        {
            string[] suit = { "крести", "пики", "черви", "бубны" };
            Random random = new Random();
            
            return suit[random.Next(0, suit.Length)];
        }
    }

    class Deck
    {
        private Stack<Cards> _deck;
        private int _cardsInDeck = 54;

        public Deck()
        {
            _deck = new Stack<Cards>();
            FillDeck();
        }

        private void FillDeck()
        {
            for (int i = 0; i < _cardsInDeck; i++)
            {
                _deck.Push(new Cards());
            }
        }

        public Cards GetCard()
        {
            if (_deck.Count > 0)
            {
                return _deck.Pop();
            }
            else
            {
                return null;
            }
        }
    }
}