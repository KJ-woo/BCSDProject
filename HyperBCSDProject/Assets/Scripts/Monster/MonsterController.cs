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

    // 특정 레이어 지정을 위한 레이어 마스크
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

    // 종료 지점
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
        // 종료 지점까지 몬스터 이동
        float fMove = Time.deltaTime * mstat.m_speed;
        transform.position = Vector3.MoveTowards(transform.position, target, fMove);

        // 종료 지점 도달할 경우 걷기 애니메이션 멈추기
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

    // 공격
    public void AttackCommand()
    {
        // 몬스터가 보는 방향 알아내기
        /*Vector3 look = Monster.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(Monster.transform.position + Vector3.up, look * 10, Color.red);
        ray = new Ray(Monster.transform.position + Vector3.up, look);
        
        if (Physics.Raycast(ray, 10, heroLayer))
        {
            *//*Attacking();*//*
            Debug.Log(transform.name);
        }*/

        // 영웅과 몬스터 간의 거리가 공격 사거리 안에 들어올 경우
        if (!walk && Dist <= mstat.a_range)
        {
            Attacking();
        }
        else
        {
            CancelAttakcing();
        }
    }

    // targetPoint쪽으로 회전시키는 메소드
    void Rotation(Vector3 targetPoint)
    {
        Vector3 relativePosition = targetPoint - transform.position;
        relativePosition.y = 0;
        Quaternion rotation = Quaternion.LookRotation(relativePosition, Vector3.up);
        transform.rotation = rotation;
    }

    // 공격 시 타겟으로 몸 회전 후 공격 코루틴 실시
    void Attacking()
    {
        Rotation(GameObject.FindWithTag("Hero").transform.position);
        if (attack_ready)
        {
            attackCoroutine = StartCoroutine(AttackingIEnumerator());
        }
    }

    // 공격 정지
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

    // 데미지만큼 체력 감소
    public void TakingDamage(int _damage)
    {
        takedamage = true;
        GameObject hero = GameObject.FindWithTag("Hero");
        // 데미지만큼 체력 감소
        monsterHP -= _damage;
        attack_ready = true;
        if (monsterHP <= 0)
        {
            Die();
        }
    }

    // 사망
    public void Die()
    {
        dead = true;
        // 몬스터 삭제
        Destroy(gameObject);
    }
}
