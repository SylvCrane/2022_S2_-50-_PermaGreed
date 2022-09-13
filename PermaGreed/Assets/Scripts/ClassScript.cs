using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassScript : MonoBehaviour
{
    //This is a generic class that represents a test for a character class

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            rightClick();
        }

        if (Input.GetKeyDown("1"))
        {
            Ability1();
        }

        if (Input.GetKeyDown("2"))
        {
            Ability2();
        }

        if (Input.GetKeyDown("3"))
        {
            Ability3();
        }
    }

    //The following are stubs for the subclasses

    private void rightClick()
    {
        Debug.Log("Right Click ability was used (TestClass 1)");
    }

    private void Ability1()
    {
        Debug.Log("Ability1 was used (TestClass 1)");
    }

    private void Ability2()
    {
        Debug.Log("Ability2 was used (TestClass 1)");
    }

    private void Ability3()
    {
        Debug.Log("Ability3 was used (TestClass 1)");
    }
}
