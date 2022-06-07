using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCarMovement : MonoBehaviour {
    [SerializeField] Transform target;
    Vector2 carPosition ;

    public float maxDurability = 100f;
    //[HideInInspector]
    public float durability;
    
    public float CarSpeed;
    private void Start()
    {
        carPosition = transform.position;
        durability = maxDurability;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            carPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            carPosition.y = (float)-4.13;

            target.position = carPosition;

            if ((Vector2)target.position != carPosition)
            {
                var newPosition = Vector2.MoveTowards(target.position, carPosition, float.MaxValue);
                newPosition = new Vector2(Mathf.Clamp(newPosition.x, -2.44f, 2.44f), newPosition.y);

                target.position = newPosition;

                carPosition.x = Mathf.Clamp(carPosition.x, -2.44f, 2.44f);
            }

        }
            if ((Vector2)transform.position != carPosition)
            {
            transform.position= Vector2.MoveTowards(transform.position, carPosition,CarSpeed*Time.deltaTime);
           
            carPosition.x= Mathf.Clamp(carPosition.x,-2.44f,2.44f);
            
        }
        }
    }
