using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Cards
{
    public class Bang : Card
    {
        public override void Initialize(int value, CardSuit suit)
        {
            base.Initialize(value, suit);
            _cardType = CardType.Brown;
        }

        public void ChooseTarget()
        {
            Owner.GameControler.ChoosingBangTarget(this);
            Owner.Discard(this);
        }
    }
}