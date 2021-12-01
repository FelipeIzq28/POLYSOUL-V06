using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWall : MonoBehaviour
{

    [SerializeField] GameManager gm;
    [SerializeField] LlaveBoss llave;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (llave.key == true)
        {

            gm.ChangeLevel(5);


        }

    }


}
