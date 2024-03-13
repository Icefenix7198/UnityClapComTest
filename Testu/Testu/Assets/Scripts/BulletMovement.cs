using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxDistance;
    public float speed;
    public float damage;
    float time;
    [SerializeField] private Vector3 firstPosition;
    void Start()
    {
        firstPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //If collide with enemy and not piercing destroy bullet
        //if (Collision.)

        time += Time.deltaTime;
        //Mover bala
        Vector3 newPos = Vector3.zero;
        newPos.z = time * speed;
        transform.position = firstPosition + newPos;

        if(time > (maxDistance/speed)) 
        { 
            Destroy(gameObject);
        }
    }

}
