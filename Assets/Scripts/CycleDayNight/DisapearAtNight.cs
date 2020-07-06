using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearAtNight : MonoBehaviour
{
    bool isActive;
    BoxCollider2D[] colliders;
    SpriteRenderer sprite;

    private void Start()
    {
        colliders = GetComponents<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       if (isActive && !SwitchDayNight.isDay)
        {
            StartCoroutine(vanish());
            isActive = false;
        }

        if (!isActive && SwitchDayNight.isDay)
        {
            StartCoroutine(appear());
            isActive = true ;
        }
    }

    IEnumerator vanish()
    {
        yield return new WaitForSeconds(1f);
        foreach (BoxCollider2D col in colliders)
        {
            col.enabled = false;
        }
        sprite.enabled = false;
    }

    IEnumerator appear()
    {
        yield return new WaitForSeconds(1f);
        foreach (BoxCollider2D col in colliders)
        {
            col.enabled = true;
        }
        sprite.enabled = true;
    }
}
