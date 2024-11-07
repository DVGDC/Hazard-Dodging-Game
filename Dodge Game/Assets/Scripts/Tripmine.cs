using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tripmine : Hazard
{
    [SerializeField] float armDelay;

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
}
