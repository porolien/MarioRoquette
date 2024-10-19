using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class IBasePlayerState 
{

    public abstract void OnEnter(PlayerStateMachine stateMachine);

    public abstract void OnExit();

    public abstract void Update();
    
}
