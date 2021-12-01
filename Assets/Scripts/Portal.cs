using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject canva;
    void Start()
    {
        canva.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canva.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canva.SetActive(false);
    }
    
}
