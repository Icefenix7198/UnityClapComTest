using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpitSkill1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxDistance;
    public float speed;
    public float damage;
    float time;
    public bool piercing;
    public Vector3 direction;
    [SerializeField] private Vector3 firstPosition;
    public GameObject acidPuddle;
    void Start()
    {
        //Debug.Log(transform.rotation);
        firstPosition = transform.position;
        transform.forward = direction;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //Mover bala
        Vector3 newPos = Vector3.zero;
        newPos = time * speed * transform.forward;
        transform.position = firstPosition + newPos;

        if(time > (maxDistance/speed)) 
        { 
            KillBullet();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hubo impacto con:", other.gameObject);
        //Collision with wall
        if (other.gameObject.CompareTag("Wall")) 
        {
            KillBullet();
        }

        //If collides with enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Deal damage
            other.gameObject.GetComponent<DamageDetector>().HP -= damage;

            KillBullet();


        }
        
    }

    //Como hay que destruir e instanciar cada vez el charco de acido se hace en una funcion aparte.
    void KillBullet() 
    {
        //Crear charco de acido.
        
        Destroy(gameObject);
    }
}
