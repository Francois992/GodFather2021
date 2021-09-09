using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{

    [SerializeField] private int randomMirrorId;
    [SerializeField] private int randomSpawnTime;
    [SerializeField] private float timer;

    public GameObject PowerUpPrefab;

    void Start()
    {
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
        yield return new WaitForSeconds(randomSpawnTime);
        Instantiate(PowerUpPrefab, new Vector2 (randomMirror.position.x, randomMirror.position.y), Quaternion.identity);
        StartCoroutine(ChooseRandomMirror());
    }
}