using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior_Axe : Hero
{
    public HeroStat stat;

    protected override void Attack()
    {
        Debug.Log("Warrior_Axe : Attack()");
        base.Attack();
    }
}
