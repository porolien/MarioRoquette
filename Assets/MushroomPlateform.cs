using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomPlateform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<DynamicObject>() != null)
        {
            DynamicObject col = collision.GetComponent<DynamicObject>();
            
            col.AddImpulse(transform.up * Vector2.Dot(-transform.up,col.Velocity));
            col.AddImpulse(transform.up * 45);
            //Debug.Log("HHHHHHHHHHHHHHHHHHHHHHHH  " + transform.up * Vector2.Dot(transform.up, col.Velocity) +"    "+ col.Velocity +"   " + Vector2.Dot(transform.up, col.Velocity));
            transform.parent.gameObject.GetComponent<Animation>().Stop("MushroomBounce");
            transform.parent.gameObject.GetComponent<Animation>().Play("MushroomBounce", PlayMode.StopAll);
        }else if (collision.GetComponent<RocketMove>())
        {
            collision.GetComponent<RocketMove>().Sense += (Vector2)transform.up * Vector2.Dot(-transform.up, collision.GetComponent<RocketMove>().Sense)*2;
            transform.parent.gameObject.GetComponent<Animation>().Stop("MushroomBounce");
            transform.parent.gameObject.GetComponent<Animation>().Play("MushroomBounce", PlayMode.StopAll);
        }
    }
}
