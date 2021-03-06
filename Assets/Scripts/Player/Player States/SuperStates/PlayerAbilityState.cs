﻿using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    public bool IsAbilityDone { get; protected set; }

    private bool _isGrounded;

    public PlayerAbilityState(Player player, PlayerFiniteStateMachine playerFiniteStateMachine, D_PlayerData playerData, string animationBoolName)
        : base(player, playerFiniteStateMachine, playerData, animationBoolName)
    {
        IsAbilityDone = true;
    }

    public override void Enter()
    {
        base.Enter();

        IsAbilityDone = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (IsAbilityDone)
        {
            Debug.Log("IsAbilityDone");

            if (_isGrounded && Player.CurrentVelocity.y < 0.01f)
            {
                FiniteStateMachine.ChangeState(Player.IdleState);
            }
            else
            {
                FiniteStateMachine.ChangeState(Player.InAirState);
            }
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();

        _isGrounded = Player.CheckIfGrounded();
    }
}
