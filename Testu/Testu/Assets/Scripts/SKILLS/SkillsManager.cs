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


    //Skill 2 things
    public GunParent gunParent; //Gestionar el modo enrage de el parent
    public MovementPlayer jugadorController; //Gestinar el aumento de speed
    public DamageDetector damageDetector; //Aumentar armadura 


    //Skill 3 things
    public GameObject swipe;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
