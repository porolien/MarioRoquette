using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IBasePlayerState
{
    PlayerStateMachine sm;
    void OnEnter(PlayerStateMachine _stateMachine)
    {
        this.sm = _stateMachine;
        sm.pc.Damping = sm.pc.GroundDamping;
    }

    void OnExit()
    {

    }

    void Update()
    {
        if(!sm.pc.isGrounded)
        {
            sm.Transition(sm.fallState);
        }

        if (sm.pc.isHoldingJumpKey)
        {
            sm.Transition(sm.jumpState);
        }


        if(sm.pc.MovementInput!=Vector2.zero) 
        {
            sm.Transition(sm.walkState);
        }
    }
}
