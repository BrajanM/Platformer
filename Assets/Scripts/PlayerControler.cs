using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
	public float jumpForce;
	public float liftingForce;

	public bool jumped;
	public bool doubleJumped;

	private Rigidbody2D rb;
	public float startingY;

    void Start()
    {
		rb = gameObject.GetComponent<Rigidbody2D>();
		startingY = transform.position.y + 0.03f;
    }

    // Update is called once per frame
    void Update()
    {
		if (jumped && transform.position.y<=startingY)
		{
			jumped = false;
			doubleJumped = false;
		}

		if (Input.GetMouseButtonDown(0))
		{
			if (!jumped)
			{
				rb.velocity = (new Vector2(0f, jumpForce));
				jumped = true;
			}
			else if (!doubleJumped)
			{
				rb.velocity = (new Vector2(0f, jumpForce));
				doubleJumped = true;
			}
		}
		if (Input.GetMouseButton(0))
		{
			rb.AddForce(new Vector2(0f,liftingForce* Time.deltaTime));
		}


    }
}
