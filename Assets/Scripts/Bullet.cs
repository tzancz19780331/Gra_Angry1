using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;
    public int bulletDamage;
    [HideInInspector]
    public int direction;
    public float bulletSpeed;

    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(direction, 0, 0) * bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            obj.gameObject.GetComponent<RedCarMovement>().durability -= bulletDamage;
            GameObject spawnedExplosion = (GameObject)Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            spawnedExplosion.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
            Destroy(this.gameObject);
        }
        else if ( obj.gameObject.tag == "Barrier" || obj.gameObject.tag == "PoliceCar")
        {
            Destroy(this.gameObject);
        }
    }
}
