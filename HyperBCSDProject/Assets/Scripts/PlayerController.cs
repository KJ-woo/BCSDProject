using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    RunMode,
    PlacementMode,      // 배치 모드

}
public class PlayerController : MonoBehaviour
{
    
    [SerializeField]
    private float runSpeed;         // 플레이어 속도
    
    private Rigidbody playerRigid;

    [SerializeField]
    private float dragDistance;     // 플레이어가 드래그 한 거리

    private Vector3 touchStart;     // 터치 시작 지점
    private Vector3 touchEnd;       // 터치 종료 지점

    public GameMode gameMode;
    /*
     * [serializeField]
     * private GameObject Units;    // 움직일 유닛들 오브젝트
     * 
     */
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
        gameMode = GameMode.RunMode;
    }

    void Update()
    {
        if(gameMode == GameMode.RunMode)
        {
            PlayerMove();
            OnMouse();
        }
        else
        {

        }
    }

    // 기본 이동
    private void PlayerMove()
    {
        transform.position += Vector3.forward * runSpeed * Time.deltaTime;
    }
    // 플레이어가 터치(PC는 왼쪽 마우스 클릭) 했을 때 작동
    private void OnMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            touchEnd = Input.mousePosition;

            StartCoroutine(OnMove());
        }
    }

    // 플레이어 드래그 시 좌 우 이동
    IEnumerator OnMove()
    {
        transform.position += new Vector3(touchEnd.x - touchStart.x, 0, 0).normalized * dragDistance;
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        // 결승점에 도달하면
        if (other.CompareTag("FinishLine"))
        {
            // 게임모드를 배치 모드로 바꿈
            gameMode = GameMode.PlacementMode;
            // 180도 회전시킴
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

            // 카메라, 애니메이션 변경해줘야 함
        }
    }
}
