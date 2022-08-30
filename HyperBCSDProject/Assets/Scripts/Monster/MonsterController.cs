using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public MonsterStat mstat;
    public HeroStat hstat;

    private bool attack;
    private bool attacking;

    // 종료 지점
    [SerializeField]
    Vector3 target;

    void Start()
    {

    }

    void Update()
    {
        // 종료 지점까지 몬스터 이동
        float fMove = Time.deltaTime * mstat.m_speed;
        transform.position = Vector3.MoveTowards(transform.position, target, fMove);
    }

    private void FixedUpdate()
    {
        if (attack == true)
        {
            AttakMontion();
        }
    }

    // 몬스터 공격 액션
    void AttakMontion()
    {
        attack = false;
        attacking = true;
    }

    // 몬스터 공격
    void Attack()
    {
        hstat.hp -= mstat.power;
    }

    // 플레이어에게 공격을 받았을 경우 체력 깎기
    public void TakeDamage(int damage)
    {
        mstat.HP -= damage;
        if (mstat.HP <= 0)
        {
            // 공격받은 몬스터만 삭제
            /*Destroy()*/
        }
    }
}
