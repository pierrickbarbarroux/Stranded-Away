using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretPath : Interactable
{
    public GameObject destination = null;
    private GameObject transition_screen = null;
    public Item needeItem;

    public override void interact()
    {
        if ( needeItem == null ||Inventory.instance.hasInInventory(needeItem.itemName, 1) )
        {
            StartCoroutine(interactWithTransition());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && (needeItem == null || Inventory.instance.hasInInventory(needeItem.itemName, 1)))
        {
            instanciatedSprite.SetActive(true);
        }
    }
    

    public IEnumerator interactWithTransition()
    {
            if (transition_screen == null)
            {
                transition_screen = GameObject.Find("TransitionScreen");
            }

            transition_screen.GetComponent<Animator>().Play("Transition_white_to_black");
            yield return new WaitForSecondsRealtime(1f);
            SamController.instance.transform.position = destination.transform.position + new Vector3(0,1,0);
            transition_screen.GetComponent<Animator>().Play("Transition_black_to_white");
    }
}
