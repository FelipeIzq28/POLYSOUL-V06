using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _isAttacking;
    private Animator _animator;
    Enemies enemy;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            _isAttacking = true;
        } else
        {
            _isAttacking = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isAttacking == true)
        {
            if (collision.CompareTag("Enemy"))
            {
                //collision.SendMessageUpwards("Damage");
            }
        }
    }
}
