using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPoundState : PlayerUsingAbilityState
{
    public GroundPoundState(PlayerStateMachine player, StateMachine stateMachine, PlayerData data) : base(player, stateMachine, data)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.RB.velocity = Vector2.zero;
        player.SetGravityScale(data.gravityScale * data.quickFallGravityMult);
    }

    public override void Exit()
    {
        base.Exit();

        player.GroundPounding = false;
        player.LastHardLandedTime = data.coyoteTime;
        player.SetGravityScale(data.gravityScale);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (player.LastOnGroundTime > 0f)
        {
            player.StateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
