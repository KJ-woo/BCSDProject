using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera firstCamera;
    public Camera mainCamera;
    public PlayerController playerController;
    [SerializeField]
    private float cameraSpeed;      // 카메라 이동 스피드
    [SerializeField]
    private float startPoint;          // 보여줄 곳 좌표 ( 33 추천 )

    void Awake()
    {
        firstCamera.enabled = true;
        mainCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (firstCamera.transform.position.z > startPoint)
        {
            firstCamera.transform.position += Vector3.back * cameraSpeed * Time.deltaTime;
        }
        else
        {
            if(playerController.gameMode == GameMode.IntroMode)
            {
                playerController.gameMode = GameMode.RunMode;
                firstCamera.enabled = false;
                mainCamera.enabled = true;

            }
        }
    }
}
