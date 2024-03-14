using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetector : MonoBehaviour
{
    public float HP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If 0 life, die
        if (HP <= 0) 
        {
            Destroy(this.gameObject);

            //Crear charco de acido
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hubo impacto con:", other.gameObject);
        //If collides with player bullet
        if (other.gameObject.CompareTag("Bullet"))
        {
            //Deal damage
            float dmg = other.gameObject.GetComponent<BulletMovement>().damage;
            HP -= dmg;

            //If not piercing destoy bullet
        }
    }
}
