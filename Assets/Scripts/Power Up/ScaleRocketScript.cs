using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleRocketScript : PowerUp
{
    protected override void PowerUpEffect()
    {
        RocketMove.multiplicateurDeLexplosion += 1;
        RocketMove.muultiplicateurScale += 1;
    }
}
