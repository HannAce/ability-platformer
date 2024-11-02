using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameplayConfig", menuName = "Hannah/GameplayConfig")]
public class GameplayConfig : ScriptableObject
{
    [Header("Player")]
    public float PlayerMovementSpeed;
}
