using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed = 5;
    [SerializeField] private float lifeTime = 6;

    private Quaternion initRot;

    [HideInInspector] public bool IsReflected = false;

    void Start()
    {
        initRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        float elapsedTime = 0;
        elapsedTime += Time.deltaTime;

        if(elapsedTime>= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
