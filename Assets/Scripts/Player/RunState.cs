using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IBasePlayerState
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



    }
}
