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
    public InteractScript interactScript;
    public TrailRenderer trailRenderer;

    public bool isInRange;
    private bool hpUPGRADE;
    public bool spdUPGRADE;
    private bool isAMMOMActive;
    public bool shockwaveUPGRADE;

    [Header("Collision Settings")]
    public LayerMask interactLayer;
    public Transform interactcheckLoc;

    [Range(0.0f, 10.0f)]
    public float interactcheckRadius;

    private enum PowerUps { health, speed, ammo, shockwave }
    [SerializeField]
    private PowerUps types;


    private void Awake()
    {
        interactScript = GameObject.Find("PLAYER CONTROLLER").GetComponent<InteractScript>();
        cAnimation = GameObject.Find("Player").GetComponent<CharacterAnimationScript>();
        trailRenderer = GameObject.Find("PLAYER CONTROLLER").GetComponent<TrailRenderer>();
        hpUPGRADE = false;
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

    public void ActivatePowerUp()
    {
            switch (types)
            {
                case PowerUps.health:
                    if (Interactable() && interactScript.isInteracting())
                    {
                        Debug.Log("Health UPGRADE Complete");
                        HPUPGRADELOGIC();                      
                    }
                    break;

                case PowerUps.speed:
                    if (Interactable() && interactScript.isInteracting())
                    {
                        Debug.Log("Speed UPGRADE Complete");
                        SPDUPGRADELOGIC();
                    }
                break;

                case PowerUps.shockwave:
                    if (Interactable() && interactScript.isInteracting())
                    {
                        Debug.Log("Shockwave UPGRADE Complete");
                        SHOCKWAVEUPGRADELOGIC();
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
