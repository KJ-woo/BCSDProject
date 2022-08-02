using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public float viewAngle;
    public LayerMask targetMask;

    private MonsterInfo monsterstat;
    private SphereCollider sphereCollider;
    private bool attack;

    public float attackReady = 0.5f;

    private bool attacking;

    private Rigidbody rigid;

    public float attackForce;

    public float reMove;

    private void Start()
    {
        monsterstat = GetComponent<MonsterInfo>();
        sphereCollider = transform.Find("Attack").GetComponent<SphereCollider>();
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        sphereCollider.radius = monsterstat.a_range;
    }

    private void FixedUpdate()
    {
        if (attack == true)
        {
            BasicAttackMotion();
        }
    }

    void BasicAttackMotion()
    {
        attack = false;

        attacking = true;
    }

    // 공격 시 플레이어 체력 마이너스
    /*void Attack(PlayerStat player)
    {
        player.health -= monsterstat.power;
    }*/

    /*private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Attack(playerStat);
        }
    }*/
}
