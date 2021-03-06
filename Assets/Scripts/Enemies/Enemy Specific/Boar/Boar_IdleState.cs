﻿public class Boar_IdleState : IdleState
{
    private Boar boar;

    public Boar_IdleState(FiniteStateMachine finiteStateMachine, Entity entity, string animationBoolName, D_IdleState stateData, Boar boar)
        : base(finiteStateMachine, entity, animationBoolName, stateData)
    {
        this.boar = boar;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isPlayerInMinAgroRange || isPlayerInMaxAgroRange)
        {
            finiteStateMachine.ChangeState(boar.playerDetectedState);
        }
        else if (isIdleTimeOver)
        {
            finiteStateMachine.ChangeState(boar.moveState);
        }
    }
}
