using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	// Float values for player movement speed, jump force, and dodge force
	[SerializeField] private float speed;
	[SerializeField] private float jumpForce;
	[SerializeField] private Vector2 dodgeForce;

	// Private variable to store whether or not the player has used their air-dodge yet
	private bool hasDodged;

	// Stores referrence to player's Rigidbody2D component
	private Rigidbody2D rb;

	// Inspector fields for groundcheck to check whether or not the player is grounded
	[SerializeField] private Transform groundCheck;
	[SerializeField] private float groundCheckRadius;
	[SerializeField] private LayerMask groundMask;

	// The time window in which a jump input will be buffered
	[SerializeField] private float jumpBufferWindow;

	// Stores current value of jump buffer in seconds until buffer window is over
	// If greater than zero, we know that a jump input is currently buffered
	private float jumpBufferCountdown;

	[SerializeField] private AudioPack jumpPack;

	// Start is called upon scene initialization
	void Start()
	{
		// Assign player's Rigidbody2D component to rb
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		// Check if player is grounded using Physics2D's OverlapCircle method
		bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);

		if (isGrounded)
		{
			hasDodged = false;
		}

		// Take in horizontal input and multiply it by speed to get the player's velocity for this frame
		float moveSpeed = Input.GetAxisRaw("Horizontal") * speed;

		// If JumpButton or UpArrow pressed down
		if (Input.GetButtonDown("JumpButton") || Input.GetKeyDown(KeyCode.UpArrow))
		{
			// Buffer a jump input
			jumpBufferCountdown = jumpBufferWindow;
		}

		// If the player is in the air and hasn't used their air-dodge yet
		if (!isGrounded && !hasDodged)
		{
			// Check for dodge inputs
			if (Input.GetKeyDown(KeyCode.Q))
			{
				// Make player dodge
				rb.velocity = new Vector2(-dodgeForce.x, dodgeForce.y);
				jumpPack.Play();
				hasDodged = true;
			}
			if (Input.GetKeyDown(KeyCode.E) && !hasDodged)
			{
				// Make player dodge
				rb.velocity = new Vector2(dodgeForce.x, dodgeForce.y);
				jumpPack.Play();
				hasDodged = true;
			}
		}

		// Maintain the time window for the buffered jump input
		jumpBufferCountdown -= Time.deltaTime;

		// If jump input is buffered
		if (jumpBufferCountdown > 0 && isGrounded)
		{
			// Set vertical velocity of player to jumpForce
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			jumpPack.Play();
		}

		// Set horizontal velocity to this frame's moveSpeed (Obsolete)
		//rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

		// Add force to move player horizontally
		rb.AddForce(new Vector2(moveSpeed * 100 * Time.deltaTime, 0),ForceMode2D.Force);
		
	}
}