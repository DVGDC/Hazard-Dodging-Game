using UnityEngine;

public class VerticalRocket : MonoBehaviour
{
    [SerializeField] private float downwardsForce;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector3.down * downwardsForce, ForceMode2D.Impulse);
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        //Instantiate any visual effects
        Destroy(gameObject);
	}

}
