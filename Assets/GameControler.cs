using Assets.Scripts.Cards;
using Assets.Scripts.MonoBehaviours;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Random = System.Random;

public class GameControler : MonoBehaviour
{
    public List<GameObject> Seats = new List<GameObject>();
    public List<Character> Players = new List<Character>();
    public List<Character> ActivePlayers = new List<Character>();
    public Character CurrentPlayer;
    public int startPlayersCount;
    [SerializeField] private Dealer _dealer;

    private bool _choosingBangTarget;
    public Character Target;
    private Bang activeBang;

    #region Character roles

    Dictionary<int, List<Role>> ingameRoles = new Dictionary<int, List<Role>>()
    {
        { 4, new List<Role>() {Role.Sherrif, Role.Bandit, Role.Bandit, Role.Renegade } },
        { 5, new List<Role>() {Role.Sherrif, Role.Bandit, Role.Bandit, Role.Deputy, Role.Renegade } },
        { 6, new List<Role>() {Role.Sherrif, Role.Bandit, Role.Bandit, Role.Bandit, Role.Deputy, Role.Renegade } },
        { 7, new List<Role>() {Role.Sherrif, Role.Bandit, Role.Bandit, Role.Bandit, Role.Deputy, Role.Deputy, Role.Renegade } },
        { 8, new List<Role>() {Role.Sherrif, Role.Bandit, Role.Bandit, Role.Bandit, Role.Deputy, Role.Deputy, Role.Renegade, Role.Renegade } }
    };

    #endregion Character roles

    public void Update()
    {
        if (_choosingBangTarget)
        {
            if (Target != null)
            {
                _choosingBangTarget = false;
                Shoot();
            }
        }
    }

    public void StartGame()
    {
        if (startPlayersCount < 4 || startPlayersCount > 8)
            return;
        InstantiatePlayers();
    }

    public void ChoosingBangTarget(Bang card)
    {
        _choosingBangTarget = true;
        activeBang = card;
    }
    
    public void SelectBangTarget(Character target)
    {
        if (_choosingBangTarget)
            Target = target;
    }

    private void InstantiatePlayers()
    {
        var prefab = Resources.Load("Game Character");
        Random random = new Random();
        Stack<Role> roles = new Stack<Role>(ingameRoles[startPlayersCount].OrderBy(x => random.Next()));

        for (int i = 0; i < startPlayersCount;  i++)
        {
            var character = Instantiate(prefab, Seats[i].transform).GetComponent<Character>();
            character.Initialize(roles.Pop(), i);
        }
    }

    private void Shoot()
    {
        Target.UnderFire();
        Target = null;
        _choosingBangTarget = false;
        activeBang = null;
    }
}
