using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentoManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool fragmento;
    private static FragmentoManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);

        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
}
