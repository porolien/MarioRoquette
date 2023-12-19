using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Blocs : MonoBehaviour
{
    public bool breakable;
    public bool canExplosed;
    [SerializeField] AudioClip breakSound;
    [SerializeField] protected GameObject scorePopupPrefab;
    [SerializeField] protected GameObject breakVFXPrefab;
    protected bool isDying = false;
    void Explosion(Vector2 Center)
    {
        if (canExplosed && !isDying)
        {
            isDying = true;
            StartCoroutine(Die2((Vector3)(((Vector2)transform.position - Center).normalized * 10)));
            

        }

    }

    public virtual void BlocHitted()
    {
        print("BLOCK HITTED!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        if(!breakable) 
        {
            transform.parent.gameObject.GetComponent<Animation>().Play("Brick_bump");
            //grossir le bloc et le faire monter un ptit peu, puis le r�trecir et le remettre � sa place
            //puis le d�truire?
        }
        else if(!isDying)
        {
            isDying = true;
            AudioManager.Instance.PlaySound(breakSound);
            StartCoroutine(Die());
            //Destroy(transform.parent.gameObject);
        }
    }

    protected IEnumerator Die()
    {
        transform.parent.gameObject.GetComponent<Animation>().Play("Brick_bump");
        GameObject explosionVfx = GameObject.Instantiate(breakVFXPrefab, transform.position, Quaternion.identity);
        explosionVfx.GetComponent<VisualEffect>().SetInt("Count", 14);

        GameObject Popup = GameObject.Instantiate(scorePopupPrefab, transform.position, Quaternion.identity);
        Popup.GetComponent<scorePopup>().init(50, Color.white);

        yield return new WaitForSeconds(0.4f);
        
        //explosionVfx.GetComponent<VisualEffect>().SetVector3("AdditionalVelocity", (Vector3)(((Vector2)transform.position - Center).normalized * 10));
        Destroy(explosionVfx, 2);
        Destroy(transform.parent.gameObject);
    }

    //nsm
    IEnumerator Die2(Vector2 additionalVel)
    {
        GameObject explosionVfx = GameObject.Instantiate(breakVFXPrefab, transform.position, Quaternion.identity);
        explosionVfx.GetComponent<VisualEffect>().SetVector3("AdditionalVelocity",additionalVel);
        Destroy(explosionVfx, 2);

        GameObject Popup = GameObject.Instantiate(scorePopupPrefab,transform.position,Quaternion.identity);
        Popup.GetComponent<scorePopup>().init(50, Color.white);

        transform.parent.gameObject.GetComponent<Animation>().Play("Brick_Explode");

        yield return new WaitForSeconds(0.1f);
        //explosionVfx.GetComponent<VisualEffect>().SetVector3("AdditionalVelocity", (Vector3)(((Vector2)transform.position - Center).normalized * 10));
        
        Destroy(transform.parent.gameObject);
    }

    
}
