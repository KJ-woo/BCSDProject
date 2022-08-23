using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject HeroSpanwer;
    private HeroSpawner heroSpawner;

    private void Start()
    {
        heroSpawner = HeroSpanwer.GetComponent<HeroSpawner>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hero") && heroSpawner.CurrentHeroList.Count != 0)
        {
            heroSpawner.DeleteHero(other.gameObject);
        }
    }
}
