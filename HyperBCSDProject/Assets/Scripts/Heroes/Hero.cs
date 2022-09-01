using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Hero : MonoBehaviour
{
    protected Animator anim;
    protected bool run;
    protected Rigidbody rigid;

    protected NavMeshAgent nav;
    protected void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        run = true;
    }
    protected void Update()
    {
        anim.SetBool("Run", run);
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
        run = false;
    }
    protected virtual void Attack()
    {

    }

    protected void Death()
    {
        Destroy(gameObject);
    }
}
