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

                int newClip = 12;
                int newMax = 0;
                if (ammoScript.getAmmo() <= 0 && ammoScript.getAmmoMax() >= newClip)
                {
                    newMax = ammoScript.getAmmoMax() - newClip;
                    ammoScript.setAmmoMax(newMax);
                    ammoScript.setAmmo(newClip);
                }
                break;
            case WeaponType.Auto:
                int newClip2 = 25;
                int newMax2 = 0;
                if (ammoScript.getAmmo() <= 0 && ammoScript.getAmmoMax() >= newClip2)
                {
                    newMax2 = ammoScript.getAmmoMax() - newClip2;
                    ammoScript.setAmmoMax(newMax2);
                    ammoScript.setAmmo(newClip2);
                }
                break;
            case WeaponType.Burst:

                int newClip3 = 15;
                int newMax3 = 0;
                if (ammoScript.getAmmo() <= 0 && ammoScript.getAmmoMax() >= newClip3)
                {
                    newMax3 = ammoScript.getAmmoMax() - newClip3;
                    ammoScript.setAmmoMax(newMax3);
                    ammoScript.setAmmo(newClip3);
                }
                break;
        }
    }
}
