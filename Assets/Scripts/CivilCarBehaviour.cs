using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CivilCarBehaviour : MonoBehaviour {


    public float crashDamage = 20f;
   
    public float civilCarSpeed = 5f;
    public int direction = -1;
    [HideInInspector]
   

    private Vector3 civilCarPosition;


    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, direction, 0) * civilCarSpeed * Time.deltaTime);
    }
    
        void OnCollisionEnter2D(Collision2D obj)
        {
            if(obj.gameObject.tag == "Player")
            {
               obj.gameObject.GetComponent<RedCarMovement>().durability -= crashDamage / 5; 
            }
        }
   

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            obj.gameObject.GetComponent<RedCarMovement>().durability -= crashDamage;
            Debug.Log("Gracz w nas wjechał");
            Destroy(this.gameObject);
        } else if (obj.gameObject.tag == "EndOfTheRoad")
        {
            Destroy(this.gameObject);
        }

    }

}
