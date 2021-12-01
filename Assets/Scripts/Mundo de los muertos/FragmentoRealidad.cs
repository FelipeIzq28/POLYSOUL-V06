using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentoRealidad : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    private  FragmentoManager puenteManager;
    [SerializeField] GameObject puente;

    [SerializeField] BarraDeCordura barra;
    
    void Start()
    {
        puenteManager = GameObject.FindGameObjectWithTag("FragmentoRealidad").GetComponent<FragmentoManager>();
        puente.SetActive(puenteManager.fragmento);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            puenteManager.fragmento = true;
            Destroy(this.gameObject);
            barra.corduraActual = barra.corduraActual + 50;
            puente.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    
}
