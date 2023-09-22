using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static WeaponScript;

public class AmmoManagerScript : MonoBehaviour
{
    [Header("Refernce Settings")]
    public TextMeshProUGUI ammoText;
    public WeaponScript weaponScript;
    [Space(5)]

    [Header("Score Stats Variables")]
    public static int maxAmmoCount;
    public static int currentAmmoCount;

    private void Awake()
    {
        WeaponAmmo();
    }

    public int subAmmo(int num)
    {
        currentAmmoCount -= num;
        return currentAmmoCount;
    }

    public void setAmmo(int num) => currentAmmoCount = num;
    public void setAmmoMax(int num) => maxAmmoCount = num;
    public int getAmmo() => currentAmmoCount;
    public int getAmmoMax() => maxAmmoCount;

    public int AmmoCount()
    {
        return currentAmmoCount;
    }

    public void WeaponAmmo()
    {
        switch (weaponScript.type)
        {
            case WeaponType.SemiAuto:
                setAmmo(12);
                setAmmoMax(115);
                break;
            case WeaponType.Auto:
                setAmmo(25);
                setAmmoMax(120);
                break;
            case WeaponType.Burst:
                setAmmo(15);
                setAmmoMax(121);
                break;
        }
    }

    private void UpdateAmmo()
    {
        ammoText.text = "Ammo: "+ getAmmo().ToString()+ "/" + getAmmoMax().ToString();       
    }

    private void FixedUpdate()
    {
       
        UpdateAmmo();
    }
}
