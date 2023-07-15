using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Card : MonoBehaviour
    {
        protected int _id;
        public CardType _cardType;
        public int _value;
        public CardSuit _cardSuit;
        public Character Owner;

        public virtual void Initialize(int value, CardSuit suit)
        {
            _value = value;
            _cardSuit = suit;
        }
    }
}