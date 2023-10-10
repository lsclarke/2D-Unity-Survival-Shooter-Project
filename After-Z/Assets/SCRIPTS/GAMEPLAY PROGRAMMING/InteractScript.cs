using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;


public class InteractScript : MonoBehaviour
{
    private bool interact;
    public TrailRenderer trailRenderer;
    [SerializeField] public PlayerInput input;
    public PowerUpScript powerUpScript;

    public void setInteraction(bool i) => interact = i;
    public bool isInteracting() => interact;

    private void Awake()
    {
        interact = false;
        trailRenderer = this.GetComponent<TrailRenderer>();
        powerUpScript = GameObject.Find("PowerUpMachine").GetComponent<PowerUpScript>();
    }

    private void Update()
    {
        if (powerUpScript.spdUPGRADE)
        {
            trailRenderer.emitting = true;
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interact = true;
        }
        else
        {
            interact = false;
        }
    }

}
