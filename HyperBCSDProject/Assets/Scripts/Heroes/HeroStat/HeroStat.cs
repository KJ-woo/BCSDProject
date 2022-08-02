using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "HeroStat", menuName = "Scriptable Object/HeroStat")]
public class HeroStat : ScriptableObject
{
    public int hp = 50;                 // 체력
    public float attackRange = 1f;      // 공격범위
    public float range = 1f;            // 사거리
    public int damage = 20;             // 공격력
    public float attackSpeed = 1f;      // 공격속도
    public float moveSpeed = 1f;        // 이동속도
}
