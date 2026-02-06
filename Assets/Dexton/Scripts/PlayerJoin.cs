using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerJoin : MonoBehaviour
{
    public static List<GameObject> players = new();
    public void PlayerJoined(PlayerInput player)
    {
        players.Add(player.gameObject);
        
    }

}
