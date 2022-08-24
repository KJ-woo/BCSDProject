using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    protected PlayerController player;
    protected Animator anim;

    protected void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    protected void Update()
    {
        if(player.gameMode == GameMode.PlacementMode)
        {
            Anim_Placement();
        }
    }
    // 이동 중 속도를 동일하게 맞추는 함수
    protected void Run()
    {
        /* 
         *  if gameMode == Run
         *      tempMoveSpeed = moveSpeed
         *      moveSpeed = 1
         *  else
         *      moveSpeed = tempMoveSpeed
         */

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
