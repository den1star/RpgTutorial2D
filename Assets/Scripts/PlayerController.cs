using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] float moveSpeed;
    public string areaTransitionName;

    private Rigidbody2D playerRB;
    private Animator playerAnimator;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    public static PlayerController instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);    
            }
                
        }

        DontDestroyOnLoad(gameObject);
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hinput = Input.GetAxisRaw("Horizontal");
        float vinput = Input.GetAxisRaw("Vertical");
        float speed = moveSpeed * Time.deltaTime;
        playerRB.velocity = new Vector2(hinput, vinput).normalized * speed;
        playerAnimator.SetFloat("moveX", playerRB.velocity.x);
        playerAnimator.SetFloat("moveY", playerRB.velocity.y);

        if (hinput == 1 || vinput == 1 || hinput == -1 || vinput == -1)
        {
            playerAnimator.SetFloat("lastX", hinput);
            playerAnimator.SetFloat("lastY", vinput);
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    public void SetBounds(Vector3 botLeft, Vector3 topRight)
    {
        bottomLeftLimit = botLeft + new Vector3(.5f,1f,0f);
        topRightLimit = topRight + new Vector3(-.5f, -1f, 0f);
    }
}
