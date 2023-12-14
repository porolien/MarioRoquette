using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : IBasePlayerState
{
    PlayerStateMachine stateMachine;
    public override void OnEnter(PlayerStateMachine _stateMachine)
    {
        this.stateMachine = _stateMachine;
    }

    public override void OnExit()
    {

    }

    public override void Update()
    {
        //On ne peux plus changer de state
    }
}
