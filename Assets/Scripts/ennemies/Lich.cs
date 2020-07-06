    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lich : FollowingEnnemy
{
    public static bool isInstanciated = true;

    private static bool peaceful = true;
    public GameObject dialogueCanvas;
    private int damageOnCollisionTemp;

    public Dialogue dialogueFirst;
    public Dialogue dialogueHelp;
    public Dialogue dialogueAttack;
    private DialogueManager Dm;

    private bool firstdialogue = false ;

    void Start()
    {
        if (!isInstanciated)
        {
            gameObject.SetActive(false);
        }
        damageOnCollisionTemp = damageOnCollision;
        health = maxHealth;
        slider.value = CalculateHealth();
        healthBar.SetActive(false);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        damageOnCollision = 0;
        Dm = FindObjectOfType<DialogueManager>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            isInstanciated = false;
            SamController.instance.cursed = true;
        }
        StartCoroutine(ManageHealth());
        if(Dm.DialogueEnded && firstdialogue)
        {
            dialogueCanvas.SetActive(true);
            firstdialogue = false;
        }
        if (!peaceful &&Dm.DialogueEnded)
        {
            IA();
        }

    }

    protected override void IA()
    {
        base.IA();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (peaceful)
        {
            Dm.StartDialogue(dialogueFirst);
            firstdialogue = true;
}
        if (collision.gameObject.tag == "sword" && peaceful)
        {
            Dm.StartDialogue(dialogueAttack);
            peaceful = false;
        }
        else if (collision.gameObject.tag == "sword" && !peaceful)
        {
            health -= SamController.instance.sword.DamageOnHit;   //modifier cette valeur
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (peaceful)
        {
            dialogueCanvas.SetActive(false);
        }
    }

    public void helpHim()
    {
        dialogueCanvas.SetActive(false);
        Dm.StartDialogue(dialogueHelp);
        ChefHouse.HaveSeenLich = true;
    }
    public void attackHim()
    {
        damageOnCollision = damageOnCollisionTemp;
        Dm.StartDialogue(dialogueAttack);
        peaceful = false;
        dialogueCanvas.SetActive(false);
    }
}
