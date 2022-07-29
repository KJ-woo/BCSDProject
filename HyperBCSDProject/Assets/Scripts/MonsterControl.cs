using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{
    // x축 이동
    private float moveXWidth = 1.5f; // 1회 이동 시 이동 거리
    private float moveTimeX = 0.1f; // 1회 이동에 소요되는 시간
    private bool isXMove = false; // true : 이동, false : 이동 가능

    // y축 이동
    private float originY = 0.55f;
    private float gravity = -9.81f;
    private float moveTimeY = 0.3f;
    private bool isJump = false;

    // z축 이동
    [SerializeField]
    private float moveSpeed = 20.0f;

    private Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // z축 이동
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
    }

    public void MoveToX(int x)
    {
        if (isXMove == true)
            return;
        if (x > 0 && transform.position.x < moveXWidth)
        {
            StartCoroutine(OnMoveToX(x));
        }
        else if (x < 0 && transform.position.x > -moveXWidth)
        {
            StartCoroutine(OnMoveToX(x));
        }
    }

    public void MoveToY()
    {
        if (isJump == true)
            return;
        StartCoroutine(OnMoveToY());
    }

    private IEnumerator OnMoveToX(int direction)
    {
        float current = 0;
        float percent = 0;
        float start = transform.position.x;
        float end = transform.position.x + direction * moveXWidth;

        isXMove = true;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTimeX;

            float x = Mathf.Lerp(start, end, percent);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);

            yield return null;
        }

        isXMove = false;
    }

    private IEnumerator OnMoveToY()
    {
        float current = 0;
        float percent = 0;
        float v0 = -gravity;

        isJump = true;
        rigid.useGravity = false;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTimeY;

            float y = originY + (v0 * percent) + (gravity * percent * percent);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);

            yield return null;
        }

        isJump = false;
        rigid.useGravity = true;
    }
}
