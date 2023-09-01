using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyScript : MonoBehaviour, IZombie
{
    //Variables

    //Reference Variables - Access Character Script and obtain variable data
    [Header("Refernce Settings")]
    public GameObject player;

    public float health;
    
    public float speed;
    public float attackPower;

    private bool flip;


    //Set health variable, and get the value of the newly set health variable
    public void setHealth(float hp) => health = hp;
    public float getHealth() => health;

    //Set Speed variable, and get the value of the newly set Speed variable
    public void setSpeed(float spd) => speed = spd;
    public float getSpeed() => speed;

    //Set Attack variable, and get the value of the newly set Attack variable
    public void setAttack(float atk) => attackPower = atk;
    public float getAttack() => attackPower;

    //Move Towards specified position
    public void Hunt(Vector3 otherPosition)
    {
        Vector3 scale = transform.localScale;
        if(player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
            transform.Translate(speed * Time.deltaTime * -1, 0, 0);
        }
    }

    private void Update()
    {
        Hunt(player.transform.position);
    }
}
