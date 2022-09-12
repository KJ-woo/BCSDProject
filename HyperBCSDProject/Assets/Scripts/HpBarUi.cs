using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarUi : MonoBehaviour
{
    [SerializeField]
    private Slider hpBar;

    private float maxHp = 150;
    private float curHp = 150;

    // Start is called before the first frame update
    void Start()
    {
        hpBar.value = (float)curHp / (float)maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        HandleHp();
    }

    private void HandleHp()
    {
        hpBar.value = Mathf.Lerp(hpBar.value, (float)curHp / (float)maxHp, Time.deltaTime * 10);
    }
}
