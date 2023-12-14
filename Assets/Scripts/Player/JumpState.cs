using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IBasePlayerState
{
    PlayerStateMachine sm;
    float startTime;
    public override void OnEnter(PlayerStateMachine _stateMachine)
    {
        startTime=Time.time;
        this.sm = _stateMachine;

        sm.pc.AddImpulse(Vector2.up * sm.pc.InitialJumpPower);
    }

    public override void OnExit()
    {

    }

    public override void Update()
    {
        

        if (Time.time > startTime+sm.pc.JumpTime|| !sm.pc.isHoldingJumpKey) 
        {
            sm.Transition(sm.fallState);
        }


        sm.pc.AddForce(Vector2.up * sm.pc.JumpThrustPower);
        sm.pc.Damping = sm.pc.gravityScale;
        sm.pc.AddForce(sm.pc.MovementInput * sm.pc.AirPlayerAcceleration * Vector2.right);
        if (Mathf.Abs(sm.pc.Velocity.x) > sm.pc.maxAirSpeed)
        {
            sm.pc.Damping = sm.pc.AirPlayerAcceleration;
        }
        else
        {
            sm.pc.Damping = 0;
        }
    }
}
