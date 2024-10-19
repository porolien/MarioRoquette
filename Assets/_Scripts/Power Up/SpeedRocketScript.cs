using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRocketScript : PowerUp
{
    protected override void PowerUpEffect()
    {
        GameObject s = GameObject.Instantiate(infoText);
        s.GetComponent<scorePopup>().setText("Fire Rate ++", .6f);
        RocketManager.Instance.playerController.cadence /= 1.5f;
        Destroy(s,1.5f);
            
    }

}
