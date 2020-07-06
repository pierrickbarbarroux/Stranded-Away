using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefHouse : Interactable
{
    public GameObject lich;
    public static ChefHouse instance;
    #region singleton


    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("plus d'une instance de maison du chef" +
                " trouvé");
            return;
        }
        instance = this;
    }

    #endregion

    public Dialogue dialogueBasic;
    public Dialogue dialogueDayQuest;
    public Dialogue dialogueNightQuest;

    private DialogueManager Dm;

    public static bool HaveSeenLich = false;  // changer ca dans le script de la lich

    new private void Start()
    {
        base.Start();
        Dm = FindObjectOfType<DialogueManager>();
    }

    public override void interact()
    {
        if (HaveSeenLich && !SwitchDayNight.isDay)
        {
            Dm.StartDialogue(dialogueNightQuest);
            HaveSeenLich = false;
            Lich.isInstanciated = false;
        }
        else if (HaveSeenLich && SwitchDayNight.isDay)
        {
            Dm.StartDialogue(dialogueDayQuest);
        }
        else
        {
            Dm.StartDialogue(dialogueBasic);
        }
    }
}
