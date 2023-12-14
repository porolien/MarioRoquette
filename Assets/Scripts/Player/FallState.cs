using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : IBasePlayerState
{
    PlayerStateMachine stateMachine;
    void OnEnter(PlayerStateMachine _stateMachine)
    {
        this.stateMachine = _stateMachine;
    }

    void OnExit()
    {

    }

    void Update()
    {

    }
}
