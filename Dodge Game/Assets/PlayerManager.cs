using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	[SerializeField] private LayerMask hazardMask;

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
			Hazard hazard = collision.gameObject.GetComponent<Hazard>();

			Vector2 flingForce = (Vector2)(transform.position - collision.transform.position).normalized * 
				hazard.flingMagnitude + 
				Vector2.up * hazard.upwardsFlingModifier;

			rb.AddForce(flingForce, ForceMode2D.Impulse);
			GetComponent<PlayerMovement>().enabled = false;
			playerCollider.enabled = false;
		}
	}
}
