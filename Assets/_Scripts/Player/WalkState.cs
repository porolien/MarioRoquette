using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IBasePlayerState
{
    PlayerStateMachine sm;
    string animName;
    public override void OnEnter(PlayerStateMachine _stateMachine)
    {
        this.sm = _stateMachine;

        //sm.pc.StartCoroutine(Footsteps(sm.pc.footstepsSeparation));
        sm.pc.InvokeRepeating("PlayASound", sm.pc.footstepsSeparation, sm.pc.footstepsSeparation);
        sm.pc.Damping = sm.pc.GroundDamping;
        sm.pc.AddForce(sm.pc.MovementInput * sm.pc.GroundPlayerAcceleration * Vector2.right);
        sm.pc.setWalkParticlesActive(true);
        animName = "StateWalking";
        if (sm.playerAnim != null)
        {
            sm.playerAnim.ChangeAnimPlayer(animName);
        }
        checkForTransitions();

        
    }

    public override void OnExit()
    {
        //sm.pc.StopCoroutine("Footsteps");
        sm.pc.CancelInvoke();
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
            sm.pc.StartCoroutine(CoyoteTime(sm.pc.coyoteTime));
        }

        else if (sm.pc.isHoldingJumpKey)
        {
            sm.Transition(sm.jumpState);
        }

        else if (sm.pc.MovementInput == Vector2.zero  || sm.pc.checkForSideCollisions(sm.pc.MovementInput.x * sm.pc.col.bounds.size.x / 2 + 0.2f))
        {
            sm.Transition(sm.idleState);
            
        }


    }
    IEnumerator CoyoteTime(float coyoteTime)
    {
        float endTime = Time.time + coyoteTime;
        while (Time.time < endTime)
        {
            if (sm.currentState != sm.fallState) break;
            if (sm.pc.isHoldingJumpKey)
            {
                sm.Transition(sm.jumpState);
                break;
            }
            yield return 0;
        }
        
    }

    IEnumerator Footsteps(float footstepsSeparation)
    {
        
        yield return new WaitForSeconds(footstepsSeparation);
        AudioManager.Instance.PlayFootsteps();
        if (sm.walkState == sm.currentState)
        {
            sm.pc.StartCoroutine(Footsteps(sm.pc.footstepsSeparation));
        }
    }

    void Footstepss()
    {
        Debug.Log("marche");
        AudioManager.Instance.PlayFootsteps();
    }
}
