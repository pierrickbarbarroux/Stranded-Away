using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossYeti : Thrower
{
    public GameObject stalactite;
    //private bool stalactite_bool = true;
    private int time = 0;
    public GameObject drop;
    private bool one = true;

    protected override void IA()
    {
        time++;
        float distance = Vector2.Distance(transform.position, target.position);

        if (distance <= detectingDistance && canMove)
        {
            animator.SetBool("start_moving", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            SpriteAnimation();
        }
        if (distance <= throwingDistance && canShoot)
        {

            StartCoroutine(shoot(timerShots, timerFreezAfterShot));
        }
        if (distance > detectingDistance)
        {
            animator.SetBool("start_moving", false);
        }

        if (time%240==0)
        {
            StartCoroutine(Roar(timerShots, timerFreezAfterShot));
        }
        if(health <= 0 && one)
        {
            SamController.instance.maxhp += 4;
            Instantiate(drop, transform.position, transform.rotation);
            one = false;
        }
    }

    IEnumerator Roar(float timeShoot, float timeMove)
    {
        canShoot = false;
        canMove = false;
        animator.speed = 0;
        yield return new WaitForSeconds(0.5f);
        Vector3 samPosition = GameObject.Find("Sam").transform.position;
        samPosition -= new Vector3(0, 1, 0);

        //créer l'objet stalactite
        Instantiate(stalactite, samPosition, Quaternion.identity);
        yield return new WaitForSeconds(timeMove);
        animator.speed = 1;
        canMove = true;
        yield return new WaitForSeconds(timeShoot - timeMove);
        canShoot = true;
    }
}
