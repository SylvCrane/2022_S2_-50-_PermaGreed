using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller; //Input
    private Vector3 Playervelocity; //Player Speed
    private bool isGrounded; //Checks if the player is on the ground (Gravity)
    public float speed = 5f; //Speed Value
    public float gravity = -9.8f; //Gravity Value (Gravity)
    public float jumpHeight = 1.75f; //Jump Value (Jump)

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        //if the player is the soldier class speed is increased
        if (string.Compare(GameData.plClass, "sol") == 0)
        {
            speed = speed * 1.1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    //Receive the inputs for our InputManager.cs and apply it to our character controller (controller)
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;

        moveDirection.x = input.x;
        moveDirection.z = input.y; //Grabbing the Y value to the Z-axis of the player
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime); //*

        /* Gravity [Section] */
        Playervelocity.y += gravity * Time.deltaTime; //Gravity Formula
        if(isGrounded && Playervelocity.y < 0)
        {
            Playervelocity.y = -2f;
        }
        controller.Move(Playervelocity * Time.deltaTime);
        //Debug.Log(Playervelocity.y); //Testing on Unity Console
    }

    //Jump Function
    public void Jump()
    {
        if (isGrounded)
        {
            Playervelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}
