using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDurabilityManager : MonoBehaviour{

    public GameObject RedCarPrefab;
    public GameObject spawnPoint;
    public TextMesh durabilityText;
    public int lifes;
    private GameObject RedCar;

    void Start()
    {
        RedCar = (GameObject)Instantiate(RedCarPrefab, spawnPoint.transform.position, Quaternion.identity);
    }

    void Update()
    {
        if(RedCar.GetComponent<RedCarMovement>().durability <= 0)
        {
            Destroy(RedCar);
            lifes --;
            if(lifes > 0)
            {
               StartCoroutine("SpawnaCar");
            }
        } else if (RedCar.GetComponent<RedCarMovement>().durability > RedCar.GetComponent<RedCarMovement>().maxDurability)
        {
             RedCar.GetComponent<RedCarMovement>().durability = RedCar.GetComponent<RedCarMovement>().maxDurability;
        }

        durabilityText.text = "Uszkodzenia: " + RedCar.GetComponent<RedCarMovement>().durability + "/" + RedCar.GetComponent<RedCarMovement>().maxDurability;
    }
    
    IEnumerator SpawnaCar()
    {
       RedCar = (GameObject)Instantiate(RedCarPrefab, spawnPoint.transform.position, Quaternion.identity); 
       RedCar.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.4f);
       RedCar.GetComponent<BoxCollider2D>().isTrigger = true;
       RedCar.tag = "Untouchable";
       yield return new WaitForSeconds(3);
       RedCar.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
       RedCar.GetComponent<BoxCollider2D>().isTrigger = false;
       RedCar.tag = "Player";
    }
}