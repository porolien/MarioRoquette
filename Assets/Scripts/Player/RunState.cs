using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IBasePlayerState
{
    PlayerStateMachine sm;
    public override void OnEnter(PlayerStateMachine _stateMachine)
    {
        this.sm = _stateMachine;
    }

    public override void OnExit()
    {

    }

    public override void Update()
    {
        if (!sm.pc.isGrounded)
        {
            sm.Transition(sm.fallState);
        }

        else if (sm.pc.isHoldingJumpKey)
        {
            sm.Transition(sm.jumpState);
        }



    }
}
