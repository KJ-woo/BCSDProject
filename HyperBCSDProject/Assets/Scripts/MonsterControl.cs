using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{
    public MonsterInfo monsterstat;
    [SerializeField]
    Vector3 target;
    void Start()
    {
        
    }

    void Update()
    {
        float fMove = Time.deltaTime * monsterstat.m_speed;
        transform.position = Vector3.MoveTowards(transform.position, target, fMove);
    }
}
