using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    // Start is called before the first frame update
    Animator myAnimator;
    float duracion = 0;
    float nextFire = 3;
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Ataque()
    {
        if(Time.time >= duracion)
        {
            duracion = Time.time + nextFire;
            myAnimator.SetTrigger("attack");
        }
    }
}
