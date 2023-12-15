using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public Animator animator;
    private void Start()
    {
        //animator = GetComponent<Animator>();
    }
    public void ChangeAnimPlayer(string _animState)
    {
        Debug.Log(_animState);
        animator.SetBool(_animState, true);
    }
}
