using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private HeroStat heroStat;

    private BoxCollider boxCollider;

    
    void Awake()
    {
        heroStat = GetComponentInParent<HeroStat>();
        boxCollider = GetComponent<BoxCollider>();
    }
    
    public void Attack()
    {
        StopCoroutine(Swing());
        StartCoroutine(Swing());
    }
    IEnumerator Swing()
    {
        yield return new WaitForSeconds(heroStat.attackSpeed);
        boxCollider.enabled = true;
        yield return new WaitForSeconds(heroStat.attackSpeed);
        boxCollider.enabled = false;
        yield return new WaitForSeconds(heroStat.attackSpeed);


    }

}
