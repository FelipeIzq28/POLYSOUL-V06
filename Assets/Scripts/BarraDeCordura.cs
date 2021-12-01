using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class BarraDeCordura : MonoBehaviour
{
    // Start is called before the first frame update
    public float corduraActual;
    public float corduraMaxima;
    public Light2D  lightPj;
        

    public Image barra;

    private float duracion = 0;
    private float cadaS = 3;

    private void Awake()
    {
        
    }
    void Start()
    {
        //StartCoroutine("Cordura");
    }

    // Update is called once per frame
    void Update()
    {
       
        barra.fillAmount = corduraActual / corduraMaxima;
        if(Time.time >= duracion)
        {
            duracion = Time.time + cadaS;
            corduraActual = corduraActual - 5;
            if(corduraActual <= 0)
            {
                corduraActual = 0;
            }
        }
        if(corduraActual < 50)
        {
            lightPj.intensity = 0.5f;
        } 
        else if(corduraActual < 25)
        {
            lightPj.intensity = 0.2f;
        }
        else
        {
            lightPj.intensity = 0.7f;
        }
       
       
    }
    //private IEnumerator Cordura()
    //{
    //    corduraActual = corduraActual - 10;

    //    yield return new WaitForSeconds(1);
        
    //}
}
  
