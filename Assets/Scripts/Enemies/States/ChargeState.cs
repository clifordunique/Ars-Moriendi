﻿public class ChargeState : State
{
    protected D_ChargeState stateData;

    protected bool isDetectingWall;
    protected bool isDetectingLedge;

    protected bool isPlayerInMinAgroRange;

    public ChargeState(FiniteStateMachine finiteStateMachine, Entity entity, string animationBoolName, D_ChargeState stateData)
        : base(finiteStateMachine, entity, animationBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        DoChecks();

        entity.SetVelocity(stateData.chargeSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdateFunction()
    {
        base.LogicUpdateFunction();
    }

    public override void PhysicsUpdateFunction()
    {
        base.PhysicsUpdateFunction();

        DoChecks();
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isDetectingWall = entity.CheckWall();
        isDetectingLedge = entity.CheckLedge();
        isPlayerInMinAgroRange = entity.CheckIfPlayerInMinAgro();
    }
}