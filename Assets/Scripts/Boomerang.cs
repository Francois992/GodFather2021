using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [SerializeField] protected float speed = 20;
    [SerializeField] protected float lifeTime = 6;

    [HideInInspector] public bool IsReflected = false;

    private float elapsedTime = 0;
    private float elapsedTime2 = 0;
    private float initSpeed;

    // Start is called before the first frame update
    void Start()
    {
        initSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;

        elapsedTime += Time.deltaTime;

        if(elapsedTime >= 0.75)
        {
            elapsedTime2 += Time.deltaTime;
            speed = Mathf.Lerp(initSpeed, -initSpeed, elapsedTime2);
        }
        

        if (elapsedTime >= lifeTime)
        {
            Destroy(gameObject);
        }

        transform.GetChild(0).transform.Rotate(0, 0, 6.0f * 10 * Time.deltaTime);
    }
}
