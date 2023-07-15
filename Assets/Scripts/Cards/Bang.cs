using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Cards
{
    public class Bang : Card
    {
        private bool _choosingTarget = false;
        private Character _target;

        public void Update()
        {
            if (_choosingTarget )
            {
                if ( _target != null )
                {
                    _choosingTarget = false;
                    Shoot(_target);
                }
            }
        }

        public void ChooseTarget()
        {
            _choosingTarget = true;
        }

        public void Shoot (Character target)
        {
            target.UnderFire();
            Owner.Discard(this);
        }

        public override void Initialize(int value, CardSuit suit)
        {
            base.Initialize(value, suit);
            _cardType = CardType.Brown;
        }
    }
}