using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunParent : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage;
    public float cadency;
    public float distanceBullet;
    public GameObject projectile;
    public Transform parent;
    float time = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKey(KeyCode.J)) 
        {
            if (time > cadency) 
            {
                Instantiate(projectile,parent.position, Quaternion.identity);
                BulletMovement bm = projectile.GetComponent<BulletMovement>();
                bm.maxDistance

                //Reset time to shoot
                time = 0.0f;
            }
            
        }
    }
}
