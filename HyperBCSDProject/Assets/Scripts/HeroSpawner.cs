using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    [Header("BoxCollider의 x size를 width에 맞춰야 함")]
    [SerializeField]
    private int width = 4;
    [SerializeField]
    private int height = 8; // maximum = width * height

    private GameObject instantHero;
    private BoxCollider area;
    private Vector3[] heroesPosition;
    public List<GameObject> CurrentHeroList = new List<GameObject>();
    public List<GameObject> AddedHeroList = new List<GameObject>();

    private void Start()
    {
        area = GetComponent<BoxCollider>();
        heroesPosition = new Vector3[height * width];
    }
    private void Update()
    {
        SetHeroesPosition();
        UpdateHeroesPosition();
    }
    // 영웅 선택지 중 하나를 골랐을때 실행되는 함수.
    public void AddHero(List<GameObject> AddHeroList)
    {
        AddedHeroList.AddRange(AddHeroList);
        StartCoroutine(InstantiateHero());
    }

    public void DeleteHero(GameObject hero)
    {
        int index = CurrentHeroList.IndexOf(hero);
        
        StartCoroutine(DestroyDelay(index));
    }
    IEnumerator DestroyDelay(int index)
    {
        new WaitForSeconds(2.0f);
        Destroy(CurrentHeroList[index]);
        CurrentHeroList.RemoveAt(index);
        yield return null;
    }
    // 초기 자리를 설정하는 함수
    private void SetHeroesPosition()
    {
        Vector3 size = area.size;
        Vector3 basePosition = transform.position;

        for(int i = 0; i < height * width; ++i)
        {
            float posX = basePosition.x - width / 2 + 0.5f + i % width ;
            float posY = basePosition.y;
            float posZ = basePosition.z - i / width;
            heroesPosition[i] = new Vector3(posX, posY, posZ);
        }
    }

    // 영웅의 위치를 업데이트해주는 함수
    private void UpdateHeroesPosition()
    {
        for(int i=0;i<CurrentHeroList.Count; ++i)
        {
            CurrentHeroList[i].transform.position = heroesPosition[i];
        }
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
            CurrentHeroList.Add(instantHero);
        }
        yield return null;
    }
}
