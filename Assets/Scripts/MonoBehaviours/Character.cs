using Assets.Scripts;
using Assets.Scripts.Cards;
using Assets.Scripts.MonoBehaviours;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Dealer _dealer;
    public int _maxHealth = 4;
    public int _health;
    public Role _role;
    protected List<Card> _handCards = new List<Card>();
    protected List<Card> _statusCards = new List<Card>();
    protected bool _onTurn = false;
    protected Card _selectedCard = null;
    public int _range;

    private bool _underFire = false;
    private bool _discardPhase = false;

    private Transform _hand;

    public int Seat { get; set; }

    [SerializeField] private TextMeshProUGUI _text;

    public void Update()
    {
        UpdateInfo();
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
        _dealer = GameObject.FindWithTag("Dealer").GetComponent<Dealer>();

        _role = role;
        DrawCards(_maxHealth);
        _maxHealth = role == Role.Sherrif ? _maxHealth + 1 : _maxHealth;
        _health = _maxHealth;
        _range = 1;
        
        if (Seat == 0)
        {
            _hand = GameObject.FindWithTag("Hand").transform;
        }
    }

    public void DrawCards(int amount)
    {
        var cards = _dealer.Draw(amount);
        foreach (var card in cards)
        {
            card.transform.SetParent(_hand);
        }
        _handCards.AddRange(cards);
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

    public void Discard(Card card)
    {
        _dealer.Discard(card);
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
        if (_handCards.Count > _health)
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

    private void UpdateInfo()
    {
        StringBuilder info = new StringBuilder();
        info.Append("role ");
        info.Append(_role.ToString());
        info.AppendLine();
        info.Append("health: ");
        info.Append(_health.ToString());
        _text.text = info.ToString();
    }
}
