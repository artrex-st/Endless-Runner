using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Configuration", menuName = "Config/PlayerControll")]
public class PlayerControlConfig : ScriptableObject
{
    [Header("Lanes")]
    public float horizontalSpeed = 15;
    public float laneDistanceX = 1.5f;
    [Header("Jump")]
    public float jumpDistanceZ = 5;
    public float jumpHeightY = 2, jumpLerpSpeed = 10;
    [Header("Roll")]
    public float rollDistanceZ = 5;
}
