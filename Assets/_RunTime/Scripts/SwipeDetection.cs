using System.Collections;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float minimumDistance = 0.2f;
    [SerializeField] private float maximumTime = 1f;
    [SerializeField, Range(0,1)] private float directionThreshold = 0.9f;
    private Vector2 startPosition, endPosition;
    private float startTime, endTime;
    private Vector2 axisDirection;
    public Vector2 AxisDirection => axisDirection;

    private void Start()
    {
        inputManager = inputManager != null ? inputManager : GetComponentInParent<InputManager>();
        playerController = playerController != null ? playerController : GetComponentInParent<PlayerController>();
    }
    private void OnEnable()
    {
        inputManager._OnStartTouch += SwipeStart;
        inputManager._OnEndTouch += SwipeEnd;
        inputManager._OnSwipeAxis += SwipeAxis;
    }
    private void OnDisable()
    {
        inputManager._OnStartTouch -= SwipeStart;
        inputManager._OnEndTouch -= SwipeEnd;
        inputManager._OnSwipeAxis -= SwipeAxis;
    }
    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;

    }
    private void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }
    private void DetectSwipe()
    {
        if (Vector3.Distance(startPosition, endPosition) >= minimumDistance && (endTime - startTime) <= maximumTime)
        {
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            playerController.SwipeDirection(direction2D, directionThreshold);
        }
    }
    private void SwipeAxis(Vector2 axis)
    {
        playerController.PlayerInputsVector2(axis);
    }
}
