using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;
    public float GAME_SENS = GameData.GameSenstivity;

    //Default Sensitivity for both x and y is 30.
    public float xSensitivity;
    public float ySensitivity;

    private void Awake()
    {
        xSensitivity = GAME_SENS;
        ySensitivity = GAME_SENS;
    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        //Camera Rotation for up and don
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80, 80f);
        //Apply to our camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //Rotation left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
