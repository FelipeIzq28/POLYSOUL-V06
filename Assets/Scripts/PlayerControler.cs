using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    public float longIdleTime;
    public float speed = 2.5f;
    public float jumpForce;
   

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    private float _longIdleTimer;
    private Rigidbody2D _rigibody;
    private Animator _animator;

    private Vector2 _movement;
    private bool _facingRight = true;
    public bool _isGrounded;
    private bool _isAttacking;

    private LastCheckPoint gm;
    private static PlayerControler instance;

    public bool usingLadder = false;
    public bool key = false;
    public bool gamepaused = false;

    [SerializeField] GameObject player;
    BarraDeVida vidaAc; 
     void Awake()
    {
        _rigibody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<LastCheckPoint>();
        transform.position = gm.lastCheckPointPos;
    }

    // Update is called once per frame
    //En este update creamos la variable de horizontal input para que nos dé el valor del Input en horizontal

    void Update()
    {
        if (!gamepaused)
        {
            if (_isAttacking == false)
            {
                float horizontalInput = Input.GetAxisRaw("Horizontal");
                //Luego se guarda en el _movement del Vector2, como solo nos interesa el horizontal el valor de Y puede ser 0
                _movement = new Vector2(horizontalInput, 0f);

                if (horizontalInput < 0f && _facingRight == true)
                {
                    Flip();
                }
                else if (horizontalInput > 0 && _facingRight == false)
                {
                    Flip();
                }
            }
            Jump();
            if (Input.GetKeyDown(KeyCode.R))
            {
                Checkpoint();
            }
           
                
        }
        

    }



    void FixedUpdate()
    {
        if (!gamepaused)
        {
            if (_isAttacking == false)
            {
                //Ahora en este lo que se hace es agarrar esos valores de movement y multiplicarlos por la velocidad
                //Esto determinará a que velocidad se mueve el personaje en el frame
                float horizontalVelocity = _movement.normalized.x * speed;
                //Importante, la velocidad en Y del rigibody no puede ser 0 porque significa que no habrá caída
                _rigibody.velocity = new Vector2(horizontalVelocity, _rigibody.velocity.y);
            }
        }
       
        
    }
     void LateUpdate()
    {
        if (!gamepaused)
        {
        _animator.SetBool("Idle", _movement == Vector2.zero);
        _animator.SetBool("IsGrounded", _isGrounded);
        _animator.SetFloat("VerticalVelocity", _rigibody.velocity.y);

        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            _isAttacking = true;
        } else
        {
            _isAttacking = false;

        }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle")) {
            _longIdleTimer += Time.deltaTime;

            if(_longIdleTimer >= longIdleTime)
            {
                _animator.SetTrigger("LongIdle");
            } 
        } else
        {
            _longIdleTimer = 0f;
        }
        }
      
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
    void Jump()
    {
        //En terminos sencillos aca preguntamos si nuestro personaje está en el suelo
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //para asi hacer que salte cuando pulsemos la tecla de jump
        if (Input.GetButtonDown("Jump") && _isGrounded == true && _isAttacking == false)
        {
            _rigibody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Z) && _isGrounded == true && _isAttacking == false)
        {
            _movement = Vector2.zero;
            _rigibody.velocity = Vector2.zero;
            _animator.SetTrigger("Attack");
        }

        if (usingLadder)
        {
            
        }
    }
   public void Checkpoint()
    {
        player.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    
    }

}
