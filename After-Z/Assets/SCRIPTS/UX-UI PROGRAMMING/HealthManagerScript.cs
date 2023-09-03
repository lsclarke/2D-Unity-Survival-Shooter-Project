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
        Test();
    }

    private void FixedUpdate()
    {

        //UpdateHealth();
        Test();
    }

    private void Update()
    {
        //Test();
    }

    public void UpdateHealth()
    {
        switch (characterScript.health)
        {
            case 4:
                healthObjects[0].SetActive(true);
                healthObjects[1].SetActive(true);
                healthObjects[2].SetActive(true);
                break;
            case 3:
                healthObjects[0].SetActive(true);
                healthObjects[1].SetActive(true);
                healthObjects[2].SetActive(true);
                break;
            case 2:
                healthObjects[0].SetActive(true);
                healthObjects[1].SetActive(true);
                healthObjects[2].SetActive(false);
                break;
            case 1:
                healthObjects[0].SetActive(true);
                healthObjects[1].SetActive(false);
                healthObjects[2].SetActive(false);
                break;
            case 0:
                healthObjects[0].SetActive(false);
                healthObjects[1].SetActive(false);
                healthObjects[2].SetActive(false);
                break;

        }

    }

    private void Test()
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
