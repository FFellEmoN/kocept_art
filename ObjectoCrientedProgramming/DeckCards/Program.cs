using System;
using System.Collections.Generic;

namespace DeckCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOnTable = 0;

            var deck = new Deck();
            var player_1 = new Player(++numberOnTable, "Maks");

            PutCardsInHand(player_1, deck);

            Console.WriteLine($"Рука {player_1.Name}");
            player_1.ShowCardsHand();
            Console.ReadKey();
        }

        private static void PutCardsInHand(Player player, Deck deck)
        {
            for (int i = 0; i < player.MaxCards; i++)
            {
                player.PutCardInHand(deck.GetCard());
            }
        }
    }

    class Player
    {
        private List<Cards> _cardsOnHand;
        public Player(int numberOnTable, string name)
        {
            _cardsOnHand = new List<Cards>();
            NumberOnTable = numberOnTable;
            Name = name;
            MaxCards = 4;
        }

        public int NumberOnTable { get; private set; }

        public string Name { get; private set; }

        public int MaxCards { get; private set; }

        public void PutCardInHand(Cards card)
        {
            if (_cardsOnHand.Count < 4)
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
            foreach (Cards card in _cardsOnHand)
            {
                Console.WriteLine($"Значение: {card.Value}\nЦвет: {card.Collor}\nМасть: {card.Suit}\n");
            }
        }
    }

    class Cards
    {
        public Cards()
        {
            Random random = new Random();

            Value = random.Next(2, 15);
            Collor = SetCollor(random.Next(0, 2));
            Suit = SetSuit(random.Next(0, 4));
        }

        public int Value { get; private set; }

        public string Collor { get; private set; }

        public string Suit { get; private set; }

        private string SetCollor(int value)
        {
            if (value > 0)
            {
                return "черная";
            }
            else
            {
                return "красная";
            }
        }

        private string SetSuit(int value)
        {
            const int crosses = 0;
            const int spades = 1;
            const int hearts = 2;
            const int diamonds = 3;

            switch (value)
            {
                case crosses:
                    return "крести";

                case spades:
                    return "пики";

                case hearts:
                    return "черви";

                case diamonds:
                    return "бубны";

                default:
                    return "";
            }
        }
    }

    class Deck
    {
        private Stack<Cards> _deck;

        public Deck()
        {
            _deck = new Stack<Cards>();
            FillDeck();
        }

        private void FillDeck()
        {
            for (int i = 0; i < 5; i++)
            {
                _deck.Push(new Cards());
            }
        }

        public Cards GetCard()
        {
            return _deck.Pop();
        }
    }
}