using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonEscenarioMundoDeLosMuertps : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject canva;
    [SerializeField] GameManager gm;
    void Start()
    {
        canva.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambiarNivel()
    {
        SceneManager.LoadScene(3);
    }
}
