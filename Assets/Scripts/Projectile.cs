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

    private AudioSource audioSource;
    [SerializeField] private AudioClip playerHurt;
    [SerializeField] private AudioClip mirrorBreak;

    [SerializeField] private GameObject player;

    void Start()
    {
        initRot = transform.rotation;
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player_0>() && !IsReflected)
        {
            Destroy(gameObject);
            Score.instance.scoreP1 -= 1;
            Score.instance.scoreP2 += 1;
            audioSource.PlayOneShot(playerHurt);
        }
        if (collision.gameObject.GetComponent<Mirror>() && IsReflected)
        {
            Destroy(gameObject);
            Score.instance.scoreP1 += 1;
            Score.instance.scoreP2 -= 1;
            audioSource.PlayOneShot(mirrorBreak);
        }
    }

}
