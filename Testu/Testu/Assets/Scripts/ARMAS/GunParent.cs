using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GunParent : MonoBehaviour
{
    // Stats weapon
    public GameObject actualWeapon; //se le puede poner un prefab de arma en vez de assignar a mano los valores 

    public float damage;
    public float cadency;
    public float distanceBullet;
    public float speedBullet;
    public bool piercing;
    public int maxMagazine;
    public float reloadTime;
    int currentBullets;
    public float damageScalation;
    float actualDmgScalation;
    enum shotType
    {
        FUSIL, //Basic shoot
        FUSILUPGRADE, //Recharge on shoot
        SHOTGUN, //Cada tick aumenta algo el daño

    }
    [SerializeField] private shotType tipoDisparo;

    //Referencias
    public GameObject projectile;
    public Transform parent;
    public EnemiesDetection detection;
    public List<GameObject> enemigos;
    [SerializeField] private GameObject enemyToShoot;
    float distanceEnemy = float.PositiveInfinity;

    //Time para disparar
    float shootingTime = 0.0f;

    private void Start()
    {
        if (actualWeapon != null && actualWeapon.GetComponent<WeaponInfo>())
        {
            damage = actualWeapon.GetComponent<WeaponInfo>().damage;
            cadency = actualWeapon.GetComponent<WeaponInfo>().cadency;
            distanceBullet = actualWeapon.GetComponent<WeaponInfo>().distanceBullet;
            speedBullet = actualWeapon.GetComponent<WeaponInfo>().speedBullet;
            piercing = actualWeapon.GetComponent<WeaponInfo>().piercing;
            maxMagazine = actualWeapon.GetComponent<WeaponInfo>().maxMagazine;
            reloadTime = actualWeapon.GetComponent<WeaponInfo>().reloadTime;

            projectile = actualWeapon.GetComponent<WeaponInfo>().projectile;

        }

        currentBullets = maxMagazine;
        actualDmgScalation = 0.0f;

        //TargetEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        shootingTime += Time.deltaTime;
        if (currentBullets <= 0)
        {
            actualDmgScalation = 0.0f;
            if (shootingTime > reloadTime) { currentBullets = maxMagazine; }
        }
        else
        {
            if (Input.GetKey(KeyCode.J) && !gameObject.GetComponent<MovementPlayer>().dashing)
            {
                TargetEnemy();

                //Set rotacion del disparo
                Vector3 shotDir = transform.forward;
                if (enemyToShoot != null && enemigos != null)
                {
                    //Direccion del enemigo
                    shotDir = enemyToShoot.transform.position - parent.position;
                    //transform.LookAt(enemyToShoot.transform);
                }
                if(enemyToShoot == null && enemigos != null) 
                {
                    distanceEnemy = float.PositiveInfinity;
                    TargetEnemy();
                }

                if (shootingTime > cadency)
                {
                    //Create bullet and set its characteristics
                    GameObject referencia = Instantiate(projectile, parent.position, Quaternion.identity);
                    referencia.GetComponent<BulletMovementAndDamage>().maxDistance = distanceBullet;
                    referencia.GetComponent<BulletMovementAndDamage>().speed = speedBullet;
                    referencia.GetComponent<BulletMovementAndDamage>().damage = damage;
                    referencia.GetComponent<BulletMovementAndDamage>().direction = shotDir;
                    referencia.GetComponent<BulletMovementAndDamage>().piercing = piercing;

                    //Deploy bullets
                    currentBullets -= 1; //Lo pongo por si hay en un futuro gasto de multiples balas como en la escopeta, sino simplemente poner la otra formula que sera mas eficiente
                    //currentBullets--;

                    //Escalate damage
                    actualDmgScalation += damageScalation;

                    //Reset time to shoot
                    shootingTime = 0.0f;
                }
            }
            else { actualDmgScalation = 0.0f; }
        }

    }

    private void TargetEnemy()
    {
        enemigos = detection.GetComponent<EnemiesDetection>().listEnemies;
        //Orientarse hacia el enememigo
        for (int i = 0; i < enemigos.Count; i++)
        {
            if (Vector3.Distance(enemigos[i].transform.position, parent.position) < distanceEnemy)
            {
                enemyToShoot = enemigos[i];
                distanceEnemy = Vector3.Distance(enemigos[i].transform.position, parent.position);

                //Debug.Log(distanceEnemy);
            }
        }
    }
}

