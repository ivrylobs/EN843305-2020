using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public bool isLeft;
    public bool isRight;
    public bool isJump;
    Rigidbody2D rb;

    Animator anim;
    public float moveSpeed = 20;
    public float jumpPower = 200;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardControl();

        if (isLeft)
        {
            rb.AddForce(Vector2.left * moveSpeed);
        } else if (isRight)
        {
            rb.AddForce(Vector2.right * moveSpeed);
        }

        if (isJump)
        {
            rb.AddForce(Vector2.up * jumpPower);
            isJump = false;
            anim.SetBool("ground", false);
        }

        anim.SetFloat("speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            Flip(true);
            
        } else {
            Flip(false);
            
        }
    }

    void KeyboardControl()
    {
        if (Input.GetKeyDown("a"))
        {
            SetLeft(true);
        }

        if (Input.GetKeyUp("a"))
        {
            SetLeft(false);
        }

        if (Input.GetKeyDown("d"))
        {
            SetRight(true);
        }

        if (Input.GetKeyUp("d"))
        {
            SetRight(false);
        }

        if (Input.GetKeyDown("space"))
        {
            SetJump(true);
        }
    }

    public void SetLeft(bool b)
    {
        isLeft = b;
    }

    public void SetRight(bool b)
    {
        isRight = b;
    }

    public void SetJump(bool b)
    {
        isJump = b;
    }

   
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Fruit")
        {
            Destroy(other.gameObject);
        } else if(other.gameObject.name == "ground")
        {
            anim.SetBool("ground", true);
        }
    }

    void Flip(bool isFlip)
    {
        Vector3 theScale = transform.localScale;
        if(isFlip) {
            if(transform.localScale.x > 0) {
                theScale.x *=- 1;
            }
        } else {
                if(transform.localScale.x < 0) {
                    theScale.x *=-1; 
                } 
        }
        transform.localScale = theScale;
    }
}
