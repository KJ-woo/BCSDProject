using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private int hp = 100;

    private void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnDamage(int _damage)
    {
        hp -= _damage;
    }
}
