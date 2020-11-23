﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerOnRopeState_Move : PlayerOnRopeState
{
    private int _xInput;
    private bool _distanceSet;
    private bool _ropeInput;

    public PlayerOnRopeState_Move(Player player, PlayerFiniteStateMachine playerFiniteStateMachine, D_PlayerData playerData, string animationBoolName) : base(player, playerFiniteStateMachine, playerData, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("PlayerOnRopeState_Move");

        IsHoldingRope = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!IsExitingState)
        {
            _ropeInput = Player.InputHandler.SecondaryAttackInput;

            if (_ropeInput)
            {
                RopeAttached = false;

                Player.InputHandler.UseSecondaryAttackInput();
            }
            else
            {
                _xInput = Player.InputHandler.NormalizedInputX;

                Player.CheckIfShouldFlip(_xInput);

                UpdateRopePositions();
            }
        }
    }

    public override void Exit()
    {
        base.Exit();

        ResetRope();
    }

    private void UpdateRopePositions()
    {
        // plus one for the Player position
        Player.MyRopeLineRenderer.positionCount = RopePositions.Count + 1;

        for (int i = Player.MyRopeLineRenderer.positionCount - 1; i >= 0; i--)
        {
            if (i != Player.MyRopeLineRenderer.positionCount - 1)
            {
                Player.MyRopeLineRenderer.SetPosition(i, RopePositions[i]);

                if (i == RopePositions.Count - 1 || RopePositions.Count == 1)
                {
                    Vector2 ropePosition = RopePositions[RopePositions.Count - 1];

                    if (RopePositions.Count == 1)
                    {
                        Player.RopeHingeAnchorRigidbody.transform.position = ropePosition;

                        if (!_distanceSet)
                        {
                            Player.RopeJoint.distance = Vector2.Distance(PlayerPosition, ropePosition);
                            _distanceSet = true;
                        }
                    }
                    else
                    {
                        Player.RopeHingeAnchorRigidbody.transform.position = ropePosition;

                        if (!_distanceSet)
                        {
                            Player.RopeJoint.distance = Vector2.Distance(PlayerPosition, ropePosition);
                            _distanceSet = true;
                        }
                    }
                }
                else if (i - 1 == RopePositions.IndexOf(RopePositions.Last()))
                {
                    Vector2 ropePosition = RopePositions.Last();

                    Player.RopeHingeAnchorRigidbody.transform.position = ropePosition;

                    if (!_distanceSet)
                    {
                        Player.RopeJoint.distance = Vector2.Distance(PlayerPosition, ropePosition);
                        _distanceSet = true;
                    }
                }
            }
            else
            {
                Player.MyRopeLineRenderer.SetPosition(i, PlayerPosition);
            }
        }
    }

    private void ResetRope()
    {
        Player.RopeJoint.enabled = false;
        Player.RopeHingeAnchorSpriteRenderer.enabled = false;

        Player.MyRopeLineRenderer.positionCount = 2;
        Player.MyRopeLineRenderer.SetPosition(0, PlayerPosition);
        Player.MyRopeLineRenderer.SetPosition(1, PlayerPosition);

        RopePositions.Clear();
    }
}
