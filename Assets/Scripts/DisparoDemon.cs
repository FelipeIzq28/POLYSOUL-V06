using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoDemon : MonoBehaviour
{
    // Start is called before the first frame update
    public float x;
    public float y;

    private float valorX;
    private float valorY;
    float speed = 15;
    [SerializeField] GameObject efect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        valorX = x;
        valorY = y;
        transform.Translate(new Vector2(-1 * Time.deltaTime * speed,Time.deltaTime * -2));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(efect, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
