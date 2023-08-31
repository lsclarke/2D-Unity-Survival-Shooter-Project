using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public int power;

    [Range(5.0f, 20.0f)]
    public float speed;

    public float lifeTime;
    public Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ProjectileBehavior(power, speed);
    }

    private void FixedUpdate()
    {
        rb2d.velocity = transform.right * speed;
    }

    public void ProjectileBehavior(int newPower, float newSpeed)
    {
        speed = newSpeed;
        power = newPower;
        StartCoroutine(EndLifeCycle());
    }

    private IEnumerator EndLifeCycle()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
