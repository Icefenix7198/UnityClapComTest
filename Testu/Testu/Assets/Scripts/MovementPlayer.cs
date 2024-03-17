using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    //Declaro la variable pública velocidad para poder modificarla desde la Inspector window
    [Range(1, 10)]
    public float velocidad = 5;
    public float cooldownDash;
    public bool dashing = false;

    public float time = 0.0f;
    void Update()
    {
        time += Time.deltaTime;
        if (dashing && time>0.25f) //Si estaba dasheando y paso de la duraion del dash (0.25) desactivar dash
        {
            dashing = false;
            velocidad /= 4;
        }

        //Si el tiempo del cooldown ya paso se puede volver a dasherar
        if (cooldownDash < time) 
        {
            if (Input.GetKey(KeyCode.Space) && !dashing) //Si el tiempo esta bien y no esta ya dasheando al pulsar space
            {
                time = 0.0f; //Time cooldown y duracion a 0
                dashing = true;
                velocidad *= 4;
            }
        }
        //Capturo el movimiento en horizontal y vertical de nuestro teclado
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        //Genero el vector de movimiento asociado, teniendo en cuenta la velocidad
        Vector3 movimiento = new Vector3(movimientoH , 0.0f, movimientoV).normalized;

        //Aplico ese movimiento al RigidBody del jugador
        transform.position += movimiento*Time.deltaTime*velocidad;

        //Mantener characther recto
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}