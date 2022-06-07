using System.Collections;
using UnityEngine;

public class CivilCarBehaviour : MonoBehaviour {

    public float crashDamage = 20f;
    public GameObject explosion;
    public float civilCarSpeed = 5f;
    public int direction = -1;
    [HideInInspector]
    public int pointsPerCar;
   
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
            PointsManager.points -= pointsPerCar;
            obj.gameObject.GetComponent<RedCarMovement>().durability -= crashDamage;
            Debug.Log("Gracz w nas wjechał");
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        } else if (obj.gameObject.tag == "EndOfTheRoad")
        {
            PointsManager.points += pointsPerCar;
            Destroy(this.gameObject);
        }
    }

}
