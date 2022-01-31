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
    public GameObject canvaIns;
    [SerializeField] EchoController player;
    

    private bool gamePaused = false;
    private bool instructions = false;

    private void Awake()
    {
        
    }
    private void Start()
    {
        canvaIns.SetActive(false);
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
        player.gamePaused = gamePaused;
        Time.timeScale = 0f;
       
    }
    public void Continuar()
    {
        canvaIns.SetActive(false);
        canvaPausa.SetActive(false);      
        gamePaused = false;
        player.gamePaused = gamePaused;
        Time.timeScale = 1;
    }
    public void ChangeLevel(int sgt)
    {
        
        SceneManager.LoadScene(sgt);
        Time.timeScale = 1;

    }
    public void Instructions()
    {
        canvaIns.SetActive(true);
        gamePaused = true;
        player.gamePaused = gamePaused;
        Time.timeScale = 0;
        
    }

    public void Salir()
    {
        Application.Quit();
    }
}
