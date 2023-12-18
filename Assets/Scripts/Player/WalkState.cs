using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IBasePlayerState
{
    PlayerStateMachine sm;
    public override void OnEnter(PlayerStateMachine _stateMachine)
    {
        this.sm = _stateMachine;

        sm.pc.Damping = sm.pc.GroundDamping;
        sm.pc.AddForce(sm.pc.MovementInput * sm.pc.GroundPlayerAcceleration * Vector2.right);
        sm.pc.setWalkParticlesActive(true);
        if (sm.playerAnim != null)
        {
            sm.playerAnim.ChangeAnimPlayer("StateWalking");
        }
        checkForTransitions();


    }

    public override void OnExit()
    {
        sm.pc.setWalkParticlesActive(false);
    }

    public override void Update()
    {
        checkForTransitions();
        sm.pc.Damping=sm.pc.GroundDamping; 
        sm.pc.AddForce(sm.pc.MovementInput * sm.pc.GroundPlayerAcceleration * Vector2.right);
        if (Mathf.Abs(sm.pc.Velocity.x) > sm.pc.maxWalkSpeed)
        {
            sm.pc.Damping = sm.pc.GroundPlayerAcceleration;
        }
        else
        {
            sm.pc.Damping = 0;
        }
        
    }

    void checkForTransitions()
    {
        if (!sm.pc.isGrounded)
        {
            sm.Transition(sm.fallState);
        }

        else if (sm.pc.isHoldingJumpKey)
        {
            sm.Transition(sm.jumpState);
        }

        else if (sm.pc.MovementInput == Vector2.zero)
        {
            sm.Transition(sm.idleState);
        }


        
    }
}
