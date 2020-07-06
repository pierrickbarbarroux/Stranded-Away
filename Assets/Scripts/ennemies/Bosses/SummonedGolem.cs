using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonedGolem : Following_Thrower
{
    static int deathcount = 0;
    public GameObject drop;
    private bool one = true;

    protected override void IA()
    {
        base.IA();
        if (health <= 0)
        {
            deathcount++;
            if (deathcount == 2 && one)
            {
                one = false;
                SamController.instance.maxhp += 4;
                deathcount = 0;
                Instantiate(drop, transform.position, transform.rotation);
                ManageOffrande.actualOffrande = ManageOffrande.typeOffrande.boss3;
                if (SamController.instance.karma >= ManageOffrande.instance.minimumKarma)
                    ManageOffrande.EnoughKarma3 = true;
            }
        }
    }


}
