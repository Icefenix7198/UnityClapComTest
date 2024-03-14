using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private Vector3 firstPosition;
    void Start()
    {
        Debug.Log(transform.rotation);
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

}
