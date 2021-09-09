using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceProjectile : Projectile
{
    [SerializeField] protected int bounceCountMax = 3;
    private int currentBounceCount = 0;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 10;
        GetComponent<Rigidbody2D>().AddForce(transform.right * 500);
        rb = GetComponent<Rigidbody2D>();
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

    private void Bounce()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player_0>() && !IsReflected)
        {
            Destroy(gameObject);
        }
        else
        {
            var speed = rb.velocity.magnitude;
            var direction = Vector3.Reflect(rb.velocity.normalized, collision.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(speed, 0f);
        }
    }

}
