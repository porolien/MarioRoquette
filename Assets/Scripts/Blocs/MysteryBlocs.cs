using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class MysteryBlocs : Blocs
{
    
    public PowerUp powerUp;
    public Mesh mesh;
    public Material material;
    //[SerializeField] protected GameObject breakVFXPrefab;
    // Start is called before the first frame update
    void Start()
    {
        breakable = false;
        canExplosed = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void BlocHitted()
    {
        MysteryBlocIsTouched();
    }

    public void MysteryBlocIsTouched()
    {


        PowerUp newPowerUp = Instantiate(powerUp,transform.position+Vector3.up,Quaternion.identity);
        newPowerUp.GetComponent<DynamicObject>().AddImpulse(new Vector3(0, 8, 0));

        GameObject explosionVfx = GameObject.Instantiate(breakVFXPrefab, transform.position, Quaternion.identity);
        explosionVfx.GetComponent<VisualEffect>().SetInt("Count", 14);
        Destroy(explosionVfx,2 );
        for(int i = 0; i < transform.parent.childCount; i++) 
        {
            if (transform.parent.GetChild(i).name == "Visual")
            {
                transform.parent.GetChild(i).GetComponent<MeshFilter>().mesh = mesh;
                transform.parent.GetChild(i).GetComponent<MeshRenderer>().material = material;   
            }
        }
        
        Destroy(this);
    }



   /* private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Wow un power UP");
            MysteryBlocIsTouched();
            Destroy(this);
        }

        if (other.gameObject.tag == "Rocket")
        {
            
            //Destroy(transform.parent.gameObject);
        }

    }*/

    void Explosion(Vector2 source)
    {
        PowerUp newPowerUp = Instantiate(powerUp, transform.position + Vector3.up, Quaternion.identity);
        Vector2 recul = (Vector2)transform.position - source;
        recul = recul.normalized*20;
        newPowerUp.GetComponent<DynamicObject>().AddImpulse(recul);

        GameObject explosionVfx = GameObject.Instantiate(breakVFXPrefab, transform.position, Quaternion.identity);
        explosionVfx.GetComponent<VisualEffect>().SetVector3("AdditionalVelocity", (Vector3)(((Vector2)transform.position - source).normalized * 10));
        Destroy(explosionVfx, 2);


        Destroy(transform.parent.gameObject);
    }
}
