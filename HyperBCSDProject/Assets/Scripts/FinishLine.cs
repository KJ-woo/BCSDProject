using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private PlayerController player;
    private void OnTriggerEnter(Collider other)
    {
        // 결승점에 도달하면
        if (other.CompareTag("Player"))
        {
            // 게임모드를 배치 모드로 바꿈
            player = other.GetComponent<PlayerController>();
            player.gameMode = GameMode.PlacementMode;
            // 180도 회전시킴
            player.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            
            // 카메라, 애니메이션 변경해줘야 함
            
            Destroy(this.gameObject);
        }
    }
}
