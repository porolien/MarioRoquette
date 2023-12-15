using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : IBasePlayerState
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
        if (sm.pc.isGrounded)
        {
            Debug.Log("yes");
            sm.Transition(sm.idleState);
        }


        sm.pc.Damping = sm.pc.gravityScale;
        sm.pc.AddForce(sm.pc.MovementInput * sm.pc.AirPlayerAcceleration * Vector2.right);

        if (sm.pc.MovementInput != Vector2.zero)
        {
            if (Mathf.Abs(sm.pc.Velocity.x) > sm.pc.maxAirSpeed)
            {
                sm.pc.Damping = sm.pc.AirPlayerAcceleration;
            }
            else
            {
                sm.pc.Damping = 0;
            }
        }
        else
        {
            sm.pc.Damping = sm.pc.AirDamping;
        }
    }
}
