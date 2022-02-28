using UnityEngine;

public class PlayerGlideState : PlayerInAirState
{
    public PlayerGlideState(PlayerStateMachine player, StateMachine stateMachine, PlayerData data) : base(player, stateMachine, data)
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

        if (!player.Gliding)
        {
            player.StateMachine.ChangeState(player.InAirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        player.SetGravityScale(0f);
        player.RB.velocity = new Vector2(player.RB.velocity.x, -1f);
    }
}
