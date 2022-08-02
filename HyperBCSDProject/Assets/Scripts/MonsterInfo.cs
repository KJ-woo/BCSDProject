using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInfo : MonoBehaviour
{
    // �̸�
    [SerializeField]
    public string m_name;
    // HP
    [SerializeField]
    public int HP;
    // ���ݹ���
    [SerializeField]
    public int a_range;
    // ��Ÿ�
    [SerializeField]
    public int distance;
    // ���ݷ�
    [SerializeField]
    public int power;
    // ���ݼӵ�
    [SerializeField]
    public float a_speedf;
    // �̵��ӵ�
    [SerializeField]
    public float m_speed;
}
