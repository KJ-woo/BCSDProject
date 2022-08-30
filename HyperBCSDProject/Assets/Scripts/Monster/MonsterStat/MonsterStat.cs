using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterStat", menuName = "Scriptable Object/MonsterStat")]
public class MonsterStat : ScriptableObject
{
    // 체력
    public int HP = 150; 
    // 공격 범위
    public float a_range = 1f;
    // 사거리
    public float distance = 1f;
    // 공격력
    public int power = 15;
    // 공격속도
    public float a_speed = 1f;
    // 이동속도
    public float m_speed = 1f;
}
