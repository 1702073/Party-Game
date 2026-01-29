using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJoin : MonoBehaviour
{
    public static List<GameObject> players = new();
    public void PlayerJoined(PlayerInput player)
    {
        players.Add(player.gameObject);

        //if (player.GetComponent<PlayerInput>().currentControlScheme == "Gamepad")
        //{
        //    GameObject cursor = Instantiate(cursorPrefab, canvasTransform);
        //}
    }

}
