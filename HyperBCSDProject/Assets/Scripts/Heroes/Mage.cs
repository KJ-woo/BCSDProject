using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Hero
{
    public HeroStat stat;

    protected override void Attack()
    {
        Debug.Log("Mage : Attack()");
        base.Attack();
    }
}
