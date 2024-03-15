using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxDistance;
    public float speed;
    public float damage;
    float time;
    public bool piercing;
    public Vector3 direction;
    public bool EnemyBullet;
    [SerializeField] private Vector3 firstPosition;
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
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hubo impacto con:", other.gameObject);
        //If collides with player bullet
        if (other.gameObject.CompareTag("Enemy") && !EnemyBullet)
        {
            //Deal damage
            other.gameObject.GetComponent<DamageDetector>().HP -= damage;

            //If not piercing destoy bullet
            if (!other.gameObject.GetComponent<BulletMovement>().piercing)
            {
                Destroy(other.gameObject);
            }
        }

    }
}
