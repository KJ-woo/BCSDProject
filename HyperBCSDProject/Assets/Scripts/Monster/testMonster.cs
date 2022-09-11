using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMonster : MonoBehaviour
{
    public List<GameObject> monsterList = new List<GameObject>();
    public List<Monster> ReturnMonsters()
    {
        List<Monster> currentMonsterList = new List<Monster>(monsterList.Count);
        for (int i = 0; i < monsterList.Count; ++i)
        {
            if (monsterList[i].gameObject != null)
            {
                Monster monster = monsterList[i].GetComponent<Monster>();
                currentMonsterList.Add(monster);
            }
        }
        return currentMonsterList;
    }
}
