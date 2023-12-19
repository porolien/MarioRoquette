using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FallState : IBasePlayerState
{
    PlayerStateMachine sm;
    string animName;
    public override void OnEnter(PlayerStateMachine _stateMachine)
    {
        this.sm = _stateMachine;
        animName = "StateFalling";
        if (sm.playerAnim != null)
        {
            sm.playerAnim.ChangeAnimPlayer(animName);
        }

    }

    public override void OnExit()
    {
        if (sm.playerAnim != null)
        {
            sm.pc.transform.Find("FrenchMarioCombined/vfx_jump").GetComponent<VisualEffect>().Play();
            // sm.playerAnim.ChangeAnimPlayer("IsLanding");
        }
    }

    public override void Update()
    {
        if (sm.pc.isGrounded)
        {
            Debug.Log("yes");
            AudioManager.Instance.PlayFall();
            RumbleManager.Instance.Rumble(0.1f, 0.1f, 0.2f);
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
