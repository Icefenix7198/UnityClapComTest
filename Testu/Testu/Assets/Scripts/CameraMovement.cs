using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //player
    [SerializeField] GameObject target;

    //position difference between camera and player
    [SerializeField] Vector3 difPos;

    //camera velocity
    float followStrenght;

    private void Start()
    {
        //The camera velocity is equal to the players
        followStrenght = target.GetComponent<JugadorController>().velocidad;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newpos = target.transform.position + difPos;

        float dis = Vector3.Distance(transform.position, newpos);

        transform.position = Vector3.Lerp(transform.position, newpos, Time.deltaTime * followStrenght * dis);
    }
}
