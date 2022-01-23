using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    //
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch _OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch _OnEndTouch;
    public delegate void SwipeAxis(Vector2 position);
    public event SwipeAxis _OnSwipeAxis;
    //
    private PlayerControls _playerControls;
    private Vector2 _inputPlayerPosition;
    public Vector2 InputPlayer => _inputPlayerPosition;
    
    [SerializeField]private Camera mainCamera;
    private void Awake()
    {
        _playerControls = new PlayerControls();
        mainCamera = Camera.main;
        _playerControls.PlayerInputs.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        _playerControls.PlayerInputs.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
        _playerControls.PlayerInputs.MoveControls.performed += ctx => PlayerInputsVector2(ctx);
    }
    private void OnEnable()
    {
        _playerControls.Enable();
    }
    private void OnDisable()
    {
        _playerControls.Disable();
    }
    private void StartTouchPrimary(InputAction.CallbackContext contex)
    {
        _OnStartTouch?.Invoke(Utils.ScreenToWorld(mainCamera, _playerControls.PlayerInputs.PrimaryPosition.ReadValue<Vector2>()), (float)contex.startTime);
    }
    private void EndTouchPrimary(InputAction.CallbackContext contex)
    {
        _OnEndTouch?.Invoke(Utils.ScreenToWorld(mainCamera, _playerControls.PlayerInputs.PrimaryPosition.ReadValue<Vector2>()), (float)contex.time);
    }
    private void PlayerInputsVector2(InputAction.CallbackContext contex)
    {
        _OnSwipeAxis?.Invoke(contex.ReadValue<Vector2>());  
    }
    

}
