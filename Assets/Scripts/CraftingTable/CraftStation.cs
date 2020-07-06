using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftStation : Interactable
{
    public GameObject craftCanva;

    new private void Start()
    {
        base.Start();
        craftCanva = GameObject.Find("CraftingCanvas");
    }

    public override void interact()
    {
        craftCanva.GetComponent<openCraftStation>().openInterface();
    }
}
