using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInfo : MonoBehaviour
{
    // 이름
    [SerializeField]
    public string m_name;
    // HP
    [SerializeField]
    public int HP;
    // 공격범위
    [SerializeField]
    public int a_range;
    // 사거리
    [SerializeField]
    public int distance;
    // 공격력
    [SerializeField]
    public int power;
    // 공격속도
    [SerializeField]
    public float a_speedf;
    // 이동속도
    [SerializeField]
    public float m_speed;
}
