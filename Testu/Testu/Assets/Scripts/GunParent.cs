using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunParent : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage;
    public float cadency;
    public float distanceBullet;
    public float speedBullet;
    public GameObject projectile;
    public Transform parent;
    float time = 0.0f;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKey(KeyCode.J)) 
        {
            if (time > cadency) 
            {
                //Create bullet and set its characteristics
                GameObject bullet = Instantiate(projectile,parent.position, Quaternion.identity);
                bullet.GetComponent<BulletMovement>().maxDistance = distanceBullet;
                bullet.GetComponent<BulletMovement>().speed = speedBullet;

                //More things would go here

                //Reset time to shoot
                time = 0.0f;
            }
        }
    }
}
