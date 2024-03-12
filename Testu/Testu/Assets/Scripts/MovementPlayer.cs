using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorController : MonoBehaviour
{
    //Declaro la variable pública velocidad para poder modificarla desde la Inspector window
    [Range(1, 10)]
    public float velocidad = 5;

    void FixedUpdate()
    {
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