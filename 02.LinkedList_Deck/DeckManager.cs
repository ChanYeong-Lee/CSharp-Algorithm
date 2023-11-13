using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LinkedList_Deck
{
    internal class DeckManager
    {
        public Deck deck;
        public DeckManager()
        {
            deck = new Deck();
        }

        public void AddCard()
        {
            while (deck.dealer.Count > 0)
            {
                int number;
                try
                {
                    number = int.Parse(Console.ReadLine());
                    deck.AddCardLast(number);
                }
                catch
                {
                    continue;
                }
            }
        }

        public int PickCard()
        {
            while (true)
            {
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        return deck.PickCard();
                        break;
                    case 2:
                        return deck.PickLastCard();
                        break;
                    default:
                        return 0;
                }
            }
        }

        public void Operate()
        {
            AddCard();

            while (deck.deck.Count() > 0)
            {
                int card = PickCard();
                if (card != 0)
                {
                    Console.WriteLine("You picked {0}", card);
                }
            }
        }
    }
}
