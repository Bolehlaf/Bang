using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Card
    {
        protected int _id;
        protected CardType _cardType;
        protected int _value;
        protected CardSuit _cardSuit;
        protected Character _owner;
    }
}