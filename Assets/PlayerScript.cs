using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript: MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    public Rigidbody2D rb;
    public Vector2 moveDirection;
    public bool isJumping = false;
    public float jump = 25f;
    public Vector2 walk = new Vector2(0, 0);
    public Rigidbody2D platform;
    private PolygonCollider2D polyCollider;
    public bool isHittingSide = false;
    public float offsetY = 4f;
    public Animator animator;
    public SpriteRenderer sr;
    public float SpeedX;
    public float SpeedY;
    private bool hasCollectedKey1;
    private Camera camera;


    public bool getHasCollectedKey1()
    {
        return hasCollectedKey1;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name.Equals("Key1"))
        {
            hasCollectedKey1 = true;
            GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        sr = GetComponent<SpriteRenderer>();
        hasCollectedKey1 = false;
    }
    private void Awake()
    {
        platform = GameObject.FindGameObjectWithTag("Platform").GetComponent<Rigidbody2D>();
        polyCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<PolygonCollider2D>();

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject coin in objects)
        {
            coin.GetComponent<Rigidbody2D>().isKinematic = true;
        }
        platform.isKinematic = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //isGrounded = true;
        //isJumping = false;

        //if (collision.gameObject.CompareTag("Coin"))
        //{
        //    Destroy(collision.gameObject);
        //}

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //isGrounded = false;
        //rb.velocity += new Vector2(0, -50);


    }
    //private bool IsGrounded()
    //{
    //    RaycastHit2D ray = Physics2D.BoxCast(polyCollider.bounds.center, polyCollider.bounds.size, 0f, Vector2.down, 1f, platformLayerMask);
    //    Debug.Log(ray.collider);
    //    return ray.collider != null;
    //}
    //private bool IsNotHittingPlatformSide()
    //{
    //    RaycastHit2D rayRight = Physics2D.BoxCast(polyCollider.bounds.center, polyCollider.bounds.size, 0f, Vector2.right, 1f, platformLayerMask);
    //    RaycastHit2D rayLeft = Physics2D.BoxCast(polyCollider.bounds.center, polyCollider.bounds.size, 0f, Vector2.left, 1f, platformLayerMask);

    //    Debug.Log(rayRight.collider);
    //    return rayRight.collider == null && rayLeft.collider == null;


    //}
    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        //{
        //    isJumping = true;
        //}


    }

    private void FixedUpdate()
    {
        float moveX = 0;
        float moveY = 0;
        if (Input.GetKey(KeyCode.D) )
        {
            moveX = 8f;
            moveY = 0f;

            sr.flipX = true;
            sr.flipY = false;


        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -8f;
            moveY = 0f;
            sr.flipX = false;
            sr.flipY = false;
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveY = 8f;
            moveX = 0f;
            //sr.flipY = true;
            sr.flipX = false;


        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -8f;
            moveX = 0f;
            sr.flipY = false;
            sr.flipX = false;

        }
        

        //if (isJumping)
        //{
        //    rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        //    print("UP");
        //    isJumping = false;
        //}
        SpeedX = Mathf.Abs(moveX);
        SpeedY = moveY;
        animator.SetFloat("SpeedX", SpeedX);
        animator.SetFloat("SpeedY", SpeedY);
        walk = new Vector2(moveX, moveY);
        rb.velocity = walk;
        camera.transform.position = new Vector3(rb.position.x, rb.position.y, -1f);

        

    }
}
