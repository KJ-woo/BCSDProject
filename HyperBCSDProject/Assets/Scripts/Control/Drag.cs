using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    [SerializeField]
    private RectTransform dragRectangle;    // 드래그 범위 가시화

    private Rect dragRect;                  // 드래그 범위
    private Vector2 start = Vector2.zero;   // 시작 위치
    private Vector2 end = Vector2.zero;     // 종료 위치

    private Camera mainCamera;
    private HeroControlSystem heroControlSystem;
    private PlayerController player;


    private void Awake()
    {
        mainCamera = Camera.main;
        heroControlSystem = GetComponent<HeroControlSystem>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();


        DrawDragRectangle();

    }

    private void Update()
    {
        if(player.gameMode == GameMode.PlacementMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                start = Input.mousePosition;
                dragRect = new Rect();
            }

            if (Input.GetMouseButton(0))
            {
                end = Input.mousePosition;

                // 클릭한 상태로 드래그하는 동안 드래그 범위를 이미지로 표현
                DrawDragRectangle();
            }
            if (Input.GetMouseButtonUp(0))
            {
                // 클릭 종료 시 드래그 범위 내에 있는 유닛 선택
                CalculateDragRect();
                SelectHeros();

                // 클릭 종료시 드래그 범위 보이지 않도록
                // start, end를 0,0으로 초기화
                start = end = Vector2.zero;
                DrawDragRectangle();
            }
        }        
    }

    // 드래그 범위 표시 UI
    private void DrawDragRectangle()
    {
        // Image UI 위치
        dragRectangle.position = (start + end) * 0.5f;
        // Image UI 크기
        dragRectangle.sizeDelta = new Vector2(Mathf.Abs(start.x - end.x), Mathf.Abs(start.y - end.y));
    }

    private void CalculateDragRect()
    {
        if(Input.mousePosition.x < start.x)
        {
            dragRect.xMin = Input.mousePosition.x;
            dragRect.xMax = start.x;
        }
        else
        {
            dragRect.xMin = start.x;
            dragRect.xMax = Input.mousePosition.x;
        }

        if (Input.mousePosition.y < start.y)
        {
            dragRect.yMin = Input.mousePosition.y;
            dragRect.yMax = start.y;
        }
        else
        {
            dragRect.yMin = start.y;
            dragRect.yMax = Input.mousePosition.y;
        }
    }

    private void SelectHeros()
    {
        // 모든 유닛 검사
        foreach(HeroController hero in heroControlSystem.HeroList)
        {
            // 유닛 월드 좌표를 화면 좌표로 변환. 드래그 범위 안에 있는지 검사
            if(dragRect.Contains(mainCamera.WorldToScreenPoint(hero.transform.position)))
            {
                heroControlSystem.DragSelectHero(hero);
            }
        }
    }
}
