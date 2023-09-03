using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterKnockBackScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public float strength;
    [SerializeField] public float duration;

    [SerializeField] public bool isKnockedBack;
    [SerializeField] public MovementScript player;
    [SerializeField] public WeaponScript rifle;
    public void PlayKnockBack(GameObject other)
    {
        StopAllCoroutines();
        isKnockedBack = true;
        player.enabled = false;
        rifle.enabled = false;
        Vector2 direction = (transform.position - other.transform.position).normalized;
        rb.AddForce(direction * strength, ForceMode2D.Impulse);
        StartCoroutine(StopKnockBack(duration));
    }

    public IEnumerator StopKnockBack(float time)
    {
        yield return new WaitForSeconds(time);
        isKnockedBack = false;
        player.enabled = true;
        rifle.enabled = true;
        rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        EnemyScript enemy = other.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            PlayKnockBack(other.gameObject);
        }
    }
}
