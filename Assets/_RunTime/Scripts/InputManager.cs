using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    //
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;
    public delegate void SwipeAxis(Vector2 position);
    public event SwipeAxis OnSwipeAxis;
    //
    private PlayerControls playerControls;
    private Vector2 inputPlayerPosition;
    public Vector2 InputPlayer => inputPlayerPosition;
    
    [SerializeField]private Camera mainCamera;
    private void Awake()
    {
        playerControls = new PlayerControls(); // new Inputsystem
        mainCamera = Camera.main; // TODO
        playerControls.PlayerInputs.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        playerControls.PlayerInputs.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
        // axis Keys
        playerControls.PlayerInputs.MoveControls.started += ctx => PlayerInputsVector2(ctx); // move axis
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    private void StartTouchPrimary(InputAction.CallbackContext contex)
    {
        if (OnStartTouch != null)
        {
            OnStartTouch(Utils.ScreenToWorld(mainCamera, playerControls.PlayerInputs.PrimaryPosition.ReadValue<Vector2>()), (float)contex.startTime);
        }
    }
    private void EndTouchPrimary(InputAction.CallbackContext contex)
    {
        if (OnEndTouch != null)
        {
            OnEndTouch(Utils.ScreenToWorld(mainCamera, playerControls.PlayerInputs.PrimaryPosition.ReadValue<Vector2>()), (float)contex.time);
        }
    }
    private void PlayerInputsVector2(InputAction.CallbackContext contex)
    {
        if (OnSwipeAxis != null)
        {
            OnSwipeAxis(contex.ReadValue<Vector2>());  
        }
    }
    // public Vector2 PrimaryPosition() // TRAIL
    // {
    //     return Utils.ScreenToWorld(mainCamera, playerControls.PlayerInputs.PrimaryPosition.ReadValue<Vector2>());
    // }
}
