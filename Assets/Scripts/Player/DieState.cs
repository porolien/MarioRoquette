using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : IBasePlayerState
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
        //On ne peux plus changer de state
    }
}
