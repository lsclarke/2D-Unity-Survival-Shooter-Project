using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WeaponScript;

public class ProjectileScript : MonoBehaviour
{
    public int power;

    [Range(5.0f, 20.0f)]
    public float speed;

    public float lifeTime;
    public Rigidbody2D rb2d;

    [SerializeField] private WeaponType type;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ProjectileBehavior(power, speed);
        PowerScaler();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = transform.right * speed;
        //PowerScaler();
    }

    public void ProjectileBehavior(int newPower, float newSpeed)
    {
        speed = newSpeed;
        power = newPower;
        StartCoroutine(EndLifeCycle());
    }

    public void PowerScaler()
    {
        switch (type)
        {
            case WeaponType.SemiAuto:
                power = 25;
                break; 
            case WeaponType.Auto:
                power = 15;
                break; 
            case WeaponType.Burst:
                power = 20;
                break;
        }
    }

    private IEnumerator EndLifeCycle()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Destroy(this.gameObject);
    }

}
