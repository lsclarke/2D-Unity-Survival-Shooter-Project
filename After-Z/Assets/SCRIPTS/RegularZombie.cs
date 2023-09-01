using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class RegularZombie : MonoBehaviour, IDamagable
{
    [Header("Refernce Settings")]
    [SerializeField] public Rigidbody2D rb2D;
    [SerializeField] public EnemyScript enemyScript;
    [SerializeField] public Transform player;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    //HitAnimationFlash - When hit by player projectile the sprite renderer will
    //then activate the Animflash method to visually show the effect of being hit
    public void HitAnimationFlash(Collider2D hitInfo)
    {
        ProjectileScript projectile = hitInfo.GetComponent<ProjectileScript>();

        if (projectile != null)
        {
            StartCoroutine(AnimFlash());
        }
        
    }

    //This will detect any trigger collison that is a projectile
    //and if there is a hit then the player will take damage and activate the flash animation
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        ProjectileScript projectile = hitInfo.GetComponent<ProjectileScript>();

        if (projectile != null)
        {
            HitAnimationFlash(hitInfo);
            TakeDamage(projectile.power);
        }
    }

    //This will calculate the amount of damage received from a hit
    public void TakeDamage(float damage)
    {
        enemyScript.health -= damage;

        if(enemyScript.health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    //AnimFlash - changes the sprite color when activated
    private IEnumerator AnimFlash()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(0.15f);
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.15f);
        spriteRenderer.color = Color.white;
    }

}
