using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CursorScript : MonoBehaviour
{

    [SerializeField] private float cursorSpeed = 560f;
    private Camera _camera;
    private RectTransform cursorTransform;
    private Vector2 pos;
    private Vector2 dir;
    public PlayerInput cursorInput;
    

    private InputAction lookAction;
    //playerInput = GetComponent<PlayerInput>();

    private void Awake()
    {
        _camera = Camera.main;
        cursorTransform = GetComponent<RectTransform>();
        Rect r = _camera.rect;
        pos = new Vector2((r.x + r.width * 0.5f) * Screen.width, (r.y + r.height * 0.5f) * Screen.height);

    }

    void Start()
    {
        
        lookAction = cursorInput.actions["Look"];
    }

    void Update()
    {
        dir = lookAction.ReadValue<Vector2>();
        pos += dir * cursorSpeed * Time.deltaTime;
        ClampCursor();
        cursorTransform.position = pos;
    }

    private void ClampCursor() //This part is more or less not needed but it'll work for multiple cameras
    {
        Rect r = _camera.rect;
        float minX = r.x * Screen.width;
        float maxX = (r.x + r.width) * Screen.width;
        float minY = r.y * Screen.height;
        float maxY = (r.y + r.height) * Screen.height;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

    }
}
