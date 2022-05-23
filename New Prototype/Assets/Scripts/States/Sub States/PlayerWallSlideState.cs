using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerOnWallState
{
	public PlayerWallSlideState(PlayerStateMachine player, StateMachine stateMachine, PlayerData data) : base(player, stateMachine, data)
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
			player.StateMachine.ChangeState(player.WallJumpState);
		}
		else if (player.LastOnWallTime <= 0 || player.movementInput != Vector2.zero || !player.Sliding)
		{
			player.StateMachine.ChangeState(player.InAirState);
		}
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
		player.Drag(data.dragAmount);
		player.Slide();
	}
}
