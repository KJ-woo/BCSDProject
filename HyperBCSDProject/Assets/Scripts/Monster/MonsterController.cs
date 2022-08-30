using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public MonsterStat mstat;
    public HeroStat hstat;

    private bool attack;
    private bool attacking;

    // ���� ����
    [SerializeField]
    Vector3 target;

    void Start()
    {

    }

    void Update()
    {
        // ���� �������� ���� �̵�
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

    // ���� ���� �׼�
    void AttakMontion()
    {
        attack = false;
        attacking = true;
    }

    // ���� ����
    void Attack()
    {
        hstat.hp -= mstat.power;
    }

    // �÷��̾�� ������ �޾��� ��� ü�� ���
    public void TakeDamage(int damage)
    {
        mstat.HP -= damage;
        if (mstat.HP <= 0)
        {
            // ���ݹ��� ���͸� ����
            /*Destroy()*/
        }
    }
}
