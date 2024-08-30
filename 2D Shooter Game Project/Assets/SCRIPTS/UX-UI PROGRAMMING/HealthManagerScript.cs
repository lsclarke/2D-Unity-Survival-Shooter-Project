using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class HealthManagerScript : MonoBehaviour
{
    [Header("Reference Settings")]
    private CharacterScript characterScript;
    public GameObject[] healthObjects;
    public GameObject finalStatsScript;
    public bool upgraded;


    private void Awake()
    {
        characterScript = GameObject.Find("PLAYER CONTROLLER").GetComponent<CharacterScript>();
        upgraded = false;
        UpdateHealth();
    }

    private void FixedUpdate()
    {
        UpdateHealth();
        RegenerativeHealth();
    }

    private void UpdateHealth()
    {
        for (int pos = 0; pos < characterScript.health; pos++)
        {
            healthObjects[pos].SetActive(true);
        }
        for (int pos = healthObjects.Length-1; pos >= characterScript.health; pos--)
        {
            healthObjects[pos].SetActive(false);
        }

        if(characterScript == null)
        {
            Debug.Log("PLAYER IS DEAD");
            finalStatsScript.gameObject.SetActive(true);
        }

    }

    private void RegenerativeHealth()
    {

                if (characterScript.health < 6 && upgraded)
                {
                    StartCoroutine(HealthBack(5f));
                }
                else if (characterScript.health < 3 && !upgraded)
                {
                StartCoroutine(HealthBack(5f));
                }
    }

    public IEnumerator HealthBack(float time)
    {
        yield return new WaitForSeconds(time);
        if (characterScript.health < 6 && upgraded)
        {
            characterScript.health += 1;
            if (characterScript.health > 6)
            {
                characterScript.health = 6;
            }
        }
        else
        {
            if (characterScript.health < 3 && !upgraded)
            {
                characterScript.health += 1;
                if (characterScript.health > 3)
                {
                    characterScript.health = 3;
                }
            }
        }
        
    }
}
