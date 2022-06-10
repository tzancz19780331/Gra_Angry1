using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonuses : MonoBehaviour
{
    [Header("Type of bonus")]
    public bool isDurability;
    public bool isShield;
    public bool isSpeed;

    [Header("Bonuses Settings")]
    public float bonusSpeed = 10f;

    [Header("Durability Setings")]
    public float repairPoints;

    //[Header("Shield Settings")]
    //public GameObject shield;
    //private GameObject RedCar;
    //private Vector3 RedCarPos;

    [Header("Speed Settings")]
    public float speedBoost;
    public float duration;
    private bool isActivated = false;

    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, -1, 0) * bonusSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player")
        {
          if(isDurability == true)
          {
                obj.gameObject.GetComponent<RedCarMovement>().durability += repairPoints;
                Destroy(this.gameObject);
         
          }else if (isSpeed == true)
          {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;  
            isActivated = true;
            StartCoroutine("SpeedBoostActivated");
          }
        }else if(obj.gameObject.tag == "End" && isActivated == false)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator SpeedBoostActivated()
    {
       while(duration > 0)
       {
           duration -= Time.deltaTime / speedBoost;
           Time.timeScale = speedBoost;
           yield return null;
       } 
       Time.timeScale = 1f;
       Destroy(this.gameObject);
    }
}
