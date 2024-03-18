using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetector : MonoBehaviour
{
    public float HP;
    public float armor;

    public GameObject acidoMuerte;

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
            Destroy(gameObject);

            //Crear charco de acido
            GameObject referencia = Instantiate(acidoMuerte, this.transform);

            if (gameObject.CompareTag("Enemy")) 
            {
                referencia.GetComponent<AcidPuddle>().damage = 10;
                referencia.GetComponent<AcidPuddle>().enemy = true;

            }
        }
    }
}