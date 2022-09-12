using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Warrior_Shield : Hero
{
    //public HeroStat stat;

    protected override void Attack()
    {
        if (MonsterList[targetIndex].gameObject == null)
        {
            onTargetting = false;
            return;
        }

    }
}
