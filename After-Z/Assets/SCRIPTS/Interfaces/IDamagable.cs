using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{

    //Methods to calculate the damage taken from a hit, and the animation flash to visually show the hit was sucessful
    public void TakeDamage(float damage);
    public void HitAnimationFlash(Collider2D hitInfo);
}
