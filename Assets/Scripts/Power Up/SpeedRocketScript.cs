using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRocketScript : PowerUp
{
    private void Awake()
    {
        SetUpPhysics();
    }

    void LateUpdate()
    {
        UpdatePhysics();
    }


}
