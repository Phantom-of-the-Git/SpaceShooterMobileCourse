using System;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject laserBullet;
    [SerializeField] private Transform basicShootingPoint;
    [SerializeField] private float shootingInterval;
    private float inteervalReset;

    void Start()
    {
        inteervalReset = shootingInterval;
    }
    void Update()
    {
        shootingInterval -= Time.deltaTime;
        if (shootingInterval <= 0)
        {
            Shoot();
            shootingInterval = inteervalReset;
        }
    }

    private void Shoot()
    {
        Instantiate(laserBullet, basicShootingPoint.position, Quaternion.identity);
    }
}