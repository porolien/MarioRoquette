using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : IBasePlayerState
{
    PlayerStateMachine sm;
    string animName;
    public override void OnEnter(PlayerStateMachine _stateMachine)
    {
        this.sm = _stateMachine;
        /*animName = "StateDead";
        sm.pc.playerInput.SwitchCurrentActionMap("UI");
        if (sm.playerAnim != null)
        {
            sm.playerAnim.ChangeAnimPlayer(animName);
        }
        sm.pc.RocketLauncher.SetActive(false);
        sm.pc.enabled = false;
        sm.transform.position = new Vector2(sm.transform.position.x, 0);
        sm.transform.rotation = Quaternion.EulerRotation(sm.transform.rotation.x, 0, sm.transform.rotation.z);
        RocketManager.Instance._moveRocketLauncher.Cursor.gameObject.SetActive(false);*/
        sm.pc.Retry();
    }

    public override void OnExit()
    {

    }

    public override void Update()
    {
        //On ne peux plus changer de state
    }
}
