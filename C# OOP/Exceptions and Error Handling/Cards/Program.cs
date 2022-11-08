using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
            List<Card> cards = new List<Card>();
            for (int i = 0; i < input.Length; i++)
            {
                string[] currentInput = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string face = currentInput[0];
                string suit = currentInput[1];
                try
                {
                    Card card = new Card(face, suit);
                    cards.Add(card);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            Console.WriteLine(string.Join(" ", cards));
        }
    }
    public class Card
    {
        private Dictionary<string, string> suitSymbols = new Dictionary<string, string>
        {
            {"S","\u2660"},
            {"H","\u2665"},
            {"D","\u2666"},
            {"C","\u2663"}
        };
        private string[] arrayFaces = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private string[] arraySuits = new string[] { "S", "H", "D", "C" };
        private string cardFace;
        private string suit;

        public Card(string cardFace, string suit)
        {
            CardFace = cardFace;
            CardSuit = suit;
        }

        public string CardFace
        {
            get { return cardFace; }
            private set
            {
                if (arrayFaces.Contains(value))
                {
                    cardFace = value;
                }
                else
                {
                    throw new ArgumentException("Invalid card!");
                }
            }
        }
        public string CardSuit
        {
            get { return suit; }
            private set
            {
                if (arraySuits.Contains(value))
                {
                    suit = value;
                }
                else
                {
                    throw new ArgumentException("Invalid card!");
                }
            }
        }
        public override string ToString()
        {
            return $"[{CardFace}{suitSymbols[CardSuit]}]";
        }
    }
}
