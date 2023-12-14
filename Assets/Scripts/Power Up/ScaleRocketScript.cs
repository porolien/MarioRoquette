using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleRocketScript : PowerUp
{
    protected override void PowerUpEffect()
    {
        RocketManager.Instance.rocketMove.RayonDeLexplosion *= 2f;
        RocketManager.Instance.rocketMove.TailleDeLaRocket();
        RocketManager.Instance.rocketMove.multiplicateurDeLexplosion *= 2;
    }
}
