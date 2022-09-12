using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHpBarScript : MonoBehaviour
{
    // Hp 바 프리팹
    [SerializeField]
    Slider m_goPrefab = null;

    // Hp 바가 적용될 위치에 대한 리스트
    List<Transform> m_objectList = new List<Transform>();
    // Hp 바 객체 리스트
    List<Slider> m_hpBarList = new List<Slider>();

    // 카메라 변수 선언
    Camera m_cam = null;

    // Start is called before the first frame update
    void Start()
    {
        m_cam = Camera.main;
        GameObject[] t_objects = GameObject.FindGameObjectsWithTag("Monster");
        for (int i = 0; i < t_objects.Length; i++)
        {
            m_objectList.Add(t_objects[i].transform);
            Slider t_hpbar = Instantiate(m_goPrefab, t_objects[i].transform.position, Quaternion.identity, transform);
            m_hpBarList.Add(t_hpbar);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < m_objectList.Count; i++)
        {
            m_hpBarList[i].transform.position = m_cam.WorldToScreenPoint(m_objectList[i].position + new Vector3(0, 2.5f, 0));
        }
    }
}
