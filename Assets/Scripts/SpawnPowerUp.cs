using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{

    [SerializeField] private int randomMirrorId;
    [SerializeField] private int randomSpawnTime;
    [SerializeField] private float timer;

    public PowerUp PowerUpPrefab;

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
        PowerUp newPowerUp = Instantiate(PowerUpPrefab, new Vector2 (randomMirror.position.x, randomMirror.position.y), Quaternion.identity);
        int randomPowerUp = Random.Range(1, 2);
        if (randomMirror.GetComponent<Mirror>().hasSpreadPU || randomMirror.GetComponent<Mirror>().hasboomerangdPU)
        {
            randomMirror.GetComponent<Mirror>().hasSpreadPU = false;
            randomMirror.GetComponent<Mirror>().hasboomerangdPU = true;
        }

        if (randomPowerUp == 1)
        {
            randomMirror.GetComponent<Mirror>().myPowerUp = newPowerUp;
            randomMirror.GetComponent<Mirror>().hasSpreadPU = true;
        }
        else
        {
            randomMirror.GetComponent<Mirror>().myPowerUp = newPowerUp;
            randomMirror.GetComponent<Mirror>().hasboomerangdPU = true;
        }
        StartCoroutine(ChooseRandomMirror());
    }
}
