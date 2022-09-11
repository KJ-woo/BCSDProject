using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControlSystem : MonoBehaviour
{
    [SerializeField]
    private HeroSpawner heroSpawner;
    [SerializeField]
    private List<HeroController> selectedHeroList;              // 플레이어가 클릭 or 드래그로 선택한 영웅
    [SerializeField]
    public List<HeroController> HeroList { private set; get; }  // 현재 모든 영웅

    private void Awake()
    {
        selectedHeroList = new List<HeroController>();
    }

    private void Update()
    {
        GameMode gamemode = heroSpawner.player.gameMode;
        if(gamemode == GameMode.PlacementMode)
        {
            HeroList = heroSpawner.ReturnHeroes();
        }
        else if(gamemode == GameMode.BattleMode)
        {
            foreach (HeroController hero in HeroList)
            {
                hero.nav.ResetPath();
                hero.Stay();
            }
            DeselectAll();
        }
    }
    private void SelectHero(HeroController newHero)
    {
        // 영웅 마커 활성화
        newHero.SelectHero();

        // 선택 히어로 정보 저장
        selectedHeroList.Add(newHero);
    }

    private void DeselectHero(HeroController newHero)
    {
        // 마커 비활성화
        newHero.DeSelectHero();
        // 선택 히어로 정보 삭제
        selectedHeroList.Remove(newHero);
    }
    // 마우스 클릭으로 영웅 선택시 실행
    public void ClickSelectHero(HeroController newHero)
    {
        // 기존의 영웅 선택 해제
        DeselectAll();

        SelectHero(newHero);
    }

    public void ShiftClickSelectHero(HeroController newHero)
    {
        // 기존 선택중이던 영웅을 선택했으면 선택 해제
        if(selectedHeroList.Contains(newHero))
        {
            DeselectHero(newHero);
        }
        // 선택중이지 않을 경우 선택처리
        else
        {
            SelectHero(newHero);
        }
    }

    // 드래그로 선택시 호출
    public void DragSelectHero(HeroController newHero)
    {
        if (!selectedHeroList.Contains(newHero))
        {
            SelectHero(newHero);
        }
    }

    public void DeselectAll()
    {
        for (int i = 0; i < selectedHeroList.Count; ++i)
        {
            selectedHeroList[i].DeSelectHero();
        }
        selectedHeroList.Clear();
    }

    // 선택된 모든 유닛 이동
    public void MoveSelectedHeroes(Vector3 end)
    {
        for (int i = 0; i < selectedHeroList.Count; ++i)
        {
            selectedHeroList[i].MoveTo(end);
        }
    }
}
