using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikeball : Hazard
{
    [SerializeField] private float rollSpeed;

	[SerializeField] private LayerMask hazardMask;
    [SerializeField] private Vector2 flingVelocity;

    private CircleCollider2D circleCollider;

	private Rigidbody2D rb;

	// Start is called before the first frame update
	new void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        if(transform.position.x < 0)
        {
            rb.AddForce(rollSpeed * Vector2.right, ForceMode2D.Impulse);
        }
        else
        {
			rb.AddForce(rollSpeed * Vector2.left, ForceMode2D.Impulse);
		}

    }

	private void OnCollisionStay2D(Collision2D collision)
	{
		if ((hazardMask.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            circleCollider.enabled = false;
            int flingDirection = (int)Mathf.Sign(transform.position.x - collision.gameObject.transform.position.x);

			rb.velocity = new Vector2(flingDirection * flingVelocity.x, flingVelocity.y);
        }
	}

}
