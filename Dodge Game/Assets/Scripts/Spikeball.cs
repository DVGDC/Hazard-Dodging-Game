using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikeball : Hazard
{
    [SerializeField] private float rollSpeed;
	[SerializeField] private float rollTorque;

    private Rigidbody2D rb;

	// Start is called before the first frame update
	new void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody2D>();
        if(transform.position.x < 0)
        {
            rb.AddForce(rollSpeed * Vector2.right, ForceMode2D.Impulse);
        }
        else
        {
			rb.AddForce(rollSpeed * Vector2.left, ForceMode2D.Impulse);
		}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
