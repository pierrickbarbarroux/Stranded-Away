using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MendiantInteraction : Interactable
{
    public int numberOfApple;
    public int gainKarma;
    public static bool alreadyDoneToday = false;


    public Dialogue dialogueNotEnough;
    public Dialogue dialogueGive;
    public Dialogue dialogueAlreadyGiven;
    private DialogueManager Dm;

    new private void Start()
    {
        base.Start();
        Dm = FindObjectOfType<DialogueManager>();
    }

    public override void interact()
    {
        if (alreadyDoneToday)
        {
            Dm.StartDialogue(dialogueAlreadyGiven);
        }
        else
        {
            if (Inventory.instance.hasInInventory("apple", numberOfApple))
            {
                Dm.StartDialogue(dialogueGive);
                SamController.instance.karma += gainKarma;
                Debug.Log("sam's karma : " + SamController.instance.karma);
                for (int i = 0; i < 10; i++)
                {
                    Inventory.instance.removeItem("apple");
                }
                alreadyDoneToday = true;
            }
            else
                Dm.StartDialogue(dialogueNotEnough);
        }
    }
}
