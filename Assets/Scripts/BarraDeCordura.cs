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
            lightPj.pointLightOuterRadius = 12;
            lightPj.pointLightInnerRadius = 6;
        } 
        else if(corduraActual < 25)
        {
            lightPj.intensity = 0.2f;
            lightPj.pointLightOuterRadius = 8;
            lightPj.pointLightInnerRadius = 4;
        }
        else
        {
            lightPj.intensity = 0.7f;
            lightPj.pointLightOuterRadius = 21.19f;
            lightPj.pointLightInnerRadius = 11.79f;
        }
       
       
    }
    //private IEnumerator Cordura()
    //{
    //    corduraActual = corduraActual - 10;

    //    yield return new WaitForSeconds(1);
        
    //}
}
  
