using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C3L3 : MonoBehaviour
{
    public int myInteger = 5;
    public float myFloat = 3.5f;
    public bool myBoolean = true;
    public string myString = "Hello World";
    public int[] myArrayOfInts;


    private int _myPrivateInteger = 10;
    float _myFloat = 5.01f;
    // Start is called before the first frame update


    void Start()
    {
        Debug.Log("Let´s sum 10 to my Integer, Right now its value is " + myInteger);
        myInteger = myInteger + 10;
        Debug.Log("After the sum the value is " + myInteger);

        IsEven(myInteger);
        MyDebug("La suma del integer público y privado es de "+Suma(myInteger, _myPrivateInteger));

        if (IsEven(myInteger))
        {
            MyDebug("Es par");
        }else
        {
            MyDebug("Es impar");
        }


        if (myFloat >= 2)
        {
            MyDebug("My Float is equal or greather than 2");
        }
        if(IsEven(_myPrivateInteger) && _myPrivateInteger == 10)
        {
            MyDebug("My private integer is 10!!");
        }
        if(IsEven(myInteger) || IsEven(_myPrivateInteger))
        {
            MyDebug("Any of the two numbers is of to me and want to execute some code");
        }

        for(int i=0; i < 10; i++)
        {
            Debug.Log(i);
        }
        for (int i = 0; i < myArrayOfInts.Length; i++)
        {
            Debug.Log(myArrayOfInts[i]);
        }

        SpriteRenderer mySpriteRenderer  = GetComponent<SpriteRenderer>(); //Traer un componente desde el Sprite Renderer
        if (mySpriteRenderer != null)
        {
            Debug.Log("I can use the sprite renderer");
        }else
        {
            MyDebug("The game will crash if you try to use the component");
        }

        //Se usan para buscar objetos dentro de la escena
        GameObject anObjectWithSpriteRenderer = FindObjectOfType<SpriteRenderer>().gameObject; //Para buscar el primer objeto con Sprite Renderer
        GameObject anObjectWithTag = GameObject.FindWithTag("Player");  //Encontrar un objeto a partir del tag puesto
        GameObject anObjectWithName = GameObject.Find("Whatever name of you now"); //Encontrar un objeto a partir de su nombre

        //Activar o desactivar los componentes
        if(mySpriteRenderer!= null)
        {
            mySpriteRenderer.enabled = false;
        }
        //Activar o desactivar gameObjects
        if(anObjectWithName!= null)
        {
            anObjectWithName.SetActive(false);
        }
    }

    // Update is called once per frame  
    void Update()
    {
        
    }
    bool IsEven(int num)
    {
        if(num % 2 == 0)
        {
            return true;
        } else
        {
            return false;
        }
    }
    int Suma(int num1, int num2)
    {
        int num = num1 + num2;
        return num;
    }
    void MyDebug (string message)
    {
        Debug.Log(message);
    }

}
