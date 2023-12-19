using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class MysteryBlocs : Blocs
{
    
    public PowerUp powerUp;
    public Mesh mesh;
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
        //transform.parent.gameObject.GetComponent<Animation>().Play("Brick_bump");
        //GameObject explosionVfx = GameObject.Instantiate(breakVFXPrefab, transform.position, Quaternion.identity);
        //explosionVfx.GetComponent<VisualEffect>().SetInt("Count", 14);
        //Destroy(explosionVfx,2 );
        transform.parent.gameObject.GetComponent<Animation>().Play("Brick_bump");
        GameObject explosionVfx = GameObject.Instantiate(breakVFXPrefab, transform.position, Quaternion.identity);
        explosionVfx.GetComponent<VisualEffect>().SetInt("Count", 14);

        GameObject Popup = GameObject.Instantiate(scorePopupPrefab, transform.position, Quaternion.identity);
        Popup.GetComponent<scorePopup>().init(150, Color.white);
        Popup.transform.localScale *= 1.8f;

        //explosionVfx.GetComponent<VisualEffect>().SetVector3("AdditionalVelocity", (Vector3)(((Vector2)transform.position - Center).normalized * 10));
        Destroy(explosionVfx, 2);
        transform.parent.Find("Visual").gameObject.GetComponent<MeshFilter>().mesh = mesh;
        Destroy(this);

        //StartCoroutine(Die());
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

        GameObject Popup = GameObject.Instantiate(scorePopupPrefab, transform.position, Quaternion.identity);
        Popup.GetComponent<scorePopup>().init(150, Color.white);
        Popup.transform.localScale *= 1.8f;

        Destroy(transform.parent.gameObject);
    }
}
