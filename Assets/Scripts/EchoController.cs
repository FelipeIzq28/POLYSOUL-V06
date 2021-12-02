using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] BoxCollider2D floorPoint;

    private Rigidbody2D _rigidbody;
    private Animator _myAnimator;
    private LastCheckPoint gm;
    private BoxCollider2D _myCollider;

    bool facingRight = true;
    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _myAnimator = GetComponent<Animator>();
        _myCollider = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<LastCheckPoint>();
        transform.position = gm.lastCheckPointPos;
    }

    // Update is called once per frame
    void Update()
    {
        float direccion = Input.GetAxisRaw("Horizontal");
        if (direccion < 0 && facingRight == true)
        {
            Flip();
        }
        else if (direccion > 0 && facingRight == false)
        {
            Flip();
        }
        Correr();
    }
    void Correr()
    {
        float direccion = Input.GetAxisRaw("Horizontal");
        if (direccion != 0)
        {

            _myAnimator.SetBool("isRunning", true);
            transform.Translate(new Vector2(direccion * Time.deltaTime * speed, 0));
        }
        else
        {
            _myAnimator.SetBool("isRunning", false);
        }
    }
    bool EnSuelo()
    {
        return floorPoint.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }
    void Flip()
    {
        facingRight = !facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
}
