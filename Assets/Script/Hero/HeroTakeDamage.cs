using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTakeDamage : MonoBehaviour
{
    public void TakeDamage(int damage)
    {
        HeroController.instance.currentHealth -= damage;
        //    Animator anim;
        //    anim = GetComponent<Animator>();
        //    anim.SetTrigger("Hit");
        //    StartCoroutine(Delay());
        //    IEnumerator Delay()
        //    {
        //        yield return new WaitForSeconds(0.5f);
        //        if (Enemy.instance.playerIsNear == true)
        //        {
        //            anim.SetTrigger("attack");
        //        }
        //        else
        //        {
        //            anim.SetTrigger("run");
        //        }
        //    }
    }
}
