using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MonsterController : MonoBehaviour
{
    public MonsterStat mstat;
    /*public HeroStat hstat;*/

    public GameObject Monster;
    public int monsterHP;
    private float Dist;

    WaitForSeconds attackCooltime;
    public Coroutine attackCoroutine;
    [SerializeField]
    public float Cooltime;

    // Ư�� ���̾� ������ ���� ���̾� ����ũ
    /*public LayerMask heroLayer;*/
    private Ray ray;
    private RaycastHit raycastHit;

    private bool walk;
    private bool attack_ready;
    private bool attacking;
    private bool takedamage;
    private bool dead;

    private GameObject m_HpBar;

    public Animator animator;

    // ���� ����
    [SerializeField]
    Vector3 target;


    [SerializeField]
    private PlayerController playerController;
    void Start()
    {
        animator = GetComponent<Animator>();
        setAttackCooltimeWaitForSeconds(Cooltime);
        m_HpBar = GameObject.Find("Canvas/Slider");
        monsterHP = mstat.HP;
    }

    public void setAttackCooltimeWaitForSeconds(float time)
    {
        attackCooltime = new WaitForSeconds(time);
    }

    void Update()
    {
        animator.SetBool("walk", walk);
        animator.SetBool("attack_ready", attack_ready);
        animator.SetBool("attack", attacking);
        animator.SetBool("takeDamage", takedamage);
        animator.SetBool("die", dead);
        // Dist = Vector3.Distance(GameObject.FindWithTag("Hero").transform.position, Monster.transform.position);
        // Debug.Log(Dist);
        if(playerController.GetComponent<PlayerController>().gameMode == GameMode.RunMode)
        {
            MoveCommand();
        }
        if (playerController.GetComponent<PlayerController>().gameMode == GameMode.BattleMode)
        {
            AttackCommand();

        }
    }

    void MoveCommand()
    {
        // ���� �������� ���� �̵�
        float fMove = Time.deltaTime * mstat.m_speed;
        transform.position = Vector3.MoveTowards(transform.position, target, fMove);

        // ���� ���� ������ ��� �ȱ� �ִϸ��̼� ���߱�
        if (transform.position != target)
        {
            walk = true;
        }
        else
        {
            walk = false;
            attack_ready = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            TakingDamage(other.GetComponent<Projectile>().damage);
        }
    }

    // ����
    public void AttackCommand()
    {
        // ���Ͱ� ���� ���� �˾Ƴ���
        /*Vector3 look = Monster.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(Monster.transform.position + Vector3.up, look * 10, Color.red);
        ray = new Ray(Monster.transform.position + Vector3.up, look);
        
        if (Physics.Raycast(ray, 10, heroLayer))
        {
            *//*Attacking();*//*
            Debug.Log(transform.name);
        }*/

        // ������ ���� ���� �Ÿ��� ���� ��Ÿ� �ȿ� ���� ���
        if (!walk && Dist <= mstat.a_range)
        {
            Attacking();
        }
        else
        {
            CancelAttakcing();
        }
    }

    // targetPoint������ ȸ����Ű�� �޼ҵ�
    void Rotation(Vector3 targetPoint)
    {
        Vector3 relativePosition = targetPoint - transform.position;
        relativePosition.y = 0;
        Quaternion rotation = Quaternion.LookRotation(relativePosition, Vector3.up);
        transform.rotation = rotation;
    }

    // ���� �� Ÿ������ �� ȸ�� �� ���� �ڷ�ƾ �ǽ�
    void Attacking()
    {
        Rotation(GameObject.FindWithTag("Hero").transform.position);
        if (attack_ready)
        {
            attackCoroutine = StartCoroutine(AttackingIEnumerator());
        }
    }

    // ���� ����
    void CancelAttakcing()
    {
        if (attacking)
        {
            /*StopCoroutine(attackCoroutine);*/
            attacking = false;
            attack_ready = true;
        }
    }

    public IEnumerator AttackingIEnumerator()
    {
        attacking = true;
        yield return attackCooltime;
        /*attacking = false;*/
        attack_ready = true;
    }

    // ��������ŭ ü�� ����
    public void TakingDamage(int _damage)
    {
        takedamage = true;
        GameObject hero = GameObject.FindWithTag("Hero");
        // ��������ŭ ü�� ����
        monsterHP -= _damage;
        attack_ready = true;
        if (monsterHP <= 0)
        {
            Die();
        }
    }

    // ���
    public void Die()
    {
        dead = true;
        // ���� ����
        Destroy(gameObject);
    }
}
