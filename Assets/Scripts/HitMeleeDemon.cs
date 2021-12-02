using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMeleeDemon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] BoxCollider2D col;
    [SerializeField] GameObject efect;
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(col.enabled == true)
        {
            Instantiate(efect, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), transform.rotation);
        }
    }
    
}
