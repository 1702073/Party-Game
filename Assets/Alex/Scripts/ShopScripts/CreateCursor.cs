using UnityEngine;
using UnityEngine.InputSystem;

public class CreateCursor : MonoBehaviour
{
    [SerializeField] private GameObject cursorPrefab;
    [SerializeField] private RectTransform canvasTransform;




    public void Join(PlayerInput player)
    {
        if (player.GetComponent<PlayerInput>().currentControlScheme == "Gamepad") //
        {
            GameObject cursor = Instantiate(cursorPrefab, canvasTransform);
        }

    }

}
