using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //This is required

public class InputManager : MonoBehaviour
{
    private PlayerInput playerinput; //This is referred to the PlayerInput in Assets/Scripts/Input/PlayerInput class
    private PlayerInput.OnFootActions onFoot; //Player Movement

    private PlayerMotor motor; //From Assets/Input/PlayerMotor.cs
    private PlayerLook look; //Player Look
    
    //Temporary data denoting currently equipped gun by the player;
    [SerializeField] GameObject gun;
    DefaultGun gunScript;

    // Awake is called when script instance is loaded, Awake works until the Scene (e.g. level 1) is finished or unloaded. Often used in finding tags beforehand.
    void Awake()
    {
        //Assigning defalut values on the variables
        playerinput = new PlayerInput();
        onFoot = playerinput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        gunScript = gun.GetComponent<DefaultGun>();

        onFoot.Shoot.performed += ctx => gunScript.Shoot();
        onFoot.Jump.performed += ctx => motor.Jump(); //Jump Function - Anytime our jump is performed, our callbackcontext (ctx) to call our motor.Jump function
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Telling the PlayerMotor to move, by using values from our MovementAction
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>()); //Player Look Script
    }

    private void OnEnable()
    {
        //Enable is requiring to turn on input controls

        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}