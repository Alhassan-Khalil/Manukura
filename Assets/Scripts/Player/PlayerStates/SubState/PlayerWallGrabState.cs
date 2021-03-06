using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallGrabState : PlayerTouchingWallState
{
    private Vector2 holdPosition;
    public PlayerWallGrabState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolname) : base(player, stateMachine, playerData, animBoolname)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        holdPosition = player.transform.position;

        HoldPosition();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void logicUpdate()
    {
        base.logicUpdate();

        if (!IsExitingState)
        {
            HoldPosition();
            if (yinput > 0)
            {
                stateMachine.ChangeState(player.WallClimbState);
            }
            else if (yinput < 0 || !GrabInput)
            {
                stateMachine.ChangeState(player.WallSlideState);
            }

        }
    }

    private void HoldPosition()
    {
        player.transform.position = holdPosition;
        core.Movement.SetVelocityX(0f);
        core.Movement.SetVelocityY(0f);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
