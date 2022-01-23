using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerAnimationController))]
public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameMode gameMode;
    private PlayerController playerController;
    private PlayerAnimationController animationController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        animationController = GetComponent<PlayerAnimationController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Obstacle obstacle = other.GetComponent<Obstacle>();
        //if (obstacle != null)
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            playerController.Die();
            animationController.Die();
            gameMode.OnGameOver();
            obstacle.PlayCollisionFeedBack(other);
        }
        if (other.TryGetComponent(out PicUp picUp))
        {
            gameMode.AddPickUp();
            picUp.OnPic();
        }
    }
}
