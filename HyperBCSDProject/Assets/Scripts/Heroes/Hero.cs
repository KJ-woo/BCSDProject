using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
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

    protected virtual void Attack()
    {

    }

    protected void Death()
    {
        Destroy(gameObject);
    }
}
