using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject canva;
    [SerializeField] GameManager gm;
    bool enter;
    public int change;
    void Start()
    {
        canva.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(enter == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gm.ChangeLevel(change);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canva.SetActive(true);
        enter = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canva.SetActive(false);
        enter = false;
    }
    
}
