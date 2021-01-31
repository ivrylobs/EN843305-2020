using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public bool isLeft;
    public bool isRight;
    public bool isJump;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardControl();

        if (isLeft)
        {
            rb.AddForce(Vector2.left * 10);
        } else if (isLeft)
        {
            rb.AddForce(Vector2.right * 10);
        }

        if (isJump)
        {
            rb.AddForce(Vector2.up * 10);
            isJump = false;
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
}
