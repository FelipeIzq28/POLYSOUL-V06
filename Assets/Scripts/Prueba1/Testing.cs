using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Para los botones del mouse
        //0 para el botón izquierdo
        //1 para el botón derecho
        //2 para el botón de la rueda del mouse
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Button Pressed");
        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Button is Pressed");
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Button Released");
        }

        //El teclado
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Using keycode. You can use this to make the player jump");
        }
        //Llamar la opción predeterminada de Unity
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Using Jump. You can use this to make the player jump");
        }

        //Agarrar lo Axis para crear nuevos vectores de movimiento como las flechas o WASD 
        float horizontal = Input.GetAxis("Horizontal"); // -1 to 1
        float vertical = Input.GetAxis("Vertical"); // -1 to 1

        if(horizontal < 0f || horizontal > 0f){
            Debug.Log("Horizontal Axis is " + horizontal);
        }
        if(vertical < 0f || vertical > 0f)
        {
            Debug.Log("Vertical Axis is " + vertical);
        }




    }
}
