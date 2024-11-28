using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "GameplayConfig", menuName = "Hannah/GameplayConfig")]
public class GameplayConfig : ScriptableObject
{
    [Header("Player")]
    public float MovementSpeed;
    
    [Header("Physics Player")]
    [HideInInspector] public float MovementAcceleration;
    [HideInInspector] public float MaxMovementSpeed;
    [HideInInspector] public float MovementDamping;
    [HideInInspector] public float JumpStrength;
    [HideInInspector] public float SlamStrength;
}
