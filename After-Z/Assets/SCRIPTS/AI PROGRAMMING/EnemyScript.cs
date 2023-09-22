using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour, IZombie
{
    //Variables

    //Reference Variables - Access Character Script and obtain variable data
    [Header("Refernce Settings")]
    private CharacterScript player;

    public float health;
    
    public float speed;
    public float attackPower;

    public bool flip;

    private void Awake()
    {
        player = GameObject.Find("PLAYER CONTROLLER").GetComponent<CharacterScript>();
    }


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
        if(player.transform.position.x > transform.position.x)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            Debug.Log("Face right");
        }
        else if(player.transform.position.x < transform.position.x)
        { 
            transform.Translate(speed * Time.deltaTime * -1, 0, 0);
            Debug.Log("Face left");
        }

    }

    private void Update()
    {
        Hunt(player.transform.position);
    }
}
