using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {


    public float jumpForce;
    public float slideTime; // Duration of slide 
    float tmpSildeTime;

    Rigidbody2D rb2d;
    BoxCollider2D boxCollider2d;
    
    bool isJumping; // Player is jumping now
    bool isSliding; // Player is sliding now
    bool isRunning; // Player is running now

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        isJumping = false;
        isSliding = false;
        isRunning = true;

        tmpSildeTime = slideTime;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            if(touchDeltaPosition.y > 15 && isRunning)
            {
                rb2d.AddForce(new Vector2(0, jumpForce));
                isJumping = true;
                isRunning = false;
            }

            if(touchDeltaPosition.y > -15 && touchDeltaPosition.y < 0 && isRunning)
            {
                boxCollider2d.size = new Vector2((float)1.0, (float)0.25);
                boxCollider2d.offset = new Vector2(0, (float)-0.125);
                isSliding = true;
                isRunning = false;
            }

        }


       if(Input.GetMouseButtonDown(0) && isRunning) // DEBUG
        {
            boxCollider2d.size = new Vector2((float)1.0, (float)0.25);
            boxCollider2d.offset = new Vector2(0, (float)-0.125);
            isSliding = true;
            isRunning = false;

        }

       if(isSliding)
        {
            slideTime -= Time.deltaTime;
            if(slideTime <= 0)
            {
                slideTime = tmpSildeTime;
                isSliding = false;
                isRunning = true;

                boxCollider2d.size = new Vector2((float)0.5, (float)0.5);
                boxCollider2d.offset = new Vector2(0, 0);
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            if (isJumping)
            {
                isJumping = false;
                isRunning = true;
            }
        }
    }
}
