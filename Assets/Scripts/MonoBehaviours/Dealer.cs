using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.MonoBehaviours
{
    public class Dealer : MonoBehaviour
    {
        private Stack<Card> _deck = new Stack<Card>();
        private Stack<Card> _discard = new Stack<Card>();

        public void Update()
        {
            if (_deck.Count <= 0)
                Shuffle();
        }

        public List<Card> Draw(int amount)
        {
            List<Card> drawnCards = new List<Card>();

            for (int i = 0; i < amount - 1; i++)
            {
                drawnCards.Add(_deck.Pop());
            }

            return drawnCards;
        }

        public void Discard(Card card)
        {
            _discard.Push(card);
        }

        private void Shuffle()
        {
            Random rnd = new Random();
            _deck = new Stack<Card>(_discard.OrderBy(c => rnd.Next()));
            _discard.Clear();
        }
    }
}