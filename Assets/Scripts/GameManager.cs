using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameManager instance;
    public GameObject canvaPausa;
    public GameObject canvaStart;
    [SerializeField] PlayerControler player;
    

    private bool gamePaused = false;

    private void Awake()
    {
        
    }
    private void Start()
    {
        canvaPausa.SetActive(false);
        canvaStart.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Continuar();
            } else
            {
                
                Pausa();
            }
            
        }
    }
    public void Pausa()
    {
        canvaPausa.SetActive(true);
        gamePaused =  true;  
        player.gamepaused = gamePaused;
        Time.timeScale = 0f;
       
    }
    public void Continuar()
    {
        canvaPausa.SetActive(false);
        gamePaused = false;
        player.gamepaused = gamePaused;
        Time.timeScale = 1;
    }
    public void ChangeLevel(int sgt)
    {
        
        SceneManager.LoadScene(sgt);
        Time.timeScale = 1;

    }

    public void Salir()
    {
        Application.Quit();
    }
}
