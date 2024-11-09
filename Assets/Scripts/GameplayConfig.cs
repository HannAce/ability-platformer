using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "GameplayConfig", menuName = "Hannah/GameplayConfig")]
public class GameplayConfig : ScriptableObject
{
    [Header("Player")]
    public float MovementAcceleration;
    public float MaxMovementSpeed;
    public float MovementDamping;
    public float JumpStrength;
    public float SlamStrength;
    
    
}
