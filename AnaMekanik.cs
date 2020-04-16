using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnaMekanik : MonoBehaviour
{
    Animator Anim;
    private void Awake()
    {
        Anim = GetComponent<Animator>();

    }
    private void Update()
    {
        AttackHor();
    }
    void AttackHor()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Anim.SetTrigger("AtakHorizontal");

        }
        
    }
}
