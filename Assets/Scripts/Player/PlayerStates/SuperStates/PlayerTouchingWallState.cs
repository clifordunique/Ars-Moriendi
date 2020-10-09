﻿using UnityEngine;

public class PlayerTouchingWallState : PlayerState
{
    protected bool IsGrounded;
    protected bool IsTouchingWall;
    protected int XInput;
    protected int YInput;
    protected bool GrabInput;
    protected bool JumpInput;

    public PlayerTouchingWallState(Player Player, PlayerFiniteStateMachine FiniteStateMachine, D_PlayerData PlayerData, string _animationBoolName) : base(Player, FiniteStateMachine, PlayerData, _animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        XInput = Player.InputHandler.NormalizedInputX;
        YInput = Player.InputHandler.NormalizedInputY;
        GrabInput = Player.InputHandler.GrabInput;
        JumpInput = Player.InputHandler.JumpInput;

        if (JumpInput)
        {
            Player.WallJumpState.DetermineWallJumpDirection(IsTouchingWall);
            FiniteStateMachine.ChangeState(Player.WallJumpState);
        }
        else if (IsGrounded && !GrabInput)
        {
            FiniteStateMachine.ChangeState(Player.IdleState);
        }
        else if (!IsTouchingWall || (XInput != Player.FacingDirection && !GrabInput))
        {
            FiniteStateMachine.ChangeState(Player.InAirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();

        IsGrounded = Player.CheckIfGrounded();
        IsTouchingWall = Player.CheckIfTouchingWall();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void AnimationFinishedTrigger()
    {
        base.AnimationFinishedTrigger();
    }

}