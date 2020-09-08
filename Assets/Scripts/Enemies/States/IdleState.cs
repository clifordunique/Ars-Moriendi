﻿
using UnityEngine;

public class IdleState : State
{
    protected D_IdleState stateData;

    protected bool flipAfterIdle;
    protected bool isIdleTimeOver;

    protected float idleTime;

    public IdleState(FiniteStateMachine finiteStateMachine, Entity entity, string animationBoolName, D_IdleState stateData)
        : base(finiteStateMachine, entity, animationBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(0);
        isIdleTimeOver = false;
        SetRandomIdleTime();
    }

    public override void Exit()
    {
        base.Exit();

        if (flipAfterIdle)
        {
            entity.Flip();
        }
    }

    public override void LogicUpdateFunction()
    {
        base.LogicUpdateFunction();

        if (Time.time > startTime + idleTime)
        {
            isIdleTimeOver = true;
        }
    }

    public override void PhysicsUpdateFunction()
    {
        base.PhysicsUpdateFunction();
    }

    public void SetAfterIdle(bool flipAfterIdle)
    {
        this.flipAfterIdle = flipAfterIdle;
    }

    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minimumIdleTime, stateData.maximumIdleTime);
    }
}