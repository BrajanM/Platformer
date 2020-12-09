using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
	public float jumpForce;
	public float liftingForce;

	public bool jumped;
	public bool doubleJumped;

	private Rigidbody2D rb;
	public float startingY;

	public Text points;
	private int numberOfPoints=0;


	public GameObject Stalker;
	private Animator anim;

    void Start()
    {
		rb = gameObject.GetComponent<Rigidbody2D>();
		startingY = transform.position.y + 0.03f;

		points.text = "0";
		anim = Stalker.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (jumped && transform.position.y<=startingY)
		{
			jumped = false;
			doubleJumped = false;
			anim.SetBool("isJumping", false);
		}

		if (Input.GetMouseButtonDown(0))
		{
			if (!jumped)
			{
				rb.velocity = (new Vector2(0f, jumpForce));
				jumped = true;
				anim.SetBool("isJumping", true);
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

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Coin")
		{
			numberOfPoints++;
			points.text = numberOfPoints.ToString();
			Destroy(collision.gameObject, 0);
		}

		if (collision.gameObject.tag == "Trap")
		{
			GameHandler.trapTrigered = true;
			
		}
		if (collision.gameObject.tag == "HP")
		{
			GameHandler.healthGained = true;
			Destroy(collision.gameObject, 0);
		}
		if (collision.gameObject.tag == "slowTimeBonus")
		{
			GameHandler.slowTimeActivated = true;
			Destroy(collision.gameObject, 0);
		}
		if (collision.gameObject.tag == "immortalityBonus")
		{
			GameHandler.immortalityActivated = true;
			Destroy(collision.gameObject, 0);
		}

	}

}
