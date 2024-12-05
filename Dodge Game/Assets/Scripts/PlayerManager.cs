using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	[SerializeField] private LayerMask hazardMask;

	[SerializeField] private Vector2 flingForce;

	private BoxCollider2D playerCollider;

	private Rigidbody2D rb;

	private void Start()
	{
		playerCollider = GetComponent<BoxCollider2D>();
		rb = GetComponent<Rigidbody2D>();
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if ((hazardMask.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
		{
			Hazard hazard = collision.transform.root.GetComponent<Hazard>();

			int dir = (int)Mathf.Sign(transform.position.x - hazard.transform.position.x);

			rb.AddForce(new Vector2(flingForce.x * dir, flingForce.y), ForceMode2D.Impulse);
			GetComponent<PlayerMovement>().enabled = false;
			playerCollider.enabled = false;
		}
	}
}
