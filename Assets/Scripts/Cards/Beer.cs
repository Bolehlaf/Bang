using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Cards
{
    public class Beer : Card
    {
        public void Drink()
        {
            Owner.Heal();
        }

        public override void Initialize(int value, CardSuit suit)
        {
            base.Initialize(value, suit);
            _cardType = CardType.Brown;
        }
    }
}