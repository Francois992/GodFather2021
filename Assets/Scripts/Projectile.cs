using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed = 5;

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
    }
}
