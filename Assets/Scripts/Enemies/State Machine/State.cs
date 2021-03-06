﻿using UnityEngine;

public class State
{
    protected FiniteStateMachine finiteStateMachine;
    protected Entity entity;
    protected string animationBoolName;

    public float startTime { get; private set; }

    public State(FiniteStateMachine finiteStateMachine, Entity entity, string animationBoolName)
    {
        this.finiteStateMachine = finiteStateMachine;
        this.entity = entity;
        this.animationBoolName = animationBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;

        entity.myAnimator.SetBool(animationBoolName, true);

        DoChecks();
    }

    public virtual void Exit()
    {
        entity.myAnimator.SetBool(animationBoolName, false);
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {
    }
}
