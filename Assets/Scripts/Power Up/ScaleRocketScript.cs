using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleRocketScript : PowerUp
{
    protected override void PowerUpEffect()
    {
        GameObject s = GameObject.Instantiate(infoText);
        infoText.GetComponent<scorePopup>().setText("Blast Radius ++",.6f);
        Destroy(s, 1.5f);

        RocketMove.multiplicateurDeLexplosion += 1;
        RocketMove.muultiplicateurScale += 1;
    }
}
