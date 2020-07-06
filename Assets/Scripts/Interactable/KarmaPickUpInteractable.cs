using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarmaPickUpInteractable : PickUpInteractable
{

    public int baisseKarma;
    private static bool firstOnePicked = true;

    public Dialogue dialogueFirst;
    private DialogueManager Dm;

    new private void Start()
    {
        base.Start();
        Dm = FindObjectOfType<DialogueManager>();
    }

    public override void interact()
    {
        base.interact();
        SamController.instance.karma -= baisseKarma;
        if (firstOnePicked)
        {
            Dm.StartDialogue(dialogueFirst);
            firstOnePicked = false;
        }
    }
}
    
