using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    private Hero instantHero;
    public List<Hero> CurrentHeroList = new List<Hero>();
    public List<Hero> AddedHeroList = new List<Hero>();

    // 영웅 선택지 중 하나를 골랐을때 실행되는 함수.
    public void AddHero(List<Hero> AddHeroList)
    {
        CurrentHeroList.AddRange(AddHeroList);
        AddedHeroList.AddRange(AddHeroList);
        StartCoroutine(InstantiateHero());
    }

    // 새로 추가된 영웅을 생성한다.
    IEnumerator InstantiateHero()
    {
        while(AddedHeroList.Count > 0)
        {
            // 추가할 영웅 리스트의 첫 번째 영웅 추가
            instantHero = Instantiate(AddedHeroList[0], transform.position, transform.rotation);
            // HeroSpawner 게임오브젝트 위치의 자식으로 생성되게 함.
            instantHero.transform.parent = transform;
            // 리스트의 해당 인덱스 제거
            AddedHeroList.RemoveAt(0);

        }
        yield return null;
    }
}
