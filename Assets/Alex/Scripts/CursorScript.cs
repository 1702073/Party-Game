using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CursorScript : MonoBehaviour
{

    [SerializeField] private float cursorSpeed = 560f;
    [SerializeField] private Camera camera;
    private RectTransform cursorTransform;
    private Vector2 pos;
    private Vector2 dir;
    private PlayerInput playerInput;
    private InputAction lookAction;

    private void Awake()
    {
        cursorTransform = GetComponent<RectTransform>();
        Rect r = camera.rect;
        pos = new Vector2((r.x + r.width * 0.5f) * Screen.width, (r.y + r.height * 0.5f) * Screen.height);

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
