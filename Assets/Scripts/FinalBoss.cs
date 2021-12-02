using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    // Start is called before the first frame update
    Animator myAnimator;
    float duracion = 0;
    float nextFire = 3;
    float vida = 1000;

    [SerializeField] GameObject disparo;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject efect;
    [SerializeField] GameObject bulletPrefab;


    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ataque();
    }
    void Ataque()
    {
        if(Time.time >= duracion)
        {
            duracion = Time.time + nextFire;
            myAnimator.SetTrigger("attack");
        }
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation) as GameObject;
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
