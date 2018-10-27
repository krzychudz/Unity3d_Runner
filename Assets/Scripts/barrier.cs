using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour {

    public float objectSpeed;

    Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(-objectSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
