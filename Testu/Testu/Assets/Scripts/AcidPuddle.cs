using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPuddle : MonoBehaviour
{

    [SerializeField] private bool enemy;
    public float damage;
    int currentTicks = 0; //Guardamos los ticks actuales para esperar
    public float tickDamage;
    bool addTick; //No se si los triggers suceden todos a la vez pero por si acaso me esperare 1 update
    float timeTotal;
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeTotal += Time.deltaTime;
        if (addTick)
        {
            currentTicks++;
            addTick = false;
        }
        if (timeTotal > duration) 
        {
            Destroy(gameObject); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !enemy)
        {
            //Deal damage
            other.gameObject.GetComponent<DamageDetector>().HP -= damage;

            //Slow down

        }
        else if (other.gameObject.CompareTag("Player") && enemy) //Collision with player
        {
            //Solo si no esta dashing recibir daño
            if (!other.gameObject.GetComponent<MovementPlayer>().dashing)
            {
                //Deal damage
                other.gameObject.GetComponent<DamageDetector>().HP -= damage;
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if((timeTotal/tickDamage) > currentTicks) 
        {
            if (other.gameObject.CompareTag("Enemy") && !enemy)
            {
                //Deal damage
                other.gameObject.GetComponent<DamageDetector>().HP -= damage;
                Debug.Log("Tick Acido");

            }
            else if (other.gameObject.CompareTag("Player") && enemy) //Collision with player
            {
                //Solo si no esta dashing recibir daño
                if (!other.gameObject.GetComponent<MovementPlayer>().dashing)
                {
                    //Deal damage
                    other.gameObject.GetComponent<DamageDetector>().HP -= damage;
                }
            }

            addTick = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Give speed back
    }
}
