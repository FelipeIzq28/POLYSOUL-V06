using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrucciones : MonoBehaviour
{
    [SerializeField] GameObject instrucciones;
    bool ins = false;
    // Start is called before the first frame update
    void Start()
    {
        instrucciones.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && ins == true)
        {
            Time.timeScale = 1;
            instrucciones.SetActive(false);
            ins = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0;
        instrucciones.SetActive(true);
        ins = true;
    }
}
