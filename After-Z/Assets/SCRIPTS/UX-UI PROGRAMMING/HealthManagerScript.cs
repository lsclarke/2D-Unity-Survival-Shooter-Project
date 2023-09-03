using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthManagerScript : MonoBehaviour
{
    [Header("Reference Settings")]
    private CharacterScript characterScript;
    public GameObject[] healthObjects;

    private void Awake()
    {
        characterScript = GameObject.Find("PLAYER CONTROLLER").GetComponent<CharacterScript>();
        UpdateHealth();
    }

    private void FixedUpdate()
    {
        UpdateHealth();
    }

    private void UpdateHealth()
    {

        for (int pos = 0; pos < characterScript.health; pos++)
        {
            healthObjects[pos].SetActive(true);
            Debug.Log("LOOP");

        }

        for (int pos = healthObjects.Length-1; pos >= characterScript.health; pos--)
        {
            healthObjects[pos].SetActive(false);
            Debug.Log("LOOP");

        }

    }


}
