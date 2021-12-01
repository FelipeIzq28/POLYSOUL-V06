using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogos : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI textD;
    [SerializeField] GameObject botonContinue;
    [SerializeField] GameObject panelDialogo;
  

    [TextArea(3,30)]

    public string[] parrafos;
    int index;
    public float velParrafo;

    void Start()
    {
        panelDialogo.SetActive(false);
        botonContinue.SetActive(false);
      

    }

    // Update is called once per frame
    void Update()
    {
        if(textD.text == parrafos[index])
        {
            botonContinue.SetActive(true);
        }
    }
    IEnumerator TextDialogo()
    {
        foreach(char letra in parrafos[index].ToCharArray())
        {
            textD.text += letra;    
        }
        yield return new WaitForSeconds(velParrafo);
    }

    public void SiguienteParrafo()
    {
        botonContinue.SetActive(false);
        if(index < parrafos.Length - 1)
        {
            index++;
            textD.text = "";
            StartCoroutine(TextDialogo());
        }
        else
        {
            textD.text = "";

            botonContinue.SetActive(false);
            panelDialogo.SetActive(false);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            index = 0;
            panelDialogo.SetActive(true);
            StartCoroutine(TextDialogo());
        }

       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        panelDialogo.SetActive(false);
        textD.text = "";

    }

}
