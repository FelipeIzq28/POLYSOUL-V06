using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maquina : MonoBehaviour
{
    public GameObject canvaMaquina;
    // Start is called before the first frame update
    void Start()
    {
        canvaMaquina.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canvaMaquina.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canvaMaquina.SetActive(false);
    }
}
