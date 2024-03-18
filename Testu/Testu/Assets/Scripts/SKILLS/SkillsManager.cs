using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsManager : MonoBehaviour
{
    //Skill 1 things
    //Targets
    public EnemiesDetection detection;
    public List<GameObject> enemies; //Al igual que el shoot lista de todos los enemigos detectados.
    public GameObject enemy;
    //Projectile
    public GameObject acidSpit;
    float distanceEnemy = float.PositiveInfinity;
    [SerializeField] private float cooldownSkill1;
    [SerializeField] private float timeS1;


    //Skill 2 things
    [SerializeField] private bool activeSkill2 = false; 
    float cadencia;
    float reload;
    float speed;
    float cooldownDash;
    float armor; //TO DO
    [SerializeField] private float cooldownSkill2;
    [SerializeField] private float durationSkill2;
    [SerializeField] private float timeS2;


    //Skill 3 things
    public GameObject swipe;
    public Transform swipeOrigin;
    [SerializeField] private float cooldownSkill3;
    [SerializeField] private float timeS3;


    // Start is called before the first frame update
    void Start()
    {
        timeS1 = timeS2 = timeS3 = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeS1 += Time.deltaTime;
        timeS2 += Time.deltaTime;
        timeS3 += Time.deltaTime;

        //Skill 1
        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (timeS1 > cooldownSkill1)
            {
                timeS1 = 0.0f;
                Skill1();
            }

        }
        //Skill 2
        if (Input.GetKey(KeyCode.Alpha2)) 
        {
            if(timeS2 > cooldownSkill2) 
            {
                timeS2 = 0.0f;
                Skill2();
            }
            
        }
        if(activeSkill2)
        {
            if (timeS2 > durationSkill2)
            {
                activeSkill2 = false;
                timeS2 = 0.0f;

                gameObject.GetComponent<GunParent>().cadency = cadencia;
                gameObject.GetComponent<GunParent>().reloadTime = reload;
                gameObject.GetComponent<MovementPlayer>().velocidad = speed;
                gameObject.GetComponent<MovementPlayer>().cooldownDash = cooldownDash;
                //armadura

            }
        }
        //Skill 3
        if (Input.GetKey(KeyCode.Alpha3))
        {
            if (timeS3 > cooldownSkill3)
            {
                timeS3 = 0.0f;
                Invoke("Skill3",swipe.GetComponent<SwipeSkill3>().preparationTime);
            }

        }
    }

    void Skill1() 
    {
        TargetEnemy();

        Vector3 shotDir = transform.forward;
        GameObject referencia = Instantiate(acidSpit, gameObject.transform.position, Quaternion.identity);
        referencia.GetComponent<SpitSkill1>().direction = shotDir;
    }

    private void TargetEnemy()
    {
        enemies = detection.GetComponent<EnemiesDetection>().listEnemies;
        //Orientarse hacia el enememigo
        for (int i = 0; i < enemies.Count; i++)
        {
            if (Vector3.Distance(enemies[i].transform.position, gameObject.transform.position) < distanceEnemy)
            {
                enemy = enemies[i];
                distanceEnemy = Vector3.Distance(enemies[i].transform.position, gameObject.transform.position);

                Debug.Log(distanceEnemy);
            }
        }
    }

    void Skill2()
    {
        //Guardar antiguos atributos
        cadencia = gameObject.GetComponent<GunParent>().cadency;
        reload = gameObject.GetComponent<GunParent>().reloadTime;
        speed = gameObject.GetComponent<MovementPlayer>().velocidad;
        cooldownDash = gameObject.GetComponent<MovementPlayer>().cooldownDash;
        //armadura

        //Cambiar stats
        gameObject.GetComponent<GunParent>().cadency = cadencia *0.7f;
        gameObject.GetComponent<GunParent>().reloadTime = reload * 0.5f;
        gameObject.GetComponent<MovementPlayer>().velocidad = speed * 1.5f;
        gameObject.GetComponent<MovementPlayer>().cooldownDash = cooldownDash * 0.5f;

        //Activar la skill durante sus 6 segundos
        activeSkill2 = true;
    }

    void Skill3()
    {

        Instantiate(swipe,swipeOrigin.position,Quaternion.identity);
    }
}
