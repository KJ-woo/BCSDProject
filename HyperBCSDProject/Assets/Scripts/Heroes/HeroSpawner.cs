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
    private Vector3[] heroesPosition;
    private PlayerController player;
    public List<GameObject> CurrentHeroList = new List<GameObject>();
    public List<GameObject> AddedHeroList = new List<GameObject>();

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        heroesPosition = new Vector3[height * width];
    }
    private void Update()
    {
        // 달리는 중일때만 동작
        if(player.gameMode == GameMode.RunMode)
        {
            SetHeroesPosition();
            UpdateHeroesPosition();
        }
    }
    // 영웅 선택지 중 하나를 골랐을때 실행되는 함수.
    public void AddHero(List<GameObject> AddHeroList)
    {
        AddedHeroList.AddRange(AddHeroList);
        StartCoroutine(InstantiateHero());
    }

    // 장애물에 부딛혔을 때 실행되는 함수
    public void DeleteHero(GameObject hero)
    {
        int index = CurrentHeroList.IndexOf(hero);
        // 현재 영웅 리스트의 영웅을 삭제한다.
        Destroy(CurrentHeroList[index].gameObject);
    }
    // 초기 자리를 설정하는 함수
    private void SetHeroesPosition()
    {
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
            if(CurrentHeroList[i].gameObject != null)
            {
                CurrentHeroList[i].transform.position = heroesPosition[i];
            }
        }
    }

    // 영웅을 추가하는 함수
    private void AddHeroOnCurrentHeroList(GameObject hero)
    {
        // 만약 빈칸이 있다면 그 자리에 영웅을 추가한다.
        for (int i = 0; i < CurrentHeroList.Count; ++i)
        {
            if(CurrentHeroList[i].gameObject == null)
            {
                CurrentHeroList[i] = hero;
                return;
            }
        }
        // 없다면 맨 뒷자리에 영웅을 추가한다.
        CurrentHeroList.Add(hero);
    }

    // 생존한 히어로들을 선택하기 위해 반환한다.
    public List<HeroController> ReturnHeroes()
    {
        List<HeroController> HeroList = new List<HeroController>();
        for(int i=0; i<CurrentHeroList.Count; ++i)
        {
            if(CurrentHeroList[i].gameObject != null)
            {
                HeroController hero = CurrentHeroList[i].GetComponent<HeroController>();
                HeroList.Add(hero);
            }
        }
        return HeroList;
    }

    // 새로 추가된 영웅을 생성한다.
    IEnumerator InstantiateHero()
    {
        while(AddedHeroList.Count > 0)
        {
            // 영웅 추가 리스트의 첫 번째 영웅 추가
            instantHero = Instantiate(AddedHeroList[0], transform.position, transform.rotation);
            // HeroSpawner 게임오브젝트 위치의 자식으로 생성되게 함.
            instantHero.transform.parent = transform;
            // 영웅 추가 리스트의 해당 인덱스 제거
            AddedHeroList.RemoveAt(0);
            // 현재 영웅 리스트에 영웅 추가
            AddHeroOnCurrentHeroList(instantHero);
        }
        yield return null;
    }
}
