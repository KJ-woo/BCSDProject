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
    public int damage;
    private GameObject target;
    public MeshCollider meshCollider;
    
    public WeaponType type;

    public Transform projectilePos; // 투사체 생성 위치.
    public GameObject projectile;   // 투사체

    void Awake()
    {
        hero = GetComponentInParent<Hero>();
        meshCollider = GetComponent<MeshCollider>();
        heroStat = hero.returnHeroStat();
        damage = heroStat.damage;
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
        yield return new WaitForSeconds(0.1f);
    }
    IEnumerator Shot()
    {
        // 발사
        GameObject instantProjtectile = Instantiate(projectile, projectilePos.position, Quaternion.Euler(new Vector3(-90,0,0)));
        Rigidbody projectileRigid = instantProjtectile.GetComponent<Rigidbody>();

        Projectile _projectile = instantProjtectile.GetComponent<Projectile>();
        _projectile.SetTarget(target);
        _projectile.SetDamage(damage);

        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(type == WeaponType.Melee && collision.gameObject.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().OnDamage(damage);
        }
    }
}
