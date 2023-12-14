using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IBasePlayerState
{
    PlayerStateMachine sm;
    void OnEnter(PlayerStateMachine _stateMachine)
    {
        this.sm = _stateMachine;

        
    }

    void OnExit()
    {
        
    }

    void Update()
    {
        if (!sm.pc.isGrounded)
        {
            sm.Transition(sm.fallState);
        }

        if (sm.pc.isHoldingJumpKey)
        {
            sm.Transition(sm.jumpState);
        }

        if (sm.pc.MovementInput == Vector2.zero )
        {
            sm.Transition(sm.idleState);
        }


        if(Mathf.Abs(sm.pc.Velocity.x) > sm.pc.maxWalkSpeed)
        {
            sm.pc.Damping = sm.pc.playerAcceleration;
        }
        else
        {
            sm.pc.Damping = 0;
        }


    }
}
