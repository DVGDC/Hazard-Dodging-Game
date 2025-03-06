using UnityEngine;

public class VerticalRocket : MonoBehaviour
{
    [SerializeField] private float downwardsForce;

    [SerializeField] AudioPack fallPack;
    [SerializeField] AudioPack explosionPack;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector3.down * downwardsForce, ForceMode2D.Impulse);

        fallPack.Play();
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        //Instantiate any visual effects
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerManager>().KillPlayer(transform);
        }

        explosionPack.Play();

        Destroy(gameObject);
	}

}
