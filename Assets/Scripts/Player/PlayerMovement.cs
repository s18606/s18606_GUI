using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const int GROUND = 8; //nr layer z listy warst

    public float speed = 500;
    public float jumpSpeed = 400;

    private Rigidbody2D rb;
    private float xDisplacement;
    private bool isGrounded;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    void Update(){
        xDisplacement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        rb.velocity = new Vector2(xDisplacement, rb.velocity.y);

        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpSpeed));
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.layer == GROUND)
            isGrounded = true;
    }
}
