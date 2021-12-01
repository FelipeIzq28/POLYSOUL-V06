using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;


    // Start is called before the first frame update


    [SerializeField] float vida;
    [SerializeField] Transform enemigo;
    [SerializeField] GameObject efect;

    private GameObject _target;
    public float minX;
    public float maxX;
    void Start()
    {
        UpdateTarget();
        StartCoroutine("PatrolToTarget");
    }

    // Update is called once per frame
    void Update()
    {
        // UpdateTarget();


    }
    private void UpdateTarget()
    {
        if (_target == null)
        {
            //Si es la primera vez, se crea el Target a la izquierda
            _target = new GameObject("Target");
            _target.transform.position = new Vector2(minX, transform.position.y);

        }

        //Si estamos en la izquierda, cambiamos el Target a la derecha
        if (_target.transform.position.x == minX)
        {
            _target.transform.position = new Vector2(maxX, transform.position.y);

        }
        //Si estamos en la derecha, cambiamos el Target a la izquierda
        else if (_target.transform.position.x == maxX)
        {
            _target.transform.position = new Vector2(minX, transform.position.y);

        }

    }
    private IEnumerator PatrolToTarget()
    {
        while (Vector2.Distance(transform.position, _target.transform.position) > 0.05f)
        {
            Vector2 direction = _target.transform.position - transform.position;
            float xDirection = direction.x;

            transform.Translate(direction.normalized * speed * Time.deltaTime);

            yield return null;
        }

        
        UpdateTarget();

        StartCoroutine("PatrolToTarget");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("HitBox"))

        {
            Damage();
        }
    }
    public void Damage()
    {
        vida -= 1;
        Instantiate(efect, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), transform.rotation);
        if (vida <= 0)
        {
           
            Destroy(this.gameObject);
        }
    }
  
}
