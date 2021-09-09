using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField] private int randomMirrorId;
    [SerializeField] private int randomSpawnTime;
    [SerializeField] private float timer;

    public GameObject player;

    private SpriteRenderer sprite;
    private SpriteRenderer previousSprite;

    void Start()
    {
        sprite = transform.GetChild(0).GetComponentInChildren<SpriteRenderer>();
        StartCoroutine(ChooseRandomMirror());
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    IEnumerator ChooseRandomMirror()
    {
        if(timer <= 60)
        {
          randomSpawnTime = Random.Range(10, 15);
        }
        else if(timer > 60 && timer <= 120)
        {
          randomSpawnTime = Random.Range(5, 10);
        }
        else
        {
          randomSpawnTime = Random.Range(2, 5);
        }
        randomMirrorId = Random.Range(0, transform.childCount);
        Transform randomMirror = transform.GetChild(randomMirrorId);
        previousSprite = sprite;
        sprite = randomMirror.GetComponentInChildren<SpriteRenderer>();
        yield return new WaitForSeconds(randomSpawnTime);
        sprite.color = new Color (0.2f, 0.2f, 0.2f, 1);
        previousSprite.color = new Color (1, 1, 1, 1);
        StartCoroutine(ChooseRandomMirror());
    }
}
