using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    // Start is called before the first frame update
    public Image barra;
    [SerializeField] GameObject canvaRetry;
    [SerializeField] GameObject player;
    [SerializeField] GameObject portal;
 

    public float vidaActual;
    public float vidaMaxima;
    void Start()
    {
        canvaRetry.SetActive(false);
        portal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        barra.fillAmount = vidaActual / vidaMaxima;

        if (vidaActual <= 0)
        {
            player.SetActive(false);
            Retry();
        }
        if (vidaActual > 100)
        {
            vidaActual = 100;
        }

        if (vidaActual < 30)
        {
            portal.SetActive(true);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            vidaActual = vidaActual - 25; 
        }
        else if (collision.CompareTag("Demon"))
        {
            vidaActual = vidaActual - 33;
        }
        else if (collision.CompareTag("Health"))
        {
            vidaActual = vidaActual + 25;
        }
    }
    void Retry()
    {
        Time.timeScale = 0;
        canvaRetry.SetActive(true);
       
    }
}
