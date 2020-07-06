using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoFight : MonoBehaviour
{
    public Dialogue dialogueTutoCombat;
    private DialogueManager Dm;

    private void Start()
    {
        Dm = FindObjectOfType<DialogueManager>();
        StartCoroutine(startDialogue());
    }

    IEnumerator startDialogue()
    {
        yield return new WaitForSeconds(1);
        Dm.StartDialogue(dialogueTutoCombat);
    }
}
