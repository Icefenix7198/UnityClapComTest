using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxDistance;
    public float speed;
    float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If collide with enemy and not piercing destroy bullet
        //if (Collision.)

        time += Time.deltaTime;

        if(time > (maxDistance/speed)) 
        { 
            Destroy(this);
        }
    }

}
