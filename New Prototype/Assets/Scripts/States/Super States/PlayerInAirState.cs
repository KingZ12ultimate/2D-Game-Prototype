﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
	public PlayerInAirState(PlayerStateMachine player, StateMachine stateMachine, PlayerData data) : base(player, stateMachine, data)
	{

	}

	public override void Enter()
	{
		base.Enter();
	}

	public override void Exit()
	{
		base.Exit();

		player.SetGravityScale(data.gravityScale);
	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();

		if (player.LastPressedDashTime > 0 && player.DashState.CanDash())
		{
			player.StateMachine.ChangeState(player.DashState);
		}
		else if (player.GroundPounding)
		{
			player.StateMachine.ChangeState(player.GroundPoundState);
		}
		else if (player.Gliding)
        {
			player.StateMachine.ChangeState(player.GlideState);
        }
		else if (player.LastOnGroundTime > 0)
		{
			if (player.LastPressedDashTime > 0 && player.DashState.CanDash())
			{
				player.StateMachine.ChangeState(player.DashState);
			}
			player.StateMachine.ChangeState(player.IdleState);
		}
		else if (((player.LastOnWallLeftTime > 0 && player.movementInput.x < 0) 
			|| (player.LastOnWallRightTime > 0 && player.movementInput.x > 0)) && player.LastPressedJumpTime > 0)
		{
			player.StateMachine.ChangeState(player.WallJumpState);
		}
		else if ((player.LastOnWallLeftTime > 0 || player.LastOnWallRightTime > 0) && player.Sliding)
		{
			player.StateMachine.ChangeState(player.WallSlideState);
		}
		else if (player.RB.velocity.y < 0)
		{
			//quick fall when holding down: feels responsive, adds some bonus depth with very little added complexity and great for speedrunners :D (In games such as Celeste and Katana ZERO)
			player.SetGravityScale(data.gravityScale * data.fallGravityMult);
		}
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();

		player.Drag(data.dragAmount);
		player.Run(1);
	}
}
