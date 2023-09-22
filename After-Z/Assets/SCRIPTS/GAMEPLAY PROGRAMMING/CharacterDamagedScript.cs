using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamagedScript : MonoBehaviour, IDamagable
{
    public CharacterScript characterScript;
    [SerializeField] public SpriteRenderer spriteRenderer;
    public Collider2D collisionDetection;

    private void Awake()
    {
        spriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        characterScript = this.gameObject.GetComponent<CharacterScript>();  
    }
    //HitAnimationFlash - When hit by player projectile the sprite renderer will
    //then activate the Animflash method to visually show the effect of being hit
    public void HitAnimationFlash(Collider2D hitInfo) {

        EnemyScript enemyScript = hitInfo.gameObject.GetComponent<EnemyScript>();

        if (enemyScript != null)
        {
            StartCoroutine(AnimFlash());
        }
    }

    //This will detect any trigger collison that is a projectile
    //and if there is a hit then the player will take damage and activate the flash animatio
    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        EnemyScript enemyScript = hitInfo.gameObject.GetComponent<EnemyScript>();

        if (enemyScript != null)
        {
            StartCoroutine(AnimFlash());
            TakeDamage(enemyScript.attackPower);

            if (characterScript.health  == 0)
            {
                enemyScript.speed = 0;
            }
        }
    }

    //This will calculate the amount of damage received from a hit
    public void TakeDamage(float damage)
    {
        characterScript.health -= (int)damage;
        
        if (characterScript.health <= 0)
        {
            Die();
        }
    }
    //Destroy Enemy
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
