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
    enum shotType
    {
        NORMAL,
        SHOTGUN1,
        SHOTGUN2,
    }
    [SerializeField] private shotType tipoDisparo;

    public GameObject projectile;
}
