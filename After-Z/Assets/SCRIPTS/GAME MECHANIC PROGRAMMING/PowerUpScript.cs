using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    ///SPEED++
    ///AMMO COUNT++
    ///STOMP/SHOCKWAVE
    public CharacterScript cScript;
    public CharacterJumpScript jumpScript;
    private CharacterAnimationScript cAnimation;
    private AmmoManagerScript ammoManager;
    private ScoreManagerScript scoreManager;
    public InteractScript interactScript;
    public TrailRenderer trailRenderer;

    public bool isInRange;
    private bool hpUPGRADE;
    public bool spdUPGRADE;
    public bool ammoUPGRADE;
    public bool shockwaveUPGRADE;

    [Header("Collision Settings")]
    public LayerMask interactLayer;
    public Transform interactcheckLoc;

    [Range(0.0f, 10.0f)]
    public float interactcheckRadius;

    [SerializeField]
    private ProjectileScript projectile1;
    [SerializeField]
    private ProjectileScript projectile2;
    [SerializeField]
    private ProjectileScript projectile3;

    private enum PowerUps { health, speed, ammo, shockwave }
    [SerializeField]
    private PowerUps types;


    private void Awake()
    {
        interactScript = GameObject.Find("PLAYER CONTROLLER").GetComponent<InteractScript>();
        cAnimation = GameObject.Find("Player").GetComponent<CharacterAnimationScript>();
        ammoManager = GameObject.Find("Ammo UI Manager").GetComponent<AmmoManagerScript>();
        scoreManager = GameObject.Find("Score UI Manager").GetComponent<ScoreManagerScript>();
        trailRenderer = GameObject.Find("PLAYER CONTROLLER").GetComponent<TrailRenderer>();
        hpUPGRADE = false;
        spdUPGRADE = false;
        ammoUPGRADE = false;
        shockwaveUPGRADE = false; 
    }

    private void FixedUpdate()
    {
        isInRange = Interactable();
        ActivatePowerUp();

    }
    public void HPUPGRADELOGIC()
    {
        int usesCount = 1;
        if (!hpUPGRADE)
        {
            if (cScript.getHealth() < 6 && usesCount == 1)
            {
                cScript.health = 6;
                cScript.setHealth(cScript.health);
                cAnimation.UpgradeFlash();
                usesCount = 0;
                hpUPGRADE = true;
            }
        }
       
    }

    public void SPDUPGRADELOGIC()
    {
        int usesCount = 1;
        if (!spdUPGRADE)
        {
            if (cScript.getSpeed() < 5 && usesCount == 1)
            {
                cScript.speed = 5;
                cScript.setSpeed(cScript.speed);
                cAnimation.UpgradeFlash();
                trailRenderer.emitting = true;
                usesCount = 0;
                spdUPGRADE = true;
            }
        }

    }

    public void SHOCKWAVEUPGRADELOGIC()
    {
        int usesCount = 1;
        if (!shockwaveUPGRADE)
        {
            if (cScript.getJumpPower() < 6.5 && usesCount == 1)
            {
                cScript.jumpPower = 6.5f;
                cScript.setJumpPower(cScript.jumpPower);
                cAnimation.UpgradeFlash();
                usesCount = 0;
                shockwaveUPGRADE = true;
            }
        }
    }

    public void AMMOUPGRADELOGIC()
    {
        int usesCount = 1;
        int ammo = ammoManager.getAmmo() * 2;
        int ammo2X = ammoManager.getAmmoMax() * 2;
        if (!ammoUPGRADE)
        {
            if (!ammoUPGRADE && usesCount == 1)
            {
                ammoManager.setAmmoMax(ammo2X);
                ammoManager.setAmmo(ammo);
                cAnimation.UpgradeFlash();
                projectile1.power = 28;
                projectile2.power = 18;
                projectile3.power = 23;
                usesCount = 0;
                ammoUPGRADE = true;
            }
            else
            {
                usesCount = 0;
            }
            
        }
        else
        {
            ammoUPGRADE = true;
        }
    }

    public void ActivatePowerUp()
    {
            switch (types)
            {
                case PowerUps.health:
                    if (Interactable() && interactScript.isInteracting() && scoreManager.ShowPoints() >= 0)
                    {
                        Debug.Log("Health UPGRADE Complete");
                        HPUPGRADELOGIC();
                        scoreManager.subScore(0);
                    }
                    break;

                case PowerUps.speed:
                    if (Interactable() && interactScript.isInteracting() && scoreManager.ShowPoints() >= 0)
                    {
                        Debug.Log("Speed UPGRADE Complete");
                        SPDUPGRADELOGIC();
                        scoreManager.subScore(0);
                    }
                break;

                case PowerUps.shockwave:
                    if (Interactable() && interactScript.isInteracting() && scoreManager.ShowPoints() >= 0)
                    {
                        Debug.Log("Shockwave UPGRADE Complete");
                        SHOCKWAVEUPGRADELOGIC();
                        scoreManager.subScore(0);
                    }
                break;

                case PowerUps.ammo:
                    if (Interactable() && interactScript.isInteracting() && scoreManager.ShowPoints() >= 0)
                    {
                        Debug.Log("AMMO UPGRADE Complete");
                        AMMOUPGRADELOGIC();
                        scoreManager.subScore(0);
                    }
                break;
        }
    }

    public bool Interactable()
    {
        return Physics2D.OverlapCircle(interactcheckLoc.position, interactcheckRadius, interactLayer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(interactcheckLoc.position, interactcheckRadius);
    }

}
