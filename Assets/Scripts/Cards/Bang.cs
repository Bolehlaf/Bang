using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Cards
{
    public class Bang : Card
    {
        public void Shoot (Character target)
        {
            target.UnderFire();
        }
    }
}