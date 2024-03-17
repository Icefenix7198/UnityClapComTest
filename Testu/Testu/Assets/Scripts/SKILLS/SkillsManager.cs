using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsManager : MonoBehaviour
{
    //Skill 1 things
    //Targets
    public List<GameObject> enemies; //Al igual que el shoot lista de todos los enemigos detectados.
    public GameObject enemy;
    //Projectile
    public GameObject acidSpit;
    [SerializeField] private float cooldownSkill1;
    float timeS1;


    //Skill 2 things
    public GunParent gunParent; //Gestionar el modo enrage de el parent
    public MovementPlayer jugadorController; //Gestinar el aumento de speed
    public DamageDetector damageDetector; //Aumentar armadura
    [SerializeField] private float cooldownSkill2;
    float timeS2;


    //Skill 3 things
    public GameObject swipe;
    public Transform swipeOrigin;
    [SerializeField] private float cooldownSkill3;
    float timeS3;


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
    
    }

    void Skill2()
    {

    }

    void Skill3()
    {

        Instantiate(swipe,swipeOrigin.position,Quaternion.identity);
    }
}
