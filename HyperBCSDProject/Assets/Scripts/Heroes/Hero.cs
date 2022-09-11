using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Hero : MonoBehaviour
{
    private PlayerController player;
    private HeroController heroController;
    protected Rigidbody rigid;
    protected Animator anim;
    protected bool isRun;
    protected bool isAttack;
    protected bool onTargetting;
    protected testMonster testMonster;
    public List<GameObject> MonsterList = new List<GameObject>();
    [SerializeField]
    protected HeroStat heroStat;
    public int heroHP;
    protected Weapon weapon;

    // 몬스터와의 거리 체크용 변수들
    protected float currentDist;  // 현재 거리 ( 영웅 <-> 몬스터 )
    protected float targetDist;   // 타겟의 거리
    protected int closeDistIndex; // 가장 가까운 인덱스
    protected int targetIndex;    // 타겟의 인덱스
    protected Vector3 targetPos;   // 타겟의 위치

    protected void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        heroController = GetComponent<HeroController>();
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        weapon = GetComponentInChildren<Weapon>();
        testMonster = GameObject.Find("Monsters").GetComponent<testMonster>();
        heroHP = heroStat.hp;
        
        isRun = true;
        isAttack = false;
        onTargetting = false;               // 사거리 안에 적이 들어오면 true
        anim.SetBool("Run", isRun);
        targetDist = 100f;
    }
    protected void Update()
    {
        if(player.gameMode == GameMode.BattleMode)
        {
            // 현재 남아있는 몬스터를 계속 갱신해주는 함수가 필요함.
            // MonsterList = Monster.ReturnCurrentMonster();
            MonsterList = testMonster.monsterList;
            if(heroHP <= 0)
            {
                Death();
            }
            else
            {
                if(MonsterList.Count != 0)
                {
                    // 사거리 안에 적이 없으면 계속 가장 가까운 적 검색 및 접근
                    if (!onTargetting)
                    {
                        {
                            SearchEnemy();     
                        }
                    }
                    // 사거리 안에 적이 있으면 해당 적 공격
                    else
                    {
                        if(!isAttack)
                        {
                            Attack();
                        }
                    }
                }
            }
        }
    }
    protected void FreezeRotation()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }
    protected void FixedUpdate()
    {
        FreezeRotation();
    }
    public void Set_Placement()
    {
        isRun = false;
        anim.SetBool("Run", isRun);
    }
    public void Run()
    {
        isRun = true;
        anim.SetBool("Run", isRun);
    }
    // 자신에게서 제일 가까운 적을 찾는다.
    protected virtual void SearchEnemy()
    {
        Debug.Log("SearchEnemy");
        currentDist = 0f;
        closeDistIndex = 0;
        targetIndex = -1;

        for (int i = 0; i < MonsterList.Count; i++)
        {
            if(MonsterList[i].gameObject != null)
            {
                currentDist = Vector3.Distance(transform.position, MonsterList[i].transform.position);
                if(targetDist >= currentDist)
                {
                    targetDist = currentDist;
                    targetIndex = i;
                    closeDistIndex = i;
                }
            }
        }
        if(targetIndex == -1 || MonsterList[targetIndex].gameObject != null)
        {
            targetIndex = closeDistIndex;
        }
        if(MonsterList.Count > targetIndex && MonsterList[targetIndex].gameObject != null)
        {
            heroController.MoveTo(MonsterList[targetIndex].transform.position);
        }

        // 공격 사거리보다 가까우면 공격모드로 전환.
        if(targetDist <= heroStat.range)
        {
            onTargetting = true;
            heroController.Stay();
        }
        targetDist = 100f;
    }
    protected virtual void Attack()
    {
        // 해당 몬스터가 죽었으면 실행하지 않음.
        if (MonsterList[targetIndex].gameObject == null)
        {
            onTargetting = false;
            return;
        }

        isAttack = true;
        StartCoroutine(AttackCoroutine());
    }

    IEnumerator AttackCoroutine()
    {
        // 해당 몬스터가 죽었으면 실행하지 않음.
        if (MonsterList[targetIndex].gameObject == null)
        {
            onTargetting = false;
            yield return null;
        }
        else
        {
            anim.SetBool("isAttack", isAttack);
            weapon.Attack(MonsterList[targetIndex].gameObject);
            yield return new WaitForSeconds( heroStat.attackSpeed );
            isAttack = false;
            anim.SetBool("isAttack", isAttack);
        }
    }

    public void OnDamage(int _damage)
    {
        heroHP -= _damage;
    }
    protected void Death()
    {
        Destroy(gameObject);
    }

    public HeroStat returnHeroStat()
    {
        return heroStat;
    }
}
