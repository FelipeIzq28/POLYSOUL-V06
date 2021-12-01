using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaAlma : MonoBehaviour
{

    [SerializeField] LlaveAlma llave;
    [SerializeField] GameObject puerta;
    [SerializeField] GameManager gm;

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

            puerta.SetActive(false);


        }

    }
}
