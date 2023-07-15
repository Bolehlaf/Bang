using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Cards
{
    public class Beer : Card
    {
        public void Drink()
        {
            _owner.Heal();
        }
    }
}