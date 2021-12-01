using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FotoHermana : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] GameObject canva;
    Dialogos dial;

    
    bool foto = false;
    bool dentro = false;
    void Start()
    {
        
        canva.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        if(dentro == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Imagen();
            }
        }
        
    }
    void Imagen()
    {
        foto = foto ? false : true;
        canva.SetActive(foto);
        
        Time.timeScale = foto ? 0 : 1;
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        dentro = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        dentro = false;
    }
}


