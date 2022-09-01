using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseHero : MonoBehaviour
{
    public List<GameObject> AddHeroList = new List<GameObject>();
    public GameObject HeroSpawner;

    private HeroSpawner heroSpawner;
    private void Start()
    {
        heroSpawner = HeroSpawner.GetComponent<HeroSpawner>();
    }
    // 플레이어와 접촉 시 해당 영웅들을 현재 플레이어의 영웅보유목록에 추가한다.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            heroSpawner.AddHero(AddHeroList);
            Destroy(this.gameObject);
        }
        
    }
}
