using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponScript : MonoBehaviour
{
    //Reference to the bullet spawn point, and the projectile itself
    [Header("Refernce Settings")]
    [SerializeField] public Rigidbody2D rb2D;
    [SerializeField] public PlayerInput input;
    [SerializeField] public Transform projectileSpawner;
    [SerializeField] public AmmoManagerScript ammoScript;

    public PowerUpScript powerUpScript;

    [Space(5)]
    [Header("Projectile Bullets")]
    [SerializeField] public ProjectileScript[] projectiles = new ProjectileScript[3];
    
    [SerializeField] public ParticleSystem muzzleFlash;

    public float fireRate = 15;
    public float nextTimeToFire = 0;
    public bool isShooting;

    public int shift;

    public bool canShift;

    public enum WeaponType { SemiAuto, Auto, Burst }
    [SerializeField] public WeaponType type;

    private void Awake()
    {
        //Start the game as a semi automatic
        type = WeaponType.SemiAuto;
        shift = 0;
        powerUpScript = GetComponent<PowerUpScript>();
        canShift = powerUpScript.ammoUPGRADE;
        

    }

    public void WeaponShift(InputAction.CallbackContext context)
    {

        if (context.performed && canShift)
        {
            
                shift++;
                if (shift > 2)
                {
                    shift = 0;
                }

                switch (shift)
                {
                    case 0:
                        type = WeaponType.SemiAuto;
                        break;
                    case 1:
                        type = WeaponType.Auto;
                        break;
                    case 2:
                        type = WeaponType.Burst;
                        break;
                }

            
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isShooting = true;

        }
        if (context.performed)
        {
            isShooting = true;
            //Instantiate(projectiles[0], projectileSpawner.position, projectileSpawner.rotation);
        }
        if (context.canceled)
        {
            isShooting = false;
        }
    }

    public void SpawnProjectile(Enum weapon)
    {
        switch (type)
        {
            
            case WeaponType.SemiAuto:

                fireRate = 1f;
                if (isShooting && Time.time >= nextTimeToFire && ammoScript.AmmoCount() > 0)
                {
                    nextTimeToFire = Time.time + 1f/fireRate;
                    Instantiate(projectiles[0], projectileSpawner.position, projectileSpawner.rotation);
                    ammoScript.subAmmo(1);
                }
                break;
            case WeaponType.Auto:
                fireRate = 7.5f;
                if (isShooting && Time.time >= nextTimeToFire && ammoScript.AmmoCount() > 0)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Instantiate(projectiles[1], projectileSpawner.position, projectileSpawner.rotation);
                    ammoScript.subAmmo(1);
                }
                break;
            case WeaponType.Burst:
                fireRate = 4.5f;
                if (isShooting && Time.time >= nextTimeToFire && ammoScript.AmmoCount() > 0)
                {
                    
                    nextTimeToFire = Time.time + 1f / fireRate;
                    Instantiate(projectiles[2], projectileSpawner.position, projectileSpawner.rotation);
                    StartCoroutine(BurstFireRate());
                    ammoScript.subAmmo(1);
                }
                break;
        }
    }
    private IEnumerator BurstFireRate()
    {
        yield return new WaitForSeconds(1f/ fireRate);
        isShooting = false;
    }

    private void Update()
    {
        SpawnProjectile(type);
    }

}
