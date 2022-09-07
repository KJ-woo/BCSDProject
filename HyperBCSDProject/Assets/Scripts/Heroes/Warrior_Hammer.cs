using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Warrior_Hammer : Hero
{
    //public HeroStat stat;

    protected override void Attack()
    {
        Debug.Log("Warrior_Hammer : Attack()");
        base.Attack();
    }
}
