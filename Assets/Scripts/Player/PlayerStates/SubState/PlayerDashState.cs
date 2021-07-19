using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilitState
{
    public bool CandDash { get; private set; }

    private bool IsHolding;
    private bool dashInputStop;
    private bool Isgrounded;


    private Vector2 DashDirection;
    private Vector2 dashDirectionInput;
    private Vector2 LastAIpos;

    private float lastDashTime;
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolname) : base(player, stateMachine, playerData, animBoolname)
    {
    }
    public override void Enter()
    {
        base.Enter();

        CandDash = false;
        player.InputHandler.UseDashInput();

        IsHolding = true;
        DashDirection = Vector2.right * player.FacingDirection;

        Time.timeScale = playerData.HoldTimeScale;
        startTime = Time.unscaledTime;

        player.DashDirectionIndicator.gameObject.SetActive(true);

    }

    public override void Exit()
    {
        base.Exit();

        if(player.CurrentVelocity.y > 0)
        {
            player.SetVelocityY(player.CurrentVelocity.y * playerData.DashEndYMultiplier);
        }
    }

    public override void logicUpdate()
    {
        base.logicUpdate();

        if (!IsExitingState)
        {
            player.Anim.SetFloat("Yvelocity", player.CurrentVelocity.y);
            player.Anim.SetFloat("Xvelocity", Mathf.Abs(player.CurrentVelocity.x));


            if (IsHolding)
            {
                dashDirectionInput = player.InputHandler.DashDirectionInput;
                dashInputStop = player.InputHandler.DashInputStop;

                if (dashDirectionInput != Vector2.zero)
                {
                    DashDirection = dashDirectionInput;
                    DashDirection.Normalize();
                }

                float angle = Vector2.SignedAngle(Vector2.right, DashDirection);
                player.DashDirectionIndicator.rotation = Quaternion.Euler(0f, 0f, angle - 45f);// -45 cuz the arrow is in 45 degree

                if (dashInputStop || Time.unscaledTime >= startTime + playerData.maxHoldTime)
                {
                    IsHolding = false;
                    Time.timeScale = 1f;
                    startTime = Time.time;
                    player.CheckIfShouldFlip(Mathf.RoundToInt(DashDirection.x));
                    player.RB.drag = playerData.Drag;
                    player.SetVeloctiydash(playerData.DashVelocity, DashDirection);
                    player.DashDirectionIndicator.gameObject.SetActive(false);
                    PlaceAfterImage();
                }
            }
            else
            {
                player.SetVeloctiydash(playerData.DashVelocity, DashDirection);
                CheckIfShouldPlaceAfterImage();

                if (Time.time >= startTime + playerData.DashTime)
                {
                    player.RB.drag = 0f;
                    IsAbilityDone = true;
                    lastDashTime = Time.time;
                }
            }
        }
    }
    private void CheckIfShouldPlaceAfterImage()
    {
        if(Vector2.Distance(player.transform.position , LastAIpos) >= playerData.DistBetweenAfterImage)
        {
            PlaceAfterImage();
        }
    }
    private void PlaceAfterImage()
    {
        PlayerAfterImagePool.Instance.GetFromPool();
        LastAIpos = player.transform.position;
    }

    public bool CheckIfCanDash()
    {
        return CandDash && Time.time >= lastDashTime + playerData.dashcooldown;
    }

    public void ResetCanDash() => CandDash = true;

}
