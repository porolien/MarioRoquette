using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IBasePlayerState
{
    PlayerStateMachine sm;
    void OnEnter(PlayerStateMachine _stateMachine)
    {
        this.sm = _stateMachine;
        sm.pc.AddImpulse(Vector2.up * sm.pc.jumpPower);
    }

    void OnExit()
    {

    }

    void Update()
    {
        //Si on touche le sol ou si on redescend on change de state
    }
}
