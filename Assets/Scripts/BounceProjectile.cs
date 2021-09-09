using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceProjectile : Projectile
{
    [SerializeField] protected int bounceCountMax = 3;
    private int currentBounceCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 10;
        GetComponent<Rigidbody2D>().AddForce(transform.right * 500);
    }

    private void Update()
    {
        float elapsedTime = 0;
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player_0>() && !IsReflected)
        {
            //Destroy(gameObject);
        }

        if (collision.gameObject.GetComponent<Wall>())
        {
            
        }
    }
}
