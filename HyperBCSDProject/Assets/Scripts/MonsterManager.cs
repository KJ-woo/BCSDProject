using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameInfo.Monster;

public class MonsterManager : MonoBehaviour
{
    MonsterInfo[] mobInfo = new MonsterInfo[4];

    void Start()
    {
        mobInfo[0] = new MonsterInfo();
        mobInfo[0].SetName("Box");
        mobInfo[0].SetHp(150);
        mobInfo[0].SetRange(1);
        mobInfo[0].SetDistance(1);
        mobInfo[0].SetPower(15);
        mobInfo[0].SetAspeed(1f);
        mobInfo[0].SetMspeed(1f);

        mobInfo[1] = new MonsterInfo();
        mobInfo[1].SetName("Cell");
        mobInfo[1].SetHp(200);
        mobInfo[1].SetRange(1);
        mobInfo[1].SetDistance(2);
        mobInfo[1].SetPower(20);
        mobInfo[1].SetAspeed(1f);
        mobInfo[1].SetMspeed(1f);

        mobInfo[0] = new MonsterInfo();
        mobInfo[0].SetName("Slim");
        mobInfo[0].SetHp(150);
        mobInfo[0].SetRange(1);
        mobInfo[0].SetDistance(1);
        mobInfo[0].SetPower(15);
        mobInfo[0].SetAspeed(1);
        mobInfo[0].SetMspeed(1);

        mobInfo[0] = new MonsterInfo();
        mobInfo[0].SetName("Turtle");
        mobInfo[0].SetHp(200);
        mobInfo[0].SetRange(1);
        mobInfo[0].SetDistance(1);
        mobInfo[0].SetPower(20);
        mobInfo[0].SetAspeed(0.8f);
        mobInfo[0].SetMspeed(0.5f);

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Mob");
    }
}
