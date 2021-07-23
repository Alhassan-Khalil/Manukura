using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilitState : PlayerState
{

    protected bool IsAbilityDone;
    //if we have ability should now abt this make is protected 
    private bool isGrounded;
    public PlayerAbilitState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolname) : base(player, stateMachine, playerData, animBoolname)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isGrounded = core.CollisionSenses.Ground;
    }

    public override void Enter()
    {
        base.Enter();

        IsAbilityDone = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void logicUpdate()
    {
        base.logicUpdate();

        if (IsAbilityDone)
        {
            if (isGrounded && core.Movement.CurrentVelocity.y <0.01f)
            {
                stateMachine.ChangeState(player.IdelState);
            }
            else
            {
                stateMachine.ChangeState(player.InAirState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
