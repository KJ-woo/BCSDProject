using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterStat", menuName = "Scriptable Object/MonsterStat")]
public class MonsterStat : ScriptableObject
{
    // ü��
    public int HP = 150; 
    // ���� ����
    public float a_range = 1f;
    // ��Ÿ�
    public float distance = 1f;
    // ���ݷ�
    public int power = 15;
    // ���ݼӵ�
    public float a_speed = 1f;
    // �̵��ӵ�
    public float m_speed = 1f;
}
