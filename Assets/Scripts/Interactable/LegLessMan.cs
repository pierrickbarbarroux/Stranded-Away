using UnityEngine;

public class LegLessMan : Interactable
{
    public int gainKarma;
    public Sprite SpriteWithLeg;
    private static bool hasLeg = false;

    public Dialogue dialogueBefore;
    public Dialogue dialogueGive;
    public Dialogue dialogueAfter;
    private DialogueManager Dm;

    private void Awake()
    {
       if (hasLeg)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteWithLeg;
        }
    }

    new private void Start()
    {
        base.Start();
        Dm = FindObjectOfType<DialogueManager>();
    }

    public override void interact()
    {
        if (!hasLeg)
        {
            if (Inventory.instance.hasInInventory("jambe de bois", 1))
            {
                SamController.instance.karma += gainKarma;
                Debug.Log("sam's karma : " + SamController.instance.karma);
                Inventory.instance.removeItem("jambe de bois");
                gameObject.GetComponent<SpriteRenderer>().sprite = SpriteWithLeg;
                hasLeg = true;
                Dm.StartDialogue(dialogueGive);
            }
            else
                Dm.StartDialogue(dialogueBefore);
        }
        else
        {
            Dm.StartDialogue(dialogueAfter);
        }
    }
}
