using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;

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

            var deck = new Deck();
            var player = new Player("Maks");

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

            Console.WriteLine("До свидания.");
        }
    }

    class Player
    {
        private List<Card> _cardsOnHand;

        public Player(string name)
        {
            _cardsOnHand = new List<Card>();
            Name = name;
            MaxCards = 4;
        }

        public int MaxCards { get; private set; }

        public string Name { get; private set; }

        public void PutCardInHand(Card card)
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

        public void PickUpCardInDeck(Card card)
        {
            _cardsOnHand.Remove(card);
        }

        public void ShowCardsHand()
        {
            if (_cardsOnHand.Count <= 0)
            {
                Console.WriteLine("Список пуст!");
            }

            foreach (Card card in _cardsOnHand)
            {
                Console.WriteLine($"Значение: {card.Value}\nЦвет: {card.Collor}\nМасть: {card.Suit}\n");
            }
        }

        public void DiscardAllCards()
        {
            _cardsOnHand.Clear();
        }
    }

    class Card
    {

        public Card(int value, string collor, string suit)
        {
            Value = value;
            Collor = collor;
            Suit = suit;
        }

        public int Value { get; private set; }

        public string Collor { get; private set; }
        public string Suit { get; private set; }
    }

    class Deck
    {
        private static Stack<Card> _cards;

        private int _minValue = 2;
        private int _maxValue = 15;
        private int _minValueCollor = 0;
        private int _maxValueCollor = 2;
        private int _minValueSuit = 0;
        private int _maxValueSuit = 4;
        private int _cardsInDeck = 54;

        private static Random _random = new Random();

        public Deck()
        {
            _cards = new Stack<Card>();
            Fill();
        }

        private void Fill()
        {
            string[] _suit = { "крести", "пики", "черви", "бубны" };
            string[] _collor = { "черный", "красный" };

            for (int i = 0; i < _cardsInDeck; i++)
            {
                int value = _random.Next(_minValue, _maxValue);
                string collor = _collor[_random.Next(_minValueCollor, _maxValueCollor)];
                string suit = _suit[_random.Next(_minValueSuit, _maxValueSuit)];

                _cards.Push(new Card(value, collor, suit));
            }

            ShuffleStack(_cards);
        }

        public Card GetCard()
        {
            if (_cards.Count > 0)
            {
                Console.WriteLine("Вы взяли карту.");
                return _cards.Pop();
            }
            else
            {
                Console.WriteLine("Колода пуста.");
                return null;
            }
        }

        private Stack<Card> ShuffleStack(Stack<Card> stack)
        {
            List<Card> list = stack.ToList();

            Shuffle(list);

            return ToStack(list);
        }

        private static void Shuffle(List<Card> list)
        {
            int countList = list.Count;

            Random random = new Random();

            for (int i = 0; i < countList; i++)
            {
                SwapElements(list, i, i + random.Next(countList - i));
            }
        }

        private static void SwapElements(List<Card> list, int aIndex, int bIndex)
        {
            Card temp = list[aIndex];
            list[aIndex] = list[bIndex];
            list[bIndex] = temp;
        }

        public static Stack<Card> ToStack(List<Card> list)
        {
            Stack<Card> stack = new Stack<Card>();

            foreach (Card card in list)
                stack.Push(card);

            return stack;
        }
    }
}