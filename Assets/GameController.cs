using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Character> players = new List<Character>();
    public List<Character> activePlayers = new List<Character>();
    public Character CurrentPlayer;
}
