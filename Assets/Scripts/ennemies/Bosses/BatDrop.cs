using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatDrop : FollowingEnnemy
{
    public GameObject drop;
    private bool one = true;
    // Update is called once per frame
    void Update()
    {
        IA();
        if (health <= 0)
        {
            if (one)
            {
                one = false;
                GameObject dropItem = Instantiate(drop, transform.position, transform.rotation);
            }
        }
        StartCoroutine(ManageHealth());
    }
}
