﻿using UnityEngine;

public class PlayerState
{
    public D_PlayerData PlayerData { get; private set; }
    protected Player Player;
    protected PlayerFiniteStateMachine FiniteStateMachine;

    protected float StartTime;

    protected bool IsAnimationFinished;

    private string _animationBoolName;

    public PlayerState(Player Player, PlayerFiniteStateMachine FiniteStateMachine, D_PlayerData PlayerData, string _animationBoolName)
    {
        this.Player = Player;
        this.FiniteStateMachine = FiniteStateMachine;
        this.PlayerData = PlayerData;
        this._animationBoolName = _animationBoolName;
    }

    public virtual void Enter()
    {
        DoChecks();

        Player.MyAnmator.SetBool(_animationBoolName, true);

        StartTime = Time.time;

        Debug.Log(_animationBoolName);

        IsAnimationFinished = false;
    }

    public virtual void Exit()
    {
        Player.MyAnmator.SetBool(_animationBoolName, false);
    }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks() { }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishedTrigger() => IsAnimationFinished = true;
}
