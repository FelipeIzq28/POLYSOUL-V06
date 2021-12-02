using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoDemon : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 10;
    [SerializeField] GameObject efect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-1 * Time.deltaTime * speed, 0));
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
