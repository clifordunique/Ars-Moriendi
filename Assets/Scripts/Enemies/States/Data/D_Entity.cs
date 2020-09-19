﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Entity Data", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public float wallCheckDistance = 0.2f;
    public float ledgeCheckDistance = 0.4f;

    public float minAgroDistance = 3.0f;
    public float maxAgroDistance = 4.0f;

    public float closeRangeActionDistance = 1.0f;
    public float longRangeActionDistance = 4.0f;

    public float maxPlayerJumpedOverDistance = 1.0f;

    public float maxHealth = 30.0f;

    public float damageHopSpeed = 9.0f;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}
