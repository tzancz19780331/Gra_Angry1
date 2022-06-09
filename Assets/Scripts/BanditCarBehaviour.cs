using System.Collections;
using UnityEngine;

public class BanditCarBehaviour : MonoBehaviour
{
    public GameObject bomb;
    public int bombsAmount;
    public int banditCarVerticalSpeed;
    public int banditVarHorizontalSpeed;
    public float bombDelay;
    [HideInInspector]
    public int pointsPerCar;

    private float Delay;
    private GameObject RedCar;
    private Vector3 banditCarPos;

    void Start()
    {
        RedCar = GameObject.FindWithTag("Player");
        Delay = bombDelay;
    }

    void Update()
    {
       if(RedCar == null)
       {
           RedCar = GameObject.FindWithTag("Player");
       } else
       {
           if (gameObject.transform.position.y > 3.8f && bombsAmount > 0)
           {
               this.gameObject.transform.Translate(new Vector3(0, -1,0) * banditCarVerticalSpeed * Time.deltaTime);
           
           }else if (bombsAmount <= 0)
           {
               this.gameObject.transform.Translate(new Vector3(0, 1,0) * banditCarVerticalSpeed * Time.deltaTime);
               if(gameObject.transform.position.y > 6.5f)
               {
                   PointsManager.points += pointsPerCar;
                   Destroy(this.gameObject);
               }
           }
           else
           {
               banditCarPos = Vector2.Lerp(transform.position, RedCar.transform.position, Time.deltaTime * banditVarHorizontalSpeed);
               transform.position = new Vector3(banditCarPos.x, transform.position.y, 0);
           
                Delay -= Time.deltaTime;
                if (Delay <= 0 && bombsAmount > 5)
                {
                    Delay = bombDelay;
                    bombsAmount--;
                    Instantiate(bomb, transform.position, Quaternion.identity);
                }else if (Delay <= 0 && bombsAmount <= 5 && bombsAmount > 0)
                {
                    Delay = bombDelay / 2;
                    bombsAmount--;
                    Instantiate(bomb, transform.position, Quaternion.identity);
                }
           }
       }
    }
}
