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
        mineCollider.enabled = false;
        base.Start();
        mineCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(ArmMine());
    }

    private IEnumerator ArmMine()
    {
        yield return new WaitForSeconds(armDelay);
        mineCollider.enabled = true;
    }
}
