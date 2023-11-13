using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LinkedList_Deck
{
    internal class Deck
    {
        public LinkedList<int> deck = new LinkedList<int>();
        public LinkedList<int> dealer = new LinkedList<int>();
        public delegate int Picker();

        public Deck()
        {
            for (int i = 1; i <= 10; i++)
            {
                dealer.AddLast(i);
            }
        }

        public void AddCardLast(int card)
        {
            if (dealer.Remove(card))
            {
                deck.AddLast(card);
            }
        }

        public int PickCard()
        {
            if (deck.Count > 0)
            {
                int value = deck.Last();
                deck.RemoveLast();
                return value;
            }
            else
            {
                return 0;
            }
        }

        public int PickLastCard()
        {
            if (deck.Count > 0)
            {
                int value = deck.First();
                deck.RemoveFirst();
                return value;
            }
            else
            {
                return 0;
            }
        }
    }
}
