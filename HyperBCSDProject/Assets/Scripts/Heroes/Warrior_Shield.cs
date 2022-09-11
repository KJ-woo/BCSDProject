using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Warrior_Shield : Hero
{
    //public HeroStat stat;

    protected override void Attack()
    {
        // 방패병은 공격이 없음
        base.Attack();
        Debug.Log("Warrior_Shield : Attack()");
    }
}
