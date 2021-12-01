using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 1f;
    public float minX;
    public float maxX;
    public float waitingTime = 5f;

    private Animator _animator;
    private GameObject _target;
    private Weapon _weapon;
    //private Anim;
    // Start is called before the first frame update
    void Awake()
    {
        //Se carga el animator en la variable _animator para usarla en el resto del codigo
        _animator = GetComponent<Animator>();
        _weapon = GetComponentInChildren<Weapon>();
    }
    void Start()
    {
        UpdateTarget();
        StartCoroutine("PatrolToTarget");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdateTarget()
    {
        if (_target == null)
        {
            //Si es la primera vez, se crea el Target a la izquierda
            _target = new GameObject("Target");
            _target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
            return;
        }

            //Si estamos en la izquierda, cambiamos el Target a la derecha
        if (_target.transform.position.x == minX)
        {
            _target.transform.position = new Vector2(maxX, transform.position.y);
            transform.localScale = new Vector3(1, 1, 1);    
        }
            //Si estamos en la derecha, cambiamos el Target a la izquierda
        else if(_target.transform.position.x == maxX)
        {
            _target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
    }
    private IEnumerator PatrolToTarget()
    {
        while (Vector2.Distance(transform.position, _target.transform.position) > 0.05f)
        {
            //actualizar el animator 
            _animator.SetBool("Idle", false);

            Vector2 direction = _target.transform.position - transform.position;
            float xDirection = direction.x;

            transform.Translate(direction.normalized * speed * Time.deltaTime);

            yield return null;
        }
       
        Debug.Log("Target reached");
        UpdateTarget();
        _animator.SetBool("Idle", true);

        _animator.SetTrigger("Shoot");

        Debug.Log("Waiting for " + waitingTime + "seconds");
        yield return new WaitForSeconds(waitingTime);

        Debug.Log("Waited enough, let´s update the target and move again");
        
        StartCoroutine("PatrolToTarget");

    }

    void CanShoot()
    {
        if (_weapon != null)
        {
            _weapon.Shoot();
        }
    }
}
