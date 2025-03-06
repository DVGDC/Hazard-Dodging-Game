using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tripmine : Hazard
{
    [SerializeField] float armDelay;

    [SerializeField] private LayerMask explodeMask;

    [SerializeField] AudioPack explosionPack;

    private BoxCollider2D mineCollider;

    // Start is called before the first frame update
    new void Start()
    {
        mineCollider = GetComponent<BoxCollider2D>();
		mineCollider.enabled = false;
        base.Start();
        StartCoroutine(ArmMine());
    }

    private IEnumerator ArmMine()
    {
        yield return new WaitForSeconds(armDelay);
        mineCollider.enabled = true;
    }

	private void OnCollisionStay2D(Collision2D collision)
	{
		if((explodeMask.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            explosionPack.Play();
            // Play explosion VFX
            Destroy(gameObject);
        }
	}
}
