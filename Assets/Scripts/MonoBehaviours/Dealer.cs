using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.MonoBehaviours
{
    public class Dealer : MonoBehaviour
    {
        private Stack<Card> _deck = new Stack<Card>();
        private Stack<Card> _discard = new Stack<Card>();

        public void Start()
        {
            LoadCards();
        }

        private void LoadCards()
        {
            var cardPrefabs = Resources.LoadAll("Prefabs/Cards");
            foreach (Object prefab in cardPrefabs)
            {
                Card card;
                Random random = new Random();
                for (int i = 0; i < 10; i++)
                {
                    card = Instantiate(prefab).GetComponent<Card>();
                    card.Initialize(random.Next(2, 15), (CardSuit)random.Next(4));
                    _discard.Push(card);
                }
            }
        }

        public void Update()
        {
            if (_deck.Count <= 0)
                Shuffle();
        }

        public List<Card> Draw(int amount)
        {
            List<Card> drawnCards = new List<Card>();

            for (int i = 0; i < amount; i++)
            {
                drawnCards.Add(_deck.Pop());
            }

            return drawnCards;
        }

        public void Discard(Card card)
        {
            _discard.Push(card);
            card.transform.parent = null;
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            _deck = new Stack<Card>(_discard.OrderBy(c => rnd.Next()));
            _discard.Clear();
        }
    }
}