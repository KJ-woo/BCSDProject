using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    protected PlayerController player;
    protected Animator anim;
    protected Rigidbody rigid;

    protected void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    protected void Update()
    {
        if(player.gameMode == GameMode.PlacementMode)
        {
            Anim_Placement();
        }
    }

    private void FreezeRotation()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;

    }
    private void FixedUpdate()
    {
        FreezeRotation();
    }
    private void Anim_Placement()
    {
        anim.SetTrigger("active_PlacementMode");
    }
    protected virtual void Attack()
    {

    }

    protected void Death()
    {
        Destroy(gameObject);
    }
}
