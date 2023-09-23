using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockBackScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public float strength;
    [SerializeField] public float duration;

    [SerializeField] public bool isKnockedBack;
    [SerializeField] public EnemyScript enemy;
    public void EnemyKnockBack(GameObject other)
    {
        StopAllCoroutines();
        isKnockedBack = true;
        enemy.enabled = false;

        Vector2 direction = (transform.position - other.transform.position).normalized;
        rb.AddForce(direction * strength, ForceMode2D.Impulse);
        StartCoroutine(StopKnockBack(duration));
    }

    public IEnumerator StopKnockBack(float time)
    {
        yield return new WaitForSeconds(time);
        isKnockedBack = false;
        enemy.enabled = true;

        rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.collider.tag == "Shockwave")
        {
            EnemyKnockBack(other.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shockwave")
        {
            EnemyKnockBack(other.gameObject);
        }
    }
}
