using Assets.Scripts.MonoBehaviours;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class GameController : MonoBehaviour
{
    public List<GameObject> Seats = new List<GameObject>();
    public List<Character> Players = new List<Character>();
    public List<Character> ActivePlayers = new List<Character>();
    public Character CurrentPlayer;
    public int startPlayersCount;
    [SerializeField] private Dealer _dealer;

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

    public void StartGame()
    {
        if (startPlayersCount < 4 || startPlayersCount > 8)
            return;
        _dealer.Shuffle();
        InstantiatePlayers();
    }

    private void InstantiatePlayers()
    {
        var prefab = Resources.Load("Game Character");
        Random random = new Random();
        Stack<Role> roles = new Stack<Role>(ingameRoles[startPlayersCount].OrderBy(x => random.Next()));

        for (int i = 0; i < startPlayersCount;  i++)
        {
            var character = Instantiate(prefab, Seats[i].transform).GetComponent<Character>();
            character.Initialize(roles.Pop());
            character.Seat = i;
        }
    }
}
