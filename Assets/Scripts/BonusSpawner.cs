using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{

public GameObject[] bonuses;
public int minDelay;
public int maxDelay;

private float delay;

void Start()
{
    delay = Random.Range(minDelay, maxDelay);
}

void Update()
{

    delay -= Time.deltaTime;
    if(delay <= 0)
    {
        delay = Random.Range(minDelay, maxDelay);
        SpawnBonus();
    }
}

void SpawnBonus()
{
    Instantiate(bonuses[(int)Random.Range(0,2)], new Vector3(Random.Range(-2.3f, 2.3f), 4.5f, 0), Quaternion.identity);
}

}
