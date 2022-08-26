using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerHero;

    [SerializeField]
    private LayerMask layerGround;

    private Camera mainCamera;
    private HeroControlSystem heroControlSystem;
    private PlayerController player;

    private void Awake()
    {
        mainCamera = Camera.main;
        heroControlSystem = GetComponent<HeroControlSystem>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

    }

    private void Update()
    {
        if(player.gameMode == GameMode.PlacementMode)
        {

            if(Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                // 유닛 클릭 시
                if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerHero))
                {
                    if (hit.transform.GetComponent<HeroController>() == null) return;

                    if(Input.GetKey(KeyCode.LeftShift))
                    {
                        heroControlSystem.ShiftClickSelectHero(hit.transform.GetComponent<HeroController>());
                    }
                    else
                    {
                        heroControlSystem.ClickSelectHero(hit.transform.GetComponent<HeroController>());

                    }
                }
                // 맨땅 클릭 시
                else
                {
                    if(!Input.GetKey(KeyCode.LeftShift))
                    {
                        heroControlSystem.DeselectAll();
                    }
                }
            }

            // 유닛 이동
            if(Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                // 유닛 오브젝트를 클릭했을 때
                if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerGround))
                {
                    heroControlSystem.MoveSelectedHeroes(hit.point);
                }
            }
        }
    }
}
