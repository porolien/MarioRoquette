using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleRocketScript : PowerUp
{
    protected override void PowerUpEffect()
    {
        RocketManager.Instance.rocketMove.RayonDeLexplosion *= 2f;
        RocketManager.Instance.rocketMove.TailleRocket *= 10;
        RocketManager.Instance.rocketMove.multiplicateurDeLexplosion *= 2;
    }
}
