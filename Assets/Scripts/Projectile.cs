using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] protected float speed = 5;
    [SerializeField] protected float lifeTime = 6;

    private Quaternion initRot;

    [HideInInspector] public bool IsReflected = false;

    private float elapsedTime = 0;

    void Start()
    {
        initRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        
        elapsedTime += Time.deltaTime;

        if(elapsedTime>= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player_0>() && !IsReflected)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.GetComponent<Mirror>() && IsReflected)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.GetComponent<Mirror>() && IsReflected)
        {
            Destroy(gameObject);
        }
    }
}
