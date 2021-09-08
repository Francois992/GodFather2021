using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed;

    [HideInInspector] public bool IsReflected = false;

    public Vector3 MoveVector = Vector3.right;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += MoveVector * speed * Time.deltaTime;
    }
}
