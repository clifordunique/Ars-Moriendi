﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Dodge State Data", menuName = "Data/State Data/Dodge State")]
public class D_DodgeState : ScriptableObject
{
    public float dodgeSpeed = 9.0f;
    public Vector2 dodgeAngle;
    public float dodgeTime = 0.2f;
    public float dodgeCooldwon = 2.0f;
}
