using Assets.Scripts;
using Assets.Scripts.Cards;
using Assets.Scripts.MonoBehaviours;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Dealer _dealer;

    protected int _maxHealth = 4;
    protected int _health;
    protected Role _role;
    protected int _seat;
    protected List<Card> _hand = new List<Card>();
    protected List<Card> _statusCards = new List<Card>();
    protected bool _onTurn = false;
    protected Card _selectedCard = null;
    protected int _range;

    private bool _underFire = false;
    private bool _discardPhase = false;

    public void Update()
    {
        if (_underFire)
        {
            if (_selectedCard.GetType() == typeof(Mancato))
            {
                _underFire = false;
                _dealer.Discard(_selectedCard);
                _selectedCard = null;
            }
        }

        if (_discardPhase) 
        {
            if (_selectedCard != null) 
            {
                _dealer.Discard(_selectedCard);
            }
            EndTurn();
        }
    }

    public void Initialize(Role role)
    {
        _role = role;
        _maxHealth = role == Role.Sherrif ? _maxHealth + 1 : _maxHealth;
        _health = _maxHealth;
    }

    public void DrawCards()
    {
        _hand.AddRange(_dealer.Draw(2));
    }

    public void Wound()
    {
        _health--;

        if (_health <= 0 )
        {
            Die();
        }
    }

    public void Heal()
    {
        if (_health >= _maxHealth)
            return;

        _health++;
    }

    public void UnderFire()
    {
        _underFire = true;
    }

    public void Pass()
    {
        _underFire = false;
        Wound();
    }

    public void EndTurn()
    {
        if (_hand.Count > _health)
        {
            _discardPhase = true;
            return;
        }

        _discardPhase = false;
        _onTurn = false;
    }

    private void Die()
    {
    }
}
