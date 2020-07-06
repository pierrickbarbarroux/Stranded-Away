using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloquingGuardsVillage : Interactable
{
    public Dialogue dialoguebloque;
    private DialogueManager Dm;

    // Start is called before the first frame update
    new private void Start()
    {
        base.Start();
        if (SamController.instance.karma >= -50)
        {
            gameObject.SetActive(false);
        }
        Dm = FindObjectOfType<DialogueManager>(); 
    }

    public override void interact()
    {
        Dm.StartDialogue(dialoguebloque);
    }
}
