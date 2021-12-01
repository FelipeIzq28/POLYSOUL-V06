using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rio : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject canvaRetry;
    [SerializeField] GameObject player;
    void Start()
    {
        canvaRetry.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvaRetry.SetActive(true);
            player.SetActive(false);
            Time.timeScale = 0;
        }
    }
}
