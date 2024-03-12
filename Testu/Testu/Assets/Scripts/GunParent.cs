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

    //Tenemos un tiempo solo para la espera entre disparos y un tiempo para la actualizacion de las balas (?)
    float shootingTime = 0.0f;
    float time = 0.0f;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        shootingTime += time;
        if(shootingTime > 0.1f) { }
        if (Input.GetKey(KeyCode.J)) 
        {
            if (shootingTime > cadency) 
            {
                //Create bullet and set its characteristics
                //projectile.GetComponent<BulletMovement>().maxDistance = distanceBullet;
                //projectile.GetComponent<BulletMovement>().speed = speedBullet;
                Instantiate(projectile,parent.position, Quaternion.identity);


                //More things would go here

                //Reset time to shoot
                shootingTime = 0.0f;
            }
        }
    }
}
