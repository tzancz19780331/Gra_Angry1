using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    [Header("Wave 1 (Civil cars)")]
    public GameObject civilCar;
    public float civilCarSpawnDelay;
    public int civilCarsAmount;
    [Header("Wave 2 (Bandit cars")]
    public GameObject banditCar;
    public int bombsAmount;
    public int banditCarVerticalSpeed;
    public int banditVarHorizontalSpeed;
    public float bombDelay;
    private GameObject spawnedBanditCar;
    private bool isSpawned;
    private bool is2ndSpawned;
    [Header("Wave 3 (Police cars")] 
    public GameObject policeCar;
    public int policeCarAmount;
    [HideInInspector]
    static public bool isLeft;
    [HideInInspector]
    static public bool isRight;
    public float shootingSeriesDelay;
    public float singleShotDelay;
    public float policeCarVerticalSpeed;
    public int bulletsInSeries;
    private GameObject spawnedPoliceCar;

    [Header("Points")]
    public int pointsPerCivilCar;
    public int pointsPerBanditCar;
    public int pointsPerBomb;
    public int pointsPerPoliceCar;

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
        else if (civilCarsAmount <= 0 && is2ndSpawned == false){
            if (isSpawned == false)
            {
                spawnBanditCar();
            }
            else if (isSpawned == true && spawnedBanditCar.GetComponent<BanditCarBehaviour>().bombsAmount < 5 && is2ndSpawned == false)
            {
                spawnBanditCar();
            }
        }else if (civilCarsAmount <= 0 && policeCarAmount > 0 && spawnedBanditCar == null)
        {
            spawnPoliceCar();
        }
    }

    void spawnPoliceCar()
    {
        if (GameObject.FindWithTag("Player").gameObject.transform.position.x <= -0.51f && isRight == false)
        {
            spawnedPoliceCar = (GameObject)Instantiate(policeCar, new Vector3(2.05f, -7f, 0), Quaternion.identity);
            spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().isLeft = false;
            isRight = true;
            policeCarAmount--;
        }else if (GameObject.FindWithTag("Player").gameObject.transform.position.x > -0.51f && isLeft == false)
        {
            spawnedPoliceCar = (GameObject)Instantiate(policeCar, new Vector3(-2.05f, -7f, 0), Quaternion.identity);
            spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().isLeft = true;
            isLeft = true;
            policeCarAmount--;
        }
        spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().shootingSeriesDelay = shootingSeriesDelay;
        spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().singleShotDelay = singleShotDelay;
        spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().bulletsInSeries = bulletsInSeries;
        spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().policeCarVerticalSpeed = policeCarVerticalSpeed;
        spawnedPoliceCar.GetComponent<PoliceCarBehaviour>().pointsPerCar = pointsPerPoliceCar;
    }

    void spawnBanditCar()
    {
        if (isSpawned == false)
        {
            spawnedBanditCar = (GameObject)Instantiate(banditCar, new Vector3(Random.Range(-2.25f, 2.25f), 7f, 0), Quaternion.identity);
            isSpawned = true;
        }else if (isSpawned == true && is2ndSpawned == false)
        {
            if (spawnedBanditCar.transform.position.x < 0.45f)
            {
                spawnedBanditCar = (GameObject)Instantiate(banditCar, new Vector3(2.2f, 7f, 0), Quaternion.identity);
                is2ndSpawned = true;
            }
            else if (spawnedBanditCar.transform.position.x >= 0.45f)
            {
                spawnedBanditCar = (GameObject)Instantiate(banditCar, new Vector3(-2.2f, 7f, 0), Quaternion.identity);
                is2ndSpawned = true;
            }
        }
        spawnedBanditCar.GetComponent<BanditCarBehaviour>().bombsAmount = bombsAmount;
        spawnedBanditCar.GetComponent<BanditCarBehaviour>().banditCarVerticalSpeed = banditCarVerticalSpeed;
        spawnedBanditCar.GetComponent<BanditCarBehaviour>().banditVarHorizontalSpeed = banditVarHorizontalSpeed;
        spawnedBanditCar.GetComponent<BanditCarBehaviour>().bombDelay = bombDelay;
        spawnedBanditCar.GetComponent<BanditCarBehaviour>().pointsPerCar = pointsPerPoliceCar;
        spawnedBanditCar.GetComponent<BanditCarBehaviour>().bomb.GetComponent<Bomb>().pointsPerBomb = pointsPerBomb;
    }

    void spawnCar()
    {
        int lane = Random.Range(0, 4);
        if (lane == 0 || lane == 1)
        {
            GameObject car = (GameObject)Instantiate(civilCar, new Vector3(lanesArray[lane], 6f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));
            car.GetComponent<CivilCarBehaviour>().direction = 1;
            car.GetComponent<CivilCarBehaviour>().civilCarSpeed = 12f;
            car.GetComponent<CivilCarBehaviour>().pointsPerCar = pointsPerCivilCar;
        }
        if (lane == 2 || lane == 3)
        {
            GameObject car = (GameObject)Instantiate(civilCar, new Vector3(lanesArray[lane], 6f, 0), Quaternion.identity);
            car.GetComponent<CivilCarBehaviour>().pointsPerCar = pointsPerCivilCar;
        }
        civilCarsAmount--;
    }

}
