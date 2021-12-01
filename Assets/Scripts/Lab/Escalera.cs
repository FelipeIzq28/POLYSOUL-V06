using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalera : MonoBehaviour
{
    [SerializeField] BoxCollider2D platformGround;
    [SerializeField] bool onLadder = false;
    [SerializeField] float climbSpeed;
    [SerializeField] float exitHop = 3f;
    Rigidbody2D _rigibody;
    PlayerControler controller;
    // Start is called before the first frame update
    void Start()
    {
        _rigibody = GetComponent < Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Escalera"))
        {
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                _rigibody.velocity = new Vector2(_rigibody.velocity.x, Input.GetAxisRaw("Vertical") * climbSpeed);
                _rigibody.gravityScale = 0;
                onLadder = true;
                platformGround.enabled = false;
                
            }else if(Input.GetAxisRaw("Vertical") == 0 && onLadder)
            {
                _rigibody.velocity = new Vector2(_rigibody.velocity.x, 0);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Escalera") && onLadder)
        {
            _rigibody.gravityScale = 1;
            onLadder = false;
            platformGround.enabled = true;

            if (!controller._isGrounded)
            {
                _rigibody.velocity = new Vector2(_rigibody.velocity.x, exitHop);
            }
        }
    }
}
