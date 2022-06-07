using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    [Header("Wave 1 (Civil cars)")]
    public GameObject civilCar;
    public float civilCarSpawnDelay;
    public int civilCarsAmount;
    [Header("Wave 1 (Bandit cars")]
    [Header("Wave 1 (Police cars")]

    private float[] lanesArray;
    private float spawnDelay;

    void Start()
    {
        lanesArray = new float[4];
        lanesArray[0] = -2.4f;
        lanesArray[1] = -0.86f;
        lanesArray[2] = 0.86f;
        lanesArray[3] = 2.4f;
        spawnDelay = civilCarSpawnDelay;
    }

    void Update()
    {
        spawnDelay -= Time.deltaTime;
        if(spawnDelay<=0 && civilCarsAmount > 0)
        {
            spawnCar();
            spawnDelay = civilCarSpawnDelay;
        }
    }
    
    void spawnCar()
    {
        int lane = Random.Range(0, 4);
        if (lane == 0 || lane == 1)
        {
           GameObject car = (GameObject)Instantiate(civilCar, new Vector3(lanesArray[lane], 6f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));
            car.GetComponent<CivilCarBehaviour>().direction = 1;
            car.GetComponent<CivilCarBehaviour>().civilCarSpeed = 12f;
        }
        if (lane == 2 || lane == 3)
        {
            Instantiate(civilCar, new Vector3(lanesArray[lane], 6f, 0), Quaternion.identity);
        }
        civilCarsAmount--;
    }
}