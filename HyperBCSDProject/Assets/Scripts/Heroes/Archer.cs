using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Archer : Hero
{
    //public HeroStat stat;

    protected override void Attack()
    {
        Debug.Log("Archer : Attack()");
        base.Attack();
    }
}
