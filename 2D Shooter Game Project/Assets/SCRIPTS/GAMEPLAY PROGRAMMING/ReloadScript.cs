using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static WeaponScript;

public class ReloadScript : MonoBehaviour
{
    [Header("Refernce Settings")]
    [SerializeField] public PlayerInput input;
    [SerializeField] public AmmoManagerScript ammoScript;
    public WeaponScript weaponScript;

    int newClip;
    int newClip2;
    int newClip3;

    int newMax;
    int newMax2;
    int newMax3;

    public bool upgraded;

    private void FixedUpdate()
    {
        if (upgraded)
        {
            newClip = 12;
            newMax = 0;

            newClip2 = 25;
            newMax2 = 0;

            newClip3 = 15;
            newMax3 = 0;
        }
        else
        {
            newClip = 15;
            newMax = 0;

            newClip2 = 28;
            newMax2 = 0;

            newClip3 = 18;
            newMax3 = 0;
        }
    }
    public void Reload(InputAction.CallbackContext context)
    {
        
        if (context.performed)
        {
            ReloadWeapon();
        }
    }


    private void ReloadWeapon()
    {

        switch (weaponScript.type)
        {
            case WeaponType.SemiAuto:


                if (ammoScript.getAmmo() < newClip && ammoScript.getAmmoMax() >= newClip)
                {
                    newMax = ammoScript.getAmmoMax() - newClip;
                    ammoScript.setAmmoMax(newMax);
                    ammoScript.setAmmo(newClip);
                }
                else 
                {
                    if (ammoScript.getAmmoMax() > 0)
                    {
                        ammoScript.setAmmo(ammoScript.getAmmoMax());
                        ammoScript.setAmmoMax(0);
                    }
                }
                break;
            case WeaponType.Auto:

                if (ammoScript.getAmmo() < newClip2 && ammoScript.getAmmoMax() >= newClip2)
                {
                    newMax2 = ammoScript.getAmmoMax() - newClip2;
                    ammoScript.setAmmoMax(newMax2);
                    ammoScript.setAmmo(newClip2);
                }
                else
                {
                    if (ammoScript.getAmmoMax() > 0)
                    {
                        ammoScript.setAmmo(ammoScript.getAmmoMax());
                        ammoScript.setAmmoMax(0);
                    }
                }
                break;
            case WeaponType.Burst:

                 
                if (ammoScript.getAmmo() < newClip3 && ammoScript.getAmmoMax() >= newClip3)
                {
                    newMax3 = ammoScript.getAmmoMax() - newClip3;
                    ammoScript.setAmmoMax(newMax3);
                    ammoScript.setAmmo(newClip3);
                }
                else
                {
                    if (ammoScript.getAmmoMax() > 0)
                    { 
                        ammoScript.setAmmo(ammoScript.getAmmoMax());
                        ammoScript.setAmmoMax(0);
                    }
                }
                break;
        }
    }
}
