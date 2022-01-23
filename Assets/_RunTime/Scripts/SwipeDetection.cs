using System.Collections;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float minimumDistance = 0.2f;
    [SerializeField] private float maximumTime = 1f;
    [SerializeField, Range(0,1)] private float directionThreshold = 0.9f;
    // [SerializeField] private GameObject trail; // TRAIL
    // private Coroutine trailPosition; // TRAIL
    private Vector2 startPosition;
    private Vector2 endPosition;
    private float startTime;
    private float endTime;
    private Vector2 axisDirection;
    public Vector2 AxisDirection => axisDirection;

    private void Start()
    {
        inputManager = inputManager != null ? inputManager : GetComponentInParent<InputManager>();
        playerController = playerController != null ? playerController : GetComponentInParent<PlayerController>();
    }
    private void OnEnable()
    {
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
        inputManager.OnSwipeAxis += SwipeAxis;
    }
    private void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
        inputManager.OnSwipeAxis -= SwipeAxis;
    }
    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
        // TRAIL
        // trail.SetActive(true);
        // trail.transform.position = position;
        // trailPosition = StartCoroutine(TrailPosition());
        // TRAIL
    }
    // private IEnumerator TrailPosition() // TRAIL
    // {
    //     while(true)
    //     {
    //         trail.transform.position = inputManager.PrimaryPosition();
    //         yield return null;
    //     }
    // } // TRAIL
    private void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        DetectSwipe();
        // TRAIL
        // trail.SetActive(false);
        // StopCoroutine(trailPosition);
        // TRAIL
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
