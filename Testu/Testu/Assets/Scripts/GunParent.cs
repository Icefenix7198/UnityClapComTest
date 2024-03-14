using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GunParent : MonoBehaviour
{
    // Stats weapon
    public float damage;
    public float cadency;
    public float distanceBullet;
    public float speedBullet;

    //Referencias
    public GameObject projectile;
    public Transform parent;
    public EnemiesDetection detection;
    public List<GameObject> enemigos;
    [SerializeField] private GameObject enemyToShoot;
    float distanceEnemy = float.PositiveInfinity;

    //Time para disparar
    float shootingTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        shootingTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.J)) 
        {
            enemigos = detection.GetComponent<EnemiesDetection>().listEnemies;
            //Orientarse hacia el enememigo
            for (int i = 0; i < enemigos.Count; i++) 
            {
                if (Vector3.Distance(enemigos[i].transform.position,parent.position) < distanceEnemy) 
                {
                    enemyToShoot = enemigos[i];
                    distanceEnemy = Vector3.Distance(enemigos[i].transform.position, parent.position);
                }
            }

            //Set rotacion del disparo
            Vector3 shotDir = transform.forward;
            if(enemigos != null) 
            {
                //Direccion del enemigo
                shotDir = enemyToShoot.transform.position - parent.position;
                //transform.LookAt(enemyToShoot.transform);
            }

            if (shootingTime > cadency) 
            {
                //Create bullet and set its characteristics
                GameObject referencia = Instantiate(projectile,parent.position, Quaternion.identity);
                referencia.GetComponent<BulletMovement>().maxDistance = distanceBullet;
                referencia.GetComponent<BulletMovement>().speed = speedBullet;
                referencia.GetComponent<BulletMovement>().damage = damage;
                referencia.GetComponent<BulletMovement>().direction = shotDir;

                //More things would go here

                //Reset time to shoot
                shootingTime = 0.0f;
            }
        }
    }
}
