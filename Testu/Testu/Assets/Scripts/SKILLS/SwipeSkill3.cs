using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeSkill3 : MonoBehaviour
{
    [SerializeField] private Transform charaPos;
    public GameObject area;
    public float preparationTime;
    public float durationTime;
    public float time;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        charaPos = transform;
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > durationTime) 
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) //Si se golpeo a un enemigo hacer cosa
        { 
            float DistanceEnemy = Vector3.Distance(charaPos.position,other.gameObject.transform.position);
            float PushDistance = ((100.0f - (8.0f * DistanceEnemy + 0.7f * DistanceEnemy * DistanceEnemy)) /100f) * area.transform.localScale.x;
            Debug.Log(DistanceEnemy.ToString());

            Vector3 vecDir =  (other.gameObject.transform.position - charaPos.position).normalized;
            other.gameObject.transform.position += vecDir * PushDistance;
        }
    }
}
