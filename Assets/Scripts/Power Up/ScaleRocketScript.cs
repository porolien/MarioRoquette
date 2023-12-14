using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleRocketScript : PowerUp
{
    protected override void PowerUpEffect()
    {
        RocketManager.Instance.rocketMove.RayonDeLexplosion *= 2;
        RocketManager.Instance.rocketMove.TailleRocket *= 2;
        RocketManager.Instance.rocketMove.multiplicateurDeLexplosion *= 2;
    }
}
