using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    public float damage;
    public float cadency;
    public float distanceBullet;
    public float speedBullet;
    public bool piercing;
    public int maxMagazine;
    public float reloadTime;
    public float damageScalation;
    enum shotType
    {
        FUSIL, //Basic shoot
        FUSILUPGRADE, //Recharge on shoot
        SHOTGUN, //Cada tick aumenta algo el daño

    }
    [SerializeField] private shotType tipoDisparo;

    public GameObject projectile;
}
