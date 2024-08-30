using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IZombie
{
    public void setHealth(float hp);
    public float getHealth();
    public void setSpeed(float spd);
    public float getSpeed();

    public void setAttack(float spd);
    public float getAttack();

    public void Hunt(Vector3 position);


}
