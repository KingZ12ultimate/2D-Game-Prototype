using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHardLandState : PlayerGroundedState
{
    public PlayerHardLandState(PlayerStateMachine player, StateMachine stateMachine, PlayerData data) : base(player, stateMachine, data)
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

        if (player.LastPressedJumpTime > 0)
        {

        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
