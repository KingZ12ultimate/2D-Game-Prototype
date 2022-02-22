using UnityEngine;

public class PlayerGlideState : PlayerInAirState
{
    public PlayerGlideState(PlayerStateMachine player, StateMachine stateMachine, PlayerData data) : base(player, stateMachine, data)
    {
    }
}
