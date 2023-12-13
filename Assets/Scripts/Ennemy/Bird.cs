using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditorInternal;
using UnityEngine;

public class Bird : Ennemies
{
    private Vector2 direction;
    public float speed;
    private Animator animator;
    private float minDistance;
    private float maxDistance;
    public GameObject player;
    bool wantToAttacked;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(-1, 0);
        speed = 1;
        Invoke("MakeAnEscape", 3);
        animator = transform.GetChild(0).GetComponent<Animator>();
        minDistance = 5;
        maxDistance = 7;
    }
    private void FixedUpdate()
    {
        Debug.Log(player.transform.position.x - transform.position.x);
        Debug.Log(transform.position.x - player.transform.position.x);
        if (wantToAttacked)
        {
            if(Mathf.Abs(player.transform.position.x - transform.position.x) > maxDistance || Mathf.Abs(transform.position.x - player.transform.position.x) > maxDistance)
            {
                if (!wantToAttacked)
                {
                    Invoke("MakeAnEscape", 3);
                }
                wantToAttacked = false;

            }
            
        }
        else
        {
            if (Mathf.Abs(player.transform.position.x - transform.position.x) < minDistance || Mathf.Abs(transform.position.x - player.transform.position.x) < minDistance)
            {
                if (wantToAttacked)
                {
                    MakeAnAttack();
                }
                wantToAttacked = true;
                
            }
            else
            {
                transform.Translate(direction * speed * Time.deltaTime);

            }
            
        }
        
    }

    void MakeAnEscape()
    {
        if (!wantToAttacked)
        {
            Debug.Log("escape");
            animator.SetBool("IsEscaped", true);
            Invoke("MakeAnEscape", 3);
        }
        
    }

    void MakeAnAttack()
    {
        if (wantToAttacked)
        {
            Debug.Log("attack");
            animator.SetBool("IsAttacked", true);
            Invoke("MakeAnAttack", 3);
        }
    }
}
