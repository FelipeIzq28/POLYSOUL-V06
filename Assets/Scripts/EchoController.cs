using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EchoController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] BoxCollider2D floorPoint;
    [SerializeField] GameObject player;

    private Rigidbody2D _rigidbody;
    private Animator _myAnimator;
    private LastCheckPoint gm;
    private BoxCollider2D _myCollider;
    private Vector2 _movement;
    private bool _isAttacking;

    bool _isGrounded;
    public bool gamePaused = false;

    bool facingRight = true;
    bool caer = false;
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
        if (!gamePaused)
        {
            if(_isAttacking == false)
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
                Caer();
                Saltar();
                Attack();
            }
           
            if (Input.GetKeyDown(KeyCode.R))
            {
                Checkpoint();
            }
        }
        
    }
    private void FixedUpdate()
    {
        if (!gamePaused)
        {
            if (_isAttacking == false)
            {
                //Ahora en este lo que se hace es agarrar esos valores de movement y multiplicarlos por la velocidad
                //Esto determinará a que velocidad se mueve el personaje en el frame
                float horizontalVelocity = _movement.normalized.x * speed;
                //Importante, la velocidad en Y del rigibody no puede ser 0 porque significa que no habrá caída
                _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
            }
        }
    }
    private void LateUpdate()
    {
        if (_myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            _isAttacking = true;
        }
        else
        {
            _isAttacking = false;

        }    
    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z) && EnSuelo()  && _isAttacking == false)
        {
            _movement = Vector2.zero;
            _rigidbody.velocity = Vector2.zero;
            _myAnimator.SetTrigger("attack");
        }
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
    void Caer()
    {
        if (_rigidbody.velocity.y < 0)
        {
            _myAnimator.SetBool("falling", true);
            caer = true;
        }
        if (caer == true && _rigidbody.velocity.y == 0)
        {
            _myAnimator.SetBool("falling", false);
            caer = false;           
        }
    }
    void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (EnSuelo())
            {                
                _myAnimator.SetBool("falling", false);
                _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                _myAnimator.SetTrigger("jumping");              
            }            
        }

    }
    void Flip()
    {
        facingRight = !facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
    public void Checkpoint()
    {
        player.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }
}
