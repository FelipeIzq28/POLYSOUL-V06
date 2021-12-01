using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private LastCheckPoint gm;
    void Start()
    {
        
        gm = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<LastCheckPoint>() ;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gm.lastCheckPointPos = transform.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
