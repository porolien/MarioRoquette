using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class IdleState : IBasePlayerState
{
    PlayerStateMachine sm;
    string animName;
    public override void OnEnter(PlayerStateMachine _stateMachine)
    {
        this.sm = _stateMachine;
        this.sm.pc.Damping = sm.pc.GroundDamping;
        sm.pc.StopCoroutine("CoyoteTime");
        if (sm.playerAnim != null)
        {
            sm.playerAnim.ChangeAnimPlayer("StateIdle");
        }
        Update();

    }

    public override void OnExit()
    {

    }

    public override void Update()
    {
        this.sm.pc.Damping = sm.pc.GroundDamping;

        if (!sm.pc.isGrounded)
        {
            sm.Transition(sm.fallState);
        }else

        if (sm.pc.isHoldingJumpKey)
        {
            sm.Transition(sm.jumpState);
        }


        else if(sm.pc.MovementInput!=Vector2.zero && !sm.pc.checkForSideCollisions(sm.pc.MovementInput.x * sm.pc.col.bounds.size.x / 2 + 0.2f)) 
        {
            sm.Transition(sm.walkState);
        }
    }
}
