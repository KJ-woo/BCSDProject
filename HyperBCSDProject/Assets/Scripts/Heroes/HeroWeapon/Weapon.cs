using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Melee,
    Range,

}
public class Weapon : MonoBehaviour
{
    private Hero hero;
    private HeroStat heroStat;
    private GameObject target;
    public BoxCollider boxCollider;
    public WeaponType type;

    public Transform projectilePos; // 투사체 생성 위치.
    public GameObject projectile;   // 투사체

    
    
    void Awake()
    {
        hero = GetComponentInParent<Hero>();
        boxCollider = GetComponent<BoxCollider>();
        heroStat = hero.returnHeroStat();
    }
    
    public void Attack(GameObject enemy)
    {
        target = enemy;
        if(type == WeaponType.Melee)
        {
            StopCoroutine(Swing());
            StartCoroutine(Swing());

        }
        else if(type == WeaponType.Range)
        {
            StopCoroutine(Shot());
            StartCoroutine(Shot());
        }
    }
    IEnumerator Swing()
    {
        yield return new WaitForSeconds(heroStat.attackSpeed/3);
        //boxCollider.enabled = true;
        yield return new WaitForSeconds(heroStat.attackSpeed/3);
        //boxCollider.enabled = false;
        yield return new WaitForSeconds(heroStat.attackSpeed/3);
    }
    IEnumerator Shot()
    {
        // 발사
        GameObject instantProjtectile = Instantiate(projectile, projectilePos.position, Quaternion.Euler(new Vector3(-90,0,-22)));
        Rigidbody projectileRigid = instantProjtectile.GetComponent<Rigidbody>();

        // projectileRigid.velocity = Vector3.forward * 5f;
        Projectile _projectile = instantProjtectile.GetComponent<Projectile>();
        _projectile.SetTarget(target);

        yield return null;
    }

}
