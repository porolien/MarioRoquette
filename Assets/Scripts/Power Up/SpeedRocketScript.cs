using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRocketScript : PowerUp
{
    protected override void PowerUpEffect()
    {
        RocketManager.Instance.playerController.cadence /= 2;
            
    }

}
