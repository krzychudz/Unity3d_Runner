using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {


    public float jumpForce;

    Rigidbody2D rb2d;
    bool isJumping;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        isJumping = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            if(touchDeltaPosition.y > 15 && !isJumping)
            {
                rb2d.AddForce(new Vector2(0, jumpForce));
                isJumping = true;
            }


        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            if (isJumping)
                isJumping = false;
        }
    }
}
