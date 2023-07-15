using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Cards
{
    public class Mancato : Card
    {
        public override void Initialize(int value, CardSuit suit)
        {
            base.Initialize(value, suit);
            _cardType = CardType.Brown;
        }
    }
}