using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;

    [SerializeField]
    float speed = 0f;

    [SerializeField]
    LayerMask layerMask = 0;

    private GameObject target;
    private Rigidbody rigid;
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    public void SetTarget(GameObject gameObject)
    {
        target = gameObject;
    }
    private void Update()
    {
        if(target != null)
        {
            Debug.Log(target);
            transform.position += transform.forward * speed * Time.deltaTime;
            Vector3 _dir = (target.transform.position - this.transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, _dir, 0.25f);
        }
        else
        {
            Destroy(gameObject, 2f);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject, 1f);
        }
        else if(collision.gameObject.CompareTag("Monster"))
        {
            Destroy(gameObject);

        }
    }
}
